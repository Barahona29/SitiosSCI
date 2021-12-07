using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto2APSW
{
    public partial class aperturanueva : System.Web.UI.Page
    {

        // string cone = "workstation id=sistemaCI.mssql.somee.com;packet size=4096;user id=maikol1113_SQLLogin_1;pwd=6t75jgalrt;data source=sistemaCI.mssql.somee.com;persist security info=False;initial catalog=sistemaCI";
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
                cargarVaras("Ambiente de control", 1);
                if (!IsPostBack)
                {
                    cargarModelo();
                    cargarComponentes(1);
                    cargarAreas();
                    cargarDependencias(1);

                    string cargar = Request.Params.Get("nombre");
                    cargarCodigo(cargar);
                }
                

            }
            catch (Exception ex)
            {

            }
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
            ddlDepartamento.Items.Clear();
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select NombreD from dependencia where idAplicacion = @id";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@id", id));

            myReader = myCommand.ExecuteReader();



            while (myReader.Read())
            {



                ddlDepartamento.Items.Add(myReader["NombreD"].ToString());

            }

            con.Close();
        }

        protected void ddlModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlModelo.SelectedValue == "Ambiente de control")
            {
                cargarComponentes(1);
            }
            else if (ddlModelo.SelectedValue == "Valoración de riesgo")
            {
                cargarComponentes(2);
            }
            else if (ddlModelo.SelectedValue == "Actividades de control")
            {
                cargarComponentes(3);
            }
            else if (ddlModelo.SelectedValue == "Sistema de información")
            {
                cargarComponentes(4);
            }
            else if (ddlModelo.SelectedValue == "Seguimiento de control interno")
            {
                cargarComponentes(5);
            }
        }

        protected void btnRevision_Click(object sender, EventArgs e)
        {
            Response.Redirect("solicitud.aspx");
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            //  try
            //  {
            var seed = Environment.TickCount;
            var codigo = new Random(seed);
            var value = codigo.Next(10000, 999999);
            int cod = Int32.Parse(value.ToString());

            int indicador=0;
            //método de conexión
            Conexion();


            if (ddlModelo.SelectedValue == "Ambiente de control")
            {
                if (ddlComponente.SelectedValue == "Compromiso")
                {
                    // cmdUsuario = new SqlCommand("insert into EvidenciaAmbiente values (@id, @codigo, @Nivel, @Descripción, @Estado, @Evidencia, @Cumplimiento, NULL,NULL,NULL, 0, @departamento, @inicio_de_apertura, @fin_de_apertura, @tipo_evidencia, 'En espera')", con);
                    cmdUsuario = new SqlCommand("update EvidenciaAmbiente set inicio_de_apertura=@inicio, fin_de_apertura = @fin where idambiente=@id", con);
                    cmdUsuario.Parameters.Add(new SqlParameter("@Inicio", CalendarInicio.SelectedDate));
                    cmdUsuario.Parameters.Add(new SqlParameter("@fin", CalendarFin.SelectedDate));
                    cmdUsuario.Parameters.Add(new SqlParameter("@id", 1));
                    indicador = 1;
                }
                else if (ddlComponente.SelectedValue == "Ética")
                {
                    cmdUsuario = new SqlCommand("update EvidenciaAmbiente set inicio_de_apertura=@inicio, fin_de_apertura = @fin where idambiente=@id", con);
                    cmdUsuario.Parameters.Add(new SqlParameter("@Inicio", CalendarInicio.SelectedDate));
                    cmdUsuario.Parameters.Add(new SqlParameter("@fin", CalendarFin.SelectedDate));
                    cmdUsuario.Parameters.Add(new SqlParameter("@id", 2));
                    indicador = 2;
                }
                else if (ddlComponente.SelectedValue == "Personal")
                {
                    cmdUsuario = new SqlCommand("update EvidenciaAmbiente set inicio_de_apertura=@inicio, fin_de_apertura = @fin where idambiente=@id", con);
                    cmdUsuario.Parameters.Add(new SqlParameter("@Inicio", CalendarInicio.SelectedDate));
                    cmdUsuario.Parameters.Add(new SqlParameter("@fin", CalendarFin.SelectedDate));
                    cmdUsuario.Parameters.Add(new SqlParameter("@id", 3));
                    indicador = 3;
                }
                else if (ddlComponente.SelectedValue == "Estructura")
                {
                    cmdUsuario = new SqlCommand("update EvidenciaAmbiente set inicio_de_apertura=@inicio, fin_de_apertura = @fin where idambiente=@id", con);
                    cmdUsuario.Parameters.Add(new SqlParameter("@Inicio", CalendarInicio.SelectedDate));
                    cmdUsuario.Parameters.Add(new SqlParameter("@fin", CalendarFin.SelectedDate));
                    cmdUsuario.Parameters.Add(new SqlParameter("@id", 4));
                    indicador = 4;
                }
                else if (ddlComponente.SelectedValue == "Todos")
                {
                    cmdUsuario = new SqlCommand("update EvidenciaAmbiente set inicio_de_apertura=@inicio, fin_de_apertura = @fin", con);
                    cmdUsuario.Parameters.Add(new SqlParameter("@Inicio", CalendarInicio.SelectedDate));
                    cmdUsuario.Parameters.Add(new SqlParameter("@fin", CalendarFin.SelectedDate));
                    indicador = 5;
                }

            }
            else if (ddlModelo.SelectedValue == "Valoración de riesgo")
            {
                cmdUsuario = new SqlCommand("insert into EvidenciaRiesgo values (@id, @codigo, @Nivel, @Descripción, @Estado, @Evidencia, @Cumplimiento, NULL,NULL,NULL, 0, @departamento, @inicio_de_apertura, @fin_de_apertura, @tipo_evidencia, 'En espera')", con);
                cmdUsuario.Parameters.Add(new SqlParameter("@id", 2));
            }
            else if (ddlModelo.SelectedValue == "Actividades de control")
            {
                cmdUsuario = new SqlCommand("insert into EvidenciaActividad values (@id, @codigo, @Nivel, @Descripción, @Estado, @Evidencia, @Cumplimiento, NULL,NULL,NULL, 0, @departamento, @inicio_de_apertura, @fin_de_apertura, @tipo_evidencia, 'En espera')", con);
                cmdUsuario.Parameters.Add(new SqlParameter("@id", 3));
            }
            else if (ddlModelo.SelectedValue == "Sistema de información")
            {
                cmdUsuario = new SqlCommand("insert into EvidenciaSistema values (@id, @codigo, @Nivel, @Descripción, @Estado, @Evidencia, @Cumplimiento, NULL,NULL,NULL, 0, @departamento, @inicio_de_apertura, @fin_de_apertura, @tipo_evidencia, 'En espera')", con);
                cmdUsuario.Parameters.Add(new SqlParameter("@id", 4));
            }
            else if (ddlModelo.SelectedValue == "Seguimiento de control interno")
            {
                cmdUsuario = new SqlCommand("insert into EvidenciaSeguimiento values (@id, @codigo, @Nivel, @Descripción, @Estado, @Evidencia, @Cumplimiento, NULL,NULL,NULL, 0, @departamento, @inicio_de_apertura, @fin_de_apertura, @tipo_evidencia, 'En espera')", con);
                cmdUsuario.Parameters.Add(new SqlParameter("@id", 5)); ;
            }

            cmdUsuario.Parameters.Add(new SqlParameter("@codigo", cod));
         
            cmdUsuario.Parameters.Add(new SqlParameter("@Estado", "Pendiente"));
            
            cmdUsuario.Parameters.Add(new SqlParameter("@Cumplimiento", "No"));
            
            cmdUsuario.Parameters.Add(new SqlParameter("@inicio_de_apertura", CalendarInicio.SelectedDate.ToShortDateString()));
            cmdUsuario.Parameters.Add(new SqlParameter("@fin_de_apertura", CalendarFin.SelectedDate.ToShortDateString()));
          
            cmdUsuario.ExecuteNonQuery();
            con.Close();


            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
           
            strCadSQL = "";
            if (indicador==1) 
            {
                strCadSQL = "select codigo from EvidenciaAmbiente where idAmbiente=1";
            }
            else if (indicador ==2) 
            {
                strCadSQL = "select codigo from EvidenciaAmbiente where idAmbiente=2";
            }
            else if (indicador == 3)
            {
                strCadSQL = "select codigo from EvidenciaAmbiente where idAmbiente=3";
            }
            else if (indicador == 4)
            {
                strCadSQL = "select codigo from EvidenciaAmbiente where idAmbiente=4";
            }
            else if (indicador == 5)
            {
                strCadSQL = "select codigo from EvidenciaAmbiente";
            }
            DataTable tabla = new DataTable();
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);


            SqlDataAdapter leer = new SqlDataAdapter(myCommand);
            leer.Fill(tabla);

            


            con.Close();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                
                insertarEvidenciaDep(tabla.Rows[i]["codigo"].ToString(), ddlDepartamento.SelectedItem.Value);
            }
            envioCorreo(ddlDepartamento.SelectedItem.Value);
            Response.Write("<script>alert('Apertura actualizada correctamente');</script>");



            /*  }

              catch (Exception ex)
              {

                  Response.Write("<script>alert('Error en la base de datos " + ex.Message + "');</script>");
              }*/
        }

        void insertarEvidenciaDep(string codigo,string departamento) 
        {
            Conexion();

            SqlCommand cmdComando;
            cmdComando = new SqlCommand("delete from abrirEvDep where codigoEv= @codigo and departamento=@dep", con);
            cmdComando.Parameters.Add(new SqlParameter("@codigo", codigo));
            cmdComando.Parameters.Add(new SqlParameter("@dep", departamento));

            cmdComando.ExecuteNonQuery();

            SqlCommand cmdComando2;
            cmdComando2 = new SqlCommand("insert into abrirEvDep values (@codigo, @departamento, @Inicio, @fin)", con);
            cmdComando2.Parameters.Add(new SqlParameter("@codigo", codigo));
            cmdComando2.Parameters.Add(new SqlParameter("@departamento", departamento));
            cmdComando2.Parameters.Add(new SqlParameter("@Inicio", CalendarInicio.SelectedDate));
            cmdComando2.Parameters.Add(new SqlParameter("@fin", CalendarFin.SelectedDate));
         

            cmdComando2.ExecuteNonQuery();
            con.Close();
        }

        void cargarModelo()
        {
            ddlModelo.Items.Clear();
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select nombreModelo from modelo";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);


            myReader = myCommand.ExecuteReader();



            while (myReader.Read())
            {



                ddlModelo.Items.Add(myReader["nombreModelo"].ToString());

            }

            con.Close();
        }

        void cargarComponentes(int id)
        {
            ddlComponente.Items.Clear();
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select NombreComp from componentes where idModelo = @id";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@id", id));

            myReader = myCommand.ExecuteReader();



            while (myReader.Read())
            {



                ddlComponente.Items.Add(myReader["NombreComp"].ToString());

            }
            ddlComponente.Items.Add("Todos");

            con.Close();
        }

        void cargarVaras(string modelo, int componente)
        {
            Table1.Rows.Clear();
            encabezado();
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "";
            if (modelo == "Ambiente de control")
            {
                strCadSQL = "select * from EvidenciaAmbiente where idambiente = @id";
            }
            else if (modelo == "Valoración de riesgo")
            {
                strCadSQL = "select * from EvidenciaRiesgo where idriesgo = @id";
            }
            else if (modelo == "Actividades de control")
            {
                strCadSQL = "select * from EvidenciaActividad where idactividad = @id";
            }
            else if (modelo == "Sistema de información")
            {
                strCadSQL = "select * from EvidenciaSistema where idsistema = @id";
            }
            else if (modelo == "Seguimiento de control interno")
            {
                strCadSQL = "select * from EvidenciaSeguimiento where idseguimiento = @id";
            }


            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@id", componente));
            myReader = myCommand.ExecuteReader();




            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            while (myReader.Read())
            {

                string fechainicio = myReader["inicio_de_apertura"].ToString();


                string fechafin = myReader["fin_de_apertura"].ToString();


                DateTime fechaAct = DateTime.Now;

                DateTime fechaini = Convert.ToDateTime(fechainicio, System.Globalization.CultureInfo.GetCultureInfo("en-GB").DateTimeFormat);

                DateTime fechaf = Convert.ToDateTime(fechafin, System.Globalization.CultureInfo.GetCultureInfo("en-GB").DateTimeFormat);


                if (fechaAct >= fechaini && fechaAct <= fechaf)
                {
                    nuevaTabla(myReader["codigo"].ToString(), myReader["Nivel"].ToString(), myReader["Descripción"].ToString(), myReader["Evidencia"].ToString(), "Activo", myReader["inicio_de_apertura"].ToString(), myReader["fin_de_apertura"].ToString(), myReader["tipo_evidencia"].ToString(), myReader["codigo"].ToString());

                }
                else 
                {
                    nuevaTabla(myReader["codigo"].ToString(), myReader["Nivel"].ToString(), myReader["Descripción"].ToString(), myReader["Evidencia"].ToString(), "Inactivo", myReader["inicio_de_apertura"].ToString(), myReader["fin_de_apertura"].ToString(), myReader["tipo_evidencia"].ToString(), myReader["codigo"].ToString());

                }



            }

            con.Close();
        }

        void cargarToadasLasVaras(string modelo)
        {
            Table1.Rows.Clear();
            encabezado();
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "";
            if (modelo == "Ambiente de control")
            {
                strCadSQL = "select * from EvidenciaAmbiente";
            }
            else if (modelo == "Valoración de riesgo")
            {
                strCadSQL = "select * from EvidenciaRiesgo";
            }
            else if (modelo == "Actividades de control")
            {
                strCadSQL = "select * from EvidenciaActividad";
            }
            else if (modelo == "Sistema de información")
            {
                strCadSQL = "select * from EvidenciaSistema";
            }
            else if (modelo == "Seguimiento de control interno")
            {
                strCadSQL = "select * from EvidenciaSeguimiento";
            }


            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
   
            myReader = myCommand.ExecuteReader();




            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            while (myReader.Read())
            {

                string fechainicio = myReader["inicio_de_apertura"].ToString();


                string fechafin = myReader["fin_de_apertura"].ToString();


                DateTime fechaAct = DateTime.Now;

                DateTime fechaini = Convert.ToDateTime(fechainicio, System.Globalization.CultureInfo.GetCultureInfo("en-GB").DateTimeFormat);

                DateTime fechaf = Convert.ToDateTime(fechafin, System.Globalization.CultureInfo.GetCultureInfo("en-GB").DateTimeFormat);


                if (fechaAct >= fechaini && fechaAct <= fechaf)
                {
                    nuevaTabla(myReader["codigo"].ToString(), myReader["Nivel"].ToString(), myReader["Descripción"].ToString(), myReader["Evidencia"].ToString(), "Activo", myReader["inicio_de_apertura"].ToString(), myReader["fin_de_apertura"].ToString(), myReader["tipo_evidencia"].ToString(), myReader["codigo"].ToString());

                }
                else
                {
                    nuevaTabla(myReader["codigo"].ToString(), myReader["Nivel"].ToString(), myReader["Descripción"].ToString(), myReader["Evidencia"].ToString(), "Inactivo", myReader["inicio_de_apertura"].ToString(), myReader["fin_de_apertura"].ToString(), myReader["tipo_evidencia"].ToString(), myReader["codigo"].ToString());

                }



            }

            con.Close();
        }
        void nuevaTabla(string codigo, string Nivel, string Descripcion, string Evidencia, string Estado, string inicio_de_apertura, string fin_de_apertura, string tipo_evidencia, string titulo)
        {



            TableRow row2 = new TableRow();


            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            TableCell cell4 = new TableCell();
            TableCell cell5 = new TableCell();
            TableCell cell7 = new TableCell();
            TableCell cell8 = new TableCell();
            TableCell cell81 = new TableCell();
           


            cell1.Text = codigo;
            cell2.Text = Nivel;
            cell3.Text = Descripcion;
            cell4.Text = Evidencia;
            cell5.Text = Estado;
            
            cell7.Text = inicio_de_apertura;
            cell8.Text = fin_de_apertura;
            cell81.Text = tipo_evidencia;
          

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

            

            row2.Cells.Add(cell7);

            row2.Cells.Add(cell8);

            row2.Cells.Add(cell81);

            row2.Cells.Add(cell9);

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
            
            TableHeaderCell hcell7 = new TableHeaderCell();
            TableHeaderCell hcell8 = new TableHeaderCell();
            TableHeaderCell hcell81 = new TableHeaderCell();
            TableHeaderCell hcell9 = new TableHeaderCell();




            hcell1.Text = "Código";
            hcell2.Text = "Nivel";
            hcell3.Text = "Descripción";
            hcell4.Text = "Evidencia";
            hcell5.Text = "Estado";
            hcell7.Text = "Inicio";
            hcell8.Text = "Fin";
            hcell81.Text = "Tipo";
            hcell9.Text = "Cargar";

            row.Cells.Add(hcell1);

            row.Cells.Add(hcell2);

            row.Cells.Add(hcell3);

            row.Cells.Add(hcell4);

            row.Cells.Add(hcell5);

            row.Cells.Add(hcell7);

            row.Cells.Add(hcell8);

            row.Cells.Add(hcell81);

            row.Cells.Add(hcell9);

            Table1.Rows.Add(row);
        }

        protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            /* if (ddlFiltro.SelectedValue == "Ambiente de control")
             {
                 cargarVaras("Ambiente");
             }
             else if (ddlFiltro.SelectedValue == "Valoración de riesgo")
             {
                 cargarVaras("Riesgos");
             }
             else if (ddlFiltro.SelectedValue == "Actividades de control")
             {
                 cargarVaras("Actividades");
             }
             else if (ddlFiltro.SelectedValue == "Sistema de información")
             {
                 cargarVaras("Sistema");
             }
             else if (ddlFiltro.SelectedValue == "Seguimiento de CI")
             {
                 cargarVaras("Seguimiento");
             }*/
        }

        void cargarCodigo(string codigo)
        {
            Conexion();
            string strCadSQL = "";


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            if (ddlFiltro.SelectedValue == "Ambiente de control")
            {
                strCadSQL = "select * from EvidenciaAmbiente where codigo = @codigo";
            }
            else if (ddlFiltro.SelectedValue == "Valoración de riesgo")
            {
                strCadSQL = "select * from EvidenciaRiesgo where codigo = @codigo";
            }
            else if (ddlFiltro.SelectedValue == "Actividades de control")
            {
                strCadSQL = "select * from EvidenciaActividad where codigo = @codigo";
            }
            else if (ddlFiltro.SelectedValue == "Sistema de información")
            {
                strCadSQL = "select * from EvidenciaSistema where codigo = @codigo";
            }
            else if (ddlFiltro.SelectedValue == "Seguimiento de CI")
            {
                strCadSQL = "select * from EvidenciaSeguimiento where codigo = @codigo";
            }

            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@codigo", codigo));

            myReader = myCommand.ExecuteReader();



            while (myReader.Read())
            {


              //  txtDescripción.Text = myReader["Descripción"].ToString();
              //  txtEvidencia.Text = myReader["Evidencia"].ToString();

              //  ddlDependencia.SelectedValue = myReader["departamento"].ToString();






                if (ddlFiltro.SelectedValue == "Ambiente de control")
                {
                    ddlModelo.SelectedValue = "Ambiente de control";
                    if (myReader["idambiente"].ToString() == "1")
                    {
                        ddlComponente.SelectedValue = "Compromiso";
                    }
                    else if (myReader["idambiente"].ToString() == "2")
                    {
                        ddlComponente.SelectedValue = "Ética";
                    }
                    else if (myReader["idambiente"].ToString() == "3")
                    {
                        ddlComponente.SelectedValue = "Personal";
                    }
                    else if (myReader["idambiente"].ToString() == "4")
                    {
                        ddlComponente.SelectedValue = "Estructura";
                    }
                }
                else if (ddlFiltro.SelectedValue == "Valoración de riesgo")
                {
                    ddlModelo.SelectedValue = "Valoración de riesgo";
                }
                else if (ddlFiltro.SelectedValue == "Actividades de control")
                {
                    ddlModelo.SelectedValue = "Actividades de control";
                }
                else if (ddlFiltro.SelectedValue == "Sistema de información")
                {
                    ddlModelo.SelectedValue = "Sistema de información";
                }
                else if (ddlFiltro.SelectedValue == "Seguimiento de CI")
                {
                    ddlModelo.SelectedValue = "Seguimiento de control interno";
                }



             //   ddlTipo.SelectedValue = myReader["tipo_evidencia"].ToString();

              //  ddlNivel.SelectedValue = myReader["Nivel"].ToString();


                btnModificar.Visible = true;

             //   ddlArea.SelectedValue = consultaArea(myReader["departamento"].ToString());

            }

            con.Close();


        }

        public string consultaArea(string departamento)
        {


            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select NombreAplicacion from aplicacion a, dependencia d where d.idAplicacion = a.idAplicacion and d.NombreD = @id";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@id", departamento));

            myReader = myCommand.ExecuteReader();

            string dato = "";

            while (myReader.Read())
            {



                dato = myReader["NombreAplicacion"].ToString();

            }

            return dato;
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            /*------------------------------------tabla 1-------------------------*/
            DataTable dt = new DataTable();
            Document documento = new Document();
            PdfWriter escribir = PdfWriter.GetInstance(documento, HttpContext.Current.Response.OutputStream);
            dt = cargarReporte();
            documento.Open();
            if (dt.Rows.Count > 0)
            {

                Font fontTitle = FontFactory.GetFont(FontFactory.COURIER_BOLD, 30);
                Font font9 = FontFactory.GetFont(FontFactory.TIMES, 10);


                PdfPTable table = new PdfPTable(dt.Columns.Count);
                documento.Add(new Paragraph(20, "Evidencias abiertas", fontTitle));
                documento.Add(new Chunk("\n"));

                float[] widths = new float[dt.Columns.Count];
                for (int i = 0; i < dt.Columns.Count; i++)
                    widths[i] = 4f;
                table.SetWidths(widths);
                table.WidthPercentage = 90;

                PdfPCell cell = new PdfPCell(new Phrase("columns"));
                cell.Colspan = dt.Columns.Count;

                foreach (DataColumn c in dt.Columns)
                {
                    table.AddCell(new Phrase(c.ColumnName, font9));
                }

                foreach (DataRow r in dt.Rows)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int h = 0; h < dt.Columns.Count; h++)
                        {
                            table.AddCell(new Phrase(r[h].ToString(), font9));
                        }

                    }
                }
                documento.Add(table);


            }

            /*------------------------------------tabla 1-------------------------*/



            documento.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Apertura.pdf");
            HttpContext.Current.Response.Write(documento);

            Response.Flush();
            Response.End();

        }

        public DataTable cargarReporte()
        {
            string valores = Request.Params.Get("valor");
            string[] parametros = valores.Split(';');
            Conexion();
            DataTable tabla = new DataTable();
            cmdUsuario = new SqlCommand("select * from abrirEvDep", con);


            SqlDataAdapter leer = new SqlDataAdapter(cmdUsuario);
            leer.Fill(tabla);
            con.Close();
            return tabla;
        }

        protected void ddlComponente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlComponente.SelectedIndex == 4)
            {
                cargarToadasLasVaras(ddlModelo.SelectedItem.Value.ToString());
            }
            else
            {
                cargarVaras(ddlModelo.SelectedItem.Value.ToString(), ddlComponente.SelectedIndex + 1);
            }
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlArea.SelectedValue == "Administración")
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

        void correo(string correo, string nombre) 
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(correo);
            mail.Subject = "Nueva apertura";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Bcc.Add("maikol.navarro.cascante@cuc.cr");
            mail.Body = "Hola "+nombre+", se ha añadido una nueva apertura disponible del "+CalendarInicio.SelectedDate.ToShortDateString()+" a " + CalendarFin.SelectedDate.ToShortDateString() +" en el modelo de "+ddlModelo.SelectedItem.Value+", componente: "+ddlComponente.SelectedItem.Value;
            mail.BodyEncoding = System.Text.Encoding.UTF8; 
            mail.IsBodyHtml = true;
            mail.From = new MailAddress("fiscalizadorsci@gmail.com");


            mail.To.Add(new MailAddress(correo)); // quien lo va a recibir
            mail.Subject = "Nueva apertura"; // asunto


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

        void envioCorreo(string dep) 
        {
            Conexion();
            DataTable tabla = new DataTable();
            cmdUsuario = new SqlCommand("select * from Asignacion ap where ap.Dependencia = @dep", con);

            cmdUsuario.Parameters.Add(new SqlParameter("@dep", dep));
           
            SqlDataAdapter leer = new SqlDataAdapter(cmdUsuario);
            leer.Fill(tabla);
            con.Close();

           string corre= tabla.Rows[0]["correo"].ToString();
            string nombre = tabla.Rows[0]["NombreCompleto"].ToString();

            correo(corre,nombre);
        }
    }
}