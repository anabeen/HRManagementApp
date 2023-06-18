using System;

public class Employee
{

	public string FirstName { get; set; }
	public string LastName { get; set; }
	public double HourlyRate { get; set; }
	private double WorkHours { get; set; }

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



}
