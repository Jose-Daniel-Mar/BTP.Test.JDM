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
            var value = "";
            while(value != "x")
            {
                Console.Clear();
                Console.WriteLine("--------- BTPJDM--------\r");
                Console.WriteLine("------------------------\n");
                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\ts - Students");
                Console.WriteLine("\ta - Assignments");
                //Console.WriteLine("\tt - Assign");
                Console.WriteLine("\tx - Exit");
                Console.WriteLine("------------------------\n");
                Console.Write("Your option? ");
                value = Console.ReadLine();
                switch (value)
                {
                    case "s":
                        ClientControllerStudents controllerStudent = new ClientControllerStudents();
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
                                    Console.WriteLine("-------Result----------");
                                    Console.WriteLine("Student Id: " + responseRead.Id);
                                    Console.WriteLine("Student Name: " + responseRead.Name);
                                    Console.WriteLine("Student Birth: " + responseRead.Birth);
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
                        ClientControllerAssignments controllerAssignment = new ClientControllerAssignments();
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
                                    Console.WriteLine("-------Result----------");
                                    Console.WriteLine("Assignment Id: " + responseRead.Id);
                                    Console.WriteLine("Assignment Name: " + responseRead.Name);
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
                    case "x":
                        value = "x";
                        break;
                }
            }    
            
        }
    }
}
