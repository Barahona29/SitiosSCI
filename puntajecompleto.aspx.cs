using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto2APSW
{
    public partial class puntajecompleto : System.Web.UI.Page
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
            string valores = Request.Params.Get("valores");
            string[] datos = valores.Split(';');

            cargarPuntajeAmbiente(datos[1]);
            cargarPuntajeGeneral();
        }

        void cargarPuntajeAmbiente(string parametro) {
            Conexion();
            string strCadSQL;


            //Formar la sentencia SQL, un SELECT en este caso
            SqlDataReader myReader = null;
            strCadSQL = "select puntaje, idcomponente from entregaEvidencias where departamento = @parametro and modelo='Ambiente de control'";
            SqlCommand myCommand = new SqlCommand(strCadSQL, con);
            myCommand.Parameters.Add(new SqlParameter("@parametro", parametro));

            myReader = myCommand.ExecuteReader();

            int suma = 0;

            while (myReader.Read())
            {



                if (myReader["idcomponente"].ToString()=="1") 
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





                lblValoracionRiesgo.Text = "0";
                

               
                    lblActivControl.Text = "0";



                lblSistInfo.Text = "0";



                lblSeguimientoSCI.Text = "0";





            }
            int porcentaje = suma / 4;
            lblAmbienteControl.Text = porcentaje.ToString();

            con.Close();
        }

        void cargarPuntajeGeneral() {

            int puntajeAmbC = Int32.Parse(lblAmbienteControl.Text);
            int puntajeActivC = Int32.Parse(lblActivControl.Text);
            int puntajeVR = Int32.Parse(lblValoracionRiesgo.Text);
            int puntajeSI = Int32.Parse(lblSistInfo.Text);
            int puntajeSCI = Int32.Parse(lblSeguimientoSCI.Text);
            int total = (puntajeAmbC + puntajeActivC + puntajeVR + puntajeSI + puntajeSCI)/5;


            lblIndiceGeneral.Text = total.ToString();

            if (total <= 20)
            {
                lblniveldemadurez.Text = "Incipiente";
            } else if (total >= 21 && total <= 40) 
            {
                lblniveldemadurez.Text = "Novato";
            }
            else if (total >= 41 && total <= 60)
            {
                lblniveldemadurez.Text = "Competente";
            }
            else if (total >= 61 && total <= 80)
            {
                lblniveldemadurez.Text = "Diestro";
            }
            else if (total >= 81 && total <= 100)
            {
                
                lblniveldemadurez.Text = "Experto";
            }


        }
    }
}