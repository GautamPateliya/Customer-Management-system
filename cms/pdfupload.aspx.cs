using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace cms
{
    public partial class pdfupload : System.Web.UI.Page
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=cms;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

        }
      
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Implement your logout logic here
            // For example, you can clear the session and redirect the user to the login page
            // Clear session data
            Response.Redirect("Login.aspx"); // Redirect to the login page
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                string fileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                byte[] fileData = fileUpload.FileBytes;
                SaveFileToDatabase(fileName, fileData);
                BindGrid();
            }
        }
        protected void BindGrid()
        {
          
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT id, pdfname FROM pdfupload", con);
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void SaveFileToDatabase(string fileName, byte[] fileData)
        {
           
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO pdfupload (pdfname, pdfdata) VALUES (@FileName, @FileData)", con);
                cmd.Parameters.AddWithValue("@FileName", fileName);
                cmd.Parameters.AddWithValue("@FileData", fileData);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewFile" || e.CommandName == "DownloadFile")
            {
                int fileId = Convert.ToInt32(e.CommandArgument);
                byte[] fileBytes = GetFileDataFromDatabase(fileId);

                if (fileBytes != null)
                {
                    if (e.CommandName == "ViewFile")
                    {
                        // View the file
                        Response.Clear();
                        Response.ContentType = "application/pdf";
                        Response.BinaryWrite(fileBytes);
                        Response.End();
                    }
                    else if (e.CommandName == "DownloadFile")
                    {
                        // Download the file
                        Response.Clear();
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("Content-Disposition", "attachment; filename=file.pdf");
                        Response.BinaryWrite(fileBytes);
                        Response.End();
                    }
                }
            }


           
        }


        protected byte[] GetFileDataFromDatabase(int fileId)
        {
         
            byte[] fileBytes = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT pdfdata FROM pdfupload WHERE id = @FileId", con);
                cmd.Parameters.AddWithValue("@FileId", fileId);
                con.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    fileBytes = (byte[])result;
                }
            }
            return fileBytes;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Retrieve the ID of the item to be deleted
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            // Delete the item from the database
            DeleteItem(id);

            // Rebind the GridView to refresh the data
            BindGrid();
        }


        private void DeleteItem(int id)
        {
            // Write your database logic here to delete the item with the given id
            // Example:
             using (SqlConnection con = new SqlConnection(connectionString))
             {
                SqlCommand cmd = new SqlCommand("DELETE FROM pdfupload WHERE id = @Id", con);
                cmd.Parameters.AddWithValue("@Id", id);
                 con.Open();
                 cmd.ExecuteNonQuery();
             }
        }
    }
}