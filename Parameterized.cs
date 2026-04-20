using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using System.Net.Configuration;

public class Program
{
    static string connectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;";
    static void PrintAllContactsWithFirstName(string FirstName)
    {
        SqlConnection connection=new SqlConnection(connectionString);
        string query = "SELECT * FROM Contacts WHERE FirstName=@FirstName";
        SqlCommand cmd=new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@FirstName",FirstName);
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
            Console.WriteLine("Error: "+ex.Message);
        }
    }
    static void PrintAllContactsWithFirstNameAndCountry(string FirstName,int CountryID)
    {
        SqlConnection connection = new SqlConnection(connectionString);
        string query = "SELECT * FROM Contacts WHERE FirstName = @FirstName and CountryID = @CountryID";
        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@FirstName", FirstName);
        cmd.Parameters.AddWithValue("@CountryID",CountryID);
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
    public static void Main()
    {
       // PrintAllContactsWithFirstName("Jane");
        PrintAllContactsWithFirstNameAndCountry("jana",1);
        Console.ReadKey();
    }
}

