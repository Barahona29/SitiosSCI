using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto2APSW
{
    public partial class generalfiscalizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnApertura_Click(object sender, EventArgs e)
        {
            string valores = Request.Params.Get("valor");
            
            Response.Redirect("aperturanueva.aspx?valor=" + valores);
        }
    }
}