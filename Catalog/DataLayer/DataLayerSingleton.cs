using Catalog.Exceptions;
using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Student AddStudent(string nume, string prenume, string oras, string strada)
        {
            using var ctx = new CatalogDBContext();
            Random rnd = new Random();

            var a = new Adresa
            {
                Oras = oras,
                Strada = strada,
                Numar = rnd.Next(1, 900)
            };

            var s = new Student
            {
                Nume = nume,
                Prenume = prenume,
                Varsta = rnd.Next(15, 20),
                Adresa = a
            };

            ctx.Adrese.Add(a);
            ctx.Studenti.Add(s);

            ctx.SaveChanges();
            return s;
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
    }
}
