<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HriCreate.aspx.cs" Inherits="WebApplication2.HriCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="UTF-8" />
    <title>Question Manager</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
    <link rel="shortcut icon" href="img/icon.ico" />
    <script src="js/bootstrap.min.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="jquery/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="js/jquery-3.5.1.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <script type="text/javascript">
        function showpreview(input) {

            if (input.files && input.files[0]) {

                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#imgpreview').css('visibility', 'visible');
                    $('#imgpreview').attr('src', e.target.result);
                }
                reader.readAsDataURL(input.files[0]);
            }

        }

    </script>
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
            <asp:Button ID="Button2" class="navbar-brand text-white" BackColor="#800000" BorderStyle="None" runat="server" OnClick="btnHome_Click" Text="Nissan HRI" />
            <button class="navbar-toggler " type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon "></span>
            </button>

            <div class="collapse navbar-collapse text-white  " id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto text-white">
                    <li class="nav-item active text-white">
                        <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="BtnAlerts" runat="server" Text="Alerts" />
                    </li>
                    <li class="nav-item active text-white">
                        <asp:Button class="nav-link text-white" BackColor="#800000" BorderStyle="None" ID="btnHomes"  runat="server" Text="Home" OnClick="btnHome_Click" />
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
            <h2>Question Manager</h2>
        </div>
        <div class="container-fluid">
            <div class="form-row text-center">
                <div class="form-group col-md-2">
                    <asp:Button ID="btnVol" runat="server" Text="◄ Volver " OnClick="btnVol_Click"  class="btn btn-warning btn-block" ForeColor="White" />

                </div>
                <div class="form-group col-md-2">
                    <asp:Button ID="btnvolHRI" runat="server" Text="Administrar IPs 💻" OnClick="btnvolHRI_Click"  class="btn btn-success btn-block" ForeColor="White" />

                </div>
            </div>
        </div>
        <div id="centrado" class=" mb-12">

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

                <div class="col-md-5 card">


                    <br />
                    <br />
               

                    <div class="form-group text-center">
                        <h3>Registro</h3>
                        <asp:TextBox  placeholder="Ingrese pregunta" class="form-control" ID="txtUser" runat="server" ></asp:TextBox>
                        <br />
                    </div>
                    <asp:FileUpload ID="fuimage" runat="server"  onchange="showpreview(this);"  />
                

                    <div class="text-center justify-content-md-center justify-content-center align-items-center">
                        <div class="card mx-auto">
                            <img id="imgpreview" height="400" width="400" src="A" style="border-width: 0px; visibility: hidden;" />
                        </div>


                    </div>


                    <div class="form-group">

                        <div class="form-row">
                            <div class="form-group">
                                 <asp:CheckBox ID="Cb1" runat="server" />
                            </div>
                            <div class="form-group col-md-10">
                                <asp:Label ID="Label1" runat="server" Text="Es necesaria la foto?"></asp:Label>
                            </div>
                        </div>

                    </div>
                    <div class="text-center">
                        <asp:Button ID="btnSave" class="btn btn-primary" runat="server" Text="Save" onclick="btnSave_Click" />
                   
                    </div>



                </div>





                <div class="col-md-7">

                    <br />



                    <div class="text-center">


                        <table class="table table-bordered table-striped" border="1" style="border-collapse: collapse;">
                            <tbody>
                                <tr style="color: White; background-color: Maroon; border-style: None;">
                                    <td class="" style="width: 50px;">Id
                                    </td>
                                    <td class="" style="width: 260px;">
                                        <label>pregunta</label>
                                    </td>

                                    <td class="" style="width: 200px;">Foto
                                    </td>

                                    <td class="" style="width: 110px;">Requerida
                                    </td>
                                    <td class="" style="width: 5px;">Editar
                                    </td>
                                    <td class="" style="width: 5px;">Eliminar
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="text-center" style="height: 500px; width: auto; overflow: auto;">

                        <%--                    <asp:TextBox ID="txtid" runat="server"></asp:TextBox>--%>

                        <asp:Label ID="cabecera" runat="server"></asp:Label>
                        <asp:GridView ID="gdvusuarios" DataKeyNames="ID" OnRowUpdating="gdvusuarios_RowUpdating" OnRowDataBound="OnRowDataBound" OnRowDeleting="OnRowDeleting" class="thead-dark text-center" ShowHeader="false" CssClass="table table-bordered table-striped " RowHeaderColumn="hola, prros" AutoGenerateColumns="false" runat="server">

                            <Columns>
                                <asp:BoundField DataField="ID" ItemStyle-CssClass="text-center" HeaderText="id" ItemStyle-Width="10" />
                                <asp:BoundField DataField="Question" ItemStyle-CssClass="text-center" HeaderText="Question" ItemStyle-Width="150" />

                                <asp:TemplateField HeaderText="Picture">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" Width="100" Height="100" />
                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:BoundField DataField="Required" ItemStyle-CssClass="text-center" HeaderText="Picture Required" ItemStyle-Width="10" />

                                <asp:TemplateField>
                                    <ItemTemplate>

                                        <h2>
                                            <asp:LinkButton Text="" runat="server" CommandName="Update" ItemStyle-Width="10">
                                        <img src="icons/edit.png" width="40" height="40"> </asp:LinkButton>
                                        </h2>

                                    </ItemTemplate>

                                </asp:TemplateField>

                                <asp:TemplateField>
                                    <ItemTemplate>

                                        <h2>
                                            <asp:LinkButton Text="" runat="server" CommandName="Delete" ItemStyle-Width="10">
                                        <img src="icons/cancel.png" > </asp:LinkButton>
                                        </h2>

                                    </ItemTemplate>

                                </asp:TemplateField>
                            </Columns>

                            <HeaderStyle BackColor="Maroon" BorderStyle="None" ForeColor="White" />
                        </asp:GridView>

                    </div>


                </div>


            </div>
        </div>
    </form>


    <div id="">
        <br />

        <br />
        <footer class="footer page-footer font-small   ">
            <div >
                <div class="row col-md-7">
                    <div class="col-md-8">
                        <p class="text-white">
                            <br />
                            <b>Nissan Mexicana             
                                <br />
                                <b>Extensiones Soporte: 2153,2154,2155,2156</b>
                                <br />
                                Nissan HRI Web Portal V0.1.1 (Release) </b>

                        </p>
                    </div>

                    <div class="col-md-4">
                        <img src="img/aad.png" alt="" height="100" width="100" />
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

