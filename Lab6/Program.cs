using Microsoft.Data.SqlClient;

namespace Lab6
{
    class Program
    {
        //zadanie 2
        public static void Main()
        {
            string conectionString =
                "Data Source=10.200.2.28;" +
                "Initial Catalog=studenci_71449;" +
                "Integrated Security=True;" +
                "Encrypt=True;" +
                "TrustServerCertificate=True";

            try
            {
                using SqlConnection connection = new
               SqlConnection(conectionString);
                connection.Open();
                Console.WriteLine("Połączono z bazą.");
            }
            catch (Exception exc)
            {
                Console.WriteLine("Wystąpił błąd: " + exc);
            }

            zadanie4();
        }

        public class Student
        {
            public int StudentId { get; set; }
            public string Imie { get; set; } = "";
            public string Nazwisko { get; set; } = "";
            public List<Ocena> Oceny { get; set; } = new();
        }
        public class Ocena
        {
            public int OcenaId { get; set; }
            public double Wartosc { get; set; }
            public string Przedmiot { get; set; } = "";
            public int StudentId { get; set; }
        }

        //zadanie 4
        public static void zadanie4()
        {
            string conectionString =
                "Data Source=10.200.2.28;" +
                "Initial Catalog=studenci_71449;" +
                "Integrated Security=True;" +
                "Encrypt=True;" +
                "TrustServerCertificate=True";

            const string query = "SELECT Student_id, Imie, Nazwisko FROM Student";

            try
            {
                using SqlConnection connection = new SqlConnection(conectionString);
                connection.Open();
                using SqlCommand command = new SqlCommand(query, connection);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int studentId = reader.GetInt32(0);
                    string imie = reader.GetString(1);
                    string nazwisko = reader.GetString(2);
                    Console.WriteLine($"ID: {studentId}, Imię: {imie}, Nazwisko: {nazwisko}");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Wystąpił błąd:" + exc);
            }
        }
    }
}