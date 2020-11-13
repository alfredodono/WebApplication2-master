<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ControlHRI.aspx.cs" Inherits="WebApplication2.ControlHRI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="UTF-8" />
    <title>HRI Manager</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
 <link rel="shortcut icon" href="img/icos/image.ico" />
    <script src="js/bootstrap.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/jquery-3.5.1.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
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

        #centrado {
            display: flex;
            align-items: center;
            justify-content: center;
            min-height: 50vh;
        }
    </style>

    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-lignt">
          <asp:Button ID="Button1" class="navbar-brand text-white" BackColor="#800000" BorderStyle="None" runat="server" OnClick="btnHome_Click" Text="Nissan HRI" />
            <button class="navbar-toggler " type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon "></span>
            </button>

            <div class="collapse navbar-collapse text-white  " id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto text-white">
                    <li class="nav-item active text-white">
                        <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="BtnAlerts" runat="server" Text="Alerts" OnClick="BtnAlerts_Click" />
                    </li>
                    <li class="nav-item active text-white">
                        <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="btnHomes" runat="server" Text="Home" OnClick="btnHome_Click" />
                    </li>
                    <li class="nav-item">
                        <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="BtnUsers" runat="server" Text="Usuarios" OnClick="BtnUsers_Click" />


                    </li>
                    <li class="nav-item">
                        <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="btnHRI" runat="server" Text="HRI" OnClick="BtnHRI_Click" />


                    </li>
                    <li class="nav-item">
                        <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="BtnControl" runat="server" Text="Control" OnClick="BtnControl_Click" />


                    </li>


                </ul>
                <div id="yo">
                    <asp:Label ID="lblId" runat="server"></asp:Label>

                </div>

                <div class="nav-item">
                    <asp:Button class="nav-link text-white" ID="btnlogout" BackColor="#800000" BorderStyle="None" runat="server" Text="Logout" OnClick="btnlogout_Click" />
                </div>


            </div>
        </nav>
        <div class="text-center">

      
        <h2>HRI Manager</h2>
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
              </div>
        <div id="centrado" class="mb-12">
            
            <div class="row">

                <div class="col-md-4 " style="">

                    <div class="text-center">
                        <h3>
                            <asp:Label ID="Label8" runat="server" Text="Relaciones Activas"></asp:Label>
                        </h3>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-8">

                            <asp:TextBox ID="TextBox2" placeholder="Ingrese Nombre" runat="server" class="form-control" OnTextChanged="TextBox2_TextChanged" AutoPostBack="True"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4">
                            <asp:Button ID="Button3" runat="server" Text="Buscar" type="button" OnClick="Button3_Click" class="btn btn-warning btn-block" ForeColor="White" />

                        </div>
                    </div>
                    <table class="table table-bordered table-striped" border="1" style="border-collapse: collapse;">
                        <tbody>
                            <tr style="color: White; background-color: Maroon; border-style: None;">
                                <td class="" style="width: ">Id
                                </td>
                                <td class="" style="width: 450px;">
                                    <label>Nombre</label>
                                </td>

                                <td class="" style="width: 5px;">Eliminar
                                </td>

                            </tr>
                        </tbody>
                    </table>
                    <div class="text-center" style="height: 400px; width: auto; overflow: auto;">

                        <%--                    <asp:TextBox ID="txtid" runat="server"></asp:TextBox>--%>

                        <asp:Label ID="cabecera" runat="server"></asp:Label>
                        <asp:GridView ID="TablaRel" DataKeyNames="ID" OnRowDeleting="OnRowDeleting" class="thead-dark text-center" OnRowUpdating="gdvHRI_RowUpdating" ShowHeader="false" CssClass="table table-bordered table-striped " RowHeaderColumn="hola, prros" AutoGenerateColumns="false" runat="server">

                            <Columns>
                                <asp:BoundField DataField="ID" ItemStyle-CssClass="text-center" HeaderText="ID" />
                                <asp:BoundField DataField="User" ItemStyle-CssClass="text-center" HeaderText="User" />
                                <asp:BoundField DataField="HRI" ItemStyle-CssClass="text-center" HeaderText="HRI" />

                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>

                                        <h2>
                                            <asp:LinkButton Text="dc" runat="server" CommandName="Delete">
                                        <img src="icons/cancel.png" width="40" height="40"> </asp:LinkButton>
                                        </h2>

                                    </ItemTemplate>

                                </asp:TemplateField>


                            </Columns>

                            <HeaderStyle BackColor="Maroon" BorderStyle="None" ForeColor="White" />
                        </asp:GridView>

                    </div>

                </div>

                <br />

                

                <div class="col-md-3 " style="">

                    <div class="text-center">
                        <h3>
                            <asp:Label ID="Label1" runat="server" Text="Usuarios"></asp:Label>
                        </h3>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-8">

                            <asp:TextBox ID="txbUsuarios" OnTextChanged="txbUsuarios_TextChanged" placeholder="Ingrese Nombre" runat="server" class="form-control" AutoPostBack="True"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4">
                            <asp:Button ID="btnUser" OnClick="btnUser_Click" runat="server" Text="Buscar" type="button" class="btn btn-warning btn-block" ForeColor="White" />

                        </div>
                    </div>
                    <table class="table table-bordered table-striped" border="1" style="border-collapse: collapse;">
                        <tbody>
                            <tr style="color: White; background-color: Maroon; border-style: None;">
                                <td class="" style="width: 100px;">Id
                                </td>
                                <td class="" style="width: 200px;">
                                    <label>Nombre</label>
                                </td>

                                <td class="" style="width: 5px;">Agregar
                                </td>

                            </tr>
                        </tbody>
                    </table>
                    <div class="text-center" style="height: 400px; width: auto; overflow: auto;">

                        <%--                    <asp:TextBox ID="txtid" runat="server"></asp:TextBox>--%>

                        <asp:Label ID="Label2" runat="server"></asp:Label>
                        <asp:GridView ID="tablaus" DataKeyNames="ID" OnRowDeleting="tablaus_RowDeleting" class="thead-dark text-center" OnRowUpdating="gdvHRI_RowUpdating" ShowHeader="false" CssClass="table table-bordered table-striped " RowHeaderColumn="hola, prros" AutoGenerateColumns="false" runat="server">

                            <Columns>
                                <asp:BoundField DataField="ID" ItemStyle-CssClass="text-center" HeaderText="ID" />
                                <asp:BoundField DataField="Usuario" ItemStyle-CssClass="text-center" HeaderText="Usuario" />


                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>

                                        <h2>
                                            <asp:LinkButton Text="dc" runat="server" CommandName="Delete">
                                        <img src="icons/add.png" width="40" height="40"> </asp:LinkButton>
                                        </h2>

                                    </ItemTemplate>

                                </asp:TemplateField>


                            </Columns>

                            <HeaderStyle BackColor="Maroon" BorderStyle="None" ForeColor="White" />
                        </asp:GridView>

                    </div>

                </div>

                <div class="col-md-2 " style="">

                    
                    
                    <br />
                    <br />
                    <br />
                      <div class="form-group text-center">
                       
                          <h3>
                              <asp:Label ID="Label5" runat="server"  Text="Relacionar"></asp:Label>
                          </h3>
                        
                        
                    </div>
                    <div class="form-group">
                       
                        <asp:TextBox class="form-control" ID="txtUser" runat="server"  placeholder="id_Usuario"></asp:TextBox>
                        
                        <small id="emailHelp" class="form-text text-muted"></small>
                    </div>
                    <div class="form-group">
                        
                        <asp:TextBox ID="txtHRI" class="form-control" placeholder="id_HRI" runat="server"></asp:TextBox>
                        

                    </div>
                    <asp:Button ID="btnrel" runat="server" OnClick="btnrel_Click" Text="Relacionar" type="button" class="btn btn-warning btn-block" ForeColor="White" />
                </div>
                <div class="col-md-3 " style="">

                    <div class="text-center">
                        <h3>
                            <asp:Label ID="Label3" runat="server" Text="HRI"></asp:Label>
                        </h3>
                    </div>

                    <div class="form-row">
                        <div class="form-group col-md-8">

                            <asp:TextBox ID="txbHRI" placeholder="Ingrese Nombre" OnTextChanged="txbHRI_TextChanged" runat="server" class="form-control" AutoPostBack="True"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-4">
                            <asp:Button ID="Button2" runat="server" Text="Buscar" type="button" class="btn btn-warning btn-block" ForeColor="White" />

                        </div>
                    </div>
                    <table class="table table-bordered table-striped" border="1" style="border-collapse: collapse;">
                        <tbody>
                            <tr style="color: White; background-color: Maroon; border-style: None;">
                                <td class="" style="width: 100px;">Id
                                </td>
                                <td class="" style="width: 200px;">
                                    <label>Nombre HRI</label>
                                </td>

                                <td class="" style="width: 5px;">Agregar
                                </td>

                            </tr>
                        </tbody>
                    </table>
                    <div class="text-center" style="height: 400px; width: auto; overflow: auto;">

                        <%--                    <asp:TextBox ID="txtid" runat="server"></asp:TextBox>--%>

                        <asp:Label ID="Label4" runat="server"></asp:Label>
                        <asp:GridView ID="gdvHRI" DataKeyNames="ID" OnRowDeleting="gdvHRI_RowDeleting" class="thead-dark text-center" OnRowUpdating="gdvHRI_RowUpdating" ShowHeader="false" CssClass="table table-bordered table-striped " RowHeaderColumn="hola, prros" AutoGenerateColumns="false" runat="server">

                            <Columns>
                                <asp:BoundField DataField="ID" ItemStyle-CssClass="text-center" HeaderText="ID" />
                                <asp:BoundField DataField="HRI" ItemStyle-CssClass="text-center" HeaderText="HRI" />


                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>

                                        <h2>
                                            <asp:LinkButton Text="dc" runat="server" CommandName="Delete">
                                        <img src="icons/add.png" width="40" height="40"> </asp:LinkButton>
                                        </h2>

                                    </ItemTemplate>

                                </asp:TemplateField>


                            </Columns>

                            <HeaderStyle BackColor="Maroon" BorderStyle="None" ForeColor="White" />
                        </asp:GridView>

                    </div>

                </div>

                <br />



            </div>


        </div>

    </form>

    <div>
     <br />
      <br />
    </div>
     

     <div id="hola ">
        <footer class="footer page-footer font-small  fixed-bottom ">
         
            <div align="center">
                <div class="row col-md-5">
                    <div class="col-md-8">
                        <p class="text-white">
                            <br/>
                        
                            <b> Nissan Mexicana</b>
                            <br/> <b>Extensiones Soporte: 2153,2154,2155,2156</b>
                            <br/>Nissan HRI Web Portal V0.1.1 (Release)
                        </p>
                    </div>

                    <div class="col-md-4">
                        <img src="img/image.png" alt="" height="150" width="200"/>
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
