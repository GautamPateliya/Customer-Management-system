<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="cms.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login - RoofTop Dashboard</title>
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="~/assets/css/tailwind.output.css" />
    <script src="https://cdn.jsdelivr.net/gh/alpinejs/alpine@v2.x.x/dist/alpine.min.js" defer></script>
    <script src="~/assets/js/init-alpine.js"></script>

    <link rel="stylesheet" href="StyleSheet1.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" integrity="sha384-TX8t27EcRE3e/ihU7zmQxVncDAy5uIKz4rEkgIXeMed4M0jlfIDPvg6uqKI2xXr2" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js" integrity="sha384-9/reFTGAW83EW2RDu2S0VKaIzap3H66lZH81PoYlFhbGU+6BZp6G7niu735Sk7lN" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/js/bootstrap.min.js" integrity="sha384-w1Q4orYjBQndcko6MimVbzY0tgp4pWB4lZ7lr30WKz0vr/aWKhXdBNmNb5D92v7s" crossorigin="anonymous"></script>

</head>
<body>
    <form id="form1" runat="server">

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
                            <a class="nav-link" href="#">User Management<span class="sr-only">(current)</span></a>
                        </li>
                      <li class="nav-item dropdown">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown2" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Lead Master</a>
   
</li>
                         <li class="nav-item dropdown  ">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown1" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Site visit</a>
   
    
</li>


                        <li class="nav-item dropdown  ">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Offer </a>
   
</li>




                        <li class="nav-item"></li>



                    </ul>
               <a href="#" id="btnLogout" class=""></a>

</div>


            </nav>
               </div>
        </header>
       
        <div>
    <div class="flex items-center min-h-screen p-6 bg-gray-50 dark:bg-gray-900">
        <div class="flex-1 h-full max-w-4xl mx-auto overflow-hidden bg-white rounded-lg shadow-xl dark:bg-gray-800">
            <div class="flex flex-col overflow-y-auto md:flex-row">
                <div class="h-32 md:h-auto md:w-1/2">
                    <asp:Image ID="MyImage" runat="server" CssClass="object-cover w-full h-full" ImageUrl="~/assets/img/login-office.jpeg" AlternateText="Your Image" />
                                   </div>
                <div class="flex items-center justify-center p-6 sm:p-12 md:w-1/2">
                    <div class="w-full">
                        <h1  class="mb-4 text-teal-500 font-bold text-gray-" style="font-size: 2em;">
                            Login
                        </h1>
                         <label class="block text-xl">
                                    <span class="text-gray-700 dark:text-gray-400">User Id</span>
                                  <asp:TextBox ID="txtUserMobileNumber" runat="server" CssClass="block w-full mt-1 text-lg dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input" 
    Placeholder="1234567890" onblur="validateMobileNumber()" />

<asp:RegularExpressionValidator ID="regexMobileNumber" runat="server" 
    ControlToValidate="txtUserMobileNumber" 
    ErrorMessage="Please enter a valid User Id" 
    ValidationExpression="^\d{10}$" 
    ForeColor="Red" Display="Dynamic" />
                                       </label>
                        
                         <label class="block mt-4  text-xl">

                                      <span class="text-gray-700 dark:text-gray-400">Password</span>
                        <div class="relative">
    <asp:TextBox ID="txtPassword" runat="server" CssClass="block w-full mt-1 text-lg dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input pr-10" 
        TextMode="Password" Placeholder="***************" />

        <asp:CustomValidator ID="customPasswordValidator" runat="server"
    ControlToValidate="txtPassword"
    ErrorMessage="Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character."
    ClientValidationFunction="validatePasswordClient"
    ForeColor="Red" Display="Dynamic" />
 </label>
                        <asp:Button runat="server" ID="btnLogin" OnClick="loginbtn" Text="Log in" CssClass="block w-full px-4 py-2 mt-4 text-lg font-medium leading-5 text-center text-white transition-colors duration-150 bg-purple-600 border border-transparent rounded-lg active:bg-purple-600 hover:bg-purple-700 focus:outline-none focus:shadow-outline-purple"></asp:Button>

                        <hr class="my-8" />
                        <p class="mt-4">
                            <a class="text-lg font-medium text-purple-600 dark:text-purple-400 hover:underline" href="forgetpassworduser.aspx">Forget your password?</a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>   <!-- footer -->
        <footer>
            <p>&copy; 2024 My Website. All Rights Reserved.</p>
        </footer>
    </form>

      <script type="text/javascript">
      function validatePasswordClient(sender, args) {
          var password = document.getElementById('<%= txtPassword.ClientID %>').value;
          var minLength = 8;
          var uppercaseRegex = /[A-Z]/;
          var lowercaseRegex = /[a-z]/;
          var digitRegex = /\d/;
          var specialCharRegex = /[!@#$%^&*()_+\-=[\]{};':"\\|,.<>/?]/;

          if (password.length < minLength ||
              !uppercaseRegex.test(password) ||
              !lowercaseRegex.test(password) ||
              !digitRegex.test(password) ||
              !specialCharRegex.test(password)) {
              args.IsValid = false;
          } else {
              args.IsValid = true;
          }
      }
 
      </script>

    <script>
        function preventBackNavigation() {
            // Check if the page is the topmost in the history
            if (window.history && window.history.pushState) {
                window.history.pushState(null, null, window.location.href);
                window.onpopstate = function () {
                    window.history.pushState(null, null, window.location.href);
                };
            }
        }

        // Call the function on page load
        window.onload = preventBackNavigation;
    </script>
</body>
</html>
