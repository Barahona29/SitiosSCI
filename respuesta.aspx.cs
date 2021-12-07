using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto2APSW
{
    public partial class respuesta : System.Web.UI.Page
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
            string valores = Request.Params.Get("valor");
            string[] parametros = valores.Split(';');
            if (parametros[2]=="1") 
            {
                aprobar();
            }
            else if (parametros[2] == "2")
            {
                rechazar();
            }
            else if (parametros[2] == "3")
            {
                descargar(parametros[0], parametros[1]);
                descargar2(parametros[0], parametros[1]);
                descargar3(parametros[0], parametros[1]);
                descargar4(parametros[0], parametros[1]);
                descargar5(parametros[0], parametros[1]);
            }


            Response.Redirect("http://empresasci-001-site1.etempurl.com/solicitud2.aspx/?valor=" + parametros[3]+";" + parametros[4] + ";" + parametros[1]);
         

        }

        void aprobar() {
            string valores = Request.Params.Get("valor");
            string[] parametros = valores.Split(';');

            Conexion();
            cmdUsuario = new SqlCommand("update EvidenciaAmbiente set Revision='Aprobada'  where codigo=@cod and departamento=@dep", con);
            cmdUsuario.Parameters.Add(new SqlParameter("@cod", parametros[0]));
            cmdUsuario.Parameters.Add(new SqlParameter("@dep", parametros[1]));
            cmdUsuario.ExecuteNonQuery();
            con.Close();


            Conexion();
            cmdUsuario = new SqlCommand("update EvidenciaActividad set Revision='Aprobada' where codigo=@cod and departamento=@dep", con);
            cmdUsuario.Parameters.Add(new SqlParameter("@cod", parametros[0]));
            cmdUsuario.Parameters.Add(new SqlParameter("@dep", parametros[1]));
            cmdUsuario.ExecuteNonQuery();
            con.Close();

            Conexion();
            cmdUsuario = new SqlCommand("update EvidenciaRiesgo set  Revision='Aprobada'  where codigo=@cod and departamento=@dep", con);
            cmdUsuario.Parameters.Add(new SqlParameter("@cod", parametros[0]));
            cmdUsuario.Parameters.Add(new SqlParameter("@dep", parametros[1]));
            cmdUsuario.ExecuteNonQuery();
            con.Close();

            Conexion();
            cmdUsuario = new SqlCommand("update EvidenciaSeguimiento set  Revision='Aprobada'  where codigo=@cod and departamento=@dep", con);
            cmdUsuario.Parameters.Add(new SqlParameter("@cod", parametros[0]));
            cmdUsuario.Parameters.Add(new SqlParameter("@dep", parametros[1]));
            cmdUsuario.ExecuteNonQuery();
            con.Close();

            Conexion();
            cmdUsuario = new SqlCommand("update EvidenciaSistema set Revision='Aprobada' where codigo=@cod and departamento=@dep", con);
            cmdUsuario.Parameters.Add(new SqlParameter("@cod", parametros[0]));
            cmdUsuario.Parameters.Add(new SqlParameter("@dep", parametros[1]));
            cmdUsuario.ExecuteNonQuery();
            con.Close();
        }

        void rechazar()
        {
            string valores = Request.Params.Get("valor");
            string[] parametros = valores.Split(';');

            Conexion();
            cmdUsuario = new SqlCommand("update EvidenciaAmbiente set Revision='Rechazada'  where codigo=@cod and departamento=@dep", con);
            cmdUsuario.Parameters.Add(new SqlParameter("@cod", parametros[0]));
            cmdUsuario.Parameters.Add(new SqlParameter("@dep", parametros[1]));
            cmdUsuario.ExecuteNonQuery();
            con.Close();


            Conexion();
            cmdUsuario = new SqlCommand("update EvidenciaActividad set Revision='Rechazada'  where codigo=@cod and departamento=@dep", con);
            cmdUsuario.Parameters.Add(new SqlParameter("@cod", parametros[0]));
            cmdUsuario.Parameters.Add(new SqlParameter("@dep", parametros[1]));
            cmdUsuario.ExecuteNonQuery();
            con.Close();

            Conexion();
            cmdUsuario = new SqlCommand("update EvidenciaRiesgo set Revision='Rechazada' where codigo=@cod and departamento=@dep", con);
            cmdUsuario.Parameters.Add(new SqlParameter("@cod", parametros[0]));
            cmdUsuario.Parameters.Add(new SqlParameter("@dep", parametros[1]));
            cmdUsuario.ExecuteNonQuery();
            con.Close();

            Conexion();
            cmdUsuario = new SqlCommand("update EvidenciaSeguimiento set Revision='Rechazada'  where codigo=@cod and departamento=@dep", con);
            cmdUsuario.Parameters.Add(new SqlParameter("@cod", parametros[0]));
            cmdUsuario.Parameters.Add(new SqlParameter("@dep", parametros[1]));
            cmdUsuario.ExecuteNonQuery();
            con.Close();

            Conexion();
            cmdUsuario = new SqlCommand("update EvidenciaSistema set Revision='Rechazada'  where codigo=@cod and departamento=@dep", con);
            cmdUsuario.Parameters.Add(new SqlParameter("@cod", parametros[0]));
            cmdUsuario.Parameters.Add(new SqlParameter("@dep", parametros[1]));
            cmdUsuario.ExecuteNonQuery();
            con.Close();
        }

        void descargar(string id, string dep) 
        {
            try { 
            byte[] bytes;
            string fileName, contentType;
            string constr = "workstation id=SistemaCI.mssql.somee.com;packet size=4096;user id=maikol1113_SQLLogin_1;pwd=6t75jgalrt;data source=SistemaCI.mssql.somee.com;persist security info=False;initial catalog=SistemaCI";
                using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "select codigo, archivo, tipoarchivo from EvidenciaAmbiente where codigo=@Id and departamento=@dep";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@dep", dep);
                        

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
            catch (Exception ex) 
            { 
            
            }
        }

        void descargar2(string id, string dep)
        {
            try
            {
                byte[] bytes;
                string fileName, contentType;
                string constr = "workstation id=SistemaCI.mssql.somee.com;packet size=4096;user id=maikol1113_SQLLogin_1;pwd=6t75jgalrt;data source=SistemaCI.mssql.somee.com;persist security info=False;initial catalog=SistemaCI";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select codigo, archivo, tipoarchivo from EvidenciaAtividad where codigo=@Id and departamento=@dep";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@dep", dep);

                        

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
            catch (Exception ex)
            {

            }
        }

        void descargar3(string id, string dep)
        {
            try
            {
                byte[] bytes;
                string fileName, contentType;
                string constr = "workstation id=SistemaCI.mssql.somee.com;packet size=4096;user id=maikol1113_SQLLogin_1;pwd=6t75jgalrt;data source=SistemaCI.mssql.somee.com;persist security info=False;initial catalog=SistemaCI";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select codigo, archivo, tipoarchivo from EvidenciaRiesgo where codigo=@Id and departamento=@dep";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@dep", dep);
                       

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
            catch (Exception ex)
            {

            }
        }

        void descargar4(string id, string dep)
        {
            try
            {
                byte[] bytes;
                string fileName, contentType;
                string constr = "workstation id=SistemaCI.mssql.somee.com;packet size=4096;user id=maikol1113_SQLLogin_1;pwd=6t75jgalrt;data source=SistemaCI.mssql.somee.com;persist security info=False;initial catalog=SistemaCI";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select codigo, archivo, tipoarchivo from EvidenciaSeguimiento where codigo=@Id and departamento=@dep";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@dep", dep);
                       

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
            catch (Exception ex)
            {

            }
        }

        void descargar5(string id, string dep)
        {
            try
            {
                byte[] bytes;
                string fileName, contentType;
                string constr = "workstation id=SistemaCI.mssql.somee.com;packet size=4096;user id=maikol1113_SQLLogin_1;pwd=6t75jgalrt;data source=SistemaCI.mssql.somee.com;persist security info=False;initial catalog=SistemaCI";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "select codigo, archivo, tipoarchivo from EvidenciaSistema where codigo=@Id and departamento=@dep";
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@dep", dep);

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
            catch (Exception ex)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }

        int cont = 0;

        void devolver() 
        {
            
            string valores = Request.Params.Get("valor");
            string[] parametros = valores.Split(';');



            string param1 = parametros[1];

            string param3 = parametros[3];
                
                string param4 = parametros[4];

                
            Response.Redirect("solicitud.aspx?valor=" + param3 + ";" + param4 + ";" + param1+";" + param4 + ";" + param1 + ";");
            
            
        }
    }
}