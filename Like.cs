using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using System.Net.Configuration;

namespace ConsoleApp19
{
    internal class Program
    {
        static string connectionString = "Server=.;Database=ContactsDB;User Id=your;Password=your";
        static void SearchContactsStartsWith(string StartWith)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * From Contacts WHERE FirstName LIKE '' +@StartWith+'%'";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@StartWith", StartWith);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstname = (string)reader["FirstName"];
                    string lastname = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];
                    Console.WriteLine($"Conatct ID: {contactID}");
                    Console.WriteLine($"Name: {firstname}{lastname}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"Country ID: {countryID}");
                    Console.WriteLine();
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex) { 
            Console.WriteLine("Error: "+ex.Message);
            }
            }
        static void SearchContactsEndsWith(string EndWith) { 
        SqlConnection connection=new SqlConnection(connectionString);
            string query = "SELECT * FROM Contacts WHERE FirstName LIKE '%'+@EndWith+''";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EndWith", EndWith);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstname = (string)reader["FirstName"];
                    string lastname = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];
                    Console.WriteLine($"Conatct ID: {contactID}");
                    Console.WriteLine($"Name: {firstname}{lastname}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"Country ID: {countryID}");
                    Console.WriteLine();
                }
                reader.Close ();
                connection.Close();
            }
            catch(Exception ex) {
            Console.WriteLine("Error: "+ex.Message);  
            }
        }
        static void SearchContactsContains(string Contains)
        {
            SqlConnection connection= new SqlConnection(connectionString);
            string query = "SELECT * FROM Contacts WHERE FirstName LIKE '%'+@Contains+'%'";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Contains", Contains);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstname = (string)reader["FirstName"];
                    string lastname = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];
                    Console.WriteLine($"Conatct ID: {contactID}");
                    Console.WriteLine($"Name: {firstname}{lastname}");
                    Console.WriteLine($"Email: {email}");
                    Console.WriteLine($"Phone: {phone}");
                    Console.WriteLine($"Address: {address}");
                    Console.WriteLine($"Country ID: {countryID}");
                    Console.WriteLine();
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
            
            static void Main(string[] args)
        {
            Console.WriteLine("----------Contacts starts with'j'");
            SearchContactsStartsWith("j");

            Console.WriteLine("----------Contacts Ends with'ne'");
            SearchContactsEndsWith("ne");

            Console.WriteLine("----------Contacts Contains with 'ae'");
            SearchContactsContains("ae");
        }
    }
}
