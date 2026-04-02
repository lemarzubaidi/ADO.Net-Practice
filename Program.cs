using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;

    public  class Program
    {
          static string connectionstring = "Server=.;Database=ContactsDB;User Id=your_USER;Password=your_Password";
    static void PrintAllContacts()
    {
        SqlConnection connection=new SqlConnection(connectionstring);
        string query = "SELECT * FROM Contacts";
        SqlCommand command = new SqlCommand(query, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while ((reader.Read()))
            {
                int contactId = (int)reader["ContactID"];
                string firstname = (string)reader["FirstName"];
                string lastname = (string)reader["LastName"];
                string email = (string)reader["Email"];
                string phone = (string)reader["Phone"];
                string address = (string)reader["Address"];
                int countryID = (int)reader["CountryID"];
                Console.WriteLine($"Conatct ID: {contactId}");
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
        catch(Exception ex)
        {
            Console.WriteLine("Error:"+ex.Message);
        }
    }
         public static void Main()
             {
        PrintAllContacts();
        Console.ReadKey();
              }
    }

