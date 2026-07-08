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
        static void AddNewcontact(stContact newContact)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = @"INSERT INTO Contacts (FirstName,LastName,Email,Phone, Address,CountryID)
                          Values(@FirstName,@LastName,@Email,@Phone,@Address,@CountryID);SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", newContact.FirstName);
            command.Parameters.AddWithValue("@LastName", newContact.LastName);
            command.Parameters.AddWithValue("@Email", newContact.Email);
            command.Parameters.AddWithValue("@Phone", newContact.Phone);
            command.Parameters.AddWithValue("@Address", newContact.Address);
            command.Parameters.AddWithValue("@CountryID", newContact.CountryID);
            try
            {
                connection.Open();
               object result= command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    Console.WriteLine($"Newly inserted ID: {insertedID}");
                }
                else
                {
                    Console.WriteLine("failed to retrieve the inserted ID");
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
            public string Email { get; set; }
            public string Phone { get; set; }
            public int CountryID { get; set; }
        }
        static void Main(string[] args)
        {
            stContact contact = new stContact
            {
                FirstName = "Lemar",
                LastName = "Zubaidi",
                Email = "l@example.com",
                Phone = "123456789",
                Address = "123 Main Street",
                CountryID = 5
            };
            AddNewcontact(contact);

        }
    }
}
