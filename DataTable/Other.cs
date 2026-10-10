using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp39
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable EmployeesDataTable = new DataTable();
            /*  EmployeesDataTable.Columns.Add("EmployeeID", typeof(int));
              EmployeesDataTable.Columns.Add("EmployeeName", typeof(string));
              EmployeesDataTable.Columns.Add("Country", typeof(string));
              EmployeesDataTable.Columns.Add("Salary", typeof(Double));
              EmployeesDataTable.Columns.Add("Date", typeof(DateTime));*/
            // anathor way to add columns in datatable
            DataColumn dtColumn;
            dtColumn = new DataColumn();
            dtColumn.DataType=typeof(int);
            dtColumn.ColumnName = "EmployeeID";
            dtColumn.AutoIncrement = true;
            dtColumn.AutoIncrementSeed = 1;
            dtColumn.AutoIncrementStep = 1;

            dtColumn.Caption = "ID";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = true;
            EmployeesDataTable.Columns.Add(dtColumn);
            //
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "EmployeeName";
       
            dtColumn.Caption = "Name";
            dtColumn.ReadOnly = false;
            EmployeesDataTable.Columns.Add(dtColumn);
            //
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(string);
            dtColumn.ColumnName = "Country";
            dtColumn.Caption = "Countryy";
            dtColumn.ReadOnly = false;
            EmployeesDataTable.Columns.Add(dtColumn);
            //
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(Double);
            dtColumn.ColumnName = "Salary";
            dtColumn.AutoIncrement = false;
            dtColumn.Caption = "Salary";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            EmployeesDataTable.Columns.Add(dtColumn);
            //
            dtColumn = new DataColumn();
            dtColumn.DataType = typeof(DateTime);
            dtColumn.ColumnName = "Date";
            
            dtColumn.Caption = "Date";
            dtColumn.ReadOnly = false;
            
            EmployeesDataTable.Columns.Add(dtColumn);
            //
            DataColumn[] primaryKey = new DataColumn[1];
            primaryKey[0] = EmployeesDataTable.Columns["EmployeeID"];
            EmployeesDataTable.PrimaryKey = primaryKey;
            EmployeesDataTable.Rows.Add(null, "John Doe", "USA", 50000, DateTime.Now);
            EmployeesDataTable.Rows.Add(null, "Jane Smith", "Canada", 60000, DateTime.Now);
            EmployeesDataTable.Rows.Add(null, "Michael Johnson", "UK", 55000, DateTime.Now);
            EmployeesDataTable.Rows.Add(null, "Emily Davis", "Australia", 70000, DateTime.Now);
            EmployeesDataTable.Rows.Add(null, "William Brown", "Germany", 65000, DateTime.Now);

            Console.WriteLine("\nEmployees DataTable:\n");
            foreach (DataRow i in EmployeesDataTable.Rows)
            {
                Console.WriteLine("ID: {0}\t Name: {1}\t Country: {2}\t Salary: {3} \tDate: {4}\t ", i["EmployeeID"], i["EmployeeName"], i["Country"], i["Salary"], i["Date"]);
            }
            //
        }
    }
}
