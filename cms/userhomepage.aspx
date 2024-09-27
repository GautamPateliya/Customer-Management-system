<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userhomepage.aspx.cs" Inherits="cms.userhomepage" %>

<!DOCTYPE html>

<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Home Page</title>
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
                        <a href="userleadsource.aspx">
                            <div class="card">
                                <img class="card-img-top" src="\assets\lead source.jpeg" alt="Notes image" />
                                <div class="card-body">
                                    <h3 class="card-title">Lead Source Master </h3>
                                   
                                </div>
                            </div>
                        </a>
                    </div>
                     
                    <!-- More card elements go here -->
                   
                   <div class="col-md-3">
                    <a href="userleadmaster.aspx">
                        <div class="card">
                            <img class="card-img-top" src="\assets\lead2.jpg" alt="Notes image"/>
                            <div class="card-body">
                                <h3 class="card-title">Create New Lead</h3>
                               
                            </div>
                        </div>
                    </a>
                </div>
  <div class="col-md-3">
                        <a href="userleadmasterdata.aspx">
                            <div class="card">
                                <img class="card-img-top" src="\assets\lead data.jpeg" alt="Notes image" />
                                <div class="card-body">
                                    <h3 class="card-title">Registered Lead Details</h3>
                                  
                                </div>
                            </div>
                        </a>
                    </div>
                    <div class="col-md-3">
                    <a href="usersitemaster.aspx">
                        <div class="card">
                            <img class="card-img-top" src="\assets\sitesurvey2.jpeg" alt="Notes image"/>
                            <div class="card-body">
                                <h3 class="card-title">Site Visit</h3>
                                                         </div>
                        </div>
                    </a>
                </div>
                   
              
                    <div class="col-md-3 my-5">
                    <a href="usershowsitemasterdata.aspx">
                        <div class="card">
                            <img class="card-img-top" src="\assets\site detail.jpeg" alt="Notes image"/>
                            <div class="card-body">
                                <h3 class="card-title">Site Visit Details </h3>
                                                         </div>
                        </div>

                    </a>
                          </div>


                      <div class="col-md-3 my-5">
                    <a href="userpreparoffer.aspx">
                        <div class="card">
                            <img class="card-img-top" src="\assets\prepar offer.jpeg" alt="Notes image"/>
                            <div class="card-body">
                                <h3 class="card-title">Prepar Offer</h3>
                                                         </div>
                        </div>

                    </a>
                          </div>



                     <div class="col-md-3 my-5">
                    <a href="userpreparedofferdata.aspx">
                        <div class="card">
                            <img class="card-img-top" src="\assets\prepar offer (2).jpeg" alt="Notes image"/>
                            <div class="card-body">
                                <h3 class="card-title">Prepared Offers </h3>
                                                         </div>
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