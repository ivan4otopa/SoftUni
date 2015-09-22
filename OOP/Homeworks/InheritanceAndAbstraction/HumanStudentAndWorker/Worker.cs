using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HumanStudentAndWorker
{
    class Worker : Human
    {
        public decimal WeekSalary { get; set; }
        public double WorkHoursPerDay { get; set; }
        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }
        public decimal MoneyPerHour()
        {
            decimal moneyPerDay = this.WeekSalary / 5;
            decimal moneyPerHour = moneyPerDay / (decimal)this.WorkHoursPerDay;
            return moneyPerHour;
        }
        public override string ToString()
        {
            return String.Format("Worker: {0}; Week Salary: {1}; Work Hours Per Day: {2}", base.ToString(), this.WeekSalary,
                this.WorkHoursPerDay);
        }
    }
}
