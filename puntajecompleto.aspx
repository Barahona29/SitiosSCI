<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="puntajecompleto.aspx.cs" Inherits="proyecto2APSW.puntajecompleto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 <link rel="stylesheet" href="css/puntajecompleto.css" />
       <script src="https://kit.fontawesome.com/a076d05399.js"></script>
       <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/waypoints/4.0.1/jquery.waypoints.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Counter-Up/1.0.0/jquery.counterup.min.js"></script>
   <title>Puntaje</title>
 </head>
 <body>
 
  <script>
  $(document).ready(function(){
    $('.counter').counterUp({
      delay: 10,
      time: 1200
    });
  });
  </script>
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
         <li><a href="index.html">Inicio</a></li>
         <li><a href="login2.aspx">Iniciar Sesion</a></li>
         <li><a href="contactenos.html">Contactenos</a></li>
       </div>
     </ul>
   </nav>
     <div class="counter-up">
    <div class="content">
      <div class="box">
        <div class="icon"><i class="fa fa-cogs"></i></div>
        <div class="counter"><asp:Label ID="lblAmbienteControl" runat="server" Text="0"></asp:Label></div>
        <div class="text">Ambiente de Control</div>
      </div>
      <div class="box">
        <div class="icon"><i class="fas fa-exclamation-triangle"></i></div>
        <div class="counter"><asp:Label ID="lblValoracionRiesgo" runat="server" Text="0"></asp:Label> </div>
        <div class="text">Valoración del Riesgo</div>
      </div>
      <div class="box">
        <div class="icon"><i class="fas fa-chart-line"></i></div>
        <div class="counter"> <asp:Label ID="lblActivControl" runat="server" Text="0"></asp:Label> </div>
        <div class="text">Actividades de control</div>
      </div>
      <div class="box">
        <div class="icon"><i class="fas fa-users"></i></div>
        <div class="counter"> <asp:Label ID="lblSistInfo" runat="server" Text="0"></asp:Label> </div>
        <div class="text">Sistemas de información</div>
      </div>
       <div class="box">
        <div class="icon"><i class="fas fa-folder-open"></i></div>
        <div class="counter"><asp:Label ID="lblSeguimientoSCI" runat="server" Text="0"></asp:Label></div>
        <div class="text">Seguimiento del SCI</div>
      </div>
    </div>
  </div>

    <div class="fondo">
      <div class="contraste">
      <br>
                    <h2>Indice General de Madurez del Sistema de Control Interno</h2>           
    <div class="central">
     <div class="box">
     <br>
       <div class="icon"><i class="fas fa-tasks"></i></div>
        <div class="counter"> <asp:Label ID="lblIndiceGeneral" runat="server" Text="Label"></asp:Label> </div>
        <div class="text"> <asp:Label ID="lblniveldemadurez" runat="server" Text="Label">Nivel de madurez</asp:Label></div>
      </div>
    </div>
    </div>
    </div>
    </div>
    <div class="fondo">
      <div class="contraste">
        <a class="a1" href="puntajes.html">Resultados total de Cada Sistema de Control Interno</a>
      </div>
    </div>



 </body>
</html>
