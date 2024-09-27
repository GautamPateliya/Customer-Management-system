<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="cms.homepage" %>
<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Admin Panel</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css"
          integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.7.2/css/all.css"
          integrity="sha384-fnmOCqbTlWIlj8LyTjo7mOUStjsKC4pOpQbqyi7RrhN7udi9RwhKkMHpvLbHG9Sr"
          crossorigin="anonymous" />
    <link rel="stylesheet" href="StyleSheet2.css" />
      <link rel="stylesheet" href="StyleSheet1.css" />

  

   
</head>
<body>
    <form id="form1" runat="server">
        <header class="font">
           <div>
            <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
               <asp:Image ID="Image1" runat="server" ImageUrl="\assets\logo3.png" style="width: 180px; height: 70px;" />
                 <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse text-2xl  text-uppercase " id="navbarSupportedContent">
                    <ul class="navbar-nav p-2 mr-auto">
                        <li class="nav-item active">
                            <a class="nav-link" href="homepage.aspx">User Management<span class="sr-only">(current)</span></a>
                        </li>
                      
                         <li class="nav-item dropdown  ">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown4" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Masters </a>
    <div class="dropdown-menu " aria-labelledby="navbarDropdown">
       <a class="dropdown-item" href="leadmaster.aspx">New Lead</a>
        <a class="dropdown-item" href="leadsourcemaster.aspx">New Lead Source </a>
            <a class="dropdown-item " href="sitemaster.aspx">Site Visit</a>
        <a class="dropdown-item" href="itemmaster.aspx">Item Master </a>
          <a class="dropdown-item" href="invetertype.aspx">Inverter</a>
         
        <a class="dropdown-item" href="Preperofffer.aspx">Prepar Offer  </a>
         <a class="dropdown-item" href="superadminupdateid.aspx">Update Id and password</a>
         
    </div>
</li>



<li class="nav-item dropdown">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown2" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Leads</a>
    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
        <a class="dropdown-item" href="leadmaster.aspx">New Lead</a>
        <a class="dropdown-item" href="leadsourcemaster.aspx">New Lead Source </a>
         <a class="dropdown-item" href="Leaddatashow.aspx">Registered Leads </a>
    </div>
</li>

                         <li class="nav-item dropdown  ">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown1" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Site Visit</a>
    <div class="dropdown-menu " aria-labelledby="navbarDropdown">
        <a class="dropdown-item " href="sitemaster.aspx">Site Visit</a>
        <a class="dropdown-item" href="showsitemasterdata.aspx">Site Visite Details </a>
       
    </div>
</li>


                        <li class="nav-item dropdown  ">
    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Offer </a>
    <div class="dropdown-menu " aria-labelledby="navbarDropdown">
      
        <a class="dropdown-item" href="itemmaster.aspx">Item Master </a>
        <a class="dropdown-item" href="Preperofffer.aspx">Prepar Offer  </a>
         <a class="dropdown-item" href="invetertype.aspx">Inverter</a>
         <a class="dropdown-item" href="showitemmasterdata.aspx">item master details </a>
         <a class="dropdown-item" href="prepaofferdatashow.aspx">Prepared Offers  </a>

    </div>
</li>





                        <li class="nav-item"></li>



                    </ul>
               <a href="#" id="btnLogout" class="btn btn-outline-success">Log Out</a>

</div>


            </nav>
               </div>
        </header>
       
        <main>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <section class="container text-center">
                <h3>Welcome</h3>
                <hr />
                <br />
                <div class="row ">
                    <div class="col-md-3">
                        <a href="userrole.aspx">
                            <div class="card">
                                <img class="card-img-top" src="\assets\role.jpg" alt="Notes image" />
                                <div class="card-body">
                                    <h5 class="card-title">Role</h5>
                                    Create New Role For User
                                </div>
                            </div>
                        </a>
                    </div>
                     
                    <!-- More card elements go here -->
                   
                   <div class="col-md-3">
                    <a href="Createnewuser.aspx">
                        <div class="card">
                            <img class="card-img-top" src="\assets\user.jpg" alt="Notes image"/>
                            <div class="card-body">
                                <h5 class="card-title">Create User</h5>
                                Create New User for this company
                            </div>
                        </div>
                    </a>
                </div>
  <div class="col-md-3">
                        <a href="itemmaster.aspx">
                            <div class="card">
                                <img class="card-img-top" src="\assets\item.jpeg" alt="Notes image" />
                                <div class="card-body">
                                    <h5 class="card-title">Create New Item</h5>
                                   Admin can Create New Item for the customer 
                                </div>
                            </div>
                        </a>
                    </div>

                     <div class="col-md-3">
                    <a href="createuserdata.aspx">
                        <div class="card">
                            <img class="card-img-top" src="\assets\udata.jpg" alt="Notes image"/>
                            <div class="card-body">
                                <h5 class="card-title">Create User Data </h5>
                               Admin have access to view the created user data.                            </div>
                        </div>
                    </a>
                </div>



                   

                     <div class="col-md-3 mt-5">
                    <a href="showitemmasterdata.aspx">
                        <div class="card">
                            <img class="card-img-top" src="\assets\item data.jpeg" alt="Notes image"/>
                            <div class="card-body">
                                <h5 class="card-title">Item Master Details</h5>
                              Admin can view the Created Item data and modify or delete also.                            </div>
                        </div>
                    </a>
                </div>

                    <div class="col-md-3 mt-5">
                    <a href="prepaofferdatashow.aspx">
                        <div class="card">
                            <img class="card-img-top" src="\assets\prepar offer (2).jpeg" alt="Notes image"/>
                            <div class="card-body">
                                <h5 class="card-title">Prepared Offers </h5>
                               Admin can see the prepared offers and modify or delete.                            </div>
                        </div>
                    </a>
                </div>


                    <div class="col-md-3 mt-5">
                    <a href="Leaddatashow.aspx">
                        <div class="card">
                            <img class="card-img-top" src="\assets\lead data.jpeg" alt="Notes image"/>
                            <div class="card-body">
                                <h5 class="card-title">Registered Leads</h5>
                               Admin can be see the customer details and modify or delete also                         </div>
                        </div>
                    </a>
                </div>

                     <div class="col-md-3 mt-5">
                    <a href="showsitemasterdata.aspx">
                        <div class="card">
                            <img class="card-img-top" src="\assets\site detail.jpeg" alt="Notes image"/>
                            <div class="card-body">
                                <h5 class="card-title">Site Visit Details </h5>
                               Admin can view the Customer Site Survey Details And Can be update or Deletes also.                            </div>
                        </div>
                    </a>
                </div> 
                     </div>
                
                    <!-- Repeat this pattern for other cards -->
                       </section>
        </main>
            <footer>
            <p>&copy; 2024 My Website. All Rights Reserved.</p>
        </footer>
    </form>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"
            integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1"
            crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"
            integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM"
            crossorigin="anonymous"></script>


     <script>
      // Add an event listener to the logout button
      document.getElementById("btnLogout").addEventListener("click", function (event) {
          // Prevent the default action of the anchor tag
          event.preventDefault();

          // Perform the logout action here, such as redirecting to the logout page
          // Replace "logout.aspx" with the actual URL of your logout page
          window.location.href = "login.aspx";
      });
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