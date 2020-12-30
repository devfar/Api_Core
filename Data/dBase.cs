using Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class dBase : Base
    {
        private string strCadenaConnect = string.Empty;
        protected string CadenaConexion
        {
            get { return strCadenaConnect; }
        }
        public dBase()
        {
            this.strCadenaConnect = Conexion.obtenerCadenaConexion();
        }

        public object validarNulo(object Obj, string objPropiedadHija = "")
        {
            try
            {

                if (!string.IsNullOrEmpty(objPropiedadHija))
                {
                }
                if ((Obj) is string)
                {
                    return (string.IsNullOrEmpty(Obj.ToString()) ? DBNull.Value : Obj);
                }
                else if ((Obj) is System.DateTime)
                {

                    return (DateTime.Equals(Obj, DateTime.MinValue) ? DBNull.Value : Obj);
                }
                else if ((Obj) is int | (Obj) is Int64 | (Obj) is Int16 | (Obj) is uint)
                {
                    if (Obj.Equals(-1) || Obj.Equals(0))
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return Obj;
                    }
                }
                else if ((Obj) is double | (Obj) is decimal)
                {
                    if (Obj.Equals(-1) || Obj.Equals(0))
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        return Obj;
                    }
                }
                else
                {
                    if ((Obj == null))
                    {
                        return DBNull.Value;
                    }
                    else
                    {
                        dynamic objPropiedad = Obj.GetType().GetProperty(objPropiedadHija).GetValue(Obj, null);
                        return validarNulo(objPropiedad);
                    }
                }
            }
            catch
            {
                return DBNull.Value;
            }
        }

        public bool ValidarReader(SqlDataReader reader, string columna)
        {
            return reader[columna] != DBNull.Value ? true : false;
        }

    }
}
