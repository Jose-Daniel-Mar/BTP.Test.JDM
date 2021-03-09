using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace BTP.Test.JDM.BackEnd.API.Models
{
    public partial class AssignmentsStudent
    {
        public int Id { get; set; }
        public int IdAssignment { get; set; }
        public int IdStudent { get; set; }
        [JsonIgnore]
        public virtual Assignment IdAssignmentNavigation { get; set; }
        [JsonIgnore]
        public virtual Student IdStudentNavigation { get; set; }
    }
}
