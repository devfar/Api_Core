namespace Data
{
    public static class Conexion
    {
        public static string obtenerCadenaConexion()
        {
            string strServidor = "DEVELOPER\\MSSQLSERVER2017";
            string strDatabase = "EmployeeExamen";
            return "Data Source=" + strServidor + ";Initial Catalog=" + strDatabase + ";Integrated Security=true";
        }
    }
}
