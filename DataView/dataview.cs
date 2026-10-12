using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp40
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
            DataView EmployeesDataView = EmployeesDataTable.DefaultView;

            Console.WriteLine("\nEmployees DataView:\n");
            for (int i=0;i<EmployeesDataView.Count; i++)
            {
                Console.WriteLine("ID: {0}\t Name: {1}\t Country: {2}\t Salary: {3} \tDate: {4}\t ", EmployeesDataView[i][0], EmployeesDataView[i][1], EmployeesDataView[i][2], EmployeesDataView[i][3], EmployeesDataView[i][4]);
            }

            //Filter
            EmployeesDataView.RowFilter = "Country='USA' or Country='Canada'";

            Console.WriteLine("\nEmployee List from data view after filtering \"USA or Canada\":\n");
            for (int i = 0; i < EmployeesDataView.Count; i++)
            {
                Console.WriteLine("ID: {0}\t Name: {1}\t Country: {2}\t Salary: {3} \tDate: {4}\t ", EmployeesDataView[i][0], EmployeesDataView[i][1], EmployeesDataView[i][2], EmployeesDataView[i][3], EmployeesDataView[i][4]);
            }
            //sort
            EmployeesDataView.Sort = "Salary DESC";
            Console.WriteLine("\nEmployee List from data view after Sorting:\n");
            for (int i = 0; i < EmployeesDataView.Count; i++)
            {
                Console.WriteLine("ID: {0}\t Name: {1}\t Country: {2}\t Salary: {3} \tDate: {4}\t ", EmployeesDataView[i][0], EmployeesDataView[i][1], EmployeesDataView[i][2], EmployeesDataView[i][3], EmployeesDataView[i][4]);
            }
        }
    }
}
