using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp33
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable EmployeesDataTable = new DataTable();
            EmployeesDataTable.Columns.Add("EmployeeID", typeof(int));
            EmployeesDataTable.Columns.Add("EmployeeName", typeof(string));
            EmployeesDataTable.Columns.Add("Country", typeof(string));
            EmployeesDataTable.Columns.Add("Salary", typeof(Double));
            EmployeesDataTable.Columns.Add("Date", typeof(DateTime));

            EmployeesDataTable.Rows.Add(1, "John Doe", "USA", 50000, DateTime.Now);
            EmployeesDataTable.Rows.Add(2, "Jane Smith", "Canada", 60000, DateTime.Now);
            EmployeesDataTable.Rows.Add(3, "Michael Johnson", "UK", 55000, DateTime.Now);
            EmployeesDataTable.Rows.Add(4, "Emily Davis", "Australia", 70000, DateTime.Now);
            EmployeesDataTable.Rows.Add(5, "William Brown", "Germany", 65000, DateTime.Now);

            Console.WriteLine("\nEmployees DataTable:\n");
            foreach (DataRow i in EmployeesDataTable.Rows)
            {
                Console.WriteLine("ID: {0}\t Name: {1}\t Country: {2}\t Salary: {3} \tDate: {4}\t ", i["EmployeeID"], i["EmployeeName"], i["Country"], i["Salary"], i["Date"]);
            }
            int count = 0;
            double totalSalary = 0;
            double averageSalary = 0;
            double maxSalary = 0;
            double minSalary = 0;

            count=EmployeesDataTable.Rows.Count;
            totalSalary = Convert.ToDouble(EmployeesDataTable.Compute("SUM(Salary)", string.Empty));
            averageSalary = Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)", string.Empty));
            maxSalary = Convert.ToDouble(EmployeesDataTable.Compute("MAX(Salary)", string.Empty));
            minSalary = Convert.ToDouble(EmployeesDataTable.Compute("MIN(Salary)", string.Empty));
            
            Console.WriteLine("\nTotal Employees: {0}", count);
            Console.WriteLine("Total Salary: {0}", totalSalary);
            Console.WriteLine("Average Salary: {0}", averageSalary);
            Console.WriteLine("Maximum Salary: {0}", maxSalary);
            Console.WriteLine("Minimum Salary: {0}", minSalary);
        }
    }
}
