namespace ProspectInHospitality
{
    using System;

    class ProspectInHospitality
    {
        static void Main()
        {
            uint numberOfBuilders = uint.Parse(Console.ReadLine());
            uint numberOfReceptionists = uint.Parse(Console.ReadLine());
            uint numberOfChambermaids = uint.Parse(Console.ReadLine());
            uint numberOfTechnicians = uint.Parse(Console.ReadLine());
            uint numberOfOtherStaff = uint.Parse(Console.ReadLine());
            decimal nikiSalary = decimal.Parse(Console.ReadLine());
            decimal USACurrencyRate = decimal.Parse(Console.ReadLine());
            decimal salary = decimal.Parse(Console.ReadLine());
            decimal budget = decimal.Parse(Console.ReadLine());
            decimal buildersSalary = numberOfBuilders * 1500.04M;
            decimal receptionistsSalary = numberOfReceptionists * 2102.10M;
            decimal chambermaidsSalary = numberOfChambermaids * 1465.46M;
            decimal techniciansSalary = numberOfTechnicians * 2053.33M;
            decimal otherStaffSalary = numberOfOtherStaff * 3010.98M;
            decimal nikiSalaryInLeva = nikiSalary * USACurrencyRate;
            decimal budgetNeeded =
                buildersSalary +
                receptionistsSalary +
                chambermaidsSalary +
                techniciansSalary +
                otherStaffSalary +
                nikiSalaryInLeva +
                salary;
            decimal moneyLeft = budget - budgetNeeded;

            Console.WriteLine("The amount is: {0:0.00} lv.", budgetNeeded);

            if (moneyLeft >= 0)
            {
                Console.WriteLine("YES \\ Left: {0:0.00} lv.", moneyLeft);    
            }
            else
            {
                Console.WriteLine("NO \\ Need more: {0:0.00} lv.", Math.Abs(moneyLeft));
            }
        }
    }
}
