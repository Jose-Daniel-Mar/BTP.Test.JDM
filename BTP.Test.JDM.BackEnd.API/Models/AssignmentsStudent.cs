using System;
using System.Collections.Generic;

#nullable disable

namespace BTP.Test.JDM.BackEnd.API.Models
{
    public partial class AssignmentsStudent
    {
        public int Id { get; set; }
        public int IdAssignment { get; set; }
        public int IdStudent { get; set; }

        public virtual Assignment IdAssignmentNavigation { get; set; }
        public virtual Student IdStudentNavigation { get; set; }
    }
}
