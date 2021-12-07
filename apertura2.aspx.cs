using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto2APSW
{
    public partial class apertura2 : System.Web.UI.Page
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
            cargarVaras("Ambiente");
            try
            {
                
                if (!IsPostBack)
                {
                   // cargarAreas();
                  //  cargarDependencias(1);
                    cargarModelo();
                   // cargarComponentes(1);
                   
                    
                    string cargar = Request.Params.Get("nombre");
                    string[] datoss = cargar.Split(';');
                    cargarCodigo(datoss[0], datoss[1]);
                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnRevision_Click(object sender, EventArgs e)
        {
            Response.Redirect("solicitud.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Conexion();


            if (ddlModelo.SelectedValue == "Ambiente de control")
            {
                cmdUsuario = new SqlCommand("update EvidenciaAmbiente set Descripción= @Descripción, Estado= @Estado, Evidencia= @Evidencia, tipo_evidencia= @tipo_evidencia where codigo=@codigo", con);

            }
            else if (ddlModelo.SelectedValue == "Valoración de riesgo")
            {
                cmdUsuario = new SqlCommand("update EvidenciaRiesgo set Descripción= @Descripción, Estado= @Estado, Evidencia= @Evidencia, tipo_evidencia= @tipo_evidencia where codigo=@codigo", con);

            }
            else if (ddlModelo.SelectedValue == "Actividades de control")
            {
                cmdUsuario = new SqlCommand("update EvidenciaActividad set  Descripción= @Descripción, Estado= @Estado, Evidencia= @Evidencia, tipo_evidencia= @tipo_evidencia where codigo=@codigo", con);

            }
            else if (ddlModelo.SelectedValue == "Sistema de información")
            {
                cmdUsuario = new SqlCommand("update EvidenciaSistema set Descripción= @Descripción, Estado= @Estado, Evidencia= @Evidencia, tipo_evidencia= @tipo_evidencia where codigo=@codigo", con);

            }
            else if (ddlModelo.SelectedValue == "Seguimiento de control interno")
            {
                cmdUsuario = new SqlCommand("update EvidenciaSeguimiento set  Descripción= @Descripción, Estado= @Estado, Evidencia= @Evidencia, tipo_evidencia= @tipo_evidencia where codigo=@codigo", con);

            }

            string cod = Request.Params.Get("nombre");
            cmdUsuario.Parameters.Add(new SqlParameter("@codigo", cod));
            
            cmdUsuario.Parameters.Add(new SqlParameter("@Descripción", txtDescripción.Text));
            cmdUsuario.Parameters.Add(new SqlParameter("@Estado", "Pendiente"));
            cmdUsuario.Parameters.Add(new SqlParameter("@Evidencia", txtEvidencia.Text));
           
            cmdUsuario.Parameters.Add(new SqlParameter("@tipo_evidencia", ddlTipo.SelectedItem.Value));

            cmdUsuario.ExecuteNonQuery();
            con.Close();

            cargarVaras("Ambiente");
            btnModificar.Visible = false;
            Response.Write("<script>alert('Apertura modificada correctamente');</script>");

        }

       /* void cargarAreas()
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
        }*/

       /* void cargarDependencias(int id)
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



            while (myReader.Read())
            {



                ddlDependencia.Items.Add(myReader["NombreD"].ToString());

            }

            con.Close();
        }*/

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  if (ddlArea.SelectedValue == "Administración")
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
            }*/
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

   /*     void cargarComponentes(int id)
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

            con.Close();
        }*/

      

        protected void ddlModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
          /*  if (ddlModelo.SelectedValue == "Ambiente de control")
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
            }*/
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
            if (indicador == "Ambiente")
            {
                strCadSQL = "select aed.codigoEv, ea.Nivel, ea.Descripción, ea.Evidencia, ea.tipo_evidencia, aed.inicio, aed.fin from EvidenciaAmbiente ea, abrirEvDep aed where aed.codigoEv=ea.codigo";
            }
            else if (indicador == "Riesgos")
            {
                strCadSQL = "select * from EvidenciaRiesgo";
            }
            else if (indicador == "Actividades")
            {
                strCadSQL = "select * from EvidenciaActividad";
            }
            else if (indicador == "Sistema")
            {
                strCadSQL = "select * from EvidenciaSistema";
            }
            else if (indicador == "Seguimiento")
            {
                strCadSQL = "select * from EvidenciaSeguimiento";
            }

            SqlCommand myCommand = new SqlCommand(strCadSQL, con);


            myReader = myCommand.ExecuteReader();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");

            while (myReader.Read())
            {


                string fechainicio = myReader["inicio"].ToString();


                string fechafin = myReader["fin"].ToString();


                DateTime fechaAct = DateTime.Now;

                DateTime fechaini = Convert.ToDateTime(fechainicio, System.Globalization.CultureInfo.GetCultureInfo("en-GB").DateTimeFormat);

                DateTime fechaf = Convert.ToDateTime(fechafin, System.Globalization.CultureInfo.GetCultureInfo("en-GB").DateTimeFormat);


                if (fechaAct >= fechaini && fechaAct <= fechaf)
                {
                    nuevaTabla(myReader["codigoEv"].ToString(), myReader["Nivel"].ToString(), myReader["Descripción"].ToString(), myReader["Evidencia"].ToString(), myReader["inicio"].ToString(), myReader["fin"].ToString(), myReader["tipo_evidencia"].ToString(), "Sí", myReader["codigoEv"].ToString(), "Abierto");

                }
                else 
                {
                    nuevaTabla(myReader["codigoEv"].ToString(), myReader["Nivel"].ToString(), myReader["Descripción"].ToString(), myReader["Evidencia"].ToString(), "", "", myReader["tipo_evidencia"].ToString(), "Sí", myReader["codigoEv"].ToString(), "Cerrado");

                }

            }

            con.Close();






            Conexion();
            string strCadSQL2;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader2 = null;
            strCadSQL2 = "";
            if (indicador == "Ambiente")
            {
                strCadSQL2 = "select distinct ea.idevidenciaambiente, ea.codigo, ea.Nivel, ea.Descripción, ea.Evidencia, ea.tipo_evidencia, ea.inicio_de_apertura, ea.fin_de_apertura from EvidenciaAmbiente ea, abrirEvDep aed where ea.codigo not in (select eva.codigoEv from abrirEvDep eva) order by ea.idevidenciaambiente";
            }
            else if (indicador == "Riesgos")
            {
                strCadSQL2 = "select * from EvidenciaRiesgo";
            }
            else if (indicador == "Actividades")
            {
                strCadSQL2 = "select * from EvidenciaActividad";
            }
            else if (indicador == "Sistema")
            {
                strCadSQL2 = "select * from EvidenciaSistema";
            }
            else if (indicador == "Seguimiento")
            {
                strCadSQL2 = "select * from EvidenciaSeguimiento";
            }

            SqlCommand myCommand2 = new SqlCommand(strCadSQL2, con);


            myReader2 = myCommand2.ExecuteReader();

            
            while (myReader2.Read())
            {


                

             

               
                    nuevaTabla(myReader2["codigo"].ToString(), myReader2["Nivel"].ToString(), myReader2["Descripción"].ToString(), myReader2["Evidencia"].ToString(), "", "", myReader2["tipo_evidencia"].ToString(), "Sí", myReader2["codigo"].ToString(), "Cerrado");

                

            }

            con.Close();
        }
        void nuevaTabla(string codigo, string Nivel, string Descripcion, string Evidencia, string inicio_de_apertura, string fin_de_apertura, string tipo_evidencia, string habilitado, string titulo, string indicador)
        {



            TableRow row2 = new TableRow();


            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            TableCell cell4 = new TableCell();
            TableCell cell7 = new TableCell();
            TableCell cell8 = new TableCell();
            TableCell cell81 = new TableCell();
            TableCell cell82 = new TableCell();


            cell1.Text = codigo;
            cell2.Text = Nivel;
            cell3.Text = Descripcion;
            cell4.Text = Evidencia;
            cell7.Text = inicio_de_apertura;
            cell8.Text = fin_de_apertura;
            cell81.Text = tipo_evidencia;
            cell82.Text = habilitado;

            Button btn1 = new Button();





            System.Web.UI.WebControls.HyperLink hyp = new HyperLink();
            System.Web.UI.WebControls.Button btn2 = new Button();

            Literal lit = new Literal();
            //  lit.Text = "<input type='Button' ID='Button"+contador+"' value='Eliminar' />";
            if (indicador == "Abierto")
            {
                lit.Text = "<button name='" + titulo + "' onclick='cargar2(this)' style='  border: none; color: white; text-align: center; text - decoration: none; display: inline-block; margin: 4px 2px; transition-duration: 0.4s; cursor: pointer; border-radius: 5px; background-color: black; font-size: 17px; ' type='button'>Cargar</button>";

            }
            else 
            {
                lit.Text = "<button name='" + titulo + "' onclick='cargar(this)' style='  border: none; color: white; text-align: center; text - decoration: none; display: inline-block; margin: 4px 2px; transition-duration: 0.4s; cursor: pointer; border-radius: 5px; background-color: black; font-size: 17px; ' type='button'>Cargar</button>";

            }

            //  lit.Text = "<input type='Button' ID='Button"+contador+"' value='Eliminar' />";







            TableCell cell9 = new TableCell();
            cell9.Controls.Add(lit);




            row2.Cells.Add(cell1);

            row2.Cells.Add(cell2);

            row2.Cells.Add(cell3);

            row2.Cells.Add(cell4);

            row2.Cells.Add(cell7);

            row2.Cells.Add(cell8);

            row2.Cells.Add(cell81);

            row2.Cells.Add(cell82);

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
            TableHeaderCell hcell7 = new TableHeaderCell();
            TableHeaderCell hcell8 = new TableHeaderCell();
            TableHeaderCell hcell81 = new TableHeaderCell();
            TableHeaderCell hcell82 = new TableHeaderCell();
            TableHeaderCell hcell9 = new TableHeaderCell();




            hcell1.Text = "Código";
            hcell2.Text = "Nivel";
            hcell3.Text = "Descripción";
            hcell4.Text = "Evidencia";
            hcell7.Text = "Inicio";
            hcell8.Text = "Fin";
            hcell81.Text = "Tipo";
            hcell82.Text = "Habilitado";
            hcell9.Text = "Cargar";

            row.Cells.Add(hcell1);

            row.Cells.Add(hcell2);

            row.Cells.Add(hcell3);

            row.Cells.Add(hcell4);

            row.Cells.Add(hcell7);

            row.Cells.Add(hcell8);

            row.Cells.Add(hcell81);

            row.Cells.Add(hcell82);

            row.Cells.Add(hcell9);

            Table1.Rows.Add(row);
        }

        protected void ddlFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFiltro.SelectedValue == "Ambiente de control")
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
            }
        }

        void cargarCodigo(string codigo, string ind)
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


                txtDescripción.Text = myReader["Descripción"].ToString();
                txtEvidencia.Text = myReader["Evidencia"].ToString();

              //  ddlDependencia.SelectedValue = myReader["departamento"].ToString();






                if (ddlFiltro.SelectedValue == "Ambiente de control")
                {
                    ddlModelo.SelectedValue = "Ambiente de control";
                    /*  if (myReader["idambiente"].ToString() == "1")
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
                      }*/
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



                ddlTipo.SelectedValue = myReader["tipo_evidencia"].ToString();

                

               
                btnModificar.Visible = true;
                if (ind== "Abierto") 
                {
                    txtDescripción.Enabled = false;
                    txtEvidencia.Enabled = false;
                }else if (ind == "Cerrado")
                {
                    txtDescripción.Enabled = true;
                    txtEvidencia.Enabled = true;
                }

                //  ddlArea.SelectedValue = consultaArea(myReader["departamento"].ToString());

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
                documento.Add(new Paragraph(20, "Evidencia ambiente", fontTitle));
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
          
            Conexion();
            DataTable tabla = new DataTable();
            cmdUsuario = new SqlCommand("select comp.NombreComp, ea.codigo, ea.nivel, ea.Descripción,ea.Evidencia, ea.tipo_evidencia from EvidenciaAmbiente ea, componentes comp where idModelo=1 and ea.idambiente=comp.idcompxmodelo", con);


            SqlDataAdapter leer = new SqlDataAdapter(cmdUsuario);
            leer.Fill(tabla);
            con.Close();
            return tabla;
        }


    }
}
