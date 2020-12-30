using System;
using System.Collections.Generic;
using Entity;
using Data;

namespace Business
{
    public class bEmployee
    {
        public List<Employee> Listar(Employee objEmployee)
        {
            List<Employee> lstEmployees;

            if (objEmployee == null) objEmployee = new Employee();

            using (dEmployee objda = new dEmployee())
            {
                lstEmployees = objda.Listar(objEmployee);
            }

            return lstEmployees;
        }

        public ResultadoDB Mantenimiento(Employee objEmployee)
        {
            try
            {
                if (objEmployee == null) objEmployee = new Employee();

                using (dEmployee objda = new dEmployee())
                {
                    return objda.Mantenimiento(objEmployee);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
