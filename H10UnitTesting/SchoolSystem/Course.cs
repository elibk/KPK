////
namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// class Course
    /// </summary>
    public class Course : IEquatable<Course>
    {
        /// <summary>
        /// The name
        /// </summary>
        private string name;

        /// <summary>
        /// The attending students
        /// </summary>
        private IList<Student> attendingStudents;

        /// <summary>
        /// The capacity
        /// </summary>
        private int capacity;

        /// <summary>
        /// Initializes a new instance of the <see cref="Course" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="courseCapacity">The course capacity.</param>
        public Course(string name, int courseCapacity)
        {
            this.Name = name;
            this.Capacity = courseCapacity;
            this.attendingStudents = new List<Student>(courseCapacity);
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        /// <exception cref="System.ArgumentException">The value for 'Name' can not contain null, empty string or only white spaces.</exception>
        public string Name
        {
            get
            {
                return this.name.ToLower();
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The value for 'Name' can not contain null, empty string or only white spaces.");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets the capacity.
        /// </summary>
        /// <value>
        /// The capacity.
        /// </value>
        /// <exception cref="System.ArgumentException">Value for 'Capacity' can not be a negative number</exception>
        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Value for 'Capacity' can not be a negative number");
                }

                this.capacity = value;
            }
        }

        /// <summary>
        /// Determines whether [is attending the course] [the specified student].
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns>
        ///   <c>true</c> if [is attending the course] [the specified student]; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">The value for 'student' can not be 'null'.</exception>
        public bool IsAttendingTheCourse(Student student) 
        {
            if (student == null)
            {
                throw new ArgumentException("The value for 'student' can not be 'null'.");
            }

            if (this.attendingStudents.Contains(student))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds the new student.
        /// </summary>
        /// <param name="newStudent">The new student.</param>
        /// <exception cref="System.InvalidOperationException">The operation can not be performed. Student with the same ID attending the school.
        /// or
        /// The student can no be sign because the capacity of the course is reached.</exception>
        public void AddNewStudent(Student newStudent) 
        {
            if (newStudent == null)
            {
                throw new ArgumentException("The value for 'student' can not be 'null'.");
            }

            if (this.IsAttendingTheCourse(newStudent))
            {
                throw new InvalidOperationException("The operation can not be performed. Student with the same ID attending.");
            }

            if (this.attendingStudents.Count >= this.capacity)
            {
                throw new InvalidOperationException("The student can no be sign because the capacity of the course is reached.");
            }

            this.attendingStudents.Add(newStudent);
        }

        /// <summary>
        /// Adds the new student.
        /// </summary>
        /// <param name="student">The new student.</param>
        /// <exception cref="System.InvalidOperationException">The operation can not be performed. Student with the same ID attending the school.
        /// or
        /// The student can no be sign because the capacity of the course is reached.</exception>
        public void RemoveStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentException("The value for 'student' can not be 'null'.");
            }

            if (!this.IsAttendingTheCourse(student))
            {
                throw new InvalidOperationException("The operation can not be performed. Student with the same ID it is not attending the course");
            }

            this.attendingStudents.Remove(student);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object Name is equal to the other parameter Name; otherwise, false.
        /// </returns>
        public bool Equals(Course other)
        {
            if (this.Name == other.Name)
            {
                return true;
            }

            return false;
        }
    }
}
