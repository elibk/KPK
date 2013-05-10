////
namespace TestSchoolSystem
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem;
   
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void CrateStudent_CrateStudentAndGetItsName()
        {
            string name = "Pesho";
            Student student = new Student(1000, "Pesho");

            Assert.AreEqual(name, student.Name);
        }

        [TestMethod]
        public void CrateStudent_CrateStudentAndGetItsId()
        {
            uint id = 1000;
            Student student = new Student(1000, "Pesho");

            Assert.AreEqual(id, student.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CrateStudent_CrateStudentWithWhiteSpacedName()
        {
            new Student(1000, "   ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CrateStudent_CrateStudentWithNullName()
        {
             new Student(1000, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CrateStudent_CrateStudentWithEmptyName()
        {
             new Student(1000, string.Empty);
        }

        [TestMethod]
        public void Equals_CompareEqualStudents()
        {
            Student student = new Student(1000, "Pesho");
            Student otherStudent = new Student(1000, "Mike");

            Assert.IsTrue(student.Equals(otherStudent));
        }

        [TestMethod]
        public void Equals_CompareNotEqualStudents()
        {
            Student student = new Student(1000, "Pesho");
            Student otherStudent = new Student(1020, "Mike");

            Assert.IsFalse(student.Equals(otherStudent));
        }
    }
}
