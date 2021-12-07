using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto2APSW
{
    public partial class generalencargado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string valores = Request.Params.Get("valor");
            string[] datoss = valores.Split(';');
            lblDepartamento.Text = datoss[2];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string valores = Request.Params.Get("valor");
            string[] datoss = valores.Split(';');
            Response.Redirect("modelomadurez.aspx?valor=" + datoss[0] + ";" + datoss[1] + ";" + datoss[2]);
            
        }
    }
}