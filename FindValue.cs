using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    internal class Program
    {
        static string ConnectionString = "Server=.;Database=contactsDB;User Id=sa;Password=sa123456;";
        static bool FindContactByID(int ContactID,ref stContact ContactInfo)
        {
          bool isFound=false;
            SqlConnection connection=new SqlConnection(ConnectionString);

            string query = "SELECT * FROM Contacts WHERE ContactID=@ContactID";

            SqlCommand command=new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ContactID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read()) { 
                isFound= true;
                ContactInfo.ID=(int)reader["ContactID"];
                    ContactInfo.FirstName=(string)reader["FirstName"];
                    ContactInfo.LastName = (string)reader["LastName"];
                    ContactInfo.Email = (string)reader["Email"];
                    ContactInfo.Phone = (string)reader["Phone"];
                    ContactInfo.Address = (string)reader["Address"];
                    ContactInfo.CountryID = (int)reader["CountryID"];  
                        }
                else
                {
                    isFound= false;
                }
                reader.Close();
                connection.Close();
            }
            catch(Exception ex)
            { 
             Console.WriteLine("Error: "+ex.Message);
            }
           
            return isFound;
        }
        public struct stContact
        {
           public int ID { get; set;}
            public string FirstName { get; set;}
            public string LastName { get; set;}
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public int CountryID{ get; set; }
        }
        static void Main(string[] args)
        {
            stContact stCont=new stContact();
            if (FindContactByID(1, ref stCont))
                {
                Console.WriteLine($"\nContact ID: {stCont.ID}");
                Console.WriteLine($"Name: {stCont.FirstName} {stCont.LastName}");
                Console.WriteLine($"Email: {stCont.Email}");
                Console.WriteLine($"Phone: {stCont.Phone}");
                Console.WriteLine($"Address: {stCont.Address}");
                Console.WriteLine($"Country ID: {stCont.CountryID}");

                 }



        }
    }
}
