<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="WebApplication2.usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <meta charset="UTF-8"/>
    <title>Users Edit</title>
    <link rel="stylesheet" href="css/bootstrap.min.css"/>
       <link rel="shortcut icon" href="img/icon.ico" />
    <script src="js/bootstrap.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/jquery-3.5.1.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
</head>
<body>
     <style>
        #yo {
            padding-right: 2rem;
            
            align-content: center;
        }


        .navbar {
            background-color: #800000;
        }

        .footer {
            background-color: #800000;
        }
         #gdvusuarios {
             border-radius: 27px 27px 27px 27px;
             -moz-border-radius: 27px 27px 27px 27px;
             -webkit-border-radius: 27px 27px 27px 27px;
             border: 0px solid #000000;

         }

         #centrado{
              display: flex;
                align-items: center;
                justify-content: center;
                min-height: 50vh;
         }
        
    </style>
 
    <form id="form1" runat="server">
<nav class="navbar navbar-expand-lg navbar-light">
       <%-- <a class="navbar-brand text-white " href="#">Nissan HRI</a>--%>
         <asp:Button ID="Button1" class="navbar-brand text-white" BackColor="#800000" BorderStyle="None" runat="server" OnClick="btnHome_Click" Text="Nissan HRI" />
          
        <button class="navbar-toggler " type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon "></span>
        </button>

        <div class="collapse navbar-collapse text-white  " id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto text-white">
                  <li class="nav-item active text-white">
                    <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="BtnAlerts" runat="server" Text="Alerts" />
                </li>
                <li class="nav-item active text-white">
                    <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="btnHome" runat="server" OnClick="btnHome_Click" Text="Home" />
                </li>
                <li class="nav-item">
                    <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="BtnUsers" runat="server" Text="Usuarios" OnClick="BtnUsers_Click" />
                    
                   
                </li>
                 <li class="nav-item">
                    <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="btnHRI" runat="server" Text="HRI" OnClick="BtnHRI_Click" />
                    
                   
                </li>
                 <li class="nav-item">
                    <asp:Button class="nav-link text-white" BackColor="#800000"  BorderStyle="None" ID="BtnControl" runat="server" Text="Control" OnClick="BtnControl_Click" />
                    
                   
                </li>
                

            </ul>
            <div id="yo">
                <asp:Label ID="lblId" runat="server" ></asp:Label>
                
            </div>

            <div class="nav-item">
                <asp:Button class="nav-link text-white" ID="btnlogout" BackColor="#800000" BorderStyle="None" runat="server" Text="Logout" OnClick="btnlogout_Click" />
               </div>
           

        </div>
    </nav>
    

        <div id="centrado" class="card mb-12" >
            <h2>User Manager</h2>
             <div class="text-center">
                <h2>
                     <asp:Label ID="lblmensaje" class="badge badge-warning" runat="server" Text=""></asp:Label>
           
                </h2>
                </div>
             <div class="text-center">
                <h2>
                     <asp:Label ID="jolosoy" class="badge badge-success" runat="server" Text=""></asp:Label>
           
                </h2>
                </div>
            <div class="row">

                <div class="col-md-6">
                 
                        <div class="form-group">
                            <label for="exampleInputEmail1">Usuario</label>

                            <asp:TextBox type="text" class="form-control" ID="txtUser" runat="server"></asp:TextBox>
                           
                           
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1">Password</label>
                            <asp:TextBox type="password" class="form-control" ID="txtPass" runat="server"></asp:TextBox>
                         
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1">Vuelva a Ingresar el pasword</label>
                            <asp:TextBox type="password" class="form-control" ID="txtPass2" runat="server"></asp:TextBox>
                         
                        </div>
                      <div class="text-center">
                          <asp:Button ID="btnAdd" class="btn btn-primary" runat="server" Text="Save" OnClick="btnAdd_Click" />
                         
                      </div>
                        
                

                </div>

                <div class="col-md-1">

                </div>

                <div class="col-md-5">

                    <asp:GridView class="thead-dark text-center" OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting" OnRowEditing="OnRowEditing" ID="gdvusuarios" DataKeyNames="id" runat="server" ImageUrl="~/icons/cancel.png" AutoGenerateDeleteButton="False"  AllowPaging="true" OnPageIndexChanging="OnPaging" PageSize="5" CssClass="table table-bordered table-striped mb-0" RowHeaderColumn="hola, prros" AutoGenerateColumns="False">
                       <Columns>
                           <asp:BoundField DataField="id" ItemStyle-CssClass="text-center" HeaderText="id" ItemStyle-Width="150" />
                           <asp:BoundField DataField="Usuario" ItemStyle-CssClass="text-center" HeaderText="Usuario" ItemStyle-Width="150" />
                           <asp:BoundField DataField="Password" ItemStyle-CssClass="text-center" HeaderText="Password" ItemStyle-Width="150" />
                           <asp:TemplateField>
                               <ItemTemplate>

                                   <h2><asp:LinkButton Text="📝" runat="server" CommandName="Edit"  >
                                        <img src="icons/edit.png" width="40" height="40"  > </asp:LinkButton> 
                                   </h2> 
                                  
                               </ItemTemplate>
                               <EditItemTemplate>
                                   <asp:LinkButton Text="Update" runat="server" OnClick="OnUpdate" />
                                   <asp:LinkButton Text="Cancel" runat="server" OnClick="OnCancel" />
                               </EditItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField>
                               <ItemTemplate>

                                   <h2><asp:LinkButton Text="" runat="server" CommandName="Delete" >
                                        <img src="icons/cancel.png" > </asp:LinkButton> 
                                   </h2>
                                  
                               </ItemTemplate>
                               
                           </asp:TemplateField>
                       </Columns>
                        <HeaderStyle BackColor="Maroon" BorderStyle="None" ForeColor="White" />
                    </asp:GridView>
                    <br />

                </div>


            </div>
           

        </div>

    </form>

    <div>
       
    </div>
    <div id="hola ">
        <footer class="footer page-footer font-small sticky-footer ">
            <div align="center">
                <div class="row col-md-7">
                    <div class="col-md-8">
                        <p class="text-white">
                            <br>
                            <br>
                            <b> Nissan Mexicana              <br> <b>Extensiones Soporte: 2153,2154,2155,2156</b>
                            <br>Nissan HRI Web Portal V0.1.1 (Release)
                        </p>
                    </div>

                    <div class="col-md-4">
                        <img src="img/aad.png" alt="" height="200" width="200">
                    </div>

                </div>




            </div>

        </footer>
    </div>
     <script src="js/bootstrap.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/jquery-3.5.1.min.js"></script>
</body>
</html>
