using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeonardoSanna_TestWeek4.Demo
{
    public class UI
    {
        static string sqlConnString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestioneSpese;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static void Menu()
        {
            int scelta = 1;
            while (scelta != 0)
            {
                Console.WriteLine("Scegli tra le seguenti opzioni");
                Console.WriteLine("1. Inserire una nuova spesa");
                Console.WriteLine("2. Approva una spesa esistente");
                Console.WriteLine("3. Cancella una spesa");
                Console.WriteLine("4. Mostra le spese approvate");
                Console.WriteLine("5. Mostra le spese di un utente");
                Console.WriteLine("6. Mostra il totale delle spese per ogni categoria");
                Console.WriteLine("0. Esci");
                while (!int.TryParse(Console.ReadLine(), out scelta))
                {
                    Console.WriteLine("Errore, riprova");
                }

                switch (scelta)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Uscita in corso...");
                        break;
                    case 1:
                        Console.Clear();
                        InserisciSpesa();
                        break;
                    case 2:
                        Console.Clear();
                        ApprovaSpesa();
                        break;
                    case 3:
                        Console.Clear();
                        CancellaSpesa();
                        break;
                    case 4:
                        Console.Clear();
                        StampaSpeseApprovate();
                        break;
                    case 5:
                        Console.Clear();
                        StampaSpeseDiUnUtente();
                        break;
                    case 6:
                        Console.Clear();
                        StampaTotaliSpesePerCategoria();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Scelta non consentita, riprova");
                        break;
                }
            }
        }

        private static void ApprovaSpesa()
        {
            DataSet SpeseDS = new DataSet();
            using SqlConnection conn = new SqlConnection(sqlConnString);
            int id;
            StampaTicketsDM();
            Console.WriteLine("______________________________________________________________________________________________________________________");

            Console.WriteLine("Inserisci l'id della spesa da approvare, scrivi annulla per tornare indietro");
            string ids = Console.ReadLine();

            if (ids.ToLower() == "annulla") { return; }

            while (!int.TryParse(ids, out id))
            {
                Console.WriteLine("Riprova");
                ids = Console.ReadLine();
                if (ids.ToLower() == "annulla") { return; }
            }

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    SqlDataAdapter adapter = InizializzaAdapter(conn);
                    adapter.SelectCommand = new SqlCommand("select * from Spese", conn);
                    adapter.Fill(SpeseDS, "SpesaDT");
                    conn.Close();

                    DataRow riga = SpeseDS.Tables["SpesaDT"].Rows.Find(id);
                    if (riga != null)
                    {
                        riga["Approvato"] = true;
                    }

                    Console.Clear();
                    adapter.Update(SpeseDS, "SpesaDT");
                    Console.WriteLine("Aggiornato!");

                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.LineNumber);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private static void CancellaSpesa()
        {
            DataSet TicketingDS = new DataSet();
            using SqlConnection conn = new SqlConnection(sqlConnString);
            int id;
            StampaTicketsDM();
            Console.WriteLine("______________________________________________________________________________________________________________________");

            Console.WriteLine("Inserisci l'id della spesa da eliminare, scrivi annulla per tornare indietro");
            string ids = Console.ReadLine();

            if (ids.ToLower() == "annulla") { return; }

            while (!int.TryParse(ids, out id))
            {
                Console.WriteLine("Riprova");
                ids = Console.ReadLine();
                if (ids.ToLower() == "annulla") { return; }
            }

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    SqlDataAdapter adapter = InizializzaAdapter(conn);
                    adapter.SelectCommand = new SqlCommand("select * from Spese", conn);
                    adapter.Fill(TicketingDS, "TicketDT");
                    conn.Close();

                    DataRow riga = TicketingDS.Tables["TicketDT"].Rows.Find(id);
                    if (riga != null)
                    {
                        riga.Delete();
                    }

                    Console.Clear();
                    adapter.Update(TicketingDS, "TicketDT");
                    Console.WriteLine("Eliminata!");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.LineNumber);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private static void InserisciSpesa()
        {
            DataSet SpeseDS = new DataSet();
            using SqlConnection conn = new SqlConnection(sqlConnString);
            string descrizione, utente;
            int categoria;
            double importo;
            bool approvato;
            DateTime data;

            Console.WriteLine("Inserisci la descrizone della spesa");
            do
            {
                descrizione = Console.ReadLine();
            } while (string.IsNullOrEmpty(descrizione));

            Console.WriteLine("Inserisci la categoria della spesa");
            while (!int.TryParse(Console.ReadLine(), out categoria))
            {
                Console.WriteLine("Riprova");
            }
            Console.WriteLine("Inserisci la data della spesa");
            while (!DateTime.TryParse(Console.ReadLine(), out data))
            {
                Console.WriteLine("Riprova");
            }
            Console.WriteLine("Inserisci l'utente");
            do
            {
                utente = Console.ReadLine();
            } while (string.IsNullOrEmpty(utente));
            Console.WriteLine("Inserisci l'importo della spesa");
            while (!double.TryParse(Console.ReadLine(), out importo))
            {
                Console.WriteLine("Riprova");
            }
            Console.WriteLine("Inserisci true se la spesa è approvata, false altrimenti");
            while (!bool.TryParse(Console.ReadLine(), out approvato))
            {
                Console.WriteLine("Riprova");
            }

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    SqlDataAdapter adapter = InizializzaAdapter(conn);
                    adapter.SelectCommand = new SqlCommand("select * from Spese", conn);
                    adapter.Fill(SpeseDS, "SpeseDT");
                    conn.Close();

                    DataRow nuovaR = SpeseDS.Tables["SpeseDT"].NewRow();
                    nuovaR["Descrizione"] = descrizione;
                    nuovaR["Data"] = data;
                    nuovaR["Utente"] = utente;
                    nuovaR["Approvato"] = approvato;
                    nuovaR["CategoriaId"] = categoria;
                    nuovaR["Importo"] = importo;

                    SpeseDS.Tables["SpeseDT"].Rows.Add(nuovaR);

                    adapter.Update(SpeseDS, "SpeseDT");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.LineNumber);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private static void StampaTicketsDM()
        {
            DataSet TicketingDS = new DataSet();
            using SqlConnection conn = new SqlConnection(sqlConnString);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    SqlDataAdapter adapter = InizializzaAdapter(conn);
                    adapter.SelectCommand = new SqlCommand("Select* from Spese", conn);
                    adapter.Fill(TicketingDS, "TicketDS");
                    conn.Close();
                    if (TicketingDS.Tables["TicketDS"].Rows.Count == 0)
                    {
                        Console.WriteLine("Nessuna spesa...");
                        return;
                    }
                    foreach (DataRow row in TicketingDS.Tables["TicketDS"].Rows)
                    {
                        Console.WriteLine($"Id: {row["Id"]}\t||Desc: {row["Descrizione"]}");
                        Console.WriteLine("______________________________________________________________________________________________________________________");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
            }
        }

        private static void StampaSpeseApprovate()
        {
            DataSet TicketingDS = new DataSet();
            using SqlConnection conn = new SqlConnection(sqlConnString);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    SqlDataAdapter adapter = InizializzaAdapter(conn);
                    adapter.SelectCommand = new SqlCommand("Select* from Spese where Approvato=1", conn);
                    adapter.Fill(TicketingDS, "TicketDS");
                    conn.Close();
                    if (TicketingDS.Tables["TicketDS"].Rows.Count == 0)
                    {
                        Console.WriteLine("Nessuna spesa...");
                        return;
                    }
                    foreach (DataRow row in TicketingDS.Tables["TicketDS"].Rows)
                    {
                        Console.WriteLine($"Id: {row["Id"]}\t||Desc: {row["Descrizione"]}");
                        Console.WriteLine("______________________________________________________________________________________________________________________");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
            }
        }

        private static void StampaSpeseDiUnUtente()
        {
            string utente;
            DataSet TicketingDS = new DataSet();
            using SqlConnection conn = new SqlConnection(sqlConnString);
            do
            {
                Console.WriteLine("Inserisci il nome dell'utente");
                utente = Console.ReadLine();
            }while (string.IsNullOrEmpty(utente));
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    SqlDataAdapter adapter = InizializzaAdapter(conn);
                    adapter.SelectCommand = new SqlCommand($"Select* from Spese where Utente='{utente}'", conn);
                    adapter.Fill(TicketingDS, "TicketDS");
                    conn.Close();
                    if (TicketingDS.Tables["TicketDS"].Rows.Count == 0)
                    {
                        Console.WriteLine("Nessuna spesa...");
                        return;
                    }
                    foreach (DataRow row in TicketingDS.Tables["TicketDS"].Rows)
                    {
                        Console.WriteLine($"Id: {row["Id"]}\t||Desc: {row["Descrizione"]}");
                        Console.WriteLine("______________________________________________________________________________________________________________________");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
            }
        }

        private static void StampaTotaliSpesePerCategoria()
        {
            string utente;
            DataSet TicketingDS = new DataSet();
            using SqlConnection conn = new SqlConnection(sqlConnString);
           
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    SqlDataAdapter adapter = InizializzaAdapter(conn);
                    adapter.SelectCommand = new SqlCommand("Select(select Categoria  from Categoria where Id = CategoriaId) as Categoria, Sum(Importo) as Totale from Spese group by CategoriaId", conn);
                    adapter.Fill(TicketingDS, "TicketDS");
                    conn.Close();
                    if (TicketingDS.Tables["TicketDS"].Rows.Count == 0)
                    {
                        Console.WriteLine("Nessuna spesa...");
                        return;
                    }
                    foreach (DataRow row in TicketingDS.Tables["TicketDS"].Rows)
                    {
                        Console.WriteLine($"Id: {row["Categoria"]}\t||Desc: {row["Totale"]}");
                        Console.WriteLine("______________________________________________________________________________________________________________________");
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.LineNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                Console.WriteLine(ex.Message);
            }
        }

        private static SqlDataAdapter InizializzaAdapter(SqlConnection conn)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            adapter.InsertCommand = GenerateInsertComm(conn);

            adapter.UpdateCommand = GenerateUpdateComm(conn);

            adapter.DeleteCommand = GenerateDeleteComm(conn);

            return adapter;
        }

        private static SqlCommand GenerateDeleteComm(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "delete Spese  where Id=@id";
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "Id"));

            return cmd;
        }

        private static SqlCommand GenerateUpdateComm(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update Spese set Descrizione=@desc, Data=@data, Utente=@utente, Approvato=@stato, CategoriaId=@categoria, Importo=@importo where Id=@id";
            cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "Id"));
            cmd.Parameters.Add(new SqlParameter("@desc", SqlDbType.VarChar, 500, "Descrizione"));
            cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.Date, 0, "Data"));
            cmd.Parameters.Add(new SqlParameter("@utente", SqlDbType.VarChar, 30, "Utente"));
            cmd.Parameters.Add(new SqlParameter("@stato", SqlDbType.Bit, 10, "Approvato"));
            cmd.Parameters.Add(new SqlParameter("@importo", SqlDbType.Decimal, 0, "Importo"));
            cmd.Parameters.Add(new SqlParameter("@categoria", SqlDbType.Int, 10, "CategoriaId"));

            return cmd;
        }

        private static SqlCommand GenerateInsertComm(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into Spese values(@data, @categoria, @desc, @utente, @importo, @stato)";
            cmd.Parameters.Add(new SqlParameter("@desc", SqlDbType.VarChar, 500, "Descrizione"));
            cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.Date, 0, "Data"));
            cmd.Parameters.Add(new SqlParameter("@utente", SqlDbType.VarChar, 100, "Utente"));
            cmd.Parameters.Add(new SqlParameter("@categoria", SqlDbType.Int, 30, "CategoriaId"));
            cmd.Parameters.Add(new SqlParameter("@importo", SqlDbType.Decimal, 30, "Importo"));
            cmd.Parameters.Add(new SqlParameter("@stato", SqlDbType.Bit, 10, "Approvato"));

            return cmd;
        }
    }
}

