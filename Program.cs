using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonyvtarAsztaliKonzolos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = Beolvasas("books.sql");

            Statisztika statisztika = Statisztika.AdatbazisBeolvasas(books);
            statisztika.OtszazOldalas();
            statisztika.VanE1950();
            statisztika.LeghosszabbKonyv();
            statisztika.LegtobbKonyv();
        }
        static List<Book> Beolvasas(string fajl) //sql beolvasás
        {
            List<Book> books = new List<Book>();
            using (StreamReader sr = new StreamReader(fajl))
            {
                string sor;
                while ((sor = sr.ReadLine()) != null)
                {
                    string[] reszek = sor.Split(';');
                    string author = reszek[0];
                    int id = int.Parse(reszek[1]);
                    string title = reszek[2];
                    int publishedYear = int.Parse(reszek[3]);
                    int pageCount = int.Parse(reszek[4]);

                    books.Add(new Book(author, id, pageCount, publishedYear, title));
                }
            }
            return books;
        }

    }
}
