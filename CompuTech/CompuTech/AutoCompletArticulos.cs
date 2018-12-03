using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CompuTech
{
    class AutoCompletArticulos
    {
       //metodo para cargar los datos de la bd
      public static DataTable Datos()
      {
          DataTable dt = new DataTable();

          SqlConnection conexion = new SqlConnection(@"Data Source=AZKENAT-PC\SQLEXPRESS;Initial Catalog=DB_CompuTech;Integrated Security=True;Pooling=False");//cadena conexion
 
          string consulta = "SELECT * FROM cliente"; 
          SqlCommand comando = new SqlCommand(consulta,conexion);
 
          SqlDataAdapter adap = new SqlDataAdapter(comando);
 
          adap.Fill(dt);
          return dt;
      }
 
      //metodo para cargar la coleccion de datos para el autocomplete

      public static AutoCompleteStringCollection Autocomplete()
      {
          DataTable dt = Datos();
 
          AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
          //recorrer y cargar los items para el autocompletado
          foreach (DataRow row in dt.Rows)
          {
              coleccion.Add(Convert.ToString(row["ct_documento"]));
              
          }
 
          return coleccion;
      }
  }

    }

    