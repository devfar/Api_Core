using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using ApiRest.Models;
using Entity;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(new MEmployee().listar());
        }

        [HttpPost]
        public JsonResult Post(Employee objEmployee)
        {
            objEmployee.OPR = 1;
            return new JsonResult(new MEmployee().mantenimiento(objEmployee));
        }

        [HttpPut]
        public JsonResult Put(Employee objEmployee)
        {
            objEmployee.OPR = 2;
            return new JsonResult(new MEmployee().mantenimiento(objEmployee));

        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Employee objEmployee = new Employee();
            objEmployee.EmployeeId = id;
            objEmployee.OPR = 3;
            return new JsonResult(new MEmployee().mantenimiento(objEmployee));

        }
    }
}
