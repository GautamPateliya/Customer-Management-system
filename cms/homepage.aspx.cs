using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cms
{
    public partial class homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void logoutbtn(object sender, EventArgs e)
        {
            // Clear session variables
                Session.Clear();
                Session.Abandon();

                // Sign out the user if using Forms Authentication
           
                // Redirect to the login page
                Response.Redirect("~/Login.aspx");
           

        }

    }
}