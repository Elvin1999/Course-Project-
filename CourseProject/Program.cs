using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public int Category { get; set; }
        //write ecperience category selection property
        public List<string> Experience = new List<string>() {
             "1 ilden asagi",
             "1 ilden - 3 ile qeder",
             "3 ilden - 5 ile qeder",
             "5 ilden daha cox"
        };
        public List<string> Categories = new List<string>()
        {
            "Programmer","Journalist","IT Specialist"
        };
        public Worker(string name, string surname, int age, string gender, int category, string education, string city, decimal minSalary, string phoneNumber, User user)
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
            Category = category;
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
            Console.WriteLine($"Category - > {Categories[Category]}");
            ShowUserProperty();
        }
    }

    class Employee : User
    {
        public string AdvertisementName { get; set; }
        public string CompanyName { get; set; }
        //change name
        public int Category { get; set; }
        public string InformationAboutWork { get; set; }
        public string City { get; set; }
        public string Salary { get; set; }
        public int MinimumAge { get; set; }
        public int Education { get; set; }
        public int Experience { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> ExperienceCategory = new List<string>() {
             "1 ilden asagi",
             "1 ilden - 3 ile qeder",
             "3 ilden - 5 ile qeder",
             "5 ilden daha cox"
        };
        public List<string> EducationCategories = new List<string>()
        {
            "orta", "natamam ali", "ali"
        };
        public List<string> Categories = new List<string>()
        {
            "Programmer","Journalist","IT Specialist"
        };

        public Employee(string advertisementName, string companyName, int category, string ınformationAboutWork,
            string city, string salary, int minimumAge, int education, int experience, string phoneNumber, User user)
            : base(user.Email, user.Username, user.Status, user.Password)
        {
            AdvertisementName = advertisementName;
            CompanyName = companyName;
            Category = category;
            InformationAboutWork = ınformationAboutWork;
            City = city;
            Salary = salary;
            MinimumAge = minimumAge;
            Education = education;
            Experience = experience;
            PhoneNumber = phoneNumber;
        }
    }
    class Controller
    {
        List<Worker> workerlist = new List<Worker>();
        List<Employee> employeelist = new List<Employee>();
        //name surname and so on for parametr
        public bool WorkerRegistriation()
        {
            return false;
        }
        public void UserRegistriation()//you have to return User type
        {
            string username, mail, status, password;
            do
            {
                Console.Write("Username - >");
                username = Console.ReadLine();
               
            } while (!CheckUsername(username));
            do
            {
                Console.Write("Password - >");
                password = Console.ReadLine();

            } while (!CheckPassword(password));
            ////mail 
            ///status
        }
        public bool EmployeeRegistriation()
        {
            return false;
        }
        public bool CheckUsername(string username)
        {
            Regex name = new Regex(@"^[A-Z]{1}?[a-zA-Z0-9]{1,15}?");
            if (name.IsMatch(username))
            {
                return true;
            }
            return false;//test
        }
        public bool CheckPassword(string password)
        {
            Regex pass = new Regex(@"^[A-Z]{1}?[a-zA-Z0-9]{7}?");
            if (pass.IsMatch(password))
            {
                return true;
            }
            return false;//test
        }
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            User user = new User("camalzade_elvin@mail.ru", "Elvin1999", "Worker", "123456798");
            Worker worker = new Worker("Elvin", "Camalzade", 19, "Male", 1, "Bachelor", "Baku", 800m, "0515848762", user);
            worker.ShowWorker();
            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("\t\t\t=============================================================================");
            //Console.WriteLine("\t\t\t||                                                                         ||");
            //Console.WriteLine("\t\t\t||                        ADVERTISEMENT SITE                               ||");
            //Console.WriteLine("\t\t\t||                                                                         ||");
            //Console.WriteLine("\t\t\t=============================================================================");
            Console.WriteLine(); Console.Write("\t\t\t\tSIGN IN (1) SIGN UP (2)");
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
