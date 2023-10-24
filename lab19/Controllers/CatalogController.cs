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
                studentToAdd.GetVarsta()
                //studentToAdd.GetOras(), 
                //studentToAdd.GetStrada()
                );

        /// <summary>
        /// Stergere student
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void DeleteStudent(int id) => 
            DataLayerSingleton.Instance.DeleteStudent(id);

        /// <summary>
        /// Modificare date student
        /// </summary>
        /// <param name="studentToUpdate"></param>
        /// <returns></returns>
        [HttpPut("UpdateStudent")]
        public Student UpdateStudent(NewStudentDto studentToUpdate) =>
            DataLayerSingleton.Instance.ChangeStudentData(studentToUpdate.Id,
                studentToUpdate.GetNume(),
                studentToUpdate.GetPrenume(),
                studentToUpdate.GetVarsta());
        //studentToUpdate.GetOras(),
        //studentToUpdate.GetStrada(),
        //studentToUpdate.GetNumar());

        /// <summary>
        /// Modificare adresa student
        /// </summary>
        /// <param name = "adressToUpdate"></param>
        /// <returns></returns>
        [HttpPut("UpdateAddress")]
        public Adresa UpdateAddressStudent(AddressDto adressToUpdate) =>
            DataLayerSingleton.Instance.ChangeStudentAdress(adressToUpdate.StudentId,
                adressToUpdate.GetOras(),
                adressToUpdate.GetStrada(),
                adressToUpdate.GetNumar());

        // Stergerea unui student

        /// <summary>
        /// Stergerea unui student cu parametru pt adresa
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deleteAdresa"></param>
        [HttpDelete()]
        public void DeleteStudenAdvanced2(int id, [FromQuery] bool deleteAdresa) 
        {
            if (deleteAdresa)
            {
                DataLayerSingleton.Instance.DeleteAdresa(id);
            }

            DataLayerSingleton.Instance.DeleteStudent(id);
        }
    }
}
