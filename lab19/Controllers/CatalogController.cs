using Catalog.DataLayer;
using Catalog.Models;
using lab19.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace lab19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        /// <summary>
        /// Obtinerea tuturor studentilor
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public List<Student> GetAll() => 
            DataLayerSingleton.Instance.GetAllStudents();

        /// <summary>
        /// Obtinerea unui student dupa ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Student GetStudent(int id) => 
            DataLayerSingleton.Instance.GetStudent(id);

        /// <summary>
        /// Creeare student
        /// </summary>
        /// <param name="studentToAdd"></param>
        /// <returns></returns>
        [HttpPost()]
        public Student AddStudent(NewStudentDto studentToAdd) => 
            DataLayerSingleton.Instance.AddStudent(studentToAdd.GetNume(), 
                studentToAdd.GetPrenume(), 
                studentToAdd.GetOras(), 
                studentToAdd.GetStrada());

        /// <summary>
        /// Stergere student
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void DeleteStudent(int id) => 
            DataLayerSingleton.Instance.DeleteStudent(id);

        // Modificare date student

        // Modificare adresa student

        // Stergerea unui student

    }
}
