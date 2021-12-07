using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto2APSW
{
    public partial class Muestra : System.Web.UI.Page
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
            try
            {
                if (!IsPostBack)
                {
                 
                    cargarVaras();
                  
                   
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnCorreo_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(txtCorreoPara.Text);
            mail.Subject = txtAsunto.Text;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Bcc.Add(txtCorreoCopia.Text);
            mail.Body = txtDescripcion.Text;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.From = new MailAddress("fiscalizadorsci@gmail.com");


            mail.To.Add(new MailAddress("dirsci01@gmail.com")); // quien lo va a recibir
            mail.Subject = txtAsunto.Text; // asunto


            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Bcc.Add(txtCorreoCopia.Text); //copia


            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("fiscalizadorsci@gmail.com", "fisca12345"); //donde se envia el correo
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            try
            {
                //envio
                smtp.Send(mail);
            }
            catch (Exception)
            {

                throw;
            }
        }

        void cargarVaras()
        {
            Table1.Rows.Clear();
            encabezado();
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "";
           
                strCadSQL = "select * from Asignacion";
         

            SqlCommand myCommand = new SqlCommand(strCadSQL, con);


            myReader = myCommand.ExecuteReader();



            while (myReader.Read())
            {



                nuevaTabla(myReader["NombreCompleto"].ToString(), myReader["Usuario"].ToString(), myReader["contraseña"].ToString(), myReader["correo"].ToString(), myReader["area"].ToString(), myReader["Dependencia"].ToString(), myReader["Cargo"].ToString());



            }

            con.Close();
        }
        void nuevaTabla(string codigo, string Nivel, string Descripcion, string Evidencia, string Estado, string departamento, string inicio_de_apertura)
        {



            TableRow row2 = new TableRow();


            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            TableCell cell4 = new TableCell();
            TableCell cell5 = new TableCell();
            TableCell cell6 = new TableCell();
            TableCell cell7 = new TableCell();
           



            cell1.Text = codigo;
            cell2.Text = Nivel;
            cell3.Text = Descripcion;
            cell4.Text = Evidencia;
            cell5.Text = Estado;
            cell6.Text = departamento;
            cell7.Text = inicio_de_apertura;
           

            System.Web.UI.WebControls.HyperLink hyp = new HyperLink();
          


            row2.Cells.Add(cell1);

            row2.Cells.Add(cell2);

            row2.Cells.Add(cell3);

            row2.Cells.Add(cell4);

            row2.Cells.Add(cell5);

            row2.Cells.Add(cell6);

            row2.Cells.Add(cell7);


            Table1.Rows.Add(row2);

        }

        void encabezado()
        {
            TableRow row = new TableRow();

            TableHeaderCell hcell1 = new TableHeaderCell();
            TableHeaderCell hcell2 = new TableHeaderCell();
            TableHeaderCell hcell3 = new TableHeaderCell();
            TableHeaderCell hcell4 = new TableHeaderCell();
            TableHeaderCell hcell5 = new TableHeaderCell();
            TableHeaderCell hcell6 = new TableHeaderCell();
            TableHeaderCell hcell7 = new TableHeaderCell();
           
         




            hcell1.Text = "Nombre";
            hcell2.Text = "Usuario";
            hcell3.Text = "Contraseña";
            hcell4.Text = "correo";
            hcell5.Text = "Área";
            hcell6.Text = "Departamento";
            hcell7.Text = "Cargo";
            
        

            row.Cells.Add(hcell1);

            row.Cells.Add(hcell2);

            row.Cells.Add(hcell3);

            row.Cells.Add(hcell4);

            row.Cells.Add(hcell5);

            row.Cells.Add(hcell6);

            row.Cells.Add(hcell7);

        

          
            Table1.Rows.Add(row);
        }
    }
}