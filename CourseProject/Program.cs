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
        public int ExperienceCategory { get; set; }
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
        public Worker(string name, string surname, int age, string gender, int category, int experiencecategory, string education, string city, decimal minSalary, string phoneNumber, User user)
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
            ExperienceCategory = experiencecategory;
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
        public User UserRegistriation()//you have to return User type
        {
            string username, mail, status, password;
            do
            {
                Console.Write("Username - >");
                username = Console.ReadLine();
                if (!CheckUsername(username))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to write at least one \"Uppercase\" letter");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            } while (!CheckUsername(username));
            do
            {
                Console.Write("Password - >");
                password = Console.ReadLine();
                if (!CheckPassword(password))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to write at least one \"Uppercase\" letter" +
                        "one symbol or number");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            } while (!CheckPassword(password));
            do
            {
                Console.Write("Mail - >");
                mail = Console.ReadLine();
                if (!CheckMail(mail))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please write correct your mail");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            } while (!CheckMail(mail));
            do
            {
                Console.Write("Status - >");
                status = Console.ReadLine();
                if (!CheckStatus(status))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Yout status can be only \"worker\" or \"employee\"");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            } while (!CheckStatus(status));
            return new User(mail, username, status, password);
        }
        public bool CheckStatus(string status)
        {
            var newstring = status.ToLower();
            if (newstring == "worker" || newstring == "employee")
            {
                return true;
            }
            return false;
        }
        //public bool EmployeeRegistriation()
        //{
        //    return false;
        //}
        public bool CheckMail(string mail)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (regex.IsMatch(mail))
            {
                return true;
            }
            return false;
        }
        public bool CheckUsername(string username)
        {
            Regex name = new Regex(@"^[A-Z]{1,3}?[a-zA-Z0-9]{8,12}?");
            if (name.IsMatch(username))
            {
                return true;
            }
            return false;//test
        }
        public bool CheckPassword(string password)
        {
            if (password.Length > 15)
            {
                return false;
            }
            Regex pass = new Regex(@"^[A-Z]{1,3}?[a-zA-Z0-9]{2,10}?[!-/_]{0,3}?[a-zA-Z0-9]{5,10}?[!-/_]{0,3}");
            if (pass.IsMatch(password))
            {
                return true;
            }
            return false;//test
        }
        public void ShowInterfaceOfProgram()
        {

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t\t\t=============================================================================");
            Console.WriteLine("\t\t\t||                                                                         ||");
            Console.WriteLine("\t\t\t||                        ADVERTISEMENT SITE                               ||");
            Console.WriteLine("\t\t\t||                                                                         ||");
            Console.WriteLine("\t\t\t=============================================================================");
            Console.WriteLine();
        }
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            //User user = new User("camalzade_elvin@mail.ru", "Elvin1999", "Worker", "123456798");
            //Worker worker = new Worker("Elvin", "Camalzade", 19, "Male", 1, 2, "Bachelor", "Baku", 800m, "0515848762", user);
            //worker.ShowWorker();
            User newuser;
            Console.Write("\t\t\t\tSIGN IN (1) SIGN UP (2)");
            int selection = Convert.ToInt32(Console.ReadLine());
            if (selection == 1)
            {
                //SIGN IN
            }
            else if (selection == 2)
            {
                newuser = UserRegistriation();
                newuser.ShowUserProperty();
                if (newuser.Status == "worker")
                {
                    //worker registr
                }
                else if (newuser.Status == "employee")
                {
                    //employee registr
                }
            }


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
