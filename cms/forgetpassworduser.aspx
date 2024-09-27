<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forgetpassworduser.aspx.cs" Inherits="cms.forgetpassworduser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Forgot password - Windmill Dashboard</title>
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800&display=swap" rel="stylesheet" />
    <link rel="stylesheet" href="~/assets/css/tailwind.output.css" />
    <script src="https://cdn.jsdelivr.net/gh/alpinejs/alpine@v2.x.x/dist/alpine.min.js" defer></script>
    <script src="~/assets/js/init-alpine.js"></script>

    <style>
         .custom-heading {
    font-size: 2rem; /* Adjust the font size as needed */
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
<div class="flex items-center min-h-screen p-6 bg-gray-50 dark:bg-gray-900">
    <div class="flex-1 h-full max-w-4xl mx-auto overflow-hidden bg-white rounded-lg shadow-xl dark:bg-gray-800">
        <div class="flex flex-col overflow-y-auto md:flex-row">
            <div class="h-32 md:h-auto md:w-1/2">
                <img aria-hidden="true" class="object-cover w-full h-full dark:hidden" src="\assets\forgetpassword.jpeg" alt="Office" />
          
            </div>
            <div class="flex items-center justify-center p-6 sm:p-12 md:w-1/2">
                <div class="w-full">
                    <h1 class="mb-4 text-xl text-teal-500 custom-heading font-semibold text-gray-700 dark:text-gray-200">
                        Forget password
                    </h1>
                     <label class="block text-lg">
                                    <span class="text-gray-700 dark:text-gray-400 text-xl">User ID</span>
                                    <asp:TextBox ID="txtforget" runat="server" CssClass="block w-full mt-1 text-lg dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:text-gray-300 dark:focus:shadow-outline-gray form-input" Placeholder="123456789" />
                                </label>

                    <!-- You should use a button here, as the anchor is only used for the example  -->
                         <asp:Button ID="btnforgetpss" runat="server"  Text="Submit" CssClass="block w-full px-4 py-2 mt-4 text-lg font-medium leading-5 text-center text-white transition-colors duration-150 bg-purple-600 border border-transparent rounded-lg active:bg-purple-600 hover:bg-purple-700 focus:outline-none focus:shadow-outline-purple" OnClick="btnSubmit_Click" />
               <asp:Button ID="Button1" runat="server"  Text="Cancel" CssClass="block w-full px-4 py-2 mt-4 text-lg font-medium leading-5 text-center text-white transition-colors duration-150 bg-purple-600 border border-transparent rounded-lg active:bg-purple-600 hover:bg-purple-700 focus:outline-none focus:shadow-outline-purple" OnClick="cancle_Click" />
          
                    </div>
            </div>
        </div>
    </div>
</div>
        </div>
    </form>
    
</body>
</html>
