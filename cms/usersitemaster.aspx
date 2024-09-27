<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usersitemaster.aspx.cs" Inherits="cms.usersitemaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Site visit</title>
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="~/assets/css/tailwind.output.css" />
    <script src="https://cdn.jsdelivr.net/gh/alpinejs/alpine@v2.x.x/dist/alpine.min.js" defer></script>
    <link rel="stylesheet" href="StyleSheet1.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js" integrity="sha384-w1Q4orYjBQndcko6MimVbzY0tgp4pWB4lZ7lr30WKz0vr/aWKhXdBNmNb5D92v7s" crossorigin="anonymous"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>

<style>
    .custom-label {
    font-size: 22px; /* Adjust the font size as needed */
}
 .custom-radio {
    font-size: 20px; /* Adjust the font size as needed */
}

  
    .alert {
        padding: 20px;
        background-color:  black; /* Red background color */
        color: white;
        margin-bottom: 15px;
         font-size:larger;
    }

    .closebtn {
        margin-left: 15px;
        color: white;
        font-weight: bold;
       
        float: right;
        font-size:  larger;
        line-height: 20px;
        cursor: pointer;
        transition: 0.3s;
    }

    .closebtn:hover {
        color: red;
    }
</style>


 
<script>
    function showAlert() {
        document.getElementById('alertBox').style.display = 'block';
        setTimeout(function () {
            document.getElementById('alertBox').style.display = 'none';
        }, 3000); // Hide the alert after 3 seconds (adjust as needed)
    }
</script>
</head>
<body>
 
             <form id="form2" runat="server" method="post">



         <div id="alertBox" class="alert" style="display:none;">
    <span class="closebtn" onclick="this.parentElement.style.display='none';">&times;</span>
    <strong></strong> "Submited Data  Successfuly".
</div>
         <header class="font">
           <div>
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
               <asp:Image ID="Image1" runat="server" ImageUrl="\assets\logo3.png" style="width: 200px; height: 80px;" />
                 <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse text-2xl  text-uppercase " id="navbarSupportedContent">
                    <ul class="navbar-nav p-2 mr-auto">
                       <li class="nav-item active">
                            <a class="nav-link" href="userhomepage.aspx">Home<span class="sr-only">(current)</span></a>
                        </li>
                      <li class="nav-item dropdown">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown2" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Lead Master</a>
    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
        <a class="dropdown-item" href="userleadmaster.aspx">New Lead</a>
        <a class="dropdown-item" href="userleadsource.aspx">New Lead Source </a>
         <a class="dropdown-item" href="userleadmasterdata.aspx">Register Leads </a>
    </div>
</li>


                         <li class="nav-item dropdown  ">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown1" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Site Visit</a>
    <div class="dropdown-menu " aria-labelledby="navbarDropdown">
        <a class="dropdown-item " href="usersitemaster.aspx">Site visit</a>
        <a class="dropdown-item" href="usershowsitemasterdata.aspx">Site Visit Details </a>
       
    </div>
</li>


                        <li class="nav-item dropdown  ">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Offer </a>
    <div class="dropdown-menu " aria-labelledby="navbarDropdown">
       
        <a class="dropdown-item" href="userpreparoffer.aspx">Prepar Offer  </a>
       
         <a class="dropdown-item" href="userpreparedofferdata.aspx">Prepared Offers  </a>

    </div>
</li>



                        <li class="nav-item"></li>



                    </ul>
               <a href="login.aspx" id="btnLogout" class="btn btn-outline-success">Log Out</a>

</div>


            </nav>
         </header>
       
      
        <main>
            <div class="flex items-center min-h-screen p-6 bg-gray-50 dark:bg-gray-900">
                <div class="flex-1 h-full max-w-4xl mx-auto overflow-hidden bg-white rounded-lg shadow-xl dark:bg-gray-800">
                    <div class="flex flex-col overflow-y-auto md:flex-row">
                        <div class="h-32 md:h-auto md:w-1/2">
                            <img aria-hidden="true" class="object-cover w-full h-full dark:hidden" src="../assets/img/create-account-office.jpeg" alt="Office" />
                        </div>
                        <div class="flex items-center justify-center p-6 sm:p-12 md:w-1/2">
                            <div class="w-full">
                                <h1 class="mb-4 text-x1 text-teal-500 font-semibold text-gray-700 dark:text-gray-200">Site Visit</h1>
                                 <label for="country" class="block text-lg  custom-label mt-2">Lead Name:</label>
                                
                                
                                



                                <asp:DropDownList ID="ddlLeadSources2" runat="server" AutoPostBack="true" CssClass=" custom-radio block w-full mt-1 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input" OnSelectedIndexChanged="ddlLeadNames_SelectedIndexChanged">
