<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarios.aspx.cs" Inherits="proyecto2APSW.usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <link rel="stylesheet" href="css/aceptacion1.css" />
   <title>Muestras</title>
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
         <li><a href="generalfiscalizador.aspx">Inicio</a></li>
         <li><a href="contactenos.html">Contactenos</a></li>
         <li><a href="asignacion.aspx">Rol de Persona</a></li>
       </div>
     </ul>
   </nav>
         <br />
         <br />
         <asp:Table ID="Table1" Width="80%" runat="server"></asp:Table>
            </form>

     <script>
         function cargar(c) {

             var nombrec = c.id;



             window.location.href = "asignacion.aspx/?nombre=" + nombrec + ";" + "2";

         }
     </script>
</body>
</html>

