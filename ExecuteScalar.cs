using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ConsoleApp20
{
    internal class Program
    {
        static string connectingString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;";
        static string GetFirstName(int ContactID)
        {
            string FirstName = "";
            SqlConnection connection = new SqlConnection(connectingString);
            string query = "SELECT FirstName FROM Contacts WHERE ContactID=@ContactID";
            SqlCommand command=new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);
            try
            {
                connection.Open();
                object result= command.ExecuteScalar();
                if(result != null)
                {
                    FirstName=result.ToString();
                }
                else
                {
                    FirstName = " ";
                }
                    connection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: "+ ex.Message);
            }
               return FirstName;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GetFirstName(1));
            Console.ReadKey();
        }
    }
}
