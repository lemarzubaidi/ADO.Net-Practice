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
        static string connectionstring = "Server=.;Database=ContactsDB;User Id=User;Password=Password;";
        static void AddNewcontact(stContact newContact)
        {
            SqlConnection connection=new SqlConnection(connectionstring);
            string query = @"INSERT INTO Contacts (FirstName,LastName,Email,Phone, Address,CountryID)
                          Values(@FirstName,@LastName,@Email,@Phone,@Address,@CountryID)";

            SqlCommand command=new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", newContact.FirstName);
            command.Parameters.AddWithValue("@LastName",newContact.LastName);
            command.Parameters.AddWithValue("@Email", newContact.Email);
            command.Parameters.AddWithValue("@Phone", newContact.Phone);
            command.Parameters.AddWithValue("@Address", newContact.Address);
            command.Parameters.AddWithValue("@CountryID",newContact.CountryID);
            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    Console.WriteLine("Record inserted successfully.");
                }
                else
                {
                    Console.WriteLine("Record insertion failed");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            
                }
        public struct stContact
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string Email{ get; set; }
            public string Phone { get; set; }
            public int CountryID { get; set; }
        }
        static void Main(string[] args)
        {
            stContact contact = new stContact
            {
                FirstName = "Mohammed",
                LastName = "Abu-Hadhoud",
                Email = "m@example.com",
                Phone = "123456789",
                Address = "123 Main Street",
                CountryID = 1
            };
            AddNewcontact(contact);

        }
    }
}
