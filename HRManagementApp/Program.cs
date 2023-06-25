
using System;

namespace HRManagementAPP
{
    internal class Program
    {
        private static List<Employee> employees = new List<Employee>();

        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------------------------");
            Console.WriteLine("***** HRManagementAPP *****");
            Console.WriteLine("---------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            string userSelection;

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine("***** Select an action by typing in the number and hit ENTER *****");
                Console.WriteLine("1.Register employee");
                Console.WriteLine("2.Register work hours for an employee");
                Console.WriteLine("3.Pay employee based on hours worked and rate");
                Console.WriteLine("4.Change the hourly rate of the employee");
                Console.WriteLine("5.Give bonus which adds to the wage when paid");
                Console.WriteLine("6.Show current employee list");
                Console.WriteLine("9.Quit application");
                Console.WriteLine("------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;

                userSelection = Console.ReadLine();

                switch (userSelection)
                {
                    case "1":
                        Console.WriteLine("Creating employee:");
                        RegisterEmployee();
                        break;
                    case "2":
                        Console.WriteLine("Registering work hours:");
                        RegisterWorkHours();
                        break;
                    case "3":
                        Console.WriteLine("Paying employee:");
                        PayEmployee();
                        break;
                    case "4":
                        Console.WriteLine("Changing the hourly rate:");
                        ChangeHourlyRate();
                        break;
                    case "5":
                        Console.WriteLine("Give bonus:");
                        GiveBonus();
                        break;
                    case "6":
                        Console.WriteLine("Showing current employee list:");
                        ShowingEmployeeDetails();
                        break;
                    case "9":
                        Console.WriteLine("Quiting application:");
                        break;
                    default:
                        Console.WriteLine("Invalid Input given. Please follow instruction and try again.");
                        break;

                }
            }
            while (userSelection != "9");
        }

        private static void GiveBonus()
        {
            Console.WriteLine("Select one of the employee to give bonus. Select 1 for the first employee, 2 for the second and so on.");
            // make sure employee list is not empty
            if (employees.Count > 0)
            {
                // capture which employee's we selected
                int employeeIndex = SelectedEmployeeFromList();

                if (employeeIndex >= 0 && employeeIndex < employees.Count)
                {
                    // capture how much bonus would the employee have
                    Console.WriteLine($"Now enter bonus amount the employee {employees[employeeIndex].FirstName} {employees[employeeIndex].LastName} will have: ");
                    string bonus = Console.ReadLine();
                    double bonusAmount = int.Parse(bonus);

                    employees[employeeIndex].bonus = bonusAmount;

                    Console.WriteLine($"{employees[employeeIndex].FirstName} {employees[employeeIndex].LastName} has now bonus amonut of {employees[employeeIndex].bonus}");

                }
                else
                    Console.WriteLine($"You selected wrong value. Please select between 1 and {employees.Count} number");

            }

        }

        private static void ChangeHourlyRate()
        {
            Console.WriteLine("Select one of the employee to change their hourly rate. Select 1 for the first employee, 2 for the second and so on.");
            // make sure employee list is not empty
            if (employees.Count > 0)
            {
                // capture which employee's we selected
                int employeeIndex = SelectedEmployeeFromList();

                if (employeeIndex >= 0 && employeeIndex < employees.Count)
                {
                    // capture the rate change for the employee
                    double prevRate = employees[employeeIndex].HourlyRate;
                    Console.WriteLine($"Now enter new hourly rate the employee {employees[employeeIndex].FirstName} {employees[employeeIndex].LastName} will have: ");
                    string rate = Console.ReadLine();
                    double hourlyRate = int.Parse(rate);

                    employees[employeeIndex].HourlyRate = hourlyRate;

                    Console.WriteLine($"{employees[employeeIndex].FirstName} {employees[employeeIndex].LastName} has his rate changed from {prevRate} to {employees[employeeIndex].HourlyRate} now");
                }
                else
                    Console.WriteLine($"You selected wrong value. Please select between 1 and {employees.Count} number");

            }
        }

        // always have if (employees.Count > 0) when calling this method for defensive coding
        private static int SelectedEmployeeFromList()
        {
            int employeeIndex=0;
            // show all the employee
            for (int i = 1; i <= employees.Count; i++)
            {
                Console.WriteLine($"{i}. Employee {employees[i - 1].FirstName} {employees[i - 1].LastName}");
            }

            // make sure employee list is not empty
            if (employees.Count > 0)
            {
                // capture which employee's we selected
                string whichEmployee = Console.ReadLine();
                return (int.Parse(whichEmployee) - 1);
            }

            return employeeIndex;

        }

        private static void PayEmployee()
        {
            Console.WriteLine("Select one of the employee to pay. Select 1 for the first employee, 2 for the second and so on.");
            // make sure employee list is not empty
            if (employees.Count > 0)
            {
                // capture which employee's we selected
                int employeeIndex = SelectedEmployeeFromList();

                if (employeeIndex >= 0 && employeeIndex < employees.Count)
                {
                    // capture how much the employee worked and pay him
                    double paid = employees[employeeIndex].PayEmployee();
                    Console.WriteLine($"Employee is paid {paid}");
                    Console.WriteLine($"Employee work hour is now {employees[employeeIndex].WorkHours}");
                }
                else
                    Console.WriteLine($"You selected wrong value. Please select between 1 and {employees.Count} number");

            }
        }

        private static void RegisterWorkHours()
        {
            Console.WriteLine("Select one of the employee to add work hours. Select 1 for the first employee, 2 for the second and so on.");

            // make sure employee list is not empty
            if (employees.Count > 0)
            {
                // capture which employee's we selected
                int employeeIndex = SelectedEmployeeFromList();

                if (employeeIndex >= 0 && employeeIndex <= employees.Count) 
                {
                    // capture how much the employee worked and add it to the class
                    Console.WriteLine($"Now enter how many hours the employee {employees[employeeIndex].FirstName} {employees[employeeIndex].LastName} worked: ");
                    string hoursWorked = Console.ReadLine();
                    double hours = int.Parse(hoursWorked);

                    double resultHours = employees[employeeIndex].EmployeeWorkHours(hours);

                    Console.WriteLine($"{employees[employeeIndex].FirstName} {employees[employeeIndex].LastName} has now worked {resultHours} hours in total");
                } else
                    Console.WriteLine($"You selected wrong value. Please select between 1 and {employees.Count} number");


            } else 
            { 
                Console.WriteLine("There is no employee here, register an employee first");
            }

        }

        private static void ShowingEmployeeDetails()
        {
            string firstName;
            string lastName;
            double hourlyRate;
            double workHours;

            //showing list of employees and their details from the list of the employee class
            for (int i = 0; i< employees.Count; i++)
            {
                firstName = employees[i].FirstName;
                lastName = employees[i].LastName;
                hourlyRate = employees[i].HourlyRate;
                workHours = employees[i].WorkHours;
                Console.WriteLine($"Employee {firstName} {lastName} has hourly rate of {hourlyRate} and worked {workHours} hours");
            }


        }

        private static void RegisterEmployee()
        {
            Console.WriteLine("Please enter first name of the employee:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Please enter last name of the employee:");
            string  lastName = Console.ReadLine();
            Console.WriteLine("Please enter the hourly rate of this employee");
            string hourlyrate = Console.ReadLine();
            double hourlyRate = double.Parse(hourlyrate);

            Employee newEmployee = new Employee(firstName, lastName, hourlyRate);
            employees.Add(newEmployee);

            Console.WriteLine("New employee created!");
        }



    }

}
