using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSZDAModel;

namespace PWS_6_client
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {

                int choice = 1;
                while (choice != 0)
                {
                    Console.WriteLine(  "1.Add\n" +
                                        "2.Update Name\n" +
                                        "3.Print\n" +
                                        "0.Exit");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {                        
                        case 1: Add(); break;
                        case 2: Update(); break;
                        case 3: PrintValues(); break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }

        }

        static void PrintValues()
        {
            WSZDAEntities service = new WSZDAEntities(new Uri("http://localhost:49240/WcfDataService1.svc"));

            foreach (var student in service.Student.AsEnumerable())
            {
                Console.WriteLine("----------------------");
                Console.WriteLine($"Id: {student.id}\nName: {student.name}");
                Console.WriteLine();
                foreach (var note in service.Note.Where(i => i.student_id == student.id).AsEnumerable())
                {
                    Console.WriteLine($"  Subj: {note.subject}, Note: {note.note1}");
                }
                Console.WriteLine("----------------------");
            }
            Console.WriteLine("\n\n\n");
        }
        static void Add()
        {
            WSZDAEntities service = new WSZDAEntities(new Uri("http://localhost:49240/WcfDataService1.svc"));

            Student student = new Student() { id = 100 };
            Console.Write("Enter Name: ");
            student.name = Console.ReadLine();
            service.AddToStudent(student);
            service.SaveChanges();
        }
        static void Update()
        {
            WSZDAEntities service = new WSZDAEntities(new Uri("http://localhost:49240/WcfDataService1.svc"));
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine());
            var student = service.Student.AsEnumerable().First(i => i.id == id);
            Console.Write("New Name: ");
            student.name = Console.ReadLine();
            service.UpdateObject(student);
            service.SaveChanges();
        }
    }
}
