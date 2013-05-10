////

namespace SchoolSystem
{
    using System;
    using System.Linq;

    /// <summary>
    /// class Student
    /// </summary>
    public class Student : IEquatable<Student>
    {
        /// <summary>
        /// The id
        /// </summary>
        private uint id;

        /// <summary>
        /// The name
        /// </summary>
        private string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Student" /> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        public Student(uint id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public uint Id
        {
            get
            {
                return this.id;
            }

            protected set
            {
                this.id = value;
            }
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
                return this.name;
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
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object Id is equal to the other parameter Id; otherwise, false.
        /// </returns>
        public bool Equals(Student other)
        {
            if (this.Id == other.Id)
            {
                return true;
            }

            return false;
        }
    }
}
