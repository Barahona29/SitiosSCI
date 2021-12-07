using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto2APSW
{
    public partial class usuarios : System.Web.UI.Page
    {

        string cone = "workstation id=SistemaCI.mssql.somee.com;packet size=4096;user id=maikol1113_SQLLogin_1;pwd=6t75jgalrt;data source=SistemaCI.mssql.somee.com;persist security info=False;initial catalog=SistemaCI";
        SqlConnection con;
        SqlCommand cmdUsuario;

        public void Conexion()
        {
            con = new SqlConnection(cone);
            con.Open();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            cargarVaras();
        }

        void cargarVaras()
        {
            Table1.Rows.Clear();
           
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "";

            strCadSQL = "select distinct r.NombreCompleto, r.Usuario, r.contraseña, r.correo from Registro r, Asignacion a where r.Usuario!=a.Usuario";

            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            

            myReader = myCommand.ExecuteReader();

            encabezado();

            while (myReader.Read())
            {
                    nuevaTabla(myReader["NombreCompleto"].ToString(), myReader["Usuario"].ToString(), myReader["contraseña"].ToString(), myReader["correo"].ToString());
            }

        }

        void encabezado()
        {

            TableRow row = new TableRow();

            TableHeaderCell hcell1 = new TableHeaderCell();
            TableHeaderCell hcell2 = new TableHeaderCell();
            TableHeaderCell hcell3 = new TableHeaderCell();
            TableHeaderCell hcell4 = new TableHeaderCell();
            TableHeaderCell hcell5 = new TableHeaderCell();

            hcell1.Text = "Nombre";
            hcell2.Text = "Usuario";
            hcell3.Text = "Contraseña";
            hcell4.Text = "Correo";
            hcell5.Text = "Cargar";


            row.Cells.Add(hcell1);

            row.Cells.Add(hcell2);

            row.Cells.Add(hcell3);

            row.Cells.Add(hcell4);

            row.Cells.Add(hcell5);

            Table1.Rows.Add(row);

        }


        void nuevaTabla(string nombre, string usuario, string contrasena, string correo)
        {

            TableRow row2 = new TableRow();


            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            TableCell cell4 = new TableCell();
            TableCell cell5 = new TableCell();

            cell1.Text = nombre;
            cell2.Text = usuario;
            cell3.Text = contrasena;
            cell4.Text = correo;

            Literal lit = new Literal();


            lit.Text = "<button id='" + nombre + "' onclick='cargar(this)' style='  border: none; color: white; text-align: center; text - decoration: none; display: inline-block; margin: 4px 2px; transition-duration: 0.4s; cursor: pointer; border-radius: 5px; background-color: black; font-size: 17px; ' type='button'>Asignar rol</button>";

            cell5.Controls.Add(lit);

            row2.Cells.Add(cell1);

            row2.Cells.Add(cell2);

            row2.Cells.Add(cell3);

            row2.Cells.Add(cell4);

            row2.Cells.Add(cell5);

            Table1.Rows.Add(row2);

        }


    }
}