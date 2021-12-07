using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto2APSW
{
    public partial class login2 : System.Web.UI.Page
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

        }

        protected void btnIniciarSes_Click(object sender, EventArgs e)
        {
           try
           {
                
              
                Conexion();
                DataTable tabla = new DataTable();
                cmdUsuario = new SqlCommand("select * from Registro where Usuario=@user and contraseña=@password", con);

                cmdUsuario.Parameters.Add(new SqlParameter("@user", txtUser.Text));
                cmdUsuario.Parameters.Add(new SqlParameter("@password", txtPass.Text));
                SqlDataAdapter leer = new SqlDataAdapter(cmdUsuario);
                leer.Fill(tabla);
                con.Close();
                string usuario = tabla.Rows[0]["Usuario"].ToString();

                if (usuario==txtUser.Text)
                {
                    verificarUsuario(usuario);
                }
                
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("No hay ninguna fila en la posición 0."))
                {
                    Response.Write("<script>alert('Usuario y/o contraseña incorrecta');</script>");
                }
                else 
                {
                    Response.Write("<script>alert('Hubo un error en la base de datos');</script>");
                }
                
                
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            //validacion de datos 
            try
            {
                //metodo de conexion
                Conexion();
                cmdUsuario = new SqlCommand("insert into Registro values (@NombreCom, @user, @contra, @correo)", con);
                
                cmdUsuario.Parameters.Add(new SqlParameter("@NombreCom", txtNombreReg.Text));
                cmdUsuario.Parameters.Add(new SqlParameter("@user", txtUserReg.Text));
                cmdUsuario.Parameters.Add(new SqlParameter("@contra", txtPassReg.Text));
                cmdUsuario.Parameters.Add(new SqlParameter("@correo", txtCorreoReg.Text));
                
                cmdUsuario.ExecuteNonQuery();
                con.Close();
                enviarCorreo();
                Response.Write("<script>alert('Usuario insertado correctamente');</script>");
            }
            //en caso de error se muestra un mensaje
            catch (Exception ex)
            {
                
                Response.Write("<script>alert('No se pudo registrar el usuario');</script>");
            }
        }

        void verificarUsuario(string username) {
            Conexion();
            SqlDataReader myReader = null;
           string strCadSQL = "select * from Asignacion where Usuario = @user";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@user", username));

            myReader = myCommand.ExecuteReader();

            string tipoUsuario="";
            string areaDepartamento = "";
            string dependenciaDep = "";

            while (myReader.Read())
            {


              tipoUsuario = myReader["Cargo"].ToString();
              areaDepartamento = myReader["area"].ToString();
                dependenciaDep = myReader["Dependencia"].ToString();

            }

            if (tipoUsuario.Contains("Encargado"))
            {
                Response.Redirect("generalencargado.aspx?valor=Encargado;" + areaDepartamento+";"+dependenciaDep);
                
            }
            else if (tipoUsuario.Contains("Supervisor"))
            {
                Response.Redirect("generalsupervisor.aspx?valor=Supervisor;" + areaDepartamento + ";" + dependenciaDep);
            }
            else if (tipoUsuario.Contains("Fiscalizador"))
            {
                Response.Redirect("generalfiscalizador.aspx?valor=Fiscalizador");
            }
            else if (tipoUsuario.Contains("Director"))
            {
                Response.Redirect("generaldirector.aspx?valor=Director;" + areaDepartamento + ";" + dependenciaDep);
            }
            else {
                Response.Redirect("modelomadurez.aspx");
            }
        }
        protected void txtCorreoReg_TextChanged(object sender, EventArgs e)
        {

        }

        void enviarCorreo() 
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(txtCorreoReg.Text);
            mail.Subject = "Bienvenido a nuestro sistema de control interno";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Bcc.Add("maikol.navarro.cascante@cuc.cr");
            mail.Body = "Bienvenido " + txtNombreReg.Text + ", muy pronto se le asignará un rol en nuestro sistema de control interno";
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.From = new MailAddress("fiscalizadorsci@gmail.com");


            mail.To.Add(new MailAddress("dirsci01@gmail.com")); // quien lo va a recibir
            mail.Subject = "Bienvenido a nuestro sistema de control interno"; // asunto

            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Bcc.Add("maikol.navarro.cascante@cuc.cr"); //copia


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
    }
}