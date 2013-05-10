////
namespace TestSchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void AddNewStudent_AddOneStudent()
        {
            School theSchool = new School();
            theSchool.AddNewStudent("Gosho");

            School myObject = theSchool;
            Type myType = typeof(School);
            FieldInfo setOfStudents = myType.GetField("students", BindingFlags.NonPublic | BindingFlags.Instance);

            IList<Student> students = setOfStudents.GetValue(myObject) as IList<Student>;

            Assert.IsTrue(students.Count == 1);
        }

        [TestMethod]
        public void AddNewStudent_AddFewStudents()
        {
            School theSchool = new School();
            int few = 5;
            for (int i = 0; i < few; i++)
            {
                theSchool.AddNewStudent("Gosho");
            }

            School myObject = theSchool;
            Type myType = typeof(School);
            FieldInfo setOfStudents = myType.GetField("students", BindingFlags.NonPublic | BindingFlags.Instance);

            IList<Student> students = setOfStudents.GetValue(myObject) as IList<Student>;

            Assert.IsTrue(students.Count == few);
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(InvalidOperationException))]
        public void AddNewStudent_AddTooManyStudents()
        {
            School theSchool = new School();
            Type myType = typeof(School);

            FieldInfo maxID = myType.GetField("maxID", BindingFlags.NonPublic | BindingFlags.Static);
            FieldInfo minID = myType.GetField("minID", BindingFlags.NonPublic | BindingFlags.Static);
            FieldInfo idGenerator = myType.GetField("studentIDGenerator", BindingFlags.NonPublic | BindingFlags.Instance);

            uint minimumIDValue = 10;
            uint maximumIDValue = 99;
            minID.SetValue(myType, minimumIDValue);
            maxID.SetValue(myType, maximumIDValue);
            idGenerator.SetValue(theSchool, minimumIDValue);

            for (uint count = minimumIDValue; count <= maximumIDValue + 1; count++)
            {
                theSchool.AddNewStudent("Gosho");
            }
        }

        [TestMethod]
        public void AddNewCourse_AddOneCourse()
        {
            School theSchool = new School();
            theSchool.AddNewCourse("CSharp");

            School myObject = theSchool;
            Type myType = typeof(School);
            FieldInfo setOfCourses = myType.GetField("courses", BindingFlags.NonPublic | BindingFlags.Instance);

            IList<Course> courses = setOfCourses.GetValue(myObject) as IList<Course>;

            Assert.IsTrue(courses.Count == 1);
        }

        [TestMethod]
        public void AddNewCourse_AddFewCoursesWithDifferantNames()
        {
            School theSchool = new School();
            int few = 5;
            for (int i = 0; i < few; i++)
            {
                theSchool.AddNewCourse("CSharp" + i);
            }

            School myObject = theSchool;
            Type myType = typeof(School);
            FieldInfo setOfCourses = myType.GetField("courses", BindingFlags.NonPublic | BindingFlags.Instance);

            IList<Course> courses = setOfCourses.GetValue(myObject) as IList<Course>;

            Assert.IsTrue(courses.Count == few);
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(InvalidOperationException))]
        public void AddNewCourse_AddCoursesWithEqualNames()
        {
            School theSchool = new School();

            theSchool.AddNewCourse("CSharp");
            theSchool.AddNewCourse("CSharp");
        }

        [TestMethod]
        public void SignStudentForCourse_SighOneStudentForOneCourse()
        {
            School theSchool = new School();
            Student newStudent = theSchool.AddNewStudent("Pesho");
            Course newCourse = theSchool.AddNewCourse("CSharp");
            theSchool.SignUpStudentForCourse(newStudent.Id, newCourse.Name);

            School myObject = theSchool;
            Type myType = typeof(School);
            FieldInfo setOfCourses = myType.GetField("courses", BindingFlags.NonPublic | BindingFlags.Instance);

            IList<Course> courses = setOfCourses.GetValue(myObject) as IList<Course>;

            Assert.IsTrue(courses[courses.IndexOf(newCourse)].IsAttendingTheCourse(newStudent));
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(InvalidOperationException))]
        public void SignStudentForCourse_SighUnexistingStudentForCourse()
        {
            School theSchool = new School();
            Course newCourse = theSchool.AddNewCourse("CSharp");
            theSchool.SignUpStudentForCourse(10000, newCourse.Name);
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(InvalidOperationException))]
        public void SignStudentForCourse_SighStudentForUnexistingCourse()
        {
            School theSchool = new School();
            Student newStudent = theSchool.AddNewStudent("Pesho");
            theSchool.SignUpStudentForCourse(newStudent.Id, "CSharp");
        }

        [TestMethod]
        public void SignOutStudentOfCourse_SighOutOneStudentOfOneCourse()
        {
            School theSchool = new School();
            Student newStudent = theSchool.AddNewStudent("Pesho");
            Course newCourse = theSchool.AddNewCourse("CSharp");
            theSchool.SignUpStudentForCourse(newStudent.Id, newCourse.Name);

            School myObject = theSchool;
            Type myType = typeof(School);
            FieldInfo setOfCourses = myType.GetField("courses", BindingFlags.NonPublic | BindingFlags.Instance);

            IList<Course> courses = setOfCourses.GetValue(myObject) as IList<Course>;

            Assert.IsTrue(courses[courses.IndexOf(newCourse)].IsAttendingTheCourse(newStudent));

            theSchool.SignOutStudentOfCourse(newStudent.Id, newCourse.Name);

            Assert.IsFalse(courses[courses.IndexOf(newCourse)].IsAttendingTheCourse(newStudent));
        }

        [TestMethod]
        [ExpectedExceptionAttribute(typeof(InvalidOperationException))]
        public void SignOutStudentOfCourse_SighOutUnexistingStudentOfCourse()
        {
            School theSchool = new School();
            Course newCourse = theSchool.AddNewCourse("CSharp");
            theSchool.SignOutStudentOfCourse(10000, newCourse.Name);
        }


        [TestMethod]
        [ExpectedExceptionAttribute(typeof(InvalidOperationException))]
        public void SignOutStudentOfCourse_SighStudentOfUnexistingCourse()
        {
            School theSchool = new School();
            Student newStudent = theSchool.AddNewStudent("Pesho");
            theSchool.SignOutStudentOfCourse(newStudent.Id, "CSharp");
        }
    }
}
