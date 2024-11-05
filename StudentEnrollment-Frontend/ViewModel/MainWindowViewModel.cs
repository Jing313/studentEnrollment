using Prism.Mvvm;
using StudentEnrollment_Frontend.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.Http.Headers;
using System.Net.Http;

namespace StudentEnrollment_Frontend.ViewModel
{
    public class MainWindowViewModel : BindableBase, INotifyPropertyChanged
    {
        #region Properties
        private List<Course> _courses;

        public List<Course> Courses
        {
            get { return _courses; }
            set => SetProperty(ref _courses, value);
        }

        private Course _selectedCourse;

        public Course SelectedCourse
        {
            get { return _selectedCourse; }
            set { SetProperty(ref _selectedCourse, value); }
        }

        private Course _newCourse;

        public Course NewCourse
        {
            get { return _newCourse; }
            set { SetProperty(ref _newCourse, value); }
        }

        private bool _isLoadData;

        public bool IsLoadData
        {
            get { return _isLoadData; }
            set { SetProperty(ref _isLoadData, value); }
        }

        private string _responseMessage = "Student Enrollment";

        public string ResponseMessage
        {
            get { return _responseMessage; }
            set { SetProperty(ref _responseMessage, value); }
        }

        #region [Create Employee Properties]

        private string _name;

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }


        private string _description;

        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        private DateTime _startDate;

        public DateTime StartDate
        {
            get { return _startDate; }
            set { SetProperty(ref _startDate, value); }
        }

        private DateTime _endDate;

        public DateTime EndDate
        {
            get { return _startDate; }
            set { SetProperty(ref _startDate, value); }
        }

        private double _fees;

        public double Fees
        {
            get { return _fees; }
            set { SetProperty(ref _fees, value); }
        }

        private string _subject;

        public string Subject
        {
            get { return _subject; }
            set { SetProperty(ref _subject, value); }
        }

        private string _location;

        public string Location
        {
            get { return _location; }
            set { SetProperty(ref _location, value); }
        }

        private string _branchAddress;

        public string BranchAddress
        {
            get { return _branchAddress; }
            set { SetProperty(ref _branchAddress, value); }
        }

        private string _contactPerson;

        public string ContactPerson
        {
            get { return _contactPerson; }
            set { SetProperty(ref _contactPerson, value); }
        }
        #endregion

        private bool _isShowForm;

        public bool IsShowForm
        {
            get { return _isShowForm; }
            set { SetProperty(ref _isShowForm, value); }
        }

        private string _showPostMessage = "Fill the form to register a course!";

        public string ShowPostMessage
        {
            get { return _showPostMessage; }
            set { SetProperty(ref _showPostMessage, value); }
        }

        #endregion

        #region ICommands
        public DelegateCommand GetButtonClicked { get; set; }
        public DelegateCommand ShowRegistrationForm { get; set; }
        public DelegateCommand PostButtonClicked { get; set; }
        public DelegateCommand<Course> PutButtonClicked { get; set; }
        public DelegateCommand<Course> DeleteButtonClicked { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initalize perperies & delegate commands
        /// </summary>
        public MainWindowViewModel()
        {
            GetButtonClicked = new DelegateCommand(GetCourseDetails);
            PutButtonClicked = new DelegateCommand<Course>(UpdateCourseDetails);
            DeleteButtonClicked = new DelegateCommand<Course>(DeleteCourseDetails);
            PostButtonClicked = new DelegateCommand(CreateNewCourse);
            ShowRegistrationForm = new DelegateCommand(RegisterCourse);
        }
        #endregion

        #region CRUD
        /// <summary>
        /// Make visible Regiter form
        /// </summary>
        private void RegisterCourse()
        {
            IsShowForm = true;
        }

        /// <summary>
        /// Fetches course details
        /// </summary>
        private void GetCourseDetails()
        {
            var courseDetails = WebAPI.GetCall(API_URIs.courses);
            if (courseDetails.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Courses = courseDetails.Result.Content.ReadAsAsync<List<Course>>().Result;
                IsLoadData = true;
            }
        }

        /// <summary>
        /// Adds new course
        /// </summary>
        private void CreateNewCourse()
        {
            Course newCourse = new Course()
            {
                Name = Name,
                Description = Description,
                StartDate = StartDate,
                EndDate = EndDate,
                Fees = Fees,
                Subject = Subject,
                Location = Location,
                BranchAddress = BranchAddress,
                ContactPerson = ContactPerson,
            };
            var courseDetails = WebAPI.PostCall(API_URIs.courses, newCourse);
            if (courseDetails.Result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                ShowPostMessage = newCourse.Name + "'s details has successfully been added!";
            }
            else
            {
                ShowPostMessage = "Failed to update" + newCourse.Name + "'s details.";
            }
        }


        /// <summary>
        /// Updates course's record
        /// </summary>
        /// <param name="course"></param>
        private void UpdateCourseDetails(Course course)
        {
            var courseDetails = WebAPI.PutCall(API_URIs.courses + "/" + course.Id, course);
            if (courseDetails.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ResponseMessage = course.Name + "'s details has successfully been updated!";
            }
            else
            {
                ResponseMessage = "Failed to update" + course.Name + "'s details.";
            }
        }

        /// <summary>
        /// Deletes course's record
        /// </summary>
        /// <param name="course"></param>
        private void DeleteCourseDetails(Course course)
        {
            var courseDetails = WebAPI.DeleteCall(API_URIs.courses + "/" + course.Id);
            if (courseDetails.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ResponseMessage = course.Name + "'s details has successfully been deleted!";
            }
            else
            {
                ResponseMessage = "Failed to delete" + course.Name + "'s details.";
            }
        }
        #endregion
    }
}
