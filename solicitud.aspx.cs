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
    public partial class solicitud : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                string valores = Request.Params.Get("valor");
                cargarTarjetas(1);
                cargarVaras(1);
                consultaIndicad1();
                consultaIndicad2();
                consultaIndicad3();
            }

        }

        void cargarTarjetas( int indicad)
        {
       
           
            Conexion();
            string strCadSQL="";

            int contador = 0;
            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            if (indicad==1) {
                strCadSQL = "select distinct evam.codigo, evam.Descripción, evam.Evidencia,aed.inicio, aed.fin, entrev.departamento from EvidenciaAmbiente evam, entregaEvidencias entrev, abrirEvDep aed where evam.codigo=entrev.codigo and entrev.estado='Entregado' order by evam.codigo desc";

            }else if (indicad == 2)
            {
                strCadSQL = "select distinct evam.codigo, evam.Descripción, evam.Evidencia,aed.inicio, aed.fin, entrev.departamento from EvidenciaAmbiente evam, entregaEvidencias entrev, abrirEvDep aed where evam.codigo=entrev.codigo and entrev.estado='Aceptado' order by evam.codigo desc";

            }
            else if (indicad == 3)
            {
                strCadSQL = "select distinct evam.codigo, evam.Descripción, evam.Evidencia,aed.inicio, aed.fin, entrev.departamento from EvidenciaAmbiente evam, entregaEvidencias entrev, abrirEvDep aed where evam.codigo=entrev.codigo and entrev.estado='Rechazado' order by evam.codigo desc";

            }
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
          

            myReader = myCommand.ExecuteReader();

            string codigo = "";

            while (myReader.Read())
            {
                
                if (contador == 0)
                {
                    lblCodigo1.Text = myReader["codigo"].ToString();
                    lblDescripcion.Text = myReader["Descripción"].ToString().Substring(0, 50) + "...";
                    lblEvidencia.Text = myReader["Evidencia"].ToString().Substring(0, 97) + "...";
                    lblInicio.Text = myReader["inicio"].ToString();
                    lblFin.Text = myReader["fin"].ToString();
                    lblDepartamento.Text = myReader["departamento"].ToString();

                    btnAprobar1.Visible = true;
                    btnRechazar1.Visible = true;
                    btnDescargar.Visible = true;
                    
                }

                if (contador == 2)
                {
                    lblCodigo2.Text = myReader["codigo"].ToString();
                    lblDescripcion2.Text = myReader["Descripción"].ToString().Substring(0, 50) + "...";
                    lblEvidencia2.Text = myReader["Evidencia"].ToString().Substring(0, 97) + "...";
                    lblInicio2.Text = myReader["inicio"].ToString();
                    lblFin2.Text = myReader["fin"].ToString();
                    lblDepartamento2.Text = myReader["departamento"].ToString();
               
                    btnAprobar2.Visible = true;
                    btnRechazar2.Visible = true;
                    btnDescargar2.Visible = true;
                    
                }

                if (contador == 4)
                {
                    lblCodigo3.Text = myReader["codigo"].ToString();
                    lblDescripcion3.Text = myReader["Descripción"].ToString().Substring(0, 50) + "...";
                    lblEvidencia3.Text = myReader["Evidencia"].ToString().Substring(0, 97) + "...";
                    lblInicio3.Text = myReader["inicio"].ToString();
                    lblFin3.Text = myReader["fin"].ToString();
                    lblDepartamento3.Text = myReader["departamento"].ToString();
               
                    btnAprobar3.Visible = true;
                    btnRechazar3.Visible = true;
                    btnDescargar3.Visible = true;
                }
               
                    contador = contador + 1;
                
                codigo = myReader["codigo"].ToString();

            }

            con.Close();
            if (lblCodigo1.Text == "Label")
            {
                lblCodigo1.Text = "Sin evidencia";
                lblDescripcion.Text = "";
                lblEvidencia.Text = "";
                lblInicio.Text = "";
                lblFin.Text = "";
                lblDepartamento.Text = "";
                lblModelo.Text = "";
                lblArea.Text = "";
                lblComponente.Text = "";
                btnAprobar1.Visible = false;
                btnRechazar1.Visible = false;
                btnDescargar.Visible = false;

            }
            if (lblCodigo2.Text == "Label")
            {
                lblCodigo2.Text = "Sin evidencia";
                lblDescripcion2.Text = "";
                lblEvidencia2.Text = "";
                lblInicio2.Text = "";
                lblFin2.Text = "";
                lblDepartamento2.Text = "";
                lblModelo2.Text = "";
                lblArea2.Text = "";
                lblComponente2.Text = "";
                btnAprobar2.Visible = false;
                btnRechazar2.Visible = false;
                btnDescargar2.Visible = false;

            }
            if (lblCodigo3.Text == "Label")
            {
                lblCodigo3.Text = "Sin evidencia";
                lblDescripcion3.Text = "";
                lblEvidencia3.Text = "";
                lblInicio3.Text = "";
                lblFin3.Text = "";
                lblDepartamento3.Text = "";
                lblModelo3.Text = "";
                lblArea3.Text = "";
                lblComponente3.Text = "";
                btnAprobar3.Visible = false;
                btnRechazar3.Visible = false;
                btnDescargar3.Visible = false;
            }
        }

        protected void btnAprobar1_Click(object sender, EventArgs e)
        {
            try
            {
                //método de conexión

                Conexion();

                cmdUsuario = new SqlCommand("update entregaEvidencias set Estado = 'Aceptado', puntaje = 20  where codigo=@cod", con);
                cmdUsuario.Parameters.Add(new SqlParameter("@cod", lblCodigo1.Text));

                cmdUsuario.ExecuteNonQuery();
                con.Close();


                Response.Redirect("solicitud.aspx/?valor=Fiscalizador");
               


            }
            //en caso de error se muestra un mensaje
            catch (Exception ex)
            {

                Response.Write("<script>alert('Error en la base de datos " + ex.Message + "');</script>");
            }
        }

        protected void btnRechazar1_Click(object sender, EventArgs e)
        {
            try
            {
                //método de conexión

                Conexion();

                cmdUsuario = new SqlCommand("update entregaEvidencias set Estado = 'Rechazado', puntaje = 0  where codigo=@cod", con);
                cmdUsuario.Parameters.Add(new SqlParameter("@cod", lblCodigo1.Text));

                cmdUsuario.ExecuteNonQuery();
                con.Close();


                Response.Redirect("solicitud.aspx/?valor=Fiscalizador");


            }
            //en caso de error se muestra un mensaje
            catch (Exception ex)
            {

                Response.Write("<script>alert('Error en la base de datos " + ex.Message + "');</script>");
            }
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select * from entregaEvidencias where codigo=@cod";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@cod", lblCodigo1.Text));

            myReader = myCommand.ExecuteReader();



            while (myReader.Read())
            {
                if (!myReader["link"].ToString().Equals(""))
                {
                    Response.Redirect(myReader["link"].ToString());
                }
                else
                {
                   // descargar(lblCodigo1.Text);
                }





            }

            con.Close();
        }

        protected void btnDescargar2_Click(object sender, EventArgs e)
        {
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select * from entregaEvidencias where codigo=@cod";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@cod", lblCodigo2.Text));

            myReader = myCommand.ExecuteReader();



            while (myReader.Read())
            {
                if (!myReader["link"].ToString().Equals(""))
                {
                    Response.Redirect(myReader["link"].ToString());
                }
                else
                {
              //      descargar(lblCodigo2.Text);
                }





            }

            con.Close();
        }

        protected void btnDescargar3_Click(object sender, EventArgs e)
        {
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select * from entregaEvidencias where codigo=@cod";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@cod", lblCodigo3.Text));

            myReader = myCommand.ExecuteReader();



            while (myReader.Read())
            {
                if (!myReader["link"].ToString().Equals(""))
                {
                    Response.Redirect(myReader["link"].ToString());
                }
                else
                {
                  //  descargar(lblCodigo3.Text);
                }

            }

            con.Close();
        }

        void descargar(string id)
        {

            byte[] bytes;
            string fileName, contentType;
            string constr = "workstation id=SistemaCI.mssql.somee.com;packet size=4096;user id=maikol1113_SQLLogin_1;pwd=6t75jgalrt;data source=SistemaCI.mssql.somee.com;persist security info=False;initial catalog=SistemaCI";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select codigo, archivo, tipoarchivo from EvidenciaAmbiente where codigo=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();
                        bytes = (byte[])sdr["archivo"];
                        contentType = sdr["tipoarchivo"].ToString();
                        fileName = sdr["codigo"].ToString() + "." + sdr["tipoarchivo"].ToString();
                    }
                    con.Close();
                }
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }

        protected void btnAprobar2_Click(object sender, EventArgs e)
        {
            try
            {
                //método de conexión

                Conexion();

                cmdUsuario = new SqlCommand("update entregaEvidencias set Estado = 'Aceptado', puntaje = 20  where codigo=@cod", con);
                cmdUsuario.Parameters.Add(new SqlParameter("@cod", lblCodigo2.Text));

                cmdUsuario.ExecuteNonQuery();
                con.Close();
                string valores = Request.Params.Get("valor");
             
                cargarTarjetas(1);

                Response.Redirect("solicitud.aspx?valor=" + valores);




            }
            //en caso de error se muestra un mensaje
            catch (Exception ex)
            {

                Response.Write("<script>alert('Error en la base de datos " + ex.Message + "');</script>");
            }
        }

        protected void btnRechazar2_Click(object sender, EventArgs e)
        {
            try
            {
                //método de conexión

                Conexion();

                cmdUsuario = new SqlCommand("update entregaEvidencias set Estado = 'Rechazado', puntaje = 0 where codigo=@cod", con);
                cmdUsuario.Parameters.Add(new SqlParameter("@cod", lblCodigo2.Text));

                cmdUsuario.ExecuteNonQuery();
                con.Close();
                string valores = Request.Params.Get("valor");
                
                cargarTarjetas(1);

                Response.Redirect("solicitud.aspx?valor=" + valores);
            }
            //en caso de error se muestra un mensaje
            catch (Exception ex)
            {

                Response.Write("<script>alert('Error en la base de datos " + ex.Message + "');</script>");
            }
        }

        protected void btnAprobar3_Click(object sender, EventArgs e)
        {
            try
            {
                //método de conexión

                Conexion();

                cmdUsuario = new SqlCommand("update entregaEvidencias set Estado = 'Aceptado', puntaje = 20  where codigo=@cod", con);
                cmdUsuario.Parameters.Add(new SqlParameter("@cod", lblCodigo3.Text));

                cmdUsuario.ExecuteNonQuery();
                con.Close();
                string valores = Request.Params.Get("valor");
                
                cargarTarjetas(1);

                Response.Redirect("solicitud.aspx?valor=" + valores);



            }
            //en caso de error se muestra un mensaje
            catch (Exception ex)
            {

                Response.Write("<script>alert('Error en la base de datos " + ex.Message + "');</script>");
            }
        }

        protected void btnRechazar3_Click(object sender, EventArgs e)
        {
            try
            {
                //método de conexión

                Conexion();

                cmdUsuario = new SqlCommand("update entregaEvidencias set Estado = 'Rechazado', puntaje = 0  where codigo=@cod", con);
                cmdUsuario.Parameters.Add(new SqlParameter("@cod", lblCodigo3.Text));

                cmdUsuario.ExecuteNonQuery();
                con.Close();
                string valores = Request.Params.Get("valor");
                
                cargarTarjetas(1);

                Response.Redirect("solicitud.aspx?valor=" + valores);
            }
            //en caso de error se muestra un mensaje
            catch (Exception ex)
            {

                Response.Write("<script>alert('Error en la base de datos " + ex.Message + "');</script>");
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
            TableHeaderCell hcell7 = new TableHeaderCell();
            TableHeaderCell hcell8 = new TableHeaderCell();
            TableHeaderCell hcell10 = new TableHeaderCell();
            TableHeaderCell hcell11 = new TableHeaderCell();




            hcell1.Text = "Código";
            hcell2.Text = "Nivel";
            hcell3.Text = "Descripción";
            hcell4.Text = "Tipo";
            hcell5.Text = "Evidencia";
            hcell7.Text = "Link";
            hcell8.Text = "Departamento";
            hcell10.Text = "Aceptar";
            hcell11.Text = "Rechazar";



            row.Cells.Add(hcell1);

            row.Cells.Add(hcell2);

            row.Cells.Add(hcell3);

            row.Cells.Add(hcell4);

            row.Cells.Add(hcell5);

            row.Cells.Add(hcell7);

            row.Cells.Add(hcell8);

            row.Cells.Add(hcell10);

            row.Cells.Add(hcell11);

            Table1.Rows.Add(row);

        }

        void nuevaTabla(string codigo, string Nivel, string Descripcion, string Estado, string Evidencia, string link, string departamento, string titulo)
        {



            TableRow row2 = new TableRow();


            TableCell cell1 = new TableCell();
            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            TableCell cell4 = new TableCell();
            TableCell cell5 = new TableCell();
            
            TableCell cell7 = new TableCell();
            TableCell cell71 = new TableCell();


            TableCell cell8 = new TableCell();
            TableCell cell9 = new TableCell();

            cell1.Text = codigo;
            cell2.Text = Nivel;

            cell4.Text = Estado;



            cell71.Text = departamento;

            Literal lit = new Literal();

            lit.Text = Descripcion;

            Literal lit2 = new Literal();

            // lit.Text = "<button id='" + titulo + "' onclick='cargar(this)' style='  border: none; color: white; text-align: center; text - decoration: none; display: inline-block; margin: 4px 2px; transition-duration: 0.4s; cursor: pointer; border-radius: 5px; background-color: black; font-size: 17px; ' type='button'>Cargar</button>";
            lit2.Text = Evidencia;

           

            cell3.Controls.Add(lit);
            cell5.Controls.Add(lit2);

            Literal lit4 = new Literal();
            if (!link.Equals(""))
            {
                lit4.Text = "<a href='" + link + "'> Link de la evidencia </a>";
            }
            else
            {
                lit4.Text = "";
            }


            

            cell7.Controls.Add(lit4);



            Literal lit6 = new Literal();
            lit6.Text = "<button name='" + titulo + "' onclick='aceptar(this)' style='  border: none; color: white; text-align: center; text - decoration: none; display: inline-block; margin: 4px 2px; transition-duration: 0.4s; cursor: pointer; border-radius: 5px; background-color: green; font-size: 17px; ' type='button'>Aceptar</button>";
            cell8.Controls.Add(lit6);

            Literal lit7 = new Literal();
            lit7.Text = "<button name='" + titulo + "' onclick='rechazar(this)' style='  border: none; color: white; text-align: center; text - decoration: none; display: inline-block; margin: 4px 2px; transition-duration: 0.4s; cursor: pointer; border-radius: 5px; background-color: red; font-size: 17px; ' type='button'>Rechazar</button>";
            cell9.Controls.Add(lit7);

            

            row2.Cells.Add(cell1);

            row2.Cells.Add(cell2);

            row2.Cells.Add(cell3);

            row2.Cells.Add(cell4);

            row2.Cells.Add(cell5);

        

            row2.Cells.Add(cell7);
            row2.Cells.Add(cell71);


            row2.Cells.Add(cell8);

            row2.Cells.Add(cell9);

            Table1.Rows.Add(row2);

        }

        void cargarVaras(int indicador)
        {
            Table1.Rows.Clear();
           
            Conexion();
            string strCadSQL="";


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "";
            if (indicador==1) 
            {
                strCadSQL = "select ea.codigo, ea.Nivel, ea.Descripción, ea.Evidencia, ea.tipo_evidencia, ee.link, ee.departamento from EvidenciaAmbiente ea, entregaEvidencias ee where ea.codigo=ee.codigo and ee.estado='Entregado'";

            }
            else if (indicador == 2)
            {
                strCadSQL = "select ea.codigo, ea.Nivel, ea.Descripción, ea.Evidencia, ea.tipo_evidencia, ee.link, ee.departamento from EvidenciaAmbiente ea, entregaEvidencias ee where ea.codigo=ee.codigo and ee.estado='Aceptado'";

            }
            else if (indicador == 3)
            {
                strCadSQL = "select ea.codigo, ea.Nivel, ea.Descripción, ea.Evidencia, ea.tipo_evidencia, ee.link, ee.departamento from EvidenciaAmbiente ea, entregaEvidencias ee where ea.codigo=ee.codigo and ee.estado='Rechazado'";

            }

            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
    

            myReader = myCommand.ExecuteReader();

            encabezado();
           
            while (myReader.Read())
            {


                
                    nuevaTabla(myReader["codigo"].ToString(), myReader["Nivel"].ToString(), myReader["Descripción"].ToString(), myReader["tipo_evidencia"].ToString(), myReader["Evidencia"].ToString(), myReader["link"].ToString(), myReader["departamento"].ToString(), myReader["codigo"].ToString());

                


            }

        }

        protected void btnPendientes_Click(object sender, EventArgs e)
        {
            limpiarTrjetas();
         
            cargarTarjetas(1);
            cargarVaras(1);
        }

        protected void btnAprobadas_Click(object sender, EventArgs e)
        {
            limpiarTrjetas();

            cargarTarjetas(2);
            cargarVaras(2);
        }

        protected void btnRechazadas_Click(object sender, EventArgs e)
        {
            limpiarTrjetas();
            cargarTarjetas(3);
            cargarVaras(3);
        }


        void limpiarTrjetas() {
            
                lblCodigo1.Text = "Sin evidencia";
                lblDescripcion.Text = "";
                lblEvidencia.Text = "";
                lblInicio.Text = "";
                lblFin.Text = "";
                lblDepartamento.Text = "";
                lblModelo.Text = "";
                lblArea.Text = "";
                lblComponente.Text = "";
                btnAprobar1.Visible = false;
                btnRechazar1.Visible = false;
                btnDescargar.Visible = false;

            
                lblCodigo2.Text = "Sin evidencia";
                lblDescripcion2.Text = "";
                lblEvidencia2.Text = "";
                lblInicio2.Text = "";
                lblFin2.Text = "";
                lblDepartamento2.Text = "";
                lblModelo2.Text = "";
                lblArea2.Text = "";
                lblComponente2.Text = "";
                btnAprobar2.Visible = false;
                btnRechazar2.Visible = false;
                btnDescargar2.Visible = false;

           
                lblCodigo3.Text = "Sin evidencia";
                lblDescripcion3.Text = "";
                lblEvidencia3.Text = "";
                lblInicio3.Text = "";
                lblFin3.Text = "";
                lblDepartamento3.Text = "";
                lblModelo3.Text = "";
                lblArea3.Text = "";
                lblComponente3.Text = "";
                btnAprobar3.Visible = false;
                btnRechazar3.Visible = false;
                btnDescargar3.Visible = false;
            
        }

        protected void btnReporteGen_Click(object sender, EventArgs e)
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
                documento.Add(new Paragraph(20, "Evidencias pendientes", fontTitle));
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

            /*------------------------------------tabla 2-------------------------*/

            DataTable dt2 = new DataTable();
          
             dt2 = cargarReporte2();
                if (dt2.Rows.Count > 0)
                {
               
                Font fontTitle2 = FontFactory.GetFont(FontFactory.COURIER_BOLD, 30);
                    Font font92 = FontFactory.GetFont(FontFactory.TIMES, 10);


                    PdfPTable table2 = new PdfPTable(dt2.Columns.Count);
                documento.Add(new Chunk("\n"));
                documento.Add(new Paragraph(20, "Evidencias aceptadas", fontTitle2));
                    documento.Add(new Chunk("\n"));

                    float[] widths2 = new float[dt2.Columns.Count];
                    for (int i = 0; i < dt2.Columns.Count; i++)
                        widths2[i] = 4f;
                    table2.SetWidths(widths2);
                    table2.WidthPercentage = 90;

                    PdfPCell cell2 = new PdfPCell(new Phrase("columns"));
                    cell2.Colspan = dt2.Columns.Count;

                    foreach (DataColumn c in dt2.Columns)
                    {
                        table2.AddCell(new Phrase(c.ColumnName, font92));
                    }

                    foreach (DataRow r in dt2.Rows)
                    {
                        if (dt2.Rows.Count > 0)
                        {
                            for (int h = 0; h < dt2.Columns.Count; h++)
                            {
                                table2.AddCell(new Phrase(r[h].ToString(), font92));
                            }

                        }
                    }
                    documento.Add(table2);
                

                /*------------------------------------tabla 2-------------------------*/

                }


            /*------------------------------------tabla 3-------------------------*/

            DataTable dt3 = new DataTable();

            dt3 = cargarReporte3();
            if (dt3.Rows.Count > 0)
            {

                Font fontTitle3 = FontFactory.GetFont(FontFactory.COURIER_BOLD, 30);
                Font font93 = FontFactory.GetFont(FontFactory.TIMES, 10);


                PdfPTable table3 = new PdfPTable(dt3.Columns.Count);
                documento.Add(new Chunk("\n"));
                documento.Add(new Paragraph(20, "Evidencias rechazadas", fontTitle3));
                documento.Add(new Chunk("\n"));

                float[] widths3 = new float[dt3.Columns.Count];
                for (int i = 0; i < dt2.Columns.Count; i++)
                    widths3[i] = 4f;
                table3.SetWidths(widths3);
                table3.WidthPercentage = 90;

                PdfPCell cell3 = new PdfPCell(new Phrase("columns"));
                cell3.Colspan = dt3.Columns.Count;

                foreach (DataColumn c in dt3.Columns)
                {
                    table3.AddCell(new Phrase(c.ColumnName, font93));
                }

                foreach (DataRow r in dt3.Rows)
                {
                    if (dt3.Rows.Count > 0)
                    {
                        for (int h = 0; h < dt3.Columns.Count; h++)
                        {
                            table3.AddCell(new Phrase(r[h].ToString(), font93));
                        }

                    }
                }
                documento.Add(table3);


                /*------------------------------------tabla 3-------------------------*/

            }

            documento.Close();

            Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Evidencias.pdf");
            HttpContext.Current.Response.Write(documento);
          
            Response.Flush();
                Response.End();
            
        }

        public DataTable cargarReporte()
        {
           
            Conexion();
            DataTable tabla = new DataTable();
            cmdUsuario = new SqlCommand("select * from entregaEvidencias ee where ee.estado='Entregado'", con);
         
           
            SqlDataAdapter leer = new SqlDataAdapter(cmdUsuario);
            leer.Fill(tabla);
            con.Close();
            return tabla;
        }

        public DataTable cargarReporte2()
        {
            
            Conexion();
            DataTable tabla = new DataTable();
            cmdUsuario = new SqlCommand("select * from entregaEvidencias ee where ee.estado='Aceptado'", con);
            

            SqlDataAdapter leer = new SqlDataAdapter(cmdUsuario);
            leer.Fill(tabla);
            con.Close();
            return tabla;
        }

        public DataTable cargarReporte3()
        {
           
            Conexion();
            DataTable tabla = new DataTable();
            cmdUsuario = new SqlCommand("select * from entregaEvidencias ee where ee.estado='Rechazado'", con);


            SqlDataAdapter leer = new SqlDataAdapter(cmdUsuario);
            leer.Fill(tabla);
            con.Close();
            return tabla;
        }

        void consultaIndicad1() //formularios disponibles
        {
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select COUNT(codigo) as numero from entregaEvidencias where estado='Entregado'";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);

            myReader = myCommand.ExecuteReader();


            while (myReader.Read())
            {

                lblpuntaje1.Text = myReader["numero"].ToString();



            }
            lblpuntaje1texto.Text = "Cantidad de evidencias entregadas";

            con.Close();
        }

        void consultaIndicad2() //formularios disponibles
        {
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select COUNT(codigo) as numero from entregaEvidencias where estado='Aceptado'";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);

            myReader = myCommand.ExecuteReader();


            while (myReader.Read())
            {

                lblpuntaje2.Text = myReader["numero"].ToString();



            }
            lblpuntaje2texto.Text = "Cantidad de evidencias aceptadas";

            con.Close();
        }

        void consultaIndicad3() //formularios disponibles
        {
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select COUNT(codigo) as numero from entregaEvidencias where estado='Rechazado'";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);

            myReader = myCommand.ExecuteReader();


            while (myReader.Read())
            {

                lblpuntaje3.Text = myReader["numero"].ToString();



            }
            lblpuntaje3texto.Text = "Cantidad de evidencias rechazadas";

            con.Close();
        }

        protected void ddlfiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlfiltro.SelectedItem.Value== "Pendiente") 
            {
                cargarVaras(1);
            }
            else if (ddlfiltro.SelectedItem.Value == "Aprobadas")
            {
                cargarVaras(2);
            }
            else if (ddlfiltro.SelectedItem.Value == "Rechazadas")
            {
                cargarVaras(3);
            }
        }
    }
}