using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testverktyg.Client.Models;
using Testverktyg.Client.Services;

namespace Testverktyg.Client.ViewModels
{
    public class TeacherOverviewViewModel
    {
        CourseService courseService = new CourseService();
        public ObservableCollection<Course> ListCourse { get; set; } = new ObservableCollection<Course>();
        

        
        
        public void GetCourses()
        {
            var courses = courseService.GetCourses();
            foreach (Course course in courses)
            {
                ListCourse.Add(course);
            }
        }

    }
}
