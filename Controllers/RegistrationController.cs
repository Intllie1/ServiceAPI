//using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
//using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Results;
using RegistrationAPI.BusinessService.Interfaces;
using RegistrationAPI.objects.Proxies;
using RegistrationAPI.objects;
using RegistrationAPI.DataAccess.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RegistrationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase//ApiController
    {
        private readonly IRegistration<Registration> _IRegistration;

        public RegistrationController(IRegistration<Registration> registration)
        {
            _IRegistration = registration;
        }   


        [HttpPost]
        [Route("RegisterUser")]
        public IActionResult AddRegistration(Registration objSetReg)
        {
            ResponseEntity objReg = _IRegistration.AddRegistration(objSetReg);
            return StatusCode(0,objReg);
        }

        [HttpPost]
        [Route("UpdateUser")]

        public IActionResult UpdateRegistration(Registration objSetReg)
        {
            ResponseEntity objReg = _IRegistration.UpdateRegistration(objSetReg);
            return StatusCode(0, objReg);
        }
        [HttpPost]
        [Route("DeleteUser")]
        public IActionResult DeleteRegistration(Registration objSetReg)
        {
            ResponseEntity objReg = _IRegistration.DeleteRegistration(objSetReg,objSetReg);
            return StatusCode(0, objReg);
        }

        [HttpGet]
        [Route("GetAllUsers")]  
        public IActionResult GetAll()
        {
            return StatusCode(0, _IRegistration.GetAll());
        }
        [HttpGet]
        [Route("GetUser")]
        public IActionResult Get(int id)
        {
            return StatusCode(0, _IRegistration.Get(id));
        }

    }
}
