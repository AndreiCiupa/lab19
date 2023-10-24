namespace Catalog.Models
{
    public class Student
    {
        //PK
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int Varsta { get; set; }
        public Adresa? Adresa { get; set; } // Reference navigation to dependent
    }
}
