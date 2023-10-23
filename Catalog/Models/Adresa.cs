using System.ComponentModel.DataAnnotations.Schema;


namespace Catalog.Models
{
    public class Adresa
    {
        
        public int Id { get; set; }
        //FK
        public int StudentId { get; set; } // Required foreign key property
        public string Oras { get; set; }
        public string Strada { get; set; }
        public int Numar { get; set; }
        public Student Student { get; set; } = null!; // Required reference navigation to principal
    }
}
