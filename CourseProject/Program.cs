using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
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
            Console.WriteLine("__________________________________\n");
            Console.WriteLine($"Email - > {Email}");
            Console.WriteLine("__________________________________\n");
            Console.WriteLine($"Username - > {Username}");
            Console.WriteLine("__________________________________\n");
            Console.WriteLine($"Status - > {Status}");
            Console.WriteLine("__________________________________\n");
            Console.Write($"Password - > ");
            for (int i = 0; i < Password.Length; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
            Console.WriteLine("__________________________________\n");
        }
    }
    class Worker : User
    {
        public Worker() { }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Education { get; set; }
        public string City { get; set; }
        public decimal MinSalary { get; set; }
        public string PhoneNumber { get; set; }
        public string SpecialityCategory { get; set; }
        public string ExperienceCategory { get; set; }
        [JsonIgnore]
        public List<string> Experience = new List<string>() {
             "Less than 1 years",
             "From 1 until 3 years",
             "From 5 until 5 years",
             "More than 5 years"
        };
        [JsonIgnore]
        public List<string> EducationCategories = new List<string>()
        {
            "Medium","Uncompleted high degree","High degree"
        };
        [JsonIgnore]
        public List<string> Categories = new List<string>()
        {
            "Programmer","Journalist","IT Specialist","Doctor","Translater"
        };
        public Worker(string name, string surname, int age, string gender, int category, int experiencecategory,
            int educationcategory, string city, decimal minSalary, string phoneNumber, User user)
            : base(user.Email, user.Username, user.Status, user.Password)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
            Education = EducationCategories[educationcategory - 1];
            City = city;
            MinSalary = minSalary;
            PhoneNumber = phoneNumber;
            SpecialityCategory = Categories[category - 1];
            ExperienceCategory = Experience[experiencecategory - 1];
        }
        public void ShowWorker()
        {
            Console.WriteLine("__________________________________\n");
            Console.WriteLine($"Name - > {Name}");
            Console.WriteLine("__________________________________\n");
            Console.WriteLine($"Surname - > {Surname}");
            Console.WriteLine("__________________________________\n");
            Console.WriteLine($"Age - > {Age}");
            Console.WriteLine("__________________________________\n");
            Console.WriteLine($"Gender - > {Gender}");
            Console.WriteLine("__________________________________\n");
            Console.WriteLine($"Education - > {Education}");
            Console.WriteLine("__________________________________\n");
            Console.WriteLine($"Experience - > {ExperienceCategory}");
            Console.WriteLine("__________________________________\n");
            Console.WriteLine($"City - > {City}");
            Console.WriteLine("__________________________________\n");
            Console.WriteLine($"Minimum Salary - > {MinSalary}");
            Console.WriteLine("__________________________________\n");
            Console.WriteLine($"Phone number - > {PhoneNumber}");
            Console.WriteLine("__________________________________\n");
            Console.WriteLine($"Category - > {SpecialityCategory}");
            Console.WriteLine("__________________________________\n");
        }
    }
    class Employee : User
    {

        public Employee() { }
        public string AdvertisementName { get; set; }
        public string CompanyName { get; set; }
        //change name
        public string SpecialityCategory { get; set; }
        public string InformationAboutWork { get; set; }
        public string City { get; set; }
        public decimal Salary { get; set; }
        public int MinimumAge { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string PhoneNumber { get; set; }
        [JsonIgnore]
        public List<string> ExperienceCategory = new List<string>() {
            "Less than 1 years",
             "From 1 until 3 years",
             "From 5 until 5 years",
             "More than 5 years"
        };
        [JsonIgnore]
        public List<string> EducationCategories = new List<string>()
        {
           "Medium","Uncompleted high degree","High degree"
        };
        [JsonIgnore]
        public List<string> Categories = new List<string>()
        {
            "Programmer","Journalist","IT Specialist","Doctor","Translater"
        };
        public Employee(string advertisementName, string companyName, int category, string ınformationAboutWork,
            string city, decimal salary, int minimumAge, int education, int experience, string phoneNumber, User user)
            : base(user.Email, user.Username, user.Status, user.Password)
        {
            AdvertisementName = advertisementName;
            CompanyName = companyName;
            SpecialityCategory = Categories[category - 1];
            InformationAboutWork = ınformationAboutWork;
            City = city;
            Salary = salary;
            MinimumAge = minimumAge;
            Education = EducationCategories[education - 1];
            Experience = ExperienceCategory[experience - 1];
            PhoneNumber = phoneNumber;
        }
        public void ShowEmployeeAdversitement()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("_____________________________________\n");
            Console.WriteLine($"Adversitement name - > {AdvertisementName}");
            Console.WriteLine("_____________________________________\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Company name - > {CompanyName}");
            Console.WriteLine("_____________________________________\n");
            Console.WriteLine($"Speciality - > {SpecialityCategory}");
            Console.WriteLine("_____________________________________\n");
            Console.WriteLine($"Information about work - > {InformationAboutWork}");
            Console.WriteLine("_____________________________________\n");
            Console.WriteLine($"City - > {City}");
            Console.WriteLine("_____________________________________\n");
            Console.WriteLine($"Salary - > {Salary}");
            Console.WriteLine("_____________________________________\n");
            Console.WriteLine($"Minimum age - > {MinimumAge}");
            Console.WriteLine("_____________________________________\n");
            Console.WriteLine($"Education - > {Education}");
            Console.WriteLine("_____________________________________\n");
            Console.WriteLine($"Experience year - > {Experience}");
            Console.WriteLine("_____________________________________\n");
            Console.WriteLine($"Phone number - > {PhoneNumber}");
            Console.WriteLine("_____________________________________\n");
        }
    }
    class Controller
    {
        List<Worker> workerlist = new List<Worker>();
        List<Employee> employeelist = new List<Employee>();
        List<User> users = new List<User>();
        JsonSerializer json = new JsonSerializer();
        public Controller()
        {
            FileInfo fileinfo = new FileInfo("workers.json");
            FileInfo fileinfo2 = new FileInfo("employee.json");
            FileInfo fileinfo3 = new FileInfo("users.json");
            if (!fileinfo.Exists)
            {
                SerializerToJasonWorkers();
            }
            else if (fileinfo.Exists)
            {
                workerlist = DeserializerFromJasonWorkers();
            }
            if (!fileinfo2.Exists)
            {
                SerializerToJasonEmployee();
            }
            else if (fileinfo2.Exists)
            {
                employeelist = DeserializerFromJasonEmployee();
            }
            if (!fileinfo3.Exists)
            {
                SerializerToJasonUsers();
            }
            else if (fileinfo3.Exists)
            {
                users = DeserializerFromJasonUsers();
            }
        }
        public void SerializerToJasonWorkers()
        {
            using (StreamWriter sw = new StreamWriter("workers.json"))
            {
                json.Serialize(sw, workerlist);
            }
        }
        public List<Worker> DeserializerFromJasonWorkers()
        {
            using (StreamReader sr = new StreamReader("workers.json"))
            {
                string reader = sr.ReadToEnd();
                workerlist = JsonConvert.DeserializeObject<List<Worker>>(reader);
                return workerlist;
            }
        }
        public void SerializerToJasonEmployee()
        {
            using (StreamWriter sw = new StreamWriter("employee.json"))
            {
                json.Serialize(sw, employeelist);
            }
        }
        public List<Employee> DeserializerFromJasonEmployee()
        {
            using (StreamReader sr = new StreamReader("employee.json"))
            {
                string reader = sr.ReadToEnd();
                employeelist = JsonConvert.DeserializeObject<List<Employee>>(reader);
                return employeelist;
            }
        }
        public void SerializerToJasonUsers()
        {
            using (StreamWriter sw = new StreamWriter("users.json"))
            {
                json.Serialize(sw, users);
            }
        }
        public List<User> DeserializerFromJasonUsers()
        {
            using (StreamReader sr = new StreamReader("users.json"))
            {
                string reader = sr.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<User>>(reader);
                return users;
            }
        }
        public Worker WorkerRegistriation(User user)
        {
            int age, categorys, excategory, educategory;
            decimal minsalary;
            string name, surname, gender, city, phonenumber;
            Console.Write("Name - >"); name = Console.ReadLine();
            Console.Write("Surname - >"); surname = Console.ReadLine();
            Console.Write("Age - >"); age = Convert.ToInt32(Console.ReadLine());
            do
            {
                Console.Write("Gender(male,female)"); gender = Console.ReadLine();
            } while (!(gender == "male" || gender == "female"));
            Console.WriteLine("Speciality__");
            Console.WriteLine("Programmer 1" + "Journalist 2" + "IT Specialist 3" + "Doctor 4" + "Translater 5");
            categorys = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Experience year__");
            Console.WriteLine("Less than 1 [1]" + "From 1 until 3 years [2]" + "From 1 until 3 years[3]" +
                "More than 5 years[4]");
            excategory = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Education__");
            Console.WriteLine("Medium (1)" + "Uncompleted high degree (2)" + "high degree (3)");
            educategory = Convert.ToInt32(Console.ReadLine());
            Console.Write("City - >"); city = Console.ReadLine();
            Console.Write("Minimum salary - >"); minsalary = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("PhoneNumber - >");
            phonenumber = Console.ReadLine();////is not ready this part
            return new Worker(name, surname, age, gender, categorys, excategory, educategory, city,
                minsalary, phonenumber, user);
        }
        public string ToHidePassword(string password)
        {
            string newstr = "";
            Random random = new Random();
            for (int i = 0; i < password.Length; i++)
            {
                newstr += (int)password[random.Next(0, password.Length)];
            }
            return newstr;
        }
        public string RandomCode()
        {
            Random random = new Random();
            char a, b, c, d;
            string str = string.Empty;
            var vs = new char[4];
            a = (char)random.Next(65, 90);
            b = (char)random.Next(97, 122);
            c = (char)random.Next(48, 57);
            d = (char)random.Next(97, 122);
            char[] chars = { a, b, c, d };
            for (int i = 0; i < vs.Length; i++)
            {
                char temp = chars[random.Next(chars.Length)];

                if (!vs.Contains(temp))
                    vs[i] = temp;
                else
                    --i;
            }
            str = new string(vs);
            return str;
        }
        public bool UsernameIsExist(string name)
        {
            var item = users.SingleOrDefault(x => x.Username == name);
            if (item != null)
            {
                return true;
            }
            return false;
        }
        public bool MailIsExist(string mail)
        {
            var item = users.SingleOrDefault(x => x.Email == mail);
            if (item != null)
            {
                return true;
            }
            return false;
        }

        public User UserRegistriation()
        {
            string username, mail, status, password, checkpassword;
            string newstatus;
            do
            {
                Console.Write("Username - >");
                username = Console.ReadLine();
                //and check exist or not
                if (!CheckUsername(username))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have to write at least one \"Uppercase\" letter");//deyish sozleri
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                if (UsernameIsExist(username))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{username} is already exist");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            } while (!(CheckUsername(username)) || (UsernameIsExist(username)));
            do
            { //and check exist or not
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
                Console.Write("Write your password again for checking - >");
                checkpassword = Console.ReadLine();
                if (checkpassword != password)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please write correct your password");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            } while (checkpassword != password);
            do
            { //and check exist or not
                Console.Write("Mail - >");
                mail = Console.ReadLine();
                if (!CheckMail(mail))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please write correct your mail");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                if (MailIsExist(mail))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{mail} is already exist");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            } while (!CheckMail(mail) || MailIsExist(mail));
            do
            {
                Console.Write("Status - > Worker or Employee (only these)");
                status = Console.ReadLine();
                newstatus = status.ToLower();
                if (!CheckStatus(newstatus))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your status can be only \"worker\" or \"employee\"");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            } while (!CheckStatus(status));
            //password = ToHidePassword(password);
            string code; string codecheck;
            do
            {
                code = RandomCode();
                Console.Write($"Random code - > [{code}]\n");
                Console.Write("Write random code - >");
                codecheck = Console.ReadLine();
            } while (codecheck != code);
            return new User(mail, username, newstatus, password);
        }
        public bool CheckPhoneNumber(string phonenumber)//it is not ready 
        {
            Regex regex = new Regex(@"^\+994(50|51|55|70|77)([0-9]){7}$");
            if (regex.IsMatch(phonenumber))
            {
                return true;
            }
            return false;
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
        public Employee EmployeeRegistriation(User user)
        {
            string advname, companyname, information, city, phonenumber; decimal salary;
            int categorys, minAge, education, experience;//realize delete defoult value
            Console.Write("Advertisement name - >");
            advname = Console.ReadLine();
            Console.Write("Company name - >");
            companyname = Console.ReadLine();
            Console.WriteLine("Speciality__");
            Console.WriteLine("Programmer 1" + "Journalist 2" + "IT Specialist 3" + "Doctor 4" + "Translater 5");
            categorys = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Age - >");
            minAge = Convert.ToInt32(Console.ReadLine());
            Console.Write("Information about work - >");
            information = Console.ReadLine();
            Console.WriteLine("Experience year__");
            Console.WriteLine("Less than 1 year select (1)\n" +
             "From 1 until 3 years select (2)\n" +
             "From 3 until 5 years select (3)\n" +
             "More than 5 years select (4)");
            experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Education__");
            Console.WriteLine("Medium (1)" + "Uncompleted high degree (2)" + "High degree (3)");
            education = Convert.ToInt32(Console.ReadLine());
            Console.Write("City - >"); city = Console.ReadLine();
            do
            {
                Console.Write("Minimum salary - >");
                salary = Convert.ToDecimal(Console.ReadLine());
            } while (salary < 0);
            do
            {
                Console.WriteLine("PhoneNumber - >");
                phonenumber = Console.ReadLine();
                if (!CheckPhoneNumber(phonenumber))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Please write phonenumber correct (for example 0556556565");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            } while (!CheckPhoneNumber(phonenumber));
            return new Employee(advname, companyname, categorys, information, city, salary, minAge, education, experience, phonenumber, user);
        }
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
        public int Run()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            User newuser; Worker worker = new Worker(); Employee employee;
            Console.Write("\t\t\t\tSIGN IN (1) SIGN UP (2) Exit (3)");
            int selection = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            if (selection == 1)
            {//SIGN IN
                var usernew = SignIn(); int select1;
                if (usernew.Status == "worker")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Create your CV [1]\nSearch Job [2]\n Show your CV [3]\nShow all adversitement [4]" +
                            " Search Job with category [5]\nLog Out [6]");
                        Console.Write("Select - > "); select1 = Convert.ToInt32(Console.ReadLine());
                        if (select1 == 1)
                        {

                            worker = WorkerRegistriation(usernew);
                            workerlist.Add(worker);
                            SerializerToJasonWorkers();
                        }
                        else if (select1 == 2)
                        {
                            Console.WriteLine("");
                        }
                        else if (select1 == 3)
                        {
                            var workercv = workerlist.SingleOrDefault(x => x.Username == usernew.Username);
                            workercv.ShowWorker();
                        }
                        else if (select1 == 4)
                        {
                            for (int i = 0; i < workerlist[0].Categories.Count; i++)
                            {
                                Console.Write($" {workerlist[0].Categories[i]} [{i}]");
                            }
                            Console.WriteLine(); Console.WriteLine("Write specialty number");
                            int selectspeciality = Convert.ToInt32(Console.ReadLine());
                            var collections = employeelist.Where(x => x.Categories[selectspeciality] == x.SpecialityCategory);
                            foreach (var item in collections)
                            {
                                item.ShowEmployeeAdversitement();
                            }
                        }
                        else if (select1 == 5)
                        {
                            //Search with category
                        }
                        else if (select1 == 6)
                        {
                            return 1;
                        }
                        Console.WriteLine("Back to Worker Menu select [0]");
                        select1 = Convert.ToInt32(Console.ReadLine());
                        if (select1 == 0)
                        {
                            continue;
                        }
                    }
                }
                else if (usernew.Status == "employee")
                {
                    Console.Clear();
                    var workercv = employeelist.SingleOrDefault(x => x.Username == usernew.Username);
                    Console.WriteLine("_______________________________________\n");
                    Console.WriteLine("__________YOUR_ADVERTISEMENT___________");
                    Console.WriteLine("_______________________________________\n");
                    workercv.ShowEmployeeAdversitement();
                    Console.WriteLine("LOG OUT select 5");
                    int choose = Convert.ToInt32(Console.ReadLine());
                    if (choose == 5) return 1;
                }

            }
            else if (selection == 2)
            {   //SIGN UP
                int select;
                newuser = UserRegistriation();//you have to add to list
                users.Add(newuser);
                SerializerToJasonUsers();
                if (newuser.Status == "worker")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Create your CV [1]\nSearch Job [2]\n Show your CV [3]\nShow all adversitement [4]" +
                            "\nLog Out [5]");
                        Console.Write("Select - > "); select = Convert.ToInt32(Console.ReadLine());
                        if (select == 1)
                        {
                            worker = WorkerRegistriation(newuser);
                            workerlist.Add(worker);
                            SerializerToJasonWorkers();
                        }
                        else if (select == 2)
                        {
                            Console.WriteLine("");
                        }
                        else if (select == 3)
                        {
                            worker.ShowWorker();
                        }
                        else if (select == 4)
                        {
                            for (int i = 0; i < workerlist[0].Categories.Count; i++)
                            {
                                Console.Write($" {workerlist[0].Categories[i]} [{i}]");
                            }
                            Console.WriteLine(); Console.WriteLine("Write specialty number");
                            int selectspeciality = Convert.ToInt32(Console.ReadLine());
                            var collections = employeelist.Where(x => x.Categories[selectspeciality] == x.SpecialityCategory);
                            foreach (var item in collections)
                            {
                                item.ShowEmployeeAdversitement();
                            }
                        }
                        else if (select == 5)
                        {
                            return 1;
                        }
                        Console.WriteLine("Back to Worker Menu select [0]");
                        select = Convert.ToInt32(Console.ReadLine());
                        if (select == 0)
                        {
                            continue;
                        }
                    }
                }
                else if (newuser.Status == "employee")
                {
                    employee = EmployeeRegistriation(newuser);
                    Console.Clear();
                    employeelist.Add(employee);
                    SerializerToJasonEmployee();
                }
            }
            else if (selection == 3)
            {
                Environment.Exit(0);
            }
            return 1;
        }
        public User SignIn()
        {
            bool check; User myuser;
            do
            {
                Console.Write("Username - >");
                string username = Console.ReadLine();
                Console.Write("Password - >");
                string password = Console.ReadLine();
                myuser = users.SingleOrDefault(x => x.Username == username && x.Password == password);
                check = myuser is User;
                if (!check)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Your username or password is not correct");
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
            } while (!check);
            return myuser;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Controller controller = new Controller();
                var backtomenu = controller.Run();
                if (backtomenu == 1)
                {
                    Console.Clear();
                    continue;
                }
            }
        }
    }
}
