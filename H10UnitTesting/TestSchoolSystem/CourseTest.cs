////
namespace TestSchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void CrateCourse_CrateCourseAndGetItsName()
        {
            string name = "css";
            Course student = new Course("Css", 10);

            Assert.AreEqual(name, student.Name);
        }

        [TestMethod]
        public void CrateCourse_CrateCourseAndGetItsCapacity()
        {
            int capacity = 10;
            Course course = new Course("css", 10);

            Assert.AreEqual(capacity, course.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CrateCourse_CrateCourseWithWhiteSpacedName()
        {
            new Course("   ", 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CrateCourse_CrateCourseWithNullName()
        {
            new Course(null, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CrateCourse_CrateCourseWithEmptyName()
        {
            new Course(string.Empty, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CrateCourse_CrateCourseWithNegativeCapacity()
        {
            new Course("CSharp", -10);
        }

        [TestMethod]
        public void IsAttendingTheCourse_StudentIsAtending()
        {
            Course course = new Course("OS", 123);
            Student student = new Student(10000, "Pesho");
            course.AddNewStudent(student);
            Assert.IsTrue(course.IsAttendingTheCourse(student));
        }

        [TestMethod]
        public void IsAttendingTheCourse_StudentIsNotAtending()
        {
            Course course = new Course("OS", 123);
            Student student = new Student(10000, "Pesho");
            
            Assert.IsFalse(course.IsAttendingTheCourse(student));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsAttendingTheCourse_StudentIsNull()
        {
            Course course = new Course("OS", 123);
            Assert.IsFalse(course.IsAttendingTheCourse(null));
        }

        [TestMethod]
        public void AddNewStudent_AddOneStudent()
        {
            Course course = new Course("OS", 123);
            Student student = new Student(10000, "Pesho");
            course.AddNewStudent(student);

            Type myType = typeof(Course);
            FieldInfo setOfStudents = myType.GetField("attendingStudents", BindingFlags.NonPublic | BindingFlags.Instance);

            IList<Student> students = setOfStudents.GetValue(course) as IList<Student>;

            Assert.IsTrue(students.Count == 1);
        }

        [TestMethod]
        public void AddNewStudent_AddFewStudentsWithDifferantIds()
        {
            Course course = new Course("OS", 123);
            for (int i = 0; i < course.Capacity; i++)
            {
                course.AddNewStudent(new Student((uint)i, "Gosho"));
            }
           
            Type myType = typeof(Course);
            FieldInfo setOfStudents = myType.GetField("attendingStudents", BindingFlags.NonPublic | BindingFlags.Instance);

            IList<Student> students = setOfStudents.GetValue(course) as IList<Student>;

            Assert.IsTrue(students.Count == course.Capacity);
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(InvalidOperationException))]
        public void AddNewStudent_AddTooManyStudents()
        {
            Course course = new Course("OS", 123);
            for (int i = 0; i < course.Capacity + 1; i++)
            {
                course.AddNewStudent(new Student((uint)i, "Gosho"));
            }
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(InvalidOperationException))]
        public void AddNewStudent_AddTooMuchStudents()
        {
            Course course = new Course("OS", 123);
            Student student = new Student(10000, "Pesho");
            Student studentWithSameID = new Student(10000, "Gosho");
            course.AddNewStudent(student);
            course.AddNewStudent(studentWithSameID);
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(ArgumentException))]
        public void AddNewStudent_AddStudentNull()
        {
            Course course = new Course("OS", 123);
            course.AddNewStudent(null);
        }

        [TestMethod]
        public void RemoveStudent_RemoveOneStudent()
        {
            Course course = new Course("OS", 123);
            Student student = new Student(10000, "Pesho");
            course.AddNewStudent(student);

            Type myType = typeof(Course);
            FieldInfo setOfStudents = myType.GetField("attendingStudents", BindingFlags.NonPublic | BindingFlags.Instance);

            IList<Student> students = setOfStudents.GetValue(course) as IList<Student>;

            Assert.IsTrue(students.Contains(student));
            course.RemoveStudent(student);
            Assert.IsFalse(students.Contains(student));
            
        }

        [TestMethod]
        public void RemoveStudent_RemoveAllStudents()
        {
            Course course = new Course("OS", 123);
            Student[] signedStudends = new Student[course.Capacity];
            for (int i = 0; i < course.Capacity; i++)
            {
                signedStudends[i] = new Student((uint)i, "Gosho");
                course.AddNewStudent(new Student((uint)i, "Gosho"));
            }

            Type myType = typeof(Course);
            FieldInfo setOfStudents = myType.GetField("attendingStudents", BindingFlags.NonPublic | BindingFlags.Instance);

            IList<Student> students = setOfStudents.GetValue(course) as IList<Student>;

            Assert.IsTrue(students.Count == course.Capacity);

            for (int i = 0; i < course.Capacity; i++)
            {
                course.RemoveStudent(signedStudends[i]);
            }

            Assert.IsTrue(students.Count == 0);
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(InvalidOperationException))]
        public void RemoveStudent_RemoveUnsignedStudent()
        {
            Course course = new Course("OS", 123);
            course.RemoveStudent(new Student(1000, "Gosho"));
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(ArgumentException))]
        public void RemoveStudent_RemoveStudentNull()
        {
            Course course = new Course("OS", 123);
            course.RemoveStudent(null);
        }

        [TestMethod]
        public void Equals_CompareEqualCourses()
        {
            Course course = new Course("css", 10);
            Course otherCourse = new Course("CSS", 12);

            Assert.IsTrue(course.Equals(otherCourse));
        }

        [TestMethod]
        public void Equals_CompareNotEqualCourses()
        {
            Course course = new Course("JSPart1", 10);
            Course otherCourse = new Course("JSPart2", 12);

            Assert.IsFalse(course.Equals(otherCourse));
        }
    }
}
