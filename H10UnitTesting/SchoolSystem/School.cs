////
namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// class School
    /// </summary>
    public class School
    {
        /// <summary>
        /// The course capacity of each course in the school
        /// </summary>
        private static int courseCapacity = 30;

        /// <summary>
        /// The max  value for ID of student in the School
        /// </summary>
        private static uint maxID = 99999;

        /// <summary>
        /// The min ID  value for ID of student in the School
        /// </summary>
        private static uint minID = 10000;

        /// <summary>
        /// The courses
        /// </summary>
        private IList<Course> courses;

        /// <summary>
        /// The students
        /// </summary>
        private IList<Student> students;

        /// <summary>
        /// The student ID generator
        /// </summary>
        private uint studentIDGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="School" /> class.
        /// </summary>
        public School()
        {
            this.Courses = new List<Course>();
            this.Students = new List<Student>();
            this.studentIDGenerator = minID;
        }

        /// <summary>
        /// Gets or sets the courses.
        /// </summary>
        /// <value>
        /// The courses.
        /// </value>
        protected IList<Course> Courses
        {
            get
            {
                return this.courses;
            }

            set
            {
                this.courses = value;
            }
        }

        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        /// <value>
        /// The students.
        /// </value>
        protected IList<Student> Students
        {
            get
            {
                return this.students;
            }

            set
            {
                this.students = value;
            }
        }

        /// <summary>
        /// Adds the new student.
        /// </summary>
        /// <param name="newStudentName">New name of the student.</param>
        /// <returns>
        /// a new instance of the <see cref="Student" /> class
        /// </returns>
        /// <exception cref="System.InvalidOperationException">The student can no be sign because the capacity of the school is reached.</exception>
        public Student AddNewStudent(string newStudentName)
        {
            if (this.studentIDGenerator == maxID + 1)
            {
                throw new InvalidOperationException("The student can no be sign because the capacity of the school is reached.");
            }

            Student newStudent = new Student(this.studentIDGenerator, newStudentName);
            this.Students.Add(newStudent);
            this.studentIDGenerator++;

            return newStudent;
        }

        /// <summary>
        /// Adds the new course.
        /// </summary>
        /// <param name="newCourseName">New name of the course.</param>
        /// <returns> a new instance of the <see cref="Course" /> class</returns>
        /// <exception cref="System.InvalidOperationException">The operation can not be performed. Course with the same Name has already signed in the school.</exception>
        public Course AddNewCourse(string newCourseName)
        {
            if (IndexOfCourse(newCourseName, this.courses) >= 0)
            {
                throw new InvalidOperationException("The operation can not be performed. Course with the same Name has already signed in the school.");
            }

            Course newCourse = new Course(newCourseName, courseCapacity);
            this.Courses.Add(newCourse);
            return newCourse;
        }

        /// <summary>
        /// Signs up student of the school for course in the school.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="courseName">Name of the course.</param>
        /// <exception cref="System.InvalidOperationException">If student is already signed for the course</exception>
        /// <exception cref="System.InvalidOperationException">If student is already signed for the course</exception>
        public void SignUpStudentForCourse(uint id, string courseName)
        {
            int indexStudent = IndexOfStudent(id, this.students);
            if (indexStudent < 0)
            {
                throw new InvalidOperationException(string.Format("The operation can not be performed. Student with ID '{0}' does not attending the school.", id));
            }

            int indexCourse = IndexOfCourse(courseName, this.courses);
            if (indexCourse < 0)
            {
                throw new InvalidOperationException(string.Format("The operation can not be performed. Course with name '{0}' does not exist in the school.", courseName));
            }

            this.courses[indexCourse].AddNewStudent(this.students[indexStudent]);
        }

        /// <summary>
        /// Signs out student of the school of course in the school.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="courseName">Name of the course.</param>
        /// <exception cref="System.InvalidOperationException">If student is already signed for the course</exception>
        /// <exception cref="System.InvalidOperationException">If student is already signed for the course</exception>
        public void SignOutStudentOfCourse(uint id, string courseName)
        {
            int indexStudent = IndexOfStudent(id, this.students);
            if (indexStudent < 0)
            {
                throw new InvalidOperationException(string.Format("The operation can not be performed. Student with ID '{0}' does not attending the school.", id));
            }

            int indexCourse = IndexOfCourse(courseName, this.courses);
            if (indexCourse < 0)
            {
                throw new InvalidOperationException(string.Format("The operation can not be performed. Course with name '{0}' does not exist in the school.", courseName));
            }

            this.courses[indexCourse].RemoveStudent(this.students[indexStudent]);
        }

        /// <summary>
        /// Indexes the of student.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="setOfStudents">The set of students.</param>
        /// <returns>If index if found - the index or -1</returns>
        private static int IndexOfStudent(uint id, IList<Student> setOfStudents)
        {
            for (int i = 0; i < setOfStudents.Count; i++)
            {
                if (setOfStudents[i].Id == id)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Indexes the of course.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="setOfCourses">The set of courses.</param>
        /// <returns>If index if found - the index or -1</returns>
        private static int IndexOfCourse(string name, IList<Course> setOfCourses)
        {
            for (int i = 0; i < setOfCourses.Count; i++)
            {
                if (setOfCourses[i].Name == name.ToLower())
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
