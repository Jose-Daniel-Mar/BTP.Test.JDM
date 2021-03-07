using System;
using System.Collections.Generic;

#nullable disable

namespace BTP.Test.JDM.BackEnd.API.Models
{
    public partial class Assignment
    {
        public Assignment()
        {
            AssignmentsStudents = new HashSet<AssignmentsStudent>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AssignmentsStudent> AssignmentsStudents { get; set; }
    }
}
