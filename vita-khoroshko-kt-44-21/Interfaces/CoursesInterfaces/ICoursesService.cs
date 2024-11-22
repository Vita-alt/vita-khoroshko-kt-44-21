using _1_lab.Models;
using System.Diagnostics;
using vita_khoroshko_kt_44_21.Database;
using Microsoft.EntityFrameworkCore;
using vita_khoroshko_kt_44_21.Filters.CourseFilters;
using vita_khoroshko_kt_44_21.Filters.CourseGroupFilters;
using vita_khoroshko_kt_44_21.Models;

namespace vita_khoroshko_kt_44_21.Interfaces.CoursesInterfaces
{
	public interface ICoursesService
	{
		public Task<Course[]> GetCoursesByGroupAsync(CourseFilter filter, CancellationToken cancellationToken);
		public Task<Course[]> GetCoursesByGroupStudentAsync(CourseGroupFilter filter, CancellationToken cancellationToken);
	}
	public class CourseService : ICoursesService
	{
		private readonly StudentDbContext _dbContext;
		public CourseService(StudentDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public Task<Course[]> GetCoursesByGroupAsync(CourseFilter filter, CancellationToken cancellationToken = default)
		{
			var courses = _dbContext.Set<Course>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);

			return courses;
		}
		public Task<Course[]> GetCoursesByGroupStudentAsync(CourseGroupFilter filter, CancellationToken cancellationToken = default)
		{
			var courses = _dbContext.Set<Course>().Where(w => w.Group.GroupId == filter.GroupId).ToArrayAsync(cancellationToken);

			return courses;
		}


	}
}
