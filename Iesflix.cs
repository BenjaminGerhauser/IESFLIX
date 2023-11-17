using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
namespace IESFLIX
{
    class Iesflix
    {
        public DataTable usuario(string email, string password)
        {
            DataTable tabla = new DataTable();
            string sql = $"SELECT username,userID FROM Users WHERE email='{email}' AND password='{password}'";
            string cadena = "Data Source=Iesflix.db";
            SQLiteDataAdapter adaptador = new SQLiteDataAdapter(sql,cadena);
            adaptador.Fill(tabla);
            return tabla;
        }
        public DataTable getTabla(string nombreTabla)
        {
            DataTable tabla = new DataTable();
            string sql = $"SELECT * FROM {nombreTabla}";
            string cadena = "Data Source=Iesflix.db";
            SQLiteDataAdapter adaptador = new SQLiteDataAdapter(sql, cadena);
            adaptador.Fill(tabla);
            return tabla;
        }
        public void score(int id,DataTable titles,DataGridView grilla )
        {
            DataTable tabla = new DataTable();
            string sql = $"SELECT * FROM Scores WHERE userID='{id}'";
            string cadena = "Data Source=Iesflix.db";
            SQLiteDataAdapter adaptador = new SQLiteDataAdapter(sql, cadena);
            adaptador.Fill(tabla);
            grilla.Rows.Clear();
            foreach (DataRow fila in titles.Rows)
            {
                string calificacion = "";
                string titleType = Convert.ToInt32(fila["titleType"]) == 1 ? "PELICULA" : "SERIE"; 
                foreach (DataRow f in tabla.Rows)
                {
                    if (Convert.ToInt32(f["titleID"]) == Convert.ToInt32(fila["titleID"]))
                    {
                        switch (Convert.ToInt32(f["score"]))
                        {
                            case 1:
                                calificacion = "MALA";
                                break;
                            case 2:
                                calificacion = "REGULAR";
                                break;
                            case 3:
                                calificacion = "BUENA";
                                break;
                            case 4:
                                calificacion = "MUY BUENA";
                                break;
                            case 5:
                                calificacion = "EXCELENTE";
                                break;
                            default:
                                calificacion = "SIN CALIFICAR";
                                break;
                        }
                    }
                }
                grilla.Rows.Add(fila["titleID"], fila["titlename"], titleType, calificacion);
            }            
        }
    }
}
