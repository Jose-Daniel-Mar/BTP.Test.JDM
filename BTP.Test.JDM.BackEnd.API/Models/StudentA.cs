using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTP.Test.JDM.BackEnd.API.Models
{
    public class StudentA : Student
    {
        public ICollection<Assignment> Assignments { get; set; }
    }
}
