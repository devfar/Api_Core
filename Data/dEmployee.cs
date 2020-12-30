using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Entity;

namespace Data
{
    public class dEmployee : dBase
    {
        //Metodo para listar sobre la tabla empleados
        public List<Employee> Listar(Employee objEmployee)
        {
            var lstEmployees= new List<Employee>();

            SqlParameter[] arrParameters = new SqlParameter[] {
                new SqlParameter("@X_EmployeeId", validarNulo(objEmployee.EmployeeId)),
                new SqlParameter("@X_EmployeeName", validarNulo(objEmployee.EmployeeName)),
                new SqlParameter("@X_EmployeeSalary", validarNulo(objEmployee.EmployeeSalary)),
                new SqlParameter("@X_EmployeeAge", validarNulo(objEmployee.EmployeeAge)),
                new SqlParameter("@X_ProfileImage", validarNulo(objEmployee.ProfileImage)),
                new SqlParameter("@X_ID_OPE", validarNulo(objEmployee.OPR))
            };

            DataTable table = new DataTable();
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(this.CadenaConexion))
            {
                try
                {
                    myCon.Open();
                    SqlCommand cmd = new SqlCommand("sp_employee_cons", myCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(arrParameters);

                    myReader = cmd.ExecuteReader();
                    if (myReader != null)
                    {
                        if (myReader.HasRows)
                        {
                            object[] arrResult = new object[myReader.FieldCount];
                            Employee temp = null;
                            while (myReader.Read())
                            {
                                myReader.GetValues(arrResult);
                                temp = new Employee();
                                if (!myReader.IsDBNull(myReader.GetOrdinal("EmployeeId"))) temp.EmployeeId = int.Parse(arrResult[myReader.GetOrdinal("EmployeeId")].ToString());
                                if (!myReader.IsDBNull(myReader.GetOrdinal("EmployeeName"))) temp.EmployeeName = arrResult[myReader.GetOrdinal("EmployeeName")].ToString();
                                if (!myReader.IsDBNull(myReader.GetOrdinal("EmployeeSalary"))) temp.EmployeeSalary = decimal.Parse(arrResult[myReader.GetOrdinal("EmployeeSalary")].ToString());
                                if (!myReader.IsDBNull(myReader.GetOrdinal("EmployeeAge"))) temp.EmployeeAge = int.Parse(arrResult[myReader.GetOrdinal("EmployeeAge")].ToString());
                                if (!myReader.IsDBNull(myReader.GetOrdinal("ProfileImage"))) temp.ProfileImage = arrResult[myReader.GetOrdinal("ProfileImage")].ToString();

                                lstEmployees.Add(temp);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    if (myCon.State != ConnectionState.Closed) myCon.Close();
                }
                finally
                {
                    if (myCon.State != ConnectionState.Closed) myCon.Close();
                }

            }

            return lstEmployees;
        }

        //Metodo para las operaciones: UPDATE/INSERT/DELETE
        public ResultadoDB Mantenimiento(Employee objEmployee)
        {
            ResultadoDB objResultadoDb = new ResultadoDB();

            SqlParameter[] arrParameters = new SqlParameter[] {
                new SqlParameter("@X_EmployeeId", validarNulo(objEmployee.EmployeeId)),
                new SqlParameter("@X_EmployeeName", validarNulo(objEmployee.EmployeeName)),
                new SqlParameter("@X_EmployeeSalary", validarNulo(objEmployee.EmployeeSalary)),
                new SqlParameter("@X_EmployeeAge", validarNulo(objEmployee.EmployeeAge)),
                new SqlParameter("@X_ProfileImage", validarNulo(objEmployee.ProfileImage)),
                new SqlParameter("@X_ID_OPE", validarNulo(objEmployee.OPR))
            };
            try
            {
                using (dDml objDml = new dDml())
                {
                    objResultadoDb = objDml.ejecutarDml(arrParameters, "sp_employee_mant");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return objResultadoDb;
        }
    }
}
