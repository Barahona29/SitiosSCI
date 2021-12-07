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
    public partial class Estructura : System.Web.UI.Page
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

            string depart = Session["departamento"] as string;
            FileUpload1.Visible = false;
            lblo.Visible = false;
            encabezado();
            cargarVaras(depart);
            try
            {

                 if (!IsPostBack) 
                { 
                    string parametro =  Request.Params.Get("valor");
                    string[] datos = parametro.Split(';');
                    if (datos[0].ToString() == "1")
                    {
                        lblCodigo.Text = "Evidencia: " + datos[1];
                        lblCodigo.Visible = true;
                        lblEstado.Text = "Estado: "+ estadoEvidencia(datos[1]);
                        lblEstado.Visible = true;
                       
                        lblTextoLink.Visible = true;

                        txtlinkEvid.Visible = true;
                       
                        btnEnviar.Visible = true;
                    }
                    else if (datos[0].ToString() == "2") {
                      //  descargar(datos[1]);
                    }




                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            // try
            //  {

            string parametro = Request.Params.Get("valor");
            string[] datos = parametro.Split(';');
            string dep = Session["departamento"] as String;
            string cod = datos[1];
            Conexion();
            if (txtlinkEvid.Text != "")
            {
                cmdUsuario = new SqlCommand("insert into entregaEvidencias values('Ambiente de control',@codigo,@departamento,0,@link,'Entregado',3)", con);
                cmdUsuario.Parameters.Add(new SqlParameter("@link", txtlinkEvid.Text));
                cmdUsuario.Parameters.Add(new SqlParameter("@codigo", datos[1]));
                cmdUsuario.Parameters.Add(new SqlParameter("@departamento", dep));
            }
            else
            {
                /*  string nombreArch = FileUpload1.FileName;
                  string[] datosArch = nombreArch.Split('.');
                  string tipoArch = datosArch[1];
                  cmdUsuario = new SqlCommand("update EvidenciaAmbiente set archivo = @arch, Cumplimiento='Sí', tipoarchivo=@tipoarch where codigo=@cod", con);
                  cmdUsuario.Parameters.Add(new SqlParameter("@arch", SqlDbType.VarBinary)).Value = FileUpload1.FileBytes;
                  cmdUsuario.Parameters.Add(new SqlParameter("@tipoarch", tipoArch));
                  cmdUsuario.Parameters.Add(new SqlParameter("@cod", datos[1]));*/

            }


            cmdUsuario.ExecuteNonQuery();
            con.Close();
            actualizarPuntajeyEstado(datos[1]);
            string depart = Session["departamento"] as string;
            cargarVaras(depart);

            Response.Write("<script>alert('Evidencia enviada correctamente');</script>");



            /* }
             //en caso de error se muestra un mensaje
             catch (Exception ex)
             {
                 if (ex.Message.Contains("Referencia a objeto no establecida como instancia de un objeto"))
                 {
                     Response.Write("<script>alert('Error, debe rellenar el campo de link');</script>");
                 }
                 else
                 {
                     Response.Write("<script>alert('Error en la base de datos " + ex.Message + "');</script>");
                 }
             }*/

        


        
            //en caso de error se muestra un mensaje
            //catch (Exception ex)
            //{

            //    Response.Write("<script>alert('Error en la base de datos " + ex.Message + "');</script>");
            //}
        }

        void cargarVaras(string dep)
        {
            Table1.Rows.Clear();

            cargarVarasEntregadas(dep);

            /*--------------------------------------------------------------------------------------*/



            Conexion();
            DataTable tabla = new DataTable();
            cmdUsuario = new SqlCommand("select distinct evam.codigo, aed.inicio, aed.fin, evam.Nivel, evam.Descripción, evam.tipo_evidencia, evam.Evidencia from EvidenciaAmbiente evam, entregaEvidencias entrev, abrirEvDep aed where evam.idambiente=1 and evam.codigo not in (select codigo from entregaEvidencias) and evam.codigo in (select codigoEv from abrirEvDep) and aed.departamento=@dep", con);

            cmdUsuario.Parameters.Add(new SqlParameter("@dep", dep));

            SqlDataAdapter leer = new SqlDataAdapter(cmdUsuario);
            leer.Fill(tabla);
            int cont = 0;
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                cont = cont + 1;
            }

            con.Close();
            string indicador = "";
            if ((cont % 2) == 0)
            {
                indicador = "par";
            }
            else
            {
                indicador = "impar";
            }

            /*--------------------------------------------------------------------------------------*/
            

                Conexion();
                string strCadSQL;


                //Formar la sentencia SQL, un SELECT en este caso
                SqlDataReader myReader = null;
                strCadSQL = "";

            //      strCadSQL = "select evam.codigo, evam.inicio_de_apertura, evam.fin_de_apertura, evam.Nivel, evam.Descripción, evam.tipo_evidencia, evam.Evidencia from EvidenciaAmbiente evam, entregaEvidencias entrev where entrev.modelo='Ambiente de control' and evam.codigo != entrev.codigo and evam.idambiente=1";
            strCadSQL = "select distinct evam.codigo, aed.inicio, aed.fin, evam.Nivel, evam.Descripción, evam.tipo_evidencia, evam.Evidencia from EvidenciaAmbiente evam, abrirEvDep aed where evam.idambiente=3 and evam.codigo not in (select codigo from entregaEvidencias) and evam.codigo in (select codigoEv from abrirEvDep) and aed.departamento=@dep";



            SqlCommand myCommand = new SqlCommand(strCadSQL, con);

                myCommand.Parameters.Add(new SqlParameter("@dep", dep));

                myReader = myCommand.ExecuteReader();

                string codigo = "";

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
                        if (codigo != myReader["codigo"].ToString())
                        {
                            nuevaTabla(myReader["Nivel"].ToString(), myReader["Descripción"].ToString(), myReader["tipo_evidencia"].ToString(), myReader["Evidencia"].ToString(), "No", "", myReader["codigo"].ToString());
                        }
                    }


                    codigo = myReader["codigo"].ToString();
                    // nuevaTabla(myReader["codigo"].ToString(), myReader["Nivel"].ToString(), myReader["Descripción"].ToString(), myReader["tipo_evidencia"].ToString(), myReader["Evidencia"].ToString(), myReader["Cumplimiento"].ToString(), myReader["link"].ToString(), myReader["puntaje"].ToString(), myReader["codigo"].ToString());




                

                con.Close();
            }
        }



        void cargarVarasEntregadas(string dep)
        {


            Conexion();
            string strCadSQL;
            encabezado();
            DataTable tabla = new DataTable();
            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "";

            strCadSQL = "select distinct ee.codigo, ee.link from entregaEvidencias ee, abrirEvDep aed where codigoEv in (select aed.codigo from entregaEvidencias aed) and ee.departamento=@dep and  ee.idcomponente='3' order by ee.codigo";


            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@dep", dep));

            SqlDataAdapter leer = new SqlDataAdapter(myCommand);
            leer.Fill(tabla);
            con.Close();

            Conexion();
            string strCadSQL2;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader2 = null;
            strCadSQL2 = "";

            strCadSQL2 = "select codigo, Nivel, Descripción, tipo_evidencia, Evidencia, idambiente from EvidenciaAmbiente";


            SqlCommand myCommand2 = new SqlCommand(strCadSQL2, con);


            myReader2 = myCommand2.ExecuteReader();



            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            while (myReader2.Read())
            {




                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    /* tabla.Rows[i]["codigo"].ToString();
                     tabla.Rows[i]["inicio"].ToString();
                     tabla.Rows[i]["fin"].ToString();
                     tabla.Rows[i]["link"].ToString();*/

                /*    string fechainicio = tabla.Rows[i]["inicio"].ToString();


                    string fechafin = tabla.Rows[i]["fin"].ToString();


                    DateTime fechaAct = DateTime.Now;

                    DateTime fechaini = Convert.ToDateTime(fechainicio, System.Globalization.CultureInfo.GetCultureInfo("en-GB").DateTimeFormat);

                    DateTime fechaf = Convert.ToDateTime(fechafin, System.Globalization.CultureInfo.GetCultureInfo("en-GB").DateTimeFormat);


                    if (fechaAct >= fechaini && fechaAct <= fechaf)
                    {*/
                        string codTabla = tabla.Rows[i]["codigo"].ToString();
                        string codBD = myReader2["codigo"].ToString().Trim();
                        if (myReader2["codigo"].ToString() == tabla.Rows[i]["codigo"].ToString() && myReader2["idambiente"].ToString() == "3")
                        {
                            nuevaTabla(myReader2["Nivel"].ToString(), myReader2["Descripción"].ToString(), myReader2["tipo_evidencia"].ToString(), myReader2["Evidencia"].ToString(), "Sí", tabla.Rows[i]["link"].ToString(), myReader2["codigo"].ToString());

                        }

                   // }
                }

            }


            con.Close();

        }

        void nuevaTabla(string Nivel, string Descripcion, string Estado, string Evidencia, string Cumplimiento, string link, string titulo)
        {



            TableRow row2 = new TableRow();



            TableCell cell2 = new TableCell();
            TableCell cell3 = new TableCell();
            TableCell cell4 = new TableCell();
            TableCell cell5 = new TableCell();
            TableCell cell6 = new TableCell();
            TableCell cell7 = new TableCell();





            cell2.Text = Nivel;

            cell4.Text = Estado;





            Literal lit = new Literal();

            lit.Text = Descripcion;

            Literal lit2 = new Literal();

            // lit.Text = "<button id='" + titulo + "' onclick='cargar(this)' style='  border: none; color: white; text-align: center; text - decoration: none; display: inline-block; margin: 4px 2px; transition-duration: 0.4s; cursor: pointer; border-radius: 5px; background-color: black; font-size: 17px; ' type='button'>Cargar</button>";
            lit2.Text = Evidencia;

            Literal lit3 = new Literal();
            if (Cumplimiento == "Sí")
            {
                lit3.Text = "<label class='switch'> <input type='checkbox' id='" + titulo + "' onclick='cargar(this)' checked='checked'><div class='slider round'></div></label>";

            }
            else if (Cumplimiento == "No")
            {
                lit3.Text = "<div style='text-align: center;'><label class='switch'> <input type='checkbox' id='" + titulo + "' onclick='cargar(this)'><div class='slider round'></div></label></div>";

            }



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


            cell6.Controls.Add(lit3);

            cell7.Controls.Add(lit4);




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


            TableHeaderCell hcell2 = new TableHeaderCell();
            TableHeaderCell hcell3 = new TableHeaderCell();
            TableHeaderCell hcell4 = new TableHeaderCell();
            TableHeaderCell hcell5 = new TableHeaderCell();
            TableHeaderCell hcell6 = new TableHeaderCell();
            TableHeaderCell hcell7 = new TableHeaderCell();






            hcell2.Text = "Nivel";
            hcell3.Text = "Descripción";
            hcell4.Text = "Tipo";
            hcell5.Text = "Evidencia";
            hcell6.Text = "Cumplimiento";
            hcell7.Text = "Link";






            row.Cells.Add(hcell2);

            row.Cells.Add(hcell3);

            row.Cells.Add(hcell4);

            row.Cells.Add(hcell5);

            row.Cells.Add(hcell6);

            row.Cells.Add(hcell7);


            Table1.Rows.Add(row);

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

        void actualizarPuntajeyEstado(string codigo)
        {

            /*   Conexion();
           string strCadSQL;


           //Formar la sentencia SQL, un SELECT en este caso



           strCadSQL = "update entregaEvidencias ee,EvidenciaAmbiente ea set ee.puntaje = 20, ee.Estado='Entregado' where ee.codigo=@codigo and ea.codigo=@codigo and ea.tipo_evidencia='Opcional'";

           SqlCommand myCommand = new SqlCommand(strCadSQL, con);

           myCommand.Parameters.AddWithValue("@codigo", codigo);

           myCommand.ExecuteNonQuery();

           con.Close();*/



            Conexion();
            string strCadSQL2;


            //Formar la sentencia SQL, un SELECT en este caso



            strCadSQL2 = "update entregaEvidencias set estado='Entregado' where codigo=@codigo";



            SqlCommand myCommand2 = new SqlCommand(strCadSQL2, con);

            myCommand2.Parameters.AddWithValue("@codigo", codigo);

            myCommand2.ExecuteNonQuery();

            con.Close();
        }

        public string estadoEvidencia(string codigo)
        {
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "";

            strCadSQL = "select estado from entregaEvidencias where codigo = @codigo";

            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@codigo", codigo));

            myReader = myCommand.ExecuteReader();

            string estEv = "";

            while (myReader.Read())
            {


                estEv = myReader["estado"].ToString();


            }

            con.Close();

            return estEv;
        }
    }
}