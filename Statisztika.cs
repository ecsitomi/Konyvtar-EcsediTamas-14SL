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
        //statisztikai feladatok alább
        public void OtszazOldalas()
        {
            int darab = 0;
            foreach (var book in books)
            {
                if (book.Page_count > 500)
                {
                    darab++;
                }
            }
            Console.WriteLine($"Ötszáz oldalnál hosszabb könyvek száma: {darab}");
        }
        public void VanE1950()
        {
            int darab = 0;
            foreach (var book in Books)
            {
                if (book.Published_year < 1950)
                {
                    darab++;
                }
            }
            if (darab != 0)
            {
                Console.WriteLine("Van 1950-nél régebben kiadott könyv.");
            }
            else
            {
                Console.WriteLine("Nincs 1950-nél régebben kiadott könyv.");
            }
        }
        public void LeghosszabbKonyv()
        {
            Book leghosszabb = Books[0]; //lista első eleme a leghosszabb először mert vele kezdünk
            foreach (var book in Books)
            {
                if (book.Page_count > leghosszabb.Page_count)
                {
                    leghosszabb = book;
                }
            }
            Console.WriteLine("A leghosszabb könyv adatai:");
            Console.WriteLine(leghosszabb.ToString());
        }
        public void LegtobbKonyv()
        {
            Dictionary<string, int> szerzokEsKonyveik = new Dictionary<string, int>();
            foreach (var book in Books)
            {
                if (szerzokEsKonyveik.ContainsKey(book.Author))
                {
                    szerzokEsKonyveik[book.Author]++;
                }
                else
                {
                    szerzokEsKonyveik[book.Author] = 1; //első találatkor kap egyet
                }
            }
            string szerzo = null;
            int konyvek = 0;
            foreach (var adatok in szerzokEsKonyveik) 
            { 
                if (adatok.Value > konyvek)
                {
                    szerzo = adatok.Key;
                    konyvek = adatok.Value;
                }
            }
            Console.WriteLine($"A legtermékenyebb szerző: {szerzo}, akinek van {konyvek} könyve.");
        }
    }
}
