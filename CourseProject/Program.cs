using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CourseProject
{
    class User
    {
        public User() { }
        public User(string email, string username, string status, string password)
        {
            Email = email;
            Username = username;
            Status = status;
            Password = password;
            
        }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
        public void ShowUserProperty()
        {
            Console.WriteLine($"Email - > {Email}");
            Console.WriteLine($"Username - > {Username}");
            Console.WriteLine($"Status - > {Status}");
            Console.Write($"Password - > ");
            for (int i = 0; i < Password.Length; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
        }
    }
    class Worker : User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Education { get; set; }
        public string City { get; set; }
        public decimal MinSalary { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Experience = new List<string>() {
             "1 ilden asagi",
             "1 ilden - 3 ile qeder",
             "3 ilden - 5 ile qeder",
             "5 ilden daha cox"
        };
        public List<string> Category = new List<string>()
        {
            "Programmer","Journalist","IT Specialist"
        };
        public Worker(string name, string surname, int age, string gender, string education, string city, decimal minSalary, string phoneNumber, User user)
            : base(user.Email, user.Username, user.Status, user.Password)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
            Education = education;
            City = city;
            MinSalary = minSalary;
            PhoneNumber = phoneNumber;
        }
        public void ShowWorker()
        {
            Console.WriteLine("========================");
            Console.WriteLine($"Name - > {Name}");
            Console.WriteLine($"Surname - > {Surname}");
            Console.WriteLine($"Age - > {Age}");
            Console.WriteLine($"Gender - > {Gender}");
            Console.WriteLine($"Education - > {Education}");
            Console.WriteLine($"City - > {City}");
            Console.WriteLine($"Minimum Salary - > {MinSalary}");
            Console.WriteLine($"Phone number - > {PhoneNumber}");
            ShowUserProperty();
        }
    }

    class Employee : User { }
    class Controller
    {

        public void Run()
        {
            //User user = new User("camalzade_elvin@mail.ru", "Elvin1999", "Worker", "123456798");
            //Worker worker = new Worker("Elvin", "Camalzade", 19, "Male", "Bachelor", "Baku", 800m, "0515848762", user);
            //worker.ShowWorker();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("=============================================================================");
            Console.WriteLine("|                                                                           |");
            Console.WriteLine("|                         ADVERTISEMENT SITE                                |");
            Console.WriteLine("|                                                                           |");
            Console.WriteLine("=============================================================================");
            Console.WriteLine(); Console.Write("SIGN IN (1) SIGN UP (2)");
            int selection = Convert.ToInt32(Console.ReadLine());
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.Run();
        }
    }
}
