/*
Main Parts of the Project:

Models: Classes that "map" onto database tables.
Context: Class that describes how to connect to the database.
Application: Everything else that uses the Context and Models in order to serve database data to the user.
*/
/*
0. Ensure MariaDB is running so that when we go to connect to it, it is there to answer.
1. Ensure packages are installed (See Slide 6).
2. Generate the files for the Context and the Models. Folder structure is up to you, organize it in a way that you can find files as needed. Ensure the classes are public.
3. Inherit the context from DbContext.
4. Declare a default constructor and one that accepts DbContextOptions.
5. Declare virtual DbSets of our model types.
6. Override OnConfiguring and connect to the database.
7. Specify OnModelCreating instructions for setting up models.
*/

using EXSM3942_Demo.Data;
using EXSM3942_Demo.Data.Models;

namespace EXSM3942_Demo
{
    internal class Program
    {
        public static int CreateStudent(string firstName, string lastName, int classroomID)
        {
            Student toCreate = new Student() { FirstName = firstName, LastName = lastName, ClassRoomID = classroomID };
            using (ClassRoomContext context = new ClassRoomContext())
            {
                context.Students.Add(toCreate);
                context.SaveChanges();
            }
            return toCreate.ID;
        }
        public static void UpdateStudent(int id, string firstName, string lastName, int classroomID)
        {
            using (ClassRoomContext context = new ClassRoomContext())
            {
                Student toUpdate = context.Students.Where(x => x.ID == id).Single();
                toUpdate.FirstName = firstName;
                toUpdate.LastName = lastName;
                toUpdate.ClassRoomID = classroomID;
                context.SaveChanges();
            }
        }
        public static void DeleteStudent(int id)
        {
            using (ClassRoomContext context = new ClassRoomContext())
            {
                Student toDelete = context.Students.Where(x => x.ID == id).Single();
                context.Students.Remove(toDelete);
                context.SaveChanges();
            }
        }
        public static List<Student> GetStudents()
        {
            List<Student> students;
            using (ClassRoomContext context = new ClassRoomContext())
            {
                students = context.Students.ToList();
            }
            return students;
        }
        public static int CreateClassroom(int roomNumber)
        {
            ClassRoom toCreate = new ClassRoom() { RoomNumber = roomNumber };
            using (ClassRoomContext context = new ClassRoomContext())
            {
                context.ClassRooms.Add(toCreate);
                context.SaveChanges();
            }
            return toCreate.ID;
        }
        public static void UpdateClassroom(int id, int roomNumber)
        {
            using (ClassRoomContext context = new ClassRoomContext())
            {
                ClassRoom toUpdate = context.ClassRooms.Where(x => x.ID == id).Single();
                toUpdate.RoomNumber = roomNumber;
                context.SaveChanges();
            }
        }
        public static void DeleteClassroom(int id)
        {
            using (ClassRoomContext context = new ClassRoomContext())
            {
                ClassRoom toDelete = context.ClassRooms.Where(x => x.ID == id).Single();
                context.ClassRooms.Remove(toDelete);
                context.SaveChanges();
            }
        }
        public static List<ClassRoom> GetClassrooms()
        {
            List<ClassRoom> classrooms;
            using (ClassRoomContext context = new ClassRoomContext())
            {
                classrooms = context.ClassRooms.ToList();
            }
            return classrooms;
        }






        public static int GetClassroomIDByRoomNumber(int number)
        {
            int classroomID;
            using (ClassRoomContext context = new ClassRoomContext())
            {
                classroomID = context.ClassRooms.Where(x => x.RoomNumber == number).Single().ID;
            }
            return classroomID;
        }

