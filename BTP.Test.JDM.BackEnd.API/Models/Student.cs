using System;
using System.Collections.Generic;

#nullable disable

namespace BTP.Test.JDM.BackEnd.API.Models
{
    public partial class Student
    {
        public Student()
        {
            AssignmentsStudents = new HashSet<AssignmentsStudent>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }

        public virtual ICollection<AssignmentsStudent> AssignmentsStudents { get; set; }
    }
}
