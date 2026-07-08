using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp23
{
    internal class Program
    {
        static string connectionstring = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;";
        static void Deletecontact(int ContactID)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = @"Delete FROM Contacts
                                      where ContactID=@ContactID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);
            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    Console.WriteLine("Record Delete successfully.");
                }
                else
                {
                    Console.WriteLine("Record deletion failed");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }
     
        static void Main(string[] args)
        {
            Deletecontact(1);

        }
    }
}
