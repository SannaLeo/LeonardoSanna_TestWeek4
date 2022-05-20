using LeonardoSanna_TestWeek4.Core.BusinessLayer;
using LeonardoSanna_TestWeek4.Core.Entities;
using LeonardoSanna_TestWeek4.RepositoryADOEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeonardoSanna_TestWeek4Presentation
{
    public class UI
    {
        

        //static string sqlConnString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestioneSpese;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static readonly IBusinessLayer bl = new BusinessLayer(new RepositoryCategoriaEF(), new RepositorySpeseEF());
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
                Console.WriteLine("7. Categoria");
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
                    case 7:
                        Console.Clear();
                        InserisciCategoria();
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
            int id;
            Console.WriteLine("Inserisci il codice della spesa da approvare");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Riprova");
            }
            bl.ApprovaSpesa(id);
        }

        private static void CancellaSpesa()
        {
            int id;
            Console.WriteLine("Inserisci il codice della spesa da eliminare");
            while(!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Riprova");
            }
            bl.EliminaSpesa(id);
        }

        private static void InserisciSpesa()
        {
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

            Spesa nuovaSpesa = new Spesa();
            nuovaSpesa.Descrizione = descrizione;
            nuovaSpesa.Data = data;
            nuovaSpesa.Utente = utente;
            nuovaSpesa.Approvato = approvato;
            nuovaSpesa.CategoriaId = categoria;
            //nuovaSpesa.Categoria = bl.GetCategoriaById(categoria);
            nuovaSpesa.Importo = decimal.Parse(importo.ToString());

            if (bl.AggiungiSpesa(nuovaSpesa))
            {
                Console.WriteLine("Spesa aggiunta correttamente!");
            }
            else
            {
                Console.WriteLine("Spesa non aggiunta!");
            }
        }



        private static void InserisciCategoria()
        {
            string descrizione;
            int categoria;
            

            Console.WriteLine("Inserisci il nome della categoria");
            do
            {
                descrizione = Console.ReadLine();
            } while (string.IsNullOrEmpty(descrizione));

           
            

            Categoria nuovaSpesa = new Categoria();
            nuovaSpesa.NomeCategoria = descrizione;
            

            if (bl.AggiungiCategoria(nuovaSpesa))
            {
                Console.WriteLine("Spesa aggiunta correttamente!");
            }
            else
            {
                Console.WriteLine("Spesa non aggiunta!");
            }
        }

        
        private static void StampaSpeseApprovate()
        {
            List<Spesa> speseApprovate = bl.GetAllSpeseApprovate();
            foreach (Spesa spesa in speseApprovate)
            {
                spesa.Categoria = bl.GetCategoriaById(spesa.CategoriaId);
                Console.WriteLine(spesa);
            }
        }

        private static void StampaSpeseDiUnUtente()
        {
            string utente;
            do
            {
                Console.WriteLine("Inserisci il nome dell'utente");
                utente = Console.ReadLine();
            }while(string.IsNullOrEmpty(utente));
            List<Spesa> speseApprovate = bl.GetAllSpeseByUtente(utente);
            foreach (Spesa spesa in speseApprovate)
            {
                Console.WriteLine(spesa);
            }
        }

        private static void StampaTotaliSpesePerCategoria()
        {
            var lista = bl.GetAllTotaliForEachCategoria();
            foreach (var item in lista)
            {
                ;
            }
        }
    }
}

