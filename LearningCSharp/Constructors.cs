using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace LearningCSharp
{
    public class Constructors
    {
        private ITestOutputHelper _output;

        public Constructors(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void HiringSomeone()
        {
            var employee = new Employee("July", "TV", 120000M);
            Assert.Equal("July", employee.Name);
            //employee.Name = "Jocelyn" Cant change name or value of private property
            var tempSue = new Employee("Sue", "HR");
            Assert.Equal("Sue", tempSue.Name);
            Assert.Equal(0, tempSue.Salary);

            var retiree = new Retiree("Ben", "Smith", 100000);
            //Can still use Person as a data type, but will only see Name and department, not info from other classes
            var folks = new List<Person> { employee, tempSue, retiree };

            GiveThemARaise(employee, 100);

            //GiveThemARaise(retiree, 10); Won't work since retiree doesn't implement the interface

            foreach(var p in folks)
            {
                _output.WriteLine(p.GetInfo());
                _output.WriteLine(p.GetCompensation());

            }
        }

        public void GiveThemARaise(ICanBeGivenARaise person, decimal amount)
        {
            person.GiveRaise(amount);
        }
    }

    public interface ICanBeGivenARaise
    {
        void GiveRaise(decimal amount);
    }
    public abstract class Person
    {
        public Person(string name, string department)
        {
            Name = name;
            Department = department;
        }

        public string Name { get; protected set; }
        public string Department { get; protected set; }

        public virtual string GetInfo()
        {
            return $"{Name} works in {Department}";
        }

        public abstract string GetCompensation();
        

 
    }

    public class Employee : Person, ICanBeGivenARaise//Since it's private it can only be changed by other code in the class
    {// Extend Person so you don't need those two properties in teh constructor
        public Employee(string name, string department, decimal salary): base(name, department)
        {
            
            Salary = salary;
        }
        //THis means the other constructor that matches this one, Allows us to not supply a salary
        public Employee(string name, string department) : this(name, department, 0) { }

        public decimal Salary { get; private set; }

        public override string GetInfo()
        {
            return base.GetInfo() + $"Is an employee with the salary {Salary}";
        }

        public override string GetCompensation()
        {
            return $"As an emplpoyee, {Name} gets a salary of {Salary}";
        }

        public void GiveRaise(decimal amount)
        {
            throw new NotImplementedException();
        }
    }

    public class Retiree : Person 
    {
        public Retiree(string name, string department, decimal pension): base(name, department)
        {
            Pension = pension;
        }
        public decimal Pension { get; private set; }

        public override string GetCompensation()
        {
            return $"As an emplpoyee, {Name} gets a pension of {Pension}";
        }
    }

}
