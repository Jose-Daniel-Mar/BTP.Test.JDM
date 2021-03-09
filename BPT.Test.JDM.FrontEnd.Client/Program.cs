using BPT.Test.JDM.FrontEnd.Client.Controllers;
using BTP.Test.JDM.BackEnd.API.Models;
using System;
using System.Threading.Tasks;

namespace BPT.Test.JDM.FrontEnd.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ClientControllerAssignments controllerAssignment = new ClientControllerAssignments();
            ClientControllerStudents controllerStudent = new ClientControllerStudents();
            ClientControllerAssign controllerAssign = new ClientControllerAssign();
            
            var value = "";
            while(value != "x")
            {
                Console.Clear();
                Console.WriteLine("--------- BTPJDM--------\r");
                Console.WriteLine("------------------------\n");
                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\ts - Students");
                Console.WriteLine("\ta - Assignments");
                Console.WriteLine("\tt - Assignments-Students");
                Console.WriteLine("\tx - Exit");
                Console.WriteLine("------------------------\n");
                Console.Write("Your option? ");
                value = Console.ReadLine();
                switch (value)
                {
                    case "s":
                        
                        var optStudent = "";
                        while(optStudent != "x")
                        {
                            var students = await controllerStudent.ReadStudents();
                            Console.WriteLine("-------Students----------\r");
                            Console.WriteLine("------------------------\n");
                            foreach (Student student in students)
                            {
                                Console.WriteLine(student.Id + ": " + student.Name);
                            }
                            Console.WriteLine("------------------------\n");
                            Console.WriteLine("Choose an option from the following list:");
                            Console.WriteLine("\tc - Create");
                            Console.WriteLine("\tr - Read");
                            Console.WriteLine("\tu - Update");
                            Console.WriteLine("\td - Delete");
                            Console.WriteLine("\tx - Exit");
                            Console.WriteLine("------------------------\n");
                            Console.Write("Your option? ");

                            switch (Console.ReadLine())
                            {
                                case "c":
                                    Student studentCreate = new Student();
                                    Console.WriteLine("-------Create Student----------\r");
                                    Console.WriteLine("------------------------\n");
                                    Console.WriteLine("Type a name:");
                                    studentCreate.Name = Console.ReadLine();
                                    Console.WriteLine("Type a birth (yyy-mm-dd):");
                                    studentCreate.Birth = Convert.ToDateTime(Console.ReadLine());
                                    var responseCreate = await controllerStudent.CreateStudent(studentCreate);
                                    Console.Clear();
                                    Console.WriteLine("-------Result----------");
                                    Console.WriteLine("Student created: Id = " + responseCreate.Id);
                                    Console.WriteLine("------------------------\n");
                                    break;
                                case "r":
                                    Console.WriteLine("-------Get Student----------\r");
                                    Console.WriteLine("------------------------\n");
                                    Console.WriteLine("Type a Student Id:");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    var responseRead = await controllerStudent.ReadStudent(id);
                                    Console.Clear();
                                    var assignments = await controllerAssignment.ReadAssignments();
                                    foreach (Assignment assignment in assignments)
                                    {
                                        Console.WriteLine(assignment.Id + ": " + assignment.Name);
                                    }
                                    Console.WriteLine("-------Result----------");
                                    Console.WriteLine("Student Id: " + responseRead.Id);
                                    Console.WriteLine("Student Name: " + responseRead.Name);
                                    Console.WriteLine("Student Birth: " + responseRead.Birth);
                                    Console.WriteLine("Assignments[");
                                    foreach (AssignmentsStudent val in responseRead.AssignmentsStudents)
                                    {
                                        Console.WriteLine("idAssignment: " + val.IdAssignment);
                                    }
                                    Console.WriteLine("]");
                                    Console.WriteLine("------------------------\n");
                                    break;
                                case "u":
                                    Student studentUpdate = new Student();
                                    Console.WriteLine("-------Update Student----------\r");
                                    Console.WriteLine("------------------------\n");
                                    Console.WriteLine("Type a Student Id:");
                                    studentUpdate.Id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Type a name:");
                                    studentUpdate.Name = Console.ReadLine();
                                    Console.WriteLine("Type a birth (yyy-mm-dd):");
                                    studentUpdate.Birth = Convert.ToDateTime(Console.ReadLine());
                                    var responseUpdate = await controllerStudent.PutStudent(studentUpdate);
                                    Console.Clear();
                                    Console.WriteLine("-------Result----------");
                                    Console.WriteLine("Student updated: Id = " + responseUpdate.Id);
                                    Console.WriteLine("------------------------\n");
                                    break;
                                case "d":
                                    Console.WriteLine("-------Delete Student----------\r");
                                    Console.WriteLine("------------------------\n");
                                    Console.WriteLine("Type a Student Id:");
                                    var Id = Convert.ToInt32(Console.ReadLine());
                                    var responseDelete = await controllerStudent.DeleteStudent(Id);
                                    Console.Clear();
                                    Console.WriteLine("-------Result----------");
                                    Console.WriteLine("Student deleted: Id = " + responseDelete);
                                    Console.WriteLine("------------------------\n");
                                    break;
                                case "x":
                                    optStudent = "x";
                                    break;
                            }
                        }
                        break;

                    case "a":
                        var optAssignment = "";
                        while (optAssignment != "x")
                        {
                            var assignments = await controllerAssignment.ReadAssignments();
                            Console.WriteLine("-------Assignments----------\r");
                            Console.WriteLine("------------------------\n");
                            foreach (Assignment assignment in assignments)
                            {
                                Console.WriteLine(assignment.Id + ": " + assignment.Name);
                            }
                            Console.WriteLine("------------------------\n");
                            Console.WriteLine("Choose an option from the following list:");
                            Console.WriteLine("\tc - Create");
                            Console.WriteLine("\tr - Read");
                            Console.WriteLine("\tu - Update");
                            Console.WriteLine("\td - Delete");
                            Console.WriteLine("\tx - Exit");
                            Console.WriteLine("------------------------\n");
                            Console.Write("Your option? ");

                            switch (Console.ReadLine())
                            {
                                case "c":
                                    Assignment assignmentCreate = new Assignment();
                                    Console.WriteLine("-------Create Assignment----------\r");
                                    Console.WriteLine("------------------------\n");
                                    Console.WriteLine("Type a name:");
                                    assignmentCreate.Name = Console.ReadLine();
                                    var responseCreate = await controllerAssignment.CreateAssignment(assignmentCreate);
                                    Console.Clear();
                                    Console.WriteLine("-------Result----------");
                                    Console.WriteLine("Assignment created: Id = " + responseCreate.Id);
                                    Console.WriteLine("------------------------\n");
                                    break;
                                case "r":
                                    Console.WriteLine("-------Get Assignment----------\r");
                                    Console.WriteLine("------------------------\n");
                                    Console.WriteLine("Type a Assignment Id:");
                                    int id = Convert.ToInt32(Console.ReadLine());
                                    var responseRead = await controllerAssignment.ReadAssignment(id);
                                    Console.Clear();
                                    var students = await controllerStudent.ReadStudents();
                                    foreach (Student student in students)
                                    {
                                        Console.WriteLine(student.Id + ": " + student.Name);
                                    }
                                    Console.WriteLine("-------Result----------");
                                    Console.WriteLine("Assignment Id: " + responseRead.Id);
                                    Console.WriteLine("Assignment Name: " + responseRead.Name);
                                    Console.WriteLine("Students[");
                                    foreach (AssignmentsStudent val in responseRead.AssignmentsStudents)
                                    {
                                        Console.WriteLine("idStudent: " + val.IdStudent);
                                    }
                                    Console.WriteLine("]");
                                    Console.WriteLine("------------------------\n");
                                    break;
                                case "u":
                                    Assignment assignmentUpdate = new Assignment();
                                    Console.WriteLine("-------Update Assignment----------\r");
                                    Console.WriteLine("------------------------\n");
                                    Console.WriteLine("Type a Assignment Id:");
                                    assignmentUpdate.Id = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Type a name:");
                                    assignmentUpdate.Name = Console.ReadLine();
                                    var responseUpdate = await controllerAssignment.PutAssignment(assignmentUpdate);
                                    Console.Clear();
                                    Console.WriteLine("-------Result----------");
                                    Console.WriteLine("Assignment updated: Id = " + responseUpdate.Id);
                                    Console.WriteLine("------------------------\n");
                                    break;
                                case "d":
                                    Console.WriteLine("-------Delete Assignment----------\r");
                                    Console.WriteLine("------------------------\n");
                                    Console.WriteLine("Type a Assignment Id:");
                                    var Id = Convert.ToInt32(Console.ReadLine());
                                    var responseDelete = await controllerAssignment.DeleteAssignment(Id);
                                    Console.Clear();
                                    Console.WriteLine("-------Result----------");
                                    Console.WriteLine("Assignment deleted: Id = " + responseDelete);
                                    Console.WriteLine("------------------------\n");
                                    break;
                                case "x":
                                    optAssignment = "x";
                                    break;
                            }

                        }
                        break;

                    case "t":
                        var optAssign = "";
                        while (optAssign != "x")
                        {
                            Console.Clear();
                            Console.WriteLine("-------Assign----------\r");
                            Console.WriteLine("-----------------------\n");
                            Console.WriteLine("Choose an option from the following list:");
                            Console.WriteLine("\tc - Assign student");
                            Console.WriteLine("\td - Delete assign");
                            Console.WriteLine("\tx - Exit");
                            Console.WriteLine("------------------------\n");
                            Console.Write("Your option? ");

                            switch (Console.ReadLine())
                            {
                                case "c":
                                    Console.Clear();
                                    var studentsA = await controllerStudent.ReadStudents();
                                    var assignmentsA = await controllerAssignment.ReadAssignments();
                                    Console.WriteLine("-------Create Assign----------\r");
                                    Console.WriteLine("------------------------\n");
                                    foreach (Student student in studentsA)
                                    {
                                        Console.WriteLine(student.Id + ": " + student.Name);
                                    }
                                    Console.WriteLine("------------------------\n");
                                    Console.WriteLine("Type a student Id:");
                                    var idS = Convert.ToInt32(Console.ReadLine());
                                    Console.Clear();
                                    Console.WriteLine("-------Create Assign----------\r");
                                    Console.WriteLine("------------------------\n");
                                    foreach (Assignment assignment in assignmentsA)
                                    {
                                        Console.WriteLine(assignment.Id + ": " + assignment.Name);
                                    }
                                    Console.WriteLine("------------------------\n");
                                    Console.WriteLine("Type a assignment Id:");
                                    var idA = Convert.ToInt32(Console.ReadLine());
                                    var responseCreate = await controllerAssign.CreateAssign(idS, idA);
                                    Console.Clear();
                                    Console.WriteLine("-------Result----------");
                                    Console.WriteLine("Assigned: Id = " + responseCreate.Id);
                                    Console.WriteLine("------------------------\n");
                                    break;

                                case "d":
                                    Console.Clear();
                                    Console.WriteLine("-------Delete Assign----------\r");
                                    Console.WriteLine("------------------------\n");
                                    Console.WriteLine("Type a Student Id:");
                                    var IdS = Convert.ToInt32(Console.ReadLine());
                                    var assignments = await controllerAssignment.ReadAssignments();
                                    Console.WriteLine("-------Assignments----------\r");
                                    Console.WriteLine("------------------------\n");
                                    foreach (Assignment assignment in assignments)
                                    {
                                        Console.WriteLine(assignment.Id + ": " + assignment.Name);
                                    }
                                    Console.WriteLine("------------------------\n");
                                    Console.WriteLine("Choose an Assign-Student Id:\n");
                                    var values = await controllerAssign.ReadAssigns(IdS);
                                    foreach (AssignmentsStudent assignment in values)
                                    {
                                        Console.WriteLine("Assignment-Student Id: " + assignment.Id);
                                        Console.WriteLine("assigment id: " + assignment.IdAssignment);
                                        Console.WriteLine("------------------------\n");
                                    }
                                    Console.WriteLine("------------------------\n");
                                    Console.WriteLine("Type a Assignment-Student Id:");
                                    var IdA = Convert.ToInt32(Console.ReadLine());
                                    var responseDelete = await controllerAssign.DeleteAssign(IdA);
                                    Console.Clear();
                                    Console.WriteLine("-------Result----------");
                                    Console.WriteLine("Assignment-Student deleted: Id = " + responseDelete);
                                    Console.WriteLine("------------------------\n");
                                    break;
                                case "x":
                                    optAssign = "x";
                                    break;
                            }
                        }
                        break;

                    case "x":
                        value = "x";
                        break;
                }
            }    
            
        }
    }
}
