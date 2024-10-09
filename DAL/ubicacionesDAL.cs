using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
namespace DAL
{
    public class ubicacionesDAL
    {
        SQLDBHelper oConexion;
        public ubicacionesDAL()
        {
            oConexion = new SQLDBHelper();
        }
        public bool Agregar(ubicacionesBLL oUbicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "INSERT INTO Ubicaciones (Ubicacion, Latitud, Longitud) VALUES (@Ubicacion, @Latitud, @Longitud)";
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = oUbicacionesBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = oUbicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = oUbicacionesBLL.Longitud;
            return oConexion.EjecutarComandoSQL(cmdComando);
        }
        public bool Eliminar(ubicacionesBLL oUbicacionesBLL) 
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "DELETE FROM Ubicaciones WHERE ID = @IDUbicacion";
            cmdComando.Parameters.Add("@IDUbicacion", SqlDbType.Int).Value = oUbicacionesBLL.ID;
            return oConexion.EjecutarComandoSQL(cmdComando);
        }
        public bool Modificar(ubicacionesBLL oUbicacionesBLL) 
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "UPDATE Ubicaciones SET Ubicacion = @Ubicacion, Latitud = @Latitud, Longitud = @Longitud WHERE ID = @ID";
            cmdComando.Parameters.Add("@ID", SqlDbType.Int).Value = oUbicacionesBLL.ID;
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = oUbicacionesBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = oUbicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = oUbicacionesBLL.Longitud;
            cmdComando.CommandType = CommandType.Text;
            return oConexion.EjecutarComandoSQL(cmdComando);
        }

        public DataTable Seleccionar(ubicacionesBLL oUbicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "SELECT * FROM Ubicaciones WHERE ID = @IDUbicacion";
            cmdComando.Parameters.Add("@IDUbicacion", SqlDbType.Int).Value = oUbicacionesBLL.ID;
            cmdComando.CommandType = CommandType.Text;
            DataTable TablaResultado = oConexion.EjecutarSentenciaSQL(cmdComando);
            return TablaResultado;
        }

        public DataTable Listar() 
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "SELECT * FROM Ubicaciones";
            cmdComando.CommandType = CommandType.Text;
            DataTable TablaResultado = oConexion.EjecutarSentenciaSQL(cmdComando);
            return TablaResultado;
        }
    }
}
