using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CacheManager.CLS
{
    public static class Cache
    {
        public static DataTable INICIAR_SESION(String pUsuario, String pClave)//PARAMETRIZAR p
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionBD Consultor = new DataManager.CLS.OperacionBD();
            String Consulta = @"SELECT a.IDUsuario, a.Usuario, a.IDEmpleado, a.IDRol, 
		CONCAT(b.Nombres, ' ',b.Apellidos) Empleado,
		c.Rol FROM usuarios a, empleados b, roles c
		WHERE a.Usuario = '" + pUsuario + @"'
		AND a.Clave=SHA1(MD5('" + pClave + @"'))
		AND a.IDEmpleado = b.IDEmpleado
		AND a.IDRol = c.IDRol;";
            try
            {
                Resultados = Consultor.Consultar(Consulta);
            }
            catch
            {
                Resultados = new DataTable();

            }


            return Resultados;
        }

    }
}
