using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Teletrabajo
{
    public partial class Login : System.Web.UI.Page
    {
        #region variables globales
        FuncionarioServicio funcionarioServicio = new FuncionarioServicio();
        int rol;
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Master.FindControl("menu").Visible = false;

            Session["rol"] = null;
            Session["nombreCompleto"] = null;
        }

        public bool AuthenticateUser( string username, string password, out string Errmsg)
        {
            Errmsg = "";
            string domainAndUsername = @"\" + username;
            try
            {
                String result = funcionarioServicio.
                if (null == result)
                {
                    return false;
                }
            }

        }

            protected void btIngresar_Click(object sender, EventArgs e)
        {
            string nombreCompleto = string.Empty;
            string userName = txtUsuario.Text.Trim().ToUpper();
        }
    }
}