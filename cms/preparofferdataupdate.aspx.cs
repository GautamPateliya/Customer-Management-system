using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace cms
{
    public partial class preparofferdataupdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["leadname"] != null && Session["mobile"] != null && Session["kw"] != null && Session["item"] != null && Session["price"] != null && Session["pvqty"] != null && Session["wp"] != null)
                {
                    // Retrieve data from session variables
                    var leadname = Session["leadname"].ToString();
                    string mobile = Session["mobile"].ToString();
                    string kw = Session["kw"].ToString();
                    string item = Session["item"].ToString();
                    string pvqty = Session["pvqty"].ToString();
                    string wp = Session["wp"].ToString();
                    string area = Session["area"].ToString();

                    string price = Session["price"].ToString();
                    // Set the values of the textboxes

                    txleadname.Text = leadname;
                    
                    txtMobileNumber.Text = mobile ?? "";
                    Txareaofcity.Text = area ?? "";

                    txkw.Text = kw;
                    txwp.Text = wp;
                    txprice.Text = price;
                    txtpvqty.Text = pvqty;
                    txtSearch.Text = item;


                }
                else
                {
                    Response.Write("<script>alert('data not found')</script>");
                }
            }
        }
        protected void create(object sender, EventArgs e)
        {
            string leadname = txleadname.Text;


            string kw = txkwHidden.Value;
            string item = txtSearch.Text;
            string pvqty = txtpvqty.Text;
            string wp = txwp.Text;


            string mobile = txtMobileNumber.Text;
            string price = txprice.Text;
            string area = Txareaofcity.Text;



            // Assuming you're using SQL Server
            string connectionString = "Data Source = localhost\\SQLEXPRESS01; Initial Catalog = cms; Integrated Security = True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE [preparoffer] SET  kw = @kw,mobile_number=@mobile,pv_brand=@item,pv_qty=@pvqty, price=@price,wp=@wp,area_of_city=@area  WHERE lead_name=@leadname";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@leadname", leadname);
                command.Parameters.AddWithValue("@kw", kw);
                command.Parameters.AddWithValue("@item", item);
                command.Parameters.AddWithValue("@pvqty", pvqty);

                command.Parameters.AddWithValue("@price", price);

                command.Parameters.AddWithValue("@mobile", mobile);
                command.Parameters.AddWithValue("@wp", wp);
                command.Parameters.AddWithValue("@area", area);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    // Check if the update was successful
                    if (rowsAffected > 0)
                    {
                        // Update successful
                        // Optionally, you can display a success message or redirect the user to another page
                        ScriptManager.RegisterStartupScript(this, GetType(), "UpdateSuccess", "showAlert(); window.location.href = 'prepaofferdatashow.aspx';", true);
                    }
                    else
                    {
                        // Update failed
                        Response.Write("Update failed!");
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                    Response.Write("An error occurred: " + ex.Message);
                }
            }


        }
        protected void btncancel_Click(object sender, EventArgs e)
        {


            // Redirect to the logout page or any other page
            Response.Redirect("~/prepaofferdatashow.aspx");
        }

    }
}