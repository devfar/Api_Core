using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Business;

namespace ApiRest.Models
{
    public class MEmployee
    {
        public List<Employee> listar()
        {
            return (new bEmployee()).Listar(new Employee() { OPR = 1 });
        }
        public string mantenimiento(Employee objEmployee)
        {
            ResultadoDB respuesta = (new bEmployee()).Mantenimiento(objEmployee);
            return respuesta.ID_ERROR == 0 ? "Operación correcta" : "Se produjo un error";
        }
    }
}
