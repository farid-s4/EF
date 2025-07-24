namespace EntityFraemwork;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
internal class Program
    {
        public static void Main(string[] args)
        {
            var connectionString = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build().GetConnectionString("Default");
            using SqlConnection conn = new(connectionString);
            conn.Open();
            while (true)
            {
                int choose = 0;
                Console.WriteLine("Choose an option: ");
                Console.WriteLine("1) View Books: ");
                Console.WriteLine("2) Add a Book: ");
                Console.WriteLine("3) Book count: ");
                Console.WriteLine("4) Enter the author's name to find his books: ");
                Console.WriteLine("5) Delete a book: ");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                    {
                        using (var command = new SqlCommand
                                   ("select * from Books", conn))
                        {
                            SqlDataReader reader = command.ExecuteReader(); 
                            while (reader.Read())
                            {
                                Console.WriteLine($"Id: {reader[0]}, Tittle: {reader[1]}, Author: {reader[2]}, Year: {reader[3]}");
                            }
                        }
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Enter a title: ");
                        string title = Console.ReadLine();
                        Console.WriteLine("Enter an author: ");
                        string author = Console.ReadLine();
                        Console.WriteLine("Enter a year: ");
                        int year = Convert.ToInt32(Console.ReadLine());

                        var insertCmd = new SqlCommand
                            ("insert into Books (Title, Author, YearPublished) values (@Title, @Author, @Year)", conn);
        
                        insertCmd.Parameters.AddWithValue("@Title", title);
                        insertCmd.Parameters.AddWithValue("@Author", author);
                        insertCmd.Parameters.AddWithValue("@Year", year);
                    
                        int rows = insertCmd.ExecuteNonQuery();
                        Console.WriteLine($"{rows} row(s) inserted.");
                        break;
                    }
                    case 3:
                    {
                        var command = new SqlCommand
                            ("select top 1 Id from Books order by Id desc", conn);
                        var reader = command.ExecuteScalar();
                        if (reader != null) Console.WriteLine($" Book count: {reader.ToString()}");
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("Enter a name: ");
                        string name = Console.ReadLine();
                        var command = new SqlCommand("select * from Books where Author = @name",  conn);
                        command.Parameters.AddWithValue("@name", name);
                        
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"Id: {reader[0]}, Tittle: {reader[1]}, Author: {reader[2]}, Year: {reader[3]}");
                        }
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("Enter id for delete book: ");
                        int id =  Convert.ToInt32(Console.ReadLine());
                        var deleteCmd = new SqlCommand("delete from Books where Id = @id", conn);
                        
                        deleteCmd.Parameters.AddWithValue("@id", id);
                        int rows = deleteCmd.ExecuteNonQuery();
                        Console.WriteLine($"{rows} book(s) deleted.");
                        break;
                    }
                }
            }
        }
    }