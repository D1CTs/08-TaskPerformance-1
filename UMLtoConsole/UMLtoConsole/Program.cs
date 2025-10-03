using System;

public class UMLtoConsole
{
    public interface IEmployee
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Department { get; set; }
        string JobTitle { get; set; }

        decimal CalculateSalary();
        void DisplaySalary();
    }

    public abstract class Employee : IEmployee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }

        public Employee(string firstName, string lastName, string department, string jobTitle)
        {
            FirstName = firstName;
            LastName = lastName;
            Department = department;
            JobTitle = jobTitle;
        }
        public abstract decimal CalculateSalary();

        public void DisplaySalary()
        {
            Console.WriteLine($"Name: {LastName}, {FirstName}");
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Job Title: {JobTitle}");
            Console.WriteLine($"Salary: {CalculateSalary():C}\n");
        }
    }

    public class FullTime : Employee
    {
        public decimal MonthlySalary { get; set; }

        public FullTime(string firstName, string lastName, string department, string jobTitle, decimal monthlySalary)
            : base(firstName, lastName, department, jobTitle)
        {
            MonthlySalary = monthlySalary;
        }
        public override decimal CalculateSalary()
        {
            return MonthlySalary * 12;
        }
    }
    public class PartTime : Employee
    {
        public decimal RatePerHour { get; set; }
        public int TotalHoursWorked { get; set; }

        public PartTime(string firstName, string lastName, string department, string jobTitle, decimal ratePerHour)
            : base(firstName, lastName, department, jobTitle)
        {
            RatePerHour = ratePerHour;
            TotalHoursWorked = 0;
        }
        public void AddHours(int hours)
        {
            TotalHoursWorked += hours;
        }
        public override decimal CalculateSalary()
        {
            return RatePerHour * TotalHoursWorked;
        }
    }
    public class Intern : Employee
    {
        public decimal MonthlyStipend { get; set; }

        public Intern(string firstName, string lastName, string department, string jobTitle, decimal monthlyStipend)
            : base(firstName, lastName, department, jobTitle)
        {
            MonthlyStipend = monthlyStipend;
        }
        public override decimal CalculateSalary()
        {
            return MonthlyStipend * 12;
        }
    }
    public class Contract : Employee
    {
        public decimal RatePerHour { get; set; }
        public int TotalHoursWorked { get; set; }

        public Contract(string firstName, string lastName, string department, string jobTitle, decimal ratePerHour)
            : base(firstName, lastName, department, jobTitle)
        {
            RatePerHour = ratePerHour;
            TotalHoursWorked = 0;
        }
        public void AddHours(int hours)
        {
            TotalHoursWorked += hours;
        }
        public override decimal CalculateSalary()
        {
            return RatePerHour * TotalHoursWorked;
        }
    }

    public static void Main(string[] args)
    {
        IEmployee fullTime = new FullTime("Pablo", "Jhab", "IT", "Software Engineer", 1000);
        PartTime partTime = new PartTime("Clare", "Marry", "HM", "Waiter", 16);
        IEmployee intern = new Intern("Anthony", "Moon", "HM", "Janitor", 500);
        Contract contract = new Contract("Makhity", "Tico", "Tourism", "Tourist", 20);

        Console.WriteLine("- - -= FULL TIME =- - -");
        fullTime.DisplaySalary();

        Console.WriteLine("- - -= PART TIME =- - -");
        partTime.DisplaySalary();
        partTime.AddHours(8);
        partTime.DisplaySalary();

        Console.WriteLine("- - -= INTERN =- - -");
        intern.DisplaySalary();

        Console.WriteLine("- - -= CONTRACT =- - -");
        contract.DisplaySalary();
        contract.AddHours(8);
        contract.DisplaySalary();
    }
}