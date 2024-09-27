using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
namespace cms
{
    public partial class forgetpassworduser : System.Web.UI.Page
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=cms;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void cancle_Click(object sender, EventArgs e)
        {

            Response.Redirect("login.aspx");
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string userID = txtforget.Text.Trim();



                // Input Validation: Validate user input (userId)
                if (string.IsNullOrWhiteSpace(userID))
                {
                    // Display an error message to the user indicating that the user ID is required
                    Response.Write("<script>alert('User ID is required')</script>");
                    return; // Exit function to prevent further execution
                }

                // Fixed email address where the confirmation email will be sent
                string email = "iampriyakant@gmail.com"; // Update with the recipient's email address
                //string email = "pateliyagautam68@gmail.com";
                // Database query to check if the user ID exists and retrieve the associated email address and password
                string query2 = "SELECT  password FROM [adminid] WHERE userid = @Userid";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        command.Parameters.AddWithValue("@Userid", userID);
                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                               
                                string password = reader["password"].ToString(); // Assuming password is retrieved from the database

                                // Send email to the user
                                SendEmail(email, userID,password);

                                // Display a success message to the user
                                Response.Write("<script>alert('Email sent successfully')</script>");
                                clearfiled();
                            }
                           
                        }
                        catch (Exception ex)
                        {
                            // Handle exception
                            Response.Write("<script>alert('An error occurred: " + ex.Message + "')</script>");
                        }
                    }
                }
                
            
            if (userID != null)
            {

                if (string.IsNullOrWhiteSpace(userID))
                {
                    // Display an error message to the user indicating that the user ID is required
                    Response.Write("<script>alert('User ID is required')</script>");
                    return; // Exit function to prevent further execution
                }

                // Database query to check if the user ID exists and retrieve the associated email address and password
                string query = "SELECT email, password FROM [user] WHERE userid = @Userid";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Userid", userID);
                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                string emailAddress = reader["email"].ToString(); // Assuming email is retrieved from the database
                                string password = reader["password"].ToString(); // Assuming password is retrieved from the database

                                // Send email to the user
                                userSendEmail(emailAddress, userID, password);

                                // Display a success message to the user
                                Response.Write("<script>alert('Email sent successfully')</script>");
                                clearfiled();
                            }
                            else
                            {
                                // User not found, show error message
                                Response.Write("<script>alert('User not found')</script>");
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle exception
                            Response.Write("<script>alert('An error occurred: " + ex.Message + "')</script>");
                        }
                    }
                }
            }

        }

        private void clearfiled()
        {
            txtforget.Text = "";
        }

        private void userSendEmail(string toEmailAddress, string userId, string password)
        {
            try
            {
                // Sender's email address and password (use your Gmail credentials or any other SMTP server)
                string fromAddress = "rooftopssolar2024@gmail.com"; // Update with your email address
                string smtpPassword = "tpcjhhlqnfibmisu";  // Update with your email password

                // Configure the SMTP client
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(fromAddress, smtpPassword);

                    // Create the email message
                    using (MailMessage mailMessage = new MailMessage(fromAddress, toEmailAddress))
                    {
                        mailMessage.Subject = "forget password";
                        mailMessage.Body = $"Dear User,\n\nThank you for submitting Request \n \n your user ID: {userId}. \n\n Your password is: {password}";

                        // Send the email
                        smtpClient.Send(mailMessage);

                        // Display success message
                        //Response.Write("<script>alert('Email sent successfully')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors
                Response.Write("<script>alert('An error occurred while sending the email: " + ex.Message + "')</script>");
            }
        }


        private void SendEmail(string email, string userID,string password)
        {
            try
            {
                // Sender's email address and app password (use your Gmail credentials)
                string fromAddress = "rooftopssolar2024@gmail.com";
                string appPassword = "tpcjhhlqnfibmisu";

                // Use app password if 2-factor authentication is enabled

                // Create and configure the SMTP client for Gmail
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(fromAddress, appPassword);

                    // Create the email message
                    using (MailMessage mailMessage = new MailMessage(fromAddress, email))
                    {
                        mailMessage.Subject = "forget password";
                        mailMessage.Body = $"Dear Admin,\n\nThank you for submitting Request \n your user ID: {userID}.\n This is your password: {password}";

                        // Send the email
                        smtpClient.Send(mailMessage);

                        // Display success message
                       // Response.Write("<script>alert('Email sent successfully')</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error message and any inner exceptions
                string errorMessage = "An error occurred: " + ex.Message;
                Exception innerException = ex.InnerException;
                while (innerException != null)
                {
                    errorMessage += "\nInner Exception: " + innerException.Message;
                    innerException = innerException.InnerException;
                }
                Response.Write("<script>alert('" + errorMessage + "')</script>");
            }
        }
           
       
    }

    
}