        static void Main(string[] args)
        {
            string input;
            do
            {
                Console.WriteLine("Welcome to the Classroom List!\n1. Classrooms\n2. Students\n0. Exit");
                Console.Write("\tPlease make a selection: ");
                input = Console.ReadLine().Trim();
                if (input == "1")
                {
                    // Classrooms
                    string inputClassrooms;
                    do
                    {
                        Console.WriteLine("Classroom Data\n1. Create Classroom\n2. List Classrooms\n3. Update Classroom\n4. Delete Classroom\n0. Back");
                        Console.Write("\tPlease make a selection: ");
                        inputClassrooms = Console.ReadLine().Trim();
                        if (inputClassrooms == "1")
                        {
                            int roomNumber;
                            Console.Write("Please enter a room number: ");
                            roomNumber = int.Parse(Console.ReadLine().Trim());
                            Console.WriteLine($"Created Classroom with ID {CreateClassroom(roomNumber)}.");
                        }
                        else if (inputClassrooms == "2")
                        {
                            foreach (ClassRoom classRoom in GetClassrooms())
                            {
                                Console.WriteLine($"{classRoom.ID} - {classRoom.RoomNumber}");
                            }
                        }
                        else if (inputClassrooms == "3")
                        {
                            int targetID, targetNumber, newNumber;
                            Console.Write("Please enter a current room number: ");
                            targetNumber = int.Parse(Console.ReadLine().Trim());
                            targetID = GetClassroomIDByRoomNumber(targetNumber);

                            Console.Write("Please enter the updated room number: ");
                            newNumber = int.Parse(Console.ReadLine().Trim());
                            UpdateClassroom(targetID, newNumber);
                        }
                        else if (inputClassrooms == "4")
                        {
                            int targetID, targetNumber;
                            Console.Write("Please enter a current room number: ");
                            targetNumber = int.Parse(Console.ReadLine().Trim());
                            targetID = GetClassroomIDByRoomNumber(targetNumber);
                            DeleteClassroom(targetID);
                        }
                        else if (inputClassrooms != "0")
                        {
                            Console.WriteLine("Error, please make a valid selection.");
                        }
                        Console.WriteLine();
                    } while (inputClassrooms != "0");
                }
                else if (input == "2")
                {
                    // Students
                    string inputStudents;
                    do
                    {
                        Console.WriteLine("Student Data\n1. Create Student\n2. List Students\n3. Update Student\n4. Delete Student\n0. Back");
                        Console.Write("\tPlease make a selection: ");
                        inputStudents = Console.ReadLine().Trim();
                        if (inputStudents == "1")
                        {
                            string firstName, lastName;
                            int roomNumber;
                            Console.Write("Please enter a first name: ");
                            firstName = Console.ReadLine().Trim();
                            Console.Write("Please enter a last name: ");
                            lastName = Console.ReadLine().Trim();
                            Console.Write("Please enter a room number: ");
                            roomNumber = int.Parse(Console.ReadLine().Trim());
                            Console.WriteLine($"Created student with ID {CreateStudent(firstName, lastName, GetClassroomIDByRoomNumber(roomNumber))}.");
                        }
                        else if (inputStudents == "2")
                        {
                            foreach (Student student in GetStudents())
                            {
                                Console.WriteLine($"{student.ID} - {student.FirstName} {student.LastName}");
                            }
                        }
                        else if (inputStudents == "3")
                        {
                            string firstName, lastName;
                            int targetID, roomNumber;
                            Console.Write("Please enter a current Student ID: ");
                            targetID = int.Parse(Console.ReadLine().Trim());
                            Console.Write("Please enter the updated first name: ");
                            firstName = Console.ReadLine().Trim();
                            Console.Write("Please enter the updated last name: ");
                            lastName = Console.ReadLine().Trim();
                            Console.Write("Please enter the updated room number: ");
                            roomNumber = int.Parse(Console.ReadLine().Trim());
                            UpdateStudent(targetID, firstName, lastName, GetClassroomIDByRoomNumber(roomNumber));                          
                        }
                        else if (inputStudents == "4")
                        {
                            int targetID;
                            Console.Write("Please enter a current Student ID: ");
                            targetID = int.Parse(Console.ReadLine().Trim());
                            DeleteStudent(targetID);
                        }
                        else if (inputStudents != "0")
                        {
                            Console.WriteLine("Error, please make a valid selection.");
                        }
                        Console.WriteLine();
                    } while (inputStudents != "0");
                }
                else if (input != "0")
                {
                    Console.WriteLine("Error, please make a valid selection.");
                }
                Console.WriteLine();
            } while (input != "0");
        }
    }
}