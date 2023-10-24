using Catalog.Exceptions;
using Catalog.Models;

namespace Catalog.DataLayer
{
    public partial class DataLayerSingleton
    {
        #region Singleton
        private DataLayerSingleton()
        {

        }

        private static DataLayerSingleton _instance;


        public static DataLayerSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DataLayerSingleton();
                }
                return _instance;
            }
        }
        #endregion

        public List<Student> GetAllStudents()
        {
            using var ctx = new CatalogDBContext();
            return ctx.Studenti.ToList();

        }

        public Student GetStudent(int id)
        {
            using var ctx = new CatalogDBContext();

            return ctx.Studenti.FirstOrDefault(s => s.Id == id);
        }

        public Student AddStudent(string nume, string prenume, int newVarsta
            //,string oras, string strada
            )
        {
            using var ctx = new CatalogDBContext();
            Random rnd = new Random();

            //var a = new Adresa
            //{
            //    Oras = oras,
            //    Strada = strada,
            //    Numar = rnd.Next(1, 900)
            //};

            var s = new Student
            {
                Nume = nume,
                Prenume = prenume,
                Varsta = newVarsta,
                //Adresa = a
            };

            //ctx.Adrese.Add(a);
            ctx.Studenti.Add(s);

            ctx.SaveChanges();
            return s;
        }

        public Student ChangeStudentData(int id, string newNume, 
            string newPrenume, int newVarsta)
        {
            using var ctx = new CatalogDBContext();

            var student = ctx.Studenti.FirstOrDefault(s => s.Id == id);

            student.Nume = newNume;
            student.Prenume = newPrenume;
            student.Varsta = newVarsta;
            //student.Adresa.Oras = newOras;
            //student.Adresa.Strada = newStrada;
            //student.Adresa.Numar = newNumar;

            ctx.SaveChanges();
            return student;
        }

        public Adresa ChangeStudentAdress(int id, string newOras, 
            string newStrada, int newNumar)
        {
            using var ctx = new CatalogDBContext();
            var student = ctx.Studenti.FirstOrDefault(s => s.Id == id);
            var adresa = ctx.Adrese.FirstOrDefault(a => a.StudentId == id);

            if( adresa == null)
            {
                ctx.Adrese.Add(new Adresa
                {
                    Oras = newOras,
                    Strada = newStrada,
                    Numar = newNumar
                });
            }
            else
            {
                adresa.Oras = newOras;
                adresa.Strada = newStrada;
                adresa.Numar = newNumar;
                
            }
            //adresa.Oras = newOras;
            //adresa.Strada = newStrada;
            //adresa.Numar = newNumar;
            //ctx.SaveChanges();
            student.Adresa = adresa;
            ctx.SaveChanges();
            return adresa;
        }
        public Adresa AddStudentAdress(string newOras,
           string newStrada, int newNumar)
        {
            using var ctx = new CatalogDBContext();

            var adresa = new Adresa
            {
                Oras = newOras,
                Strada = newStrada,
                Numar = newNumar
            };
            ctx.Adrese.Add(adresa);

            ctx.SaveChanges();

            return adresa;
        }

        public void DeleteStudent(int id)
        {
            using var ctx = new CatalogDBContext();

            var student = ctx.Studenti.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                throw new InvalidIdException($"Id student invalid {id}");
            }
            ctx.Studenti.Remove(student);
            ctx.SaveChanges();
        }

        public void DeleteAdresa(int id)
        {
            using var ctx = new CatalogDBContext();

            var adresa = ctx.Adrese.FirstOrDefault(a => a.StudentId == id);

            if (adresa == null)
            {
                throw new InvalidIdException($"Id address invalid {id}");
            }
            ctx.Adrese.Remove(adresa);
            ctx.SaveChanges();
        }
    }
}
