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
                using SqlConnection connection = new SqlConnection(conectionString);
                connection.Open();
                Console.WriteLine("Połączono z bazą.");

                Console.WriteLine("Lista studentów: ");
                zadanie_4(connection);

                Console.WriteLine("Srudent o ID 1: ");
                zadanie_5(connection, 1);

                Console.WriteLine("Dodano studenta: ");
                zadanie_7(connection, new Student { Imie = "Yuliia", Nazwisko = "Hula"});

                Console.WriteLine("Lista studentów z ocenami:");
                var studenci = zadanie_6(connection);
                foreach (var s in studenci)
                {
                    Console.WriteLine($"Student: {s.Imie} {s.Nazwisko} (ID: {s.StudentId})");
                    if (s.Oceny.Count > 0)
                    {
                        foreach (var o in s.Oceny)
                        {
                            Console.WriteLine($"  - {o.Przedmiot}: {o.Wartosc}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("  - Brak ocen");
                    }
                }

                Console.WriteLine("Dodawanie oceny: ");
                zadanie_8(connection, new Ocena { Wartosc = 4.5, Przedmiot = "Programowanie", StudentId = 1 });

                Console.WriteLine("Usuwanie geografii: ");
                zadanie_9(connection);

                Console.WriteLine("Aktualizacja oceny: ");
                zadanie_10(connection, 1, 5.0);

            }
            catch (Exception exc)
            {
                Console.WriteLine("Wystąpił błąd: " + exc);
            }

            
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
        public static void zadanie_4 (SqlConnection connection)
        {
            const string query = "SELECT student_id, imie, nazwisko FROM Student";
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["student_id"]}, Imię: {reader["imie"]}, Nazwisko: {reader["nazwisko"]}");
            }
        }

        //zadanie 5
        public static void zadanie_5 (SqlConnection connection, int id)
        {
            string query = "SELECT imie, nazwisko FROM student WHERE student_id = @id";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            using SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine($"Znaleziono: {reader["imie"]} {reader["nazwisko"]}");
            }
            else
            {
                Console.WriteLine("Nie znaleziono studenta o podanym ID.");
            }
        }

        //zadanie 6
        public static List<Student> zadanie_6 (SqlConnection connection)
        {
            var studenci = new Dictionary<int, Student>();
            string query = @"
                SELECT s.student_id, s.imie, s.nazwisko, o.ocena_id, o.wartosc, o.przedmiot 
                FROM student s 
                LEFT JOIN ocena o ON s.student_id = o.student_id";

            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int sId = (int)reader["student_id"];

                if (!studenci.ContainsKey(sId))
                {
                    studenci[sId] = new Student
                    {
                        StudentId = sId,
                        Imie = (string)reader["imie"],
                        Nazwisko = (string)reader["nazwisko"]
                    };
                }

                if (reader["ocena_id"] != DBNull.Value)
                {
                    studenci[sId].Oceny.Add(new Ocena
                    {
                        OcenaId = (int)reader["ocena_id"],
                        Wartosc = (double)reader["wartosc"],
                        Przedmiot = (string)reader["przedmiot"],
                        StudentId = sId
                    });
                }
            }

            return new List<Student>(studenci.Values);
        }

        //zadanie 7
        public static void zadanie_7 (SqlConnection connection, Student student)
        {
            string query = "INSERT INTO student (imie, nazwisko) VALUES (@imie, @nazwisko)";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@imie", student.Imie);
            command.Parameters.AddWithValue("@nazwisko", student.Nazwisko);

            command.ExecuteNonQuery();
            Console.WriteLine("Dodano nowego studenta.");
        }

        //zadanie 9
        public static void zadanie_8 (SqlConnection connection, Ocena ocena)
        {
            if (ocena.Wartosc < 2.0 || ocena.Wartosc > 5.0)
            {
                Console.WriteLine($"Błąd: Wartość {ocena.Wartosc} jest poza zakresem (2.0 - 5.0).");
                return;
            }
            else if (ocena.Wartosc % 0.5 != 0)
            {
                Console.WriteLine($"Błąd: Wartość {ocena.Wartosc} jest niepoprawna (dozwolone tylko .0 lub .5).");
                return;
            }
            else if (ocena.Wartosc == 2.5)
            {
                Console.WriteLine("Błąd: Ocena 2.5 nie istnieje w systemie.");
                return;
            }

            try
            {
                string query = "INSERT INTO ocena (wartosc, przedmiot, student_id) VALUES (@val, @sub, @sid)";

                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@val", ocena.Wartosc);
                command.Parameters.AddWithValue("@sub", ocena.Przedmiot);
                command.Parameters.AddWithValue("@sid", ocena.StudentId);

                int rows = command.ExecuteNonQuery();

                if (rows > 0)
                {
                    Console.WriteLine($"Sukces: Dodano ocenę {ocena.Wartosc} z przedmiotu {ocena.Przedmiot}.");
                }
                else
                {
                    Console.WriteLine("Ostrzeżenie: Nie dodano rekordu (może błędne ID studenta?).");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Błąd bazy danych: {ex.Message}");
            }
        }

        
        public static void zadanie_9 (SqlConnection connection)
        {
            string query = "DELETE FROM ocena WHERE przedmiot = 'Geografia'";
            using SqlCommand command = new SqlCommand(query, connection);
            int rows = command.ExecuteNonQuery();
            Console.WriteLine($"Usunięto oceny z przedmiotu Geografia. Liczba usuniętych wierszy: {rows}");
        }

        // zadanie 10
        public static void zadanie_10 (SqlConnection connection, int ocenaId, double nowaWartosc)
        {
            if (nowaWartosc < 2.0 || nowaWartosc > 5.0)
            {
                Console.WriteLine($"Błąd aktualizacji: Wartość {nowaWartosc} poza zakresem.");
                return;
            }
            else if (nowaWartosc % 0.5 != 0)
            {
                Console.WriteLine($"Błąd aktualizacji: Wartość {nowaWartosc} musi kończyć się na .0 lub .5.");
                return;
            }
            else if (nowaWartosc == 2.5)
            {
                Console.WriteLine("Błąd aktualizacji: System nie obsługuje oceny 2.5.");
                return;
            }

            try
            {
                string query = "UPDATE ocena SET wartosc = @nowaWartosc WHERE ocena_id = @id";

                using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nowaWartosc", nowaWartosc);
                command.Parameters.AddWithValue("@id", ocenaId);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"Sukces: Ocena o ID {ocenaId} została zmieniona na {nowaWartosc}.");
                }
                else
                {
                    Console.WriteLine($"Błąd: Nie znaleziono w bazie oceny o ID {ocenaId}.");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Błąd bazy danych podczas aktualizacji: {ex.Message}");
            }
        }
    }
}