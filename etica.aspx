<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="etica.aspx.cs" Inherits="proyecto2APSW.etica" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel="stylesheet" href="css/compromiso4.css">
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">

    <title>Ética</title>
    <style>
        .btnDescargar {
        background-color: black;
        color: rgb(245, 246, 250);
        border-radius: 3px;
        cursor: pointer;
        }

        

        table {
    border-collapse: collapse;
    position: absolute;
    Width: 880px;
}

th {
    background-color: #000000;
    color: white;
    
    font-weight: normal;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    position: -webkit-sticky;
    position: sticky;
    top: -1px;
}

th, td {
    /* text-align: center;*/
    padding: 8px;
   
    font-weight: normal;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
}
    </style>
</head>
<body>
     <form id="form1" runat="server">

  <nav class="navbar">
    <!-- LOGO -->
    <div class="logo"></div>
    <!-- NAVIGATION MENU -->
    <ul class="nav-links">
      <!-- USING CHECKBOX HACK -->
      <input type="checkbox" id="checkbox_toggle" />
      <label for="checkbox_toggle" class="hamburger">&#9776;</label>
      <!-- NAVIGATION MENUS -->
      <div class="menu">
        <li><a href="modelomadurez.aspx">Inicio</a></li>
       
        </li>
       <li><a href="login2.aspx">Cerrar sesión</a></li>
        <li><a href="contactenos.html">Contactenos</a></li>
      </div>
    </ul>
  </nav>

       

  <div class="banner">
    <br>
    <br>
    <br>
    <br>
    <br>
    <h1 class="titulo">&nbsp &nbsp Ética</h1>
   <p class="A2">&nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp<a class="A2" href="">Inicio</a> &nbsp > &nbsp Ambiente de control &nbsp > &nbsp Ética</p>
</div>

<br>
<div class="fondo">
<div class="contraste" style="left: 2%; position:absolute;">
  <div class="div-tabla1">
    <div class="contenedor-tabla">
   


        <asp:Table ID="Table1" runat="server">

        </asp:Table>
    </div>
  </div>
  </div>


    

    <div style="left: 76%; position: absolute; top: 58%;">
    <asp:Label ID="lblCodigo" runat="server" Visible="false" Text="Evidencia: Código"></asp:Label> <br>
        <asp:Label ID="lblEstado" runat="server" Visible="false" Text="Estado: Pendiente"></asp:Label>  <br>
        <asp:Label ID="lblTextoLink" runat="server" Visible="false" Text="Link de la evidencia:"></asp:Label>
<br>
        <asp:TextBox ID="txtlinkEvid" Visible="false" runat="server"></asp:TextBox>
<p style="text-align: center;">
    <asp:Label ID="lblo" runat="server" Visible="false" Text="o"></asp:Label></p>
<div class="file-select" id="src-file1" >
 
    <asp:FileUpload Visible="false" ID="FileUpload1" runat="server" />
</div>
<br><br>
<br> <asp:Button ID="btnEnviar" Visible="false" CssClass="button1" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
        <br />
        <br />
        
    </div>
    

  </div>

    
  

         </form>

    <script>
        function cargar(c) {
            var nombrec = c.id;
            var miCheckbox = document.getElementsByName(nombrec);

            if (!miCheckbox.checked) {
                window.location.href = "etica.aspx?valor=1;"+c.id;
            } 

           

        }

        function descargar(c) {
            var nombrec = c.name;
          
                window.location.href = "etica.aspx?valor=2;" + nombrec;
            



        }

       

    </script>

</body>
</html>
