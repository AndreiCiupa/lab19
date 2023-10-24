using Catalog.Models;

namespace Catalog.DataLayer
{
    public partial class DataLayerSingleton
    {
        

        public void Seed()
        {
            using var ctx = new CatalogDBContext();

            Random rnd = new Random();

            // 3 adrese

            var a1 = new Adresa
            {
                Oras = "Oradea",
                Strada = "Mihai Eminescu",
                Numar = rnd.Next(1, 900)
            };

            var a2 = new Adresa
            {
                Oras = "Oradea",
                Strada = "Roman Ciorogariu",
                Numar = rnd.Next(1, 900)
            };

            var a3 = new Adresa
            {
                Oras = "Santandrei",
                Strada = "30 Noiembrie",
                Numar = rnd.Next(1, 900)
            };

            // 3 studenti

            var s1 = new Student
            {
                Nume = "Maioru",
                Prenume = "Andrei",
                Varsta = rnd.Next(15, 20),
                Adresa = a1
            };

            var s2 = new Student
            {
                Nume = "Rus",
                Prenume = "Laura",
                Varsta = rnd.Next(15, 20),
                Adresa = a2
            };

            var s3 = new Student
            {
                Nume = "Silaghi",
                Prenume = "Alin",
                Varsta = rnd.Next(15, 20),
                Adresa = a3
            };

            ctx.Adrese.Add(a1);
            ctx.Adrese.Add(a2);
            ctx.Adrese.Add(a3);

            ctx.Studenti.Add(s1);
            ctx.Studenti.Add(s2);
            ctx.Studenti.Add(s3);

            ctx.SaveChanges();
        }
    }
}
