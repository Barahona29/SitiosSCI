<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="solicitud2.aspx.cs" Inherits="proyecto2APSW.solicitud2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
         <link rel="stylesheet" href="css/solicitud.css" />
 <title>Solicitud</title>
 </head>
 <body>
      <style>
         .botondesc 
         {
         background-color:black;
         color:white;
         }

         .counter-up{
  min-height: 50vh;
  background-size: cover;
  background-attachment: fixed;
  padding: 0 50px;
  position: relative;
  display: flex;
  align-items: center;
}
.counter-up::before{
  position: absolute;
  content: "";
  top: 0;
  left: 0;
  height: 100%;
  width: 100%;
 
}
.counter-up .content{
  z-index: 1;
  position: relative;
  display: flex;
  width: 100%;
  height: 100%;
  flex-wrap: wrap;
  align-items: center;
  justify-content: space-between;
}
.counter-up .content .box{

  display: flex;
  align-items: center;
  justify-content: space-evenly;
  flex-direction: column;
  padding: 10px;
}
.content .box .icon{
  font-size: 48px;
  color: #000000;
}
.content .box .counter{
  font-size: 50px;
  font-weight: 500;
  color: #000000;
  font-family: sans-serif;
}
.content .box .text{
  font-weight: 400;
  color: #000000;
}

     </style>
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
          <li><a href="http://empresasci-001-site1.etempurl.com/generaldirector.aspx">Inicio</a></li>
         <li><a href="http://empresasci-001-site1.etempurl.com/Muestra.aspx">Comunicación</a></li>
         <li><a href="http://empresasci-001-site1.etempurl.com/login2.aspx">Cerrar Sesión</a></li>
       </div>
     </ul>
   </nav>
<div class="bloque">
 <h1> Evidencias </h1>
</div>
<br>
         	<div style="text-align:center;">
                <div id="counterup" class="counter-up">
    <div id="content" class="content">
				<div class="box" >
        <div class="icon"><i id="icon1" class="fa fa-cogs"></i></div>
        <div id="cont1" class="counter"><asp:Label ID="lblpuntaje1" runat="server" Text=""></asp:Label></div>
        <div class="text">
            <asp:Label ID="lblpuntaje1texto" runat="server" Text=""></asp:Label></div>
      </div>
					&nbsp&nbsp&nbsp&nbsp&nbsp
					<div class="box" >
        <div class="icon"><i id="icon2" class="fa fa-cogs"></i></div>
        <div id="cont2" class="counter"><asp:Label ID="lblpuntaje2" runat="server" Text=""></asp:Label></div>
        <div class="text"><asp:Label ID="lblpuntaje2texto" runat="server" Text=""></asp:Label></div>
      </div>
					&nbsp&nbsp&nbsp&nbsp&nbsp
					<div class="box" >
        <div class="icon"><i id="icon3" class="fa fa-cogs"></i></div>
        <div id="cont3" class="counter"><asp:Label ID="lblpuntaje3" runat="server" Text=""></asp:Label></div>
        <div class="text"><asp:Label ID="lblpuntaje3texto" runat="server" Text=""></asp:Label></div>
      </div>
					</div>
                    </div>
                </div>


<div class="fondo">
            <div class="contraste">
                <div class="div-tabla1">
                <div class="reporte">
                
                    <asp:Button ID="btnReporteGen" class="btnreporte" runat="server" Text="Reporte General" OnClick="btnReporteGen_Click" />
                </div>
                   <h1>Lista de evidencias</h1> 
                <br/>
                     <div class="filtro">
                        <label class="label">Búsqueda por:</label>
                         <asp:DropDownList ID="ddlfiltro" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlfiltro_SelectedIndexChanged">
                        <asp:ListItem>Pendiente</asp:ListItem>
                        <asp:ListItem>Aprobadas</asp:ListItem>
                        <asp:ListItem>Rechazadas</asp:ListItem>
                    </asp:DropDownList>
                   <br/>
                    </div>
                    <div class="contenedor-tabla">
                        <asp:Table ID="Table1" runat="server">

                        </asp:Table>
                    </div>          
                </div> 
                
                </form>
     <script>

         function aceptar(c) {

             var nombrec = c.name;
             const valores = window.location.search;
             const datos = valores.split(';');
             const datoss = datos[0].split('=');

             window.location.href = "respuesta.aspx/?valor=" + nombrec + ";" + datos[2] + ";" + "1" + ";" + datoss[1] + ";" + datos[1];
         }

         function rechazar(c) {

             var nombrec = c.name;
             const valores = window.location.search;
             const datos = valores.split(';');
             const datoss = datos[0].split('=');

             window.location.href = "respuesta.aspx/?valor=" + nombrec + ";" + datos[2] + ";" + "2" + ";" + datoss[1] + ";" + datos[1];
         }

         function descargar(c) {

             var nombrec = c.name;
             const valores = window.location.search;
             const datos = valores.split(';');
             const datoss = datos[0].split('=');

             window.location.href = "respuesta.aspx/?valor=" + nombrec + ";" + datos[2] + ";" + "3" + ";" + datoss[1] + ";" + datos[1];

         }
     </script>
</body>
</html>

