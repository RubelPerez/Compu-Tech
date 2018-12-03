using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace CompuTech
{
    class FiltroCliente
    {
        private static SqlConnection DameConexion()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False";
            return con;
        }
        public static DataTable DameDatos()
        {

            SqlConnection con = Filtro.DameConexion();
            SqlCommand comando = new SqlCommand();
            comando.Connection = con;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "select * from cliente";
            using (con)
            {
                con.Open();
                SqlDataReader leer = comando.ExecuteReader();
                DataTable Tabla = new DataTable();
                Tabla.Load(leer);
                return Tabla;



            }

        }
    }
}
