using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleApp35
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
            EmployeesDataTable.DefaultView.Sort = "EmployeeID DESC";
            EmployeesDataTable = EmployeesDataTable.DefaultView.ToTable();
            Console.WriteLine("\n\n Employees List Sorted by EmployeeID in Descending Order:\n");
            foreach (DataRow i in EmployeesDataTable.Rows)
            {
                Console.WriteLine("ID: {0}\t Name: {1}\t Country: {2}\t Salary: {3} \tDate: {4}\t ", i["EmployeeID"], i["EmployeeName"], i["Country"], i["Salary"], i["Date"]);

            }
            //
            EmployeesDataTable.DefaultView.Sort = "EmployeeName ASC";
            EmployeesDataTable = EmployeesDataTable.DefaultView.ToTable();
            Console.WriteLine("\n\n Employees List Sorted by EmployeeName in ascending Order:\n");
            foreach (DataRow i in EmployeesDataTable.Rows)
            {
                Console.WriteLine("ID: {0}\t Name: {1}\t Country: {2}\t Salary: {3} \tDate: {4}\t ", i["EmployeeID"], i["EmployeeName"], i["Country"], i["Salary"], i["Date"]);

            }
            //

        }
    }
}