</asp:DropDownList>
                                 <label class="block mt-2 custom-label">
    <span class="text-gray-700 dark:text-gray-400">KW</span>


                                   <asp:TextBox ID="txkw"  runat="server" CssClass="block w-full mt-1 text-lg dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input" Placeholder="Vadodara" />
                                     <asp:RegularExpressionValidator ID="RegexValidatorFloat" runat="server"
    ControlToValidate="txkw" ErrorMessage="Please enter a valid  number."
    ValidationExpression="^\d+(\.\d+)?$"  ForeColor="Red" Display="Dynamic"/>
                               
                               </label>


                                  <label class="block mt-2 custom-label">
    <span class="text-gray-700 dark:text-gray-400">Address</span>


                                   <asp:TextBox ID="txaddress"  runat="server" CssClass="block w-full mt-1 text-lg dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input" Placeholder="Vadodara" />

                               
                               </label>

                               <label class="block mt-2 custom-label">
    <span class="text-gray-700 dark:text-gray-400">Area Of City</span>


                                   <asp:TextBox ID="txtAreaOfCity"  runat="server" CssClass="block w-full mt-1 text-lg dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input" Placeholder="Vadodara" />

                               
                               </label>
                              <label class="block mt-2  custom-label text-lg">
    <span class="text-gray-700 dark:text-gray-400 larger-font">City</span>


                                   
                                  
                                  <asp:TextBox ID="txtCity"   runat="server" CssClass="block w-full mt-1 text-lg dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input" Placeholder="Vadodara" />
                              
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCity"
    ErrorMessage="City name must contain only alphabetic characters" Display="Dynamic"
    ValidationExpression="^[a-zA-Z\s]+$" ForeColor="Red"></asp:RegularExpressionValidator>

                              
                              </label>
                                <label class="block mt-2 text-lg  custom-label">
                                    <span class="text-gray-700 dark:text-gray-400">Mobile Number</span>
                                    <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="block w-full mt-1 text-lg dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input" Placeholder="1234567890" />
                                <asp:RegularExpressionValidator ID="regexMobileNumber" runat="server" 
    ControlToValidate="txtMobileNumber" 
    ErrorMessage="Please enter a valid 10-digit mobile number" 
    ValidationExpression="^\d{10}$" 
    ForeColor="Red" Display="Dynamic" />
                                
                                </label>
                              
                                <label for="country" class="block text-lg  custom-label mt-2">Lead Sources:</label>
                                
                                
                                <asp:DropDownList ID="ddlLeadSources" runat="server" CssClass=" custom-radio block w-full mt-1 text-sm dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input">
                                    
                                </asp:DropDownList>
                               
                                <div class="form-group radio-group">
    <label for="country" class="custom-label block text-lg mt-2">Area of Lead:</label>
    <asp:RadioButton ID="rdbRuler" runat="server" Text="Rular" GroupName="leadSource" CssClass="custom-radio" />
    <asp:RadioButton ID="rdbUber" runat="server" Text="Urban" GroupName="leadSource" CssClass="custom-radio" />
    
    
</div>

                              <div class="form-group radio-group">
                                    <label for="country" class="block  mt-2  custom-label">Meter Type:</label>
                                    <asp:RadioButton ID="rdbCommonMeter" runat="server" Text="Common Meter" GroupName="meterType" CssClass="custom-radio" />
                                    <asp:RadioButton ID="rdbIndividualMeter" runat="server" Text="Individual Meter" GroupName="meterType" CssClass="custom-radio" />
                                </div>


                                <div class="form-group radio-group">
                                    <label for="country" class="block  mt-2  custom-label">Total Price:</label>
                                   <asp:TextBox ID="txprice" runat="server" CssClass="block w-full mt-1 text-lg dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input" Placeholder="120000" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
    ControlToValidate="txprice" ErrorMessage="Please enter a valid price."
    ValidationExpression="^\d+$" ForeColor="Red" Display="Dynamic" />
                                </div>


                                <div class="c">
                                       <label for="country" class="block  mt-2  custom-label">Add Site Photo:</label>
  <asp:FileUpload ID="fileUpload" runat="server" CssClass="custom-file-upload" onchange="return validateFileType();" />


</div>
                              <asp:Button ID="btnCreatelead_Click" runat="server" Text="Submit" CssClass="block w-full px-4 py-2 mt-4 text-lg font-medium leading-5 text-center text-white transition-colors duration-150 bg-purple-600 border border-transparent rounded-lg active:bg-purple-600 hover:bg-purple-700 focus:outline-none focus:shadow-outline-purple" OnClick="BtnCreatelead_Click"  />

                                 <asp:Button ID="Button1" runat="server" Text="cancel" CssClass="block w-full px-4 py-2 mt-4  text-xl font-medium leading-5 text-center text-white transition-colors duration-150 bg-purple-600 border border-transparent rounded-lg active:bg-purple-600 hover:bg-purple-700 focus:outline-none focus:shadow-outline-purple" OnClick="btncancel_Click" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>
        <footer>
            <p>&copy; 2024 My Website. All Rights Reserved.</p>
        </footer>




                 

        </div>
    </form>

   <script type="text/javascript">
       function validateFileType() {
           var fileInput = document.getElementById('<%= fileUpload.ClientID %>');
           var filePath = fileInput.value;
           var allowedExtensions = /(\.jpg|\.png)$/i;
           if (!allowedExtensions.exec(filePath)) {
               alert('Please select a valid JPG or PNG file.');
               fileInput.value = '';
               return false;
           } else {
               return true;
           }
       }
   </script>



</body>
</html>
