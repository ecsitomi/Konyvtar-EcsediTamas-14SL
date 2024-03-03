using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarAsztaliKonzolos
{
    internal class Statisztika
    {
        private List<Book> books;

        public Statisztika() 
        {
            books = new List<Book>();
        }

        public List<Book> Books 
        { 
            get { return books; } 
            set { books = value; } 
        }
        public static Statisztika AdatbazisBeolvasas(List<Book> adatbazisKonyvek)
        {
            var statisztika = new Statisztika();

            try
            {
                foreach (var book in adatbazisKonyvek)
                {
                    statisztika.Books.Add(book);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba történt az adatbázishoz csatlakozás közben.");
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
            return statisztika;
        }
    }
}
