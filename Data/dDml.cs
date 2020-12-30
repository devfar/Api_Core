using System;
using Microsoft.Data.SqlClient;
using Entity;
using System.Data;

namespace Data
{
    public class dDml : dBase
    {
        public ResultadoDB ejecutarDml(SqlParameter[] cmdParameters, string strCommandText)
        {
            ResultadoDB objResultadoDB = new ResultadoDB();
            SqlDataReader drReader;
            using (SqlConnection cnn = new SqlConnection(this.CadenaConexion))
            {
                try
                {
                    cnn.Open();
                    using (SqlTransaction trx = cnn.BeginTransaction())
                    {
                        SqlCommand cmd = new SqlCommand(strCommandText, cnn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Transaction = trx;
                        cmd.Parameters.AddRange(cmdParameters);

                        drReader = cmd.ExecuteReader();
                        {
                            if (drReader.Read())
                            {
                                if (!drReader.IsDBNull(drReader.GetOrdinal("ID_ERROR"))) objResultadoDB.ID_ERROR = int.Parse(drReader["ID_ERROR"].ToString());
                                if (!drReader.IsDBNull(drReader.GetOrdinal("MENSAJE"))) objResultadoDB.MENSAJE = drReader["MENSAJE"].ToString();
                                for (int i = 0; i < drReader.FieldCount; i++)
                                {
                                    if (drReader.GetName(i).Equals("VALOR", StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        if (!drReader.IsDBNull(drReader.GetOrdinal("VALOR"))) objResultadoDB.VALOR = drReader["VALOR"].ToString();
                                    }
                                }
                            }
                            drReader.Close();
                            if (objResultadoDB.ID_ERROR == 0)
                            {
                                trx.Commit();
                            }
                            else
                            {
                                trx.Rollback();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    objResultadoDB.ID_ERROR = 1;
                    objResultadoDB.MENSAJE = ex.Message;
                }
                finally
                {
                    if (cnn.State != ConnectionState.Closed)
                    {
                        cnn.Close();
                    }
                    if (cnn.State == ConnectionState.Closed)
                    {
                        cnn.Dispose();
                    }

                }
            }
            return objResultadoDB;

        }
    }
}
