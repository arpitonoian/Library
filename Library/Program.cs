using System;
using System.Data.SqlClient;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mutqagreq heghinaki anune 'Erich','Ralph', 'Richard'");

            string input = Console.ReadLine();

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog = LibraryDB;Integrated Security=True";
            string sqlExpression = $"SELECT Book.NameBook,Author.ListName,Book.id FROM Book JOIN BookAuthor ON BookAuthor.Book_id = Book.id JOIN Author ON BookAuthor.Author_id = Author.id WHERE ListName='{input}'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Console.WriteLine("{0}", reader.GetName(0));

                    while (reader.Read())
                    {
                        object book = reader.GetValue(0);
                        Console.WriteLine("{0}", book);
                    }
                }
                reader.Close();
            }
        }
    }
}