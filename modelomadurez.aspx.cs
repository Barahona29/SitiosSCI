using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto2APSW
{
    public partial class modelomadurez : System.Web.UI.Page
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
            
            
            string valores = Request.Params.Get("valor");
            string[] datoss = valores.Split(';');
        
            Session["departamento"] = datoss[2];
                consultaIndicad1(datoss[2]);
                consultaIndicad2(datoss[2]);
            consultaIndicad3(datoss[2]);
            }
            catch (Exception ex) 
            {
                lblpuntaje1.Visible = false;
                lblpuntaje2.Visible = false;
                lblpuntaje3.Visible = false;
            }
        }

        void consultaIndicad1(string dep) //formularios disponibles
        {
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select COUNT(codigoEv)/5 as numero from abrirEvDep where departamento =  @dep";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@dep", dep));

            myReader = myCommand.ExecuteReader();

           
            while (myReader.Read())
            {

                lblpuntaje1.Text = myReader["numero"].ToString();
               
               

            }
            lblpuntaje1texto.Text = "Cantidad de formularios disponibles";

            con.Close();
        }

        void consultaIndicad2(string dep) //formularios aceptados, cambiar cuando se amplie a los demás modelos
        {
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select COUNT(ee.idcomponente)/5 as numero from entregaEvidencias ee where departamento = @dep and idcomponente='1' and estado='Aceptado'";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@dep", dep));

            myReader = myCommand.ExecuteReader();

            int suma = 0;
            while (myReader.Read())
            {

                suma = suma + Int32.Parse(myReader["numero"].ToString());



            }
            

            con.Close();

            Conexion();
            string strCadSQL2;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader2 = null;
            strCadSQL2 = "select COUNT(ee.idcomponente)/5 as numero from entregaEvidencias ee where departamento = @dep and idcomponente='2' and estado='Aceptado'";
            SqlCommand myCommand2 = new SqlCommand(strCadSQL2, con);
            myCommand2.Parameters.Add(new SqlParameter("@dep", dep));

            myReader2 = myCommand2.ExecuteReader();

            
            while (myReader2.Read())
            {

                suma = suma + Int32.Parse(myReader2["numero"].ToString());



            }
            

            con.Close();

            Conexion();
            string strCadSQL3;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader3 = null;
            strCadSQL3 = "select COUNT(ee.idcomponente)/5 as numero from entregaEvidencias ee where departamento = @dep and idcomponente='3' and estado='Aceptado'";
            SqlCommand myCommand3 = new SqlCommand(strCadSQL3, con);
            myCommand3.Parameters.Add(new SqlParameter("@dep", dep));

            myReader3 = myCommand3.ExecuteReader();

            
            while (myReader3.Read())
            {

                suma = suma + Int32.Parse(myReader3["numero"].ToString());



            }
          

            con.Close();

            Conexion();
            string strCadSQL4;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader4 = null;
            strCadSQL4 = "select COUNT(ee.idcomponente)/5 as numero from entregaEvidencias ee where departamento = @dep and idcomponente='4' and estado='Aceptado'";
            SqlCommand myCommand4 = new SqlCommand(strCadSQL4, con);
            myCommand4.Parameters.Add(new SqlParameter("@dep", dep));

            myReader4 = myCommand4.ExecuteReader();

            
            while (myReader4.Read())
            {

                suma = suma + Int32.Parse(myReader4["numero"].ToString());



            }

            lblpuntaje2.Text = suma.ToString();

            lblpuntaje2texto.Text = "Formularios aceptados";

            con.Close();


        }


        void consultaIndicad3(string dep) //formularios terminados
        {
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select COUNT(ee.idcomponente)/5 as numero from entregaEvidencias ee where departamento = @dep and idcomponente='1' and estado='Rechazado'";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@dep", dep));

            myReader = myCommand.ExecuteReader();

            int suma = 0;
            while (myReader.Read())
            {

                suma = suma + Int32.Parse(myReader["numero"].ToString());



            }


            con.Close();

            Conexion();
            string strCadSQL2;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader2 = null;
            strCadSQL2 = "select COUNT(ee.idcomponente)/5 as numero from entregaEvidencias ee where departamento = @dep and idcomponente='2' and estado='Aceptado' and estado='Rechazado'";
            SqlCommand myCommand2 = new SqlCommand(strCadSQL2, con);
            myCommand2.Parameters.Add(new SqlParameter("@dep", dep));

            myReader2 = myCommand2.ExecuteReader();


            while (myReader2.Read())
            {

                suma = suma + Int32.Parse(myReader2["numero"].ToString());



            }


            con.Close();

            Conexion();
            string strCadSQL3;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader3 = null;
            strCadSQL3 = "select COUNT(ee.idcomponente)/5 as numero from entregaEvidencias ee where departamento = @dep and idcomponente='3' and estado='Aceptado' and estado='Rechazado'";
            SqlCommand myCommand3 = new SqlCommand(strCadSQL3, con);
            myCommand3.Parameters.Add(new SqlParameter("@dep", dep));

            myReader3 = myCommand3.ExecuteReader();


            while (myReader3.Read())
            {

                suma = suma + Int32.Parse(myReader3["numero"].ToString());



            }


            con.Close();

            Conexion();
            string strCadSQL4;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader4 = null;
            strCadSQL4 = "select COUNT(ee.idcomponente)/5 as numero from entregaEvidencias ee where departamento = @dep and idcomponente='4' and estado='Aceptado' and estado='Rechazado'";
            SqlCommand myCommand4 = new SqlCommand(strCadSQL4, con);
            myCommand4.Parameters.Add(new SqlParameter("@dep", dep));

            myReader4 = myCommand4.ExecuteReader();


            while (myReader4.Read())
            {

                suma = suma + Int32.Parse(myReader4["numero"].ToString());



            }

            lblpuntaje3.Text = suma.ToString();

            lblpuntaje3texto.Text = "Formularios rechazados";

            con.Close();


        }


        protected void btnGraficos_Click(object sender, EventArgs e)
        {
            string valores = Request.Params.Get("valor");
            string[] datoss = valores.Split(';');
            cargarPuntajes(datoss[2]);
          
        }

        void cargarPuntajes(string parametro)
        {
            
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select puntaje, idcomponente from entregaEvidencias where modelo='Ambiente de control' and departamento = @parametro";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@parametro", parametro));

            myReader = myCommand.ExecuteReader();

            string[] datos = new string[5];
            int suma = 0;
            while (myReader.Read())
            {

                if (myReader["idcomponente"].ToString() == "1")
                {
                    suma = suma + Int32.Parse(myReader["puntaje"].ToString());
                }
                else if (myReader["idcomponente"].ToString() == "2")
                {
                    suma = suma + Int32.Parse(myReader["puntaje"].ToString());
                }
                else if (myReader["idcomponente"].ToString() == "3")
                {
                    suma = suma + Int32.Parse(myReader["puntaje"].ToString());
                }
                else if (myReader["idcomponente"].ToString() == "4")
                {
                    suma = suma + Int32.Parse(myReader["puntaje"].ToString());
                }

                

                datos[3] = "0";
                

                
                    datos[2] = "0";



                datos[1] = "0";



                datos[0] = "0";





            }
            datos[4] = (suma / 4).ToString();

            con.Close();

            Response.Redirect("graficos.aspx?valores=1;" + datos[0] + ";" + datos[1] + ";" + datos[2] + ";" + datos[3] + ";" + datos[4]);
        }
    }
}