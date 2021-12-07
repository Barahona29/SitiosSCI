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
    public partial class asignacion : System.Web.UI.Page
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
            
            try {
                
                if (!IsPostBack)
                {
                    cargarAreas();
                    cargarDependencias(1);
                    string cargar = Request.Params.Get("nombre");
                    string[] param = cargar.Split(';');
                    if (param[1]=="1") 
                    {
                        cargarUsuario(param[0]);

                    }else if (param[1] == "2")
                    {
                        cargarUsuarioNuevo(param[0]);
                    }

                    
                }
                

            } catch (Exception ex) { 
            
            }
            
            cargarVaras("Área");

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                //método de conexión
                Conexion();
                cmdUsuario = new SqlCommand("Rasignacion", con);
                cmdUsuario.CommandType = System.Data.CommandType.StoredProcedure;
                cmdUsuario.Parameters.Add(new SqlParameter("@NombreCompleto", txtNombre.Text));
                cmdUsuario.Parameters.Add(new SqlParameter("@Usuario", txtUsuario.Text));
                cmdUsuario.Parameters.Add(new SqlParameter("@contraseña", txtPass.Text));
                cmdUsuario.Parameters.Add(new SqlParameter("@correo", txtCorreo.Text));
                cmdUsuario.Parameters.Add(new SqlParameter("@area", ddlArea.SelectedItem.Value));
                cmdUsuario.Parameters.Add(new SqlParameter("@Dependencia", ddlDependencia.SelectedItem.Value));
                cmdUsuario.Parameters.Add(new SqlParameter("@Cargo", ddlCargo.SelectedItem.Value));
                cmdUsuario.Parameters.Add(new SqlParameter("@Estado", ddlEstado.SelectedItem.Value));
                cmdUsuario.ExecuteNonQuery();
                con.Close();
                if (ddlFiltro.SelectedValue == "Área")
                {
                    cargarVaras("Área");
                }
                else if (ddlFiltro.SelectedValue == "Cargo")
                {
                    cargarVaras("Cargo");
                }

                enviarCorreo();
                Response.Write("<script>alert('Usuario registrado correctamente');</script>");
                

                
            }
            //en caso de error se muestra un mensaje
            catch (Exception ex)
            {
              //  throw new Exception("Error al registrar el usuario" + ex.Message);
                Response.Write("<script>alert('Error en la base de datos "+ ex.Message +"');</script>");
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                //método de conexión
                Conexion();
                cmdUsuario = new SqlCommand("delete from Asignacion where NombreCompleto = @Nombre", con);
                cmdUsuario.Parameters.Add(new SqlParameter("@Nombre", txtNombre.Text));
                cmdUsuario.ExecuteNonQuery();
                con.Close();
                if (ddlFiltro.SelectedValue == "Área")
                {
                    cargarVaras("Área");
                }
                else if (ddlFiltro.SelectedValue == "Cargo")
                {
                    cargarVaras("Cargo");
                }
                Response.Write("<script>alert('Usuario eliminado correctamente');</script>");
            }
            //en caso de error se muestra un mensaje
            catch (Exception ex)
            {
                //  throw new Exception("Error al registrar el usuario" + ex.Message);
                Response.Write("<script>alert('Error en la base de datos " + ex.Message + "');</script>");
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
               
                Conexion();
                
                    cmdUsuario = new SqlCommand("MAsignacion", con);
                cmdUsuario.CommandType = System.Data.CommandType.StoredProcedure;
                cmdUsuario.Parameters.Add(new SqlParameter("@NombreCompleto", txtNombre.Text));
                cmdUsuario.Parameters.Add(new SqlParameter("@Usuario", txtUsuario.Text));
                cmdUsuario.Parameters.Add(new SqlParameter("@contraseña", txtPass.Text));
                cmdUsuario.Parameters.Add(new SqlParameter("@correo", txtCorreo.Text));
                cmdUsuario.Parameters.Add(new SqlParameter("@area", ddlArea.SelectedItem.Value));
                cmdUsuario.Parameters.Add(new SqlParameter("@Dependencia", ddlDependencia.SelectedItem.Value));
                cmdUsuario.Parameters.Add(new SqlParameter("@Cargo", ddlCargo.SelectedItem.Value));
                cmdUsuario.Parameters.Add(new SqlParameter("@Estado", ddlEstado.SelectedItem.Value));
                cmdUsuario.ExecuteNonQuery();
                
                con.Close();
                
                Table1.Rows.Clear();
                if (ddlFiltro.SelectedValue == "Área")
                {
                    cargarVaras("Área");
                }
                else if (ddlFiltro.SelectedValue == "Cargo")
                {
                    cargarVaras("Cargo");
                }

                Response.Write("<script>alert('Usuario modificado correctamente');</script>");
                

            }
            //en caso de error se muestra un mensaje
            catch (Exception ex)
            {
                //  throw new Exception("Error al registrar el usuario" + ex.Message);
                Response.Write("<script>alert('Error en la base de datos " + ex.Message + "');</script>");
            }
                
        }




        void cargarVaras(string indicador)
        {
            Table1.Rows.Clear();
            encabezado();
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "";
            if (indicador == "Área")
            {     
             strCadSQL = "select * from Asignacion order by area asc";
            }
            else if (indicador == "Cargo")
            {
                strCadSQL = "select * from Asignacion order by Cargo asc";
            }
            
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);


            myReader = myCommand.ExecuteReader();


            
            while (myReader.Read())
            {


                // lblIndicador.Text = myReader["idNum"].ToString();
                nuevaTabla(myReader["NombreCompleto"].ToString(), myReader["Usuario"].ToString(), myReader["contraseña"].ToString(), myReader["correo"].ToString(), myReader["area"].ToString(), myReader["Dependencia"].ToString(), myReader["Cargo"].ToString(), myReader["Estado"].ToString(), myReader["NombreCompleto"].ToString());
                

            }

            con.Close();
        }
        void nuevaTabla(string NombreCompleto, string Usuario, string contrasena, string correo, string area, string Dependencia, string Cargo, string Estado, string titulo)
        {

           
         
            TableRow row2 = new TableRow();
         

            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            TableCell cell4 = new TableCell();
            TableCell cell5 = new TableCell();
            TableCell cell6 = new TableCell();
            TableCell cell7 = new TableCell();
            TableCell cell8 = new TableCell();


          

            cell1.Text = NombreCompleto;
            cell2.Text = Usuario;
            cell3.Text = contrasena;
            cell4.Text = correo;
            cell5.Text = area;
            cell6.Text = Dependencia;
            cell7.Text = Cargo;
            cell8.Text = Estado;

            Button btn1 = new Button();

          

            

            System.Web.UI.WebControls.HyperLink hyp = new HyperLink();
            System.Web.UI.WebControls.Button btn2 = new Button();

            Literal lit = new Literal();
            //  lit.Text = "<input type='Button' ID='Button"+contador+"' value='Eliminar' />";

            lit.Text = "<button name='" + titulo + "' onclick='cargar(this)' style='  border: none; color: white; text-align: center; text - decoration: none; display: inline-block; margin: 4px 2px; transition-duration: 0.4s; cursor: pointer; border-radius: 5px; background-color: black; font-size: 17px; ' type='button'>Cargar</button>";

            //  lit.Text = "<input type='Button' ID='Button"+contador+"' value='Eliminar' />";







            TableCell cell9 = new TableCell();
            cell9.Controls.Add(lit);



            row2.Cells.Add(cell1);

            row2.Cells.Add(cell2);

            row2.Cells.Add(cell3);

            row2.Cells.Add(cell4);

            row2.Cells.Add(cell5);

            row2.Cells.Add(cell6);

            row2.Cells.Add(cell7);

            row2.Cells.Add(cell8);

            row2.Cells.Add(cell9);

            Table1.Rows.Add(row2);

        }

        void cargarUsuario(string nombre)
        {
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select * from Asignacion where NombreCompleto = @NombreCompleto";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@NombreCompleto", nombre));

            myReader = myCommand.ExecuteReader();



            while (myReader.Read())
            {


                // lblIndicador.Text = myReader["idNum"].ToString();
                //   nuevaTabla(myReader["NombreCompleto"].ToString(), myReader["Usuario"].ToString(), myReader["contraseña"].ToString(), myReader["correo"].ToString(), myReader["area"].ToString(), myReader["Dependencia"].ToString(), myReader["Cargo"].ToString(), myReader["Estado"].ToString(), myReader["NombreCompleto"].ToString());
                txtNombre.Text = myReader["NombreCompleto"].ToString();
                txtUsuario.Text = myReader["Usuario"].ToString();
                txtPass.Text = myReader["contraseña"].ToString();
                txtCorreo.Text = myReader["correo"].ToString();



              
                    ddlArea.SelectedValue = myReader["area"].ToString();
                

                
                    ddlDependencia.SelectedValue = myReader["Dependencia"].ToString();
                

                if (myReader["Cargo"].ToString().Contains("Supervisor"))
                {
                    ddlCargo.SelectedValue = "Supervisor";
                }
                else if (myReader["Cargo"].ToString().Contains("Encargado")) 
                {
                    ddlCargo.SelectedValue = "Encargado";
                }

                if (myReader["Estado"].ToString().Contains("Habilitado"))
                {
                    ddlEstado.SelectedValue = "Habilitado";
                }
                else if (myReader["Estado"].ToString().Contains("Deshabilitado"))
                {
                    ddlEstado.SelectedValue = "Deshabilitado";
                }
          
            }

            con.Close();
        }


        void cargarAreas()
        {
            ddlArea.Items.Clear();
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select NombreAplicacion from aplicacion";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            

            myReader = myCommand.ExecuteReader();



            while (myReader.Read())
            {


             
                ddlArea.Items.Add(myReader["NombreAplicacion"].ToString());
               
            }

            con.Close();
        }

        void cargarDependencias(int id)
        {
            ddlDependencia.Items.Clear();
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select NombreD from dependencia where idAplicacion = @id";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@id", id));

            myReader = myCommand.ExecuteReader();


            ddlDependencia.Items.Add("Seleccione...");
            while (myReader.Read())
            {



                ddlDependencia.Items.Add(myReader["NombreD"].ToString());

            }

            con.Close();
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlArea.SelectedValue== "Administración")
            {
                cargarDependencias(1);
            }
            else if (ddlArea.SelectedValue == "Academía")
            {
                cargarDependencias(2);
            }
            else if (ddlArea.SelectedValue == "Decat")
            {
                cargarDependencias(3);
            }
            else if (ddlArea.SelectedValue == "Dpd")
            {
                cargarDependencias(4);
            }
            else if (ddlArea.SelectedValue == "Decanatura")
            {
                cargarDependencias(5);
            }
        }

        protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFiltro.SelectedValue == "Área") {
                cargarVaras("Área");
            }else if (ddlFiltro.SelectedValue == "Cargo")
            {
                cargarVaras("Cargo");
            }
           // this.MaintainScrollPositionOnPostBack = true;
        }

        void encabezado() {
            TableRow row = new TableRow();
            
            TableHeaderCell hcell1 = new TableHeaderCell();
            TableHeaderCell hcell2 = new TableHeaderCell();
            TableHeaderCell hcell3 = new TableHeaderCell();
            TableHeaderCell hcell4 = new TableHeaderCell();
            TableHeaderCell hcell5 = new TableHeaderCell();
            TableHeaderCell hcell6 = new TableHeaderCell();
            TableHeaderCell hcell7 = new TableHeaderCell();
            TableHeaderCell hcell8 = new TableHeaderCell();
            TableHeaderCell hcell9 = new TableHeaderCell();


            hcell1.Text = "Nombre completo";
            hcell2.Text = "Usuario";
            hcell3.Text = "Contraseña";
            hcell4.Text = "Correo";
            hcell5.Text = "Área";
            hcell6.Text = "Dependencia";
            hcell7.Text = "Cargo";
            hcell8.Text = "Estado";
            hcell9.Text = "Cargar";


            row.Cells.Add(hcell1);

            row.Cells.Add(hcell2);

            row.Cells.Add(hcell3);

            row.Cells.Add(hcell4);

            row.Cells.Add(hcell5);

            row.Cells.Add(hcell6);

            row.Cells.Add(hcell7);

            row.Cells.Add(hcell8);

            row.Cells.Add(hcell9);

            Table1.Rows.Add(row);
        }

        void cargarUsuarioNuevo(string nombre) 
        {
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select * from Registro where NombreCompleto = @NombreCompleto";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@NombreCompleto", nombre));

            myReader = myCommand.ExecuteReader();



            while (myReader.Read())
            {


                // lblIndicador.Text = myReader["idNum"].ToString();
                //   nuevaTabla(myReader["NombreCompleto"].ToString(), myReader["Usuario"].ToString(), myReader["contraseña"].ToString(), myReader["correo"].ToString(), myReader["area"].ToString(), myReader["Dependencia"].ToString(), myReader["Cargo"].ToString(), myReader["Estado"].ToString(), myReader["NombreCompleto"].ToString());
                txtNombre.Text = myReader["NombreCompleto"].ToString();
                txtUsuario.Text = myReader["Usuario"].ToString();
                txtPass.Text = myReader["contraseña"].ToString();
                txtCorreo.Text = myReader["correo"].ToString();

            }

            con.Close();
        }

        void enviarCorreo()
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(txtCorreo.Text);
            mail.Subject = "Bienvenido a nuestro sistema de control interno";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Bcc.Add("maikol.navarro.cascante@cuc.cr");
            mail.Body = "Bienvenido " + txtNombre.Text + ", se le ha asignado el cargo de "+ddlCargo.SelectedItem.Value + " en el departamento de "+ddlDependencia.SelectedItem.Value;
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

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select Cargo from Asignacion where Dependencia=@dep";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@dep", ddlDependencia.SelectedValue));

            myReader = myCommand.ExecuteReader();


            int cont = 0;
            string cargo = "";
            while (myReader.Read())
            {

                cargo= myReader["Cargo"].ToString();
               

                cont = cont + 1;
            }

            if (cont > 0)
            {
                ddlCargo.Enabled = false;
                btnRegistrar.Enabled = false;
                Response.Write("<script>alert('Este departamento ya está ocupado');</script>");
            }
            else 
            {
                ddlCargo.Enabled = true;
                btnRegistrar.Enabled = true;
            }

            

            con.Close();
        }
    }
}