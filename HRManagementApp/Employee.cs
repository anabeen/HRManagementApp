using System;

public class Employee
{

	public string FirstName { get; set; }
    public string LastName { get; set; }
    public double HourlyRate { get; set; }
    public double WorkHours { get; set; }
    public double bonus { get; set; }

    public Employee(string first, string last, double rate)
	{
        FirstName = first;
        LastName = last;
        HourlyRate = rate;
	}

	public double EmployeeWorkHours(double workHrs) 
	{
        WorkHours += workHrs;
		return WorkHours;
    }

    public double PayEmployee()
    {
        double pay = (HourlyRate * WorkHours) + bonus;

        // would be called after employee is paid. 
        WorkHours = 0;
        bonus = 0;

        return pay;
    }



}
