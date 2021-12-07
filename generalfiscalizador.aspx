<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="generalfiscalizador.aspx.cs" Inherits="proyecto2APSW.generalfiscalizador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <link rel="stylesheet" href="css/general.css" />
   <title>Pagina General Fiscalizador</title>
	 <script src="https://kit.fontawesome.com/a076d05399.js"></script>
       <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/waypoints/4.0.1/jquery.waypoints.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Counter-Up/1.0.0/jquery.counterup.min.js"></script>
 </head>
 <body>
	 <style>
	  .botontranspar 
    {
    background-color: transparent;
	border: none;
    outline:none;
	color:white;
	font-size:12px;
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
         <li><a href="index.html">Inicio</a></li>
         <li><a href="contactenos.html">Contactenos</a></li>
		<li><a href="login2.aspx">Cerrar Sesion</a></li>
	 </div>
     </ul>
   </nav>


    <div class="wrapper">
  <h1> Bienvenido Fiscalizador</h1>
  <div class="cols">
			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://www.freefilecloud.com/wp-content/uploads/2021/07/login.gif)">
						<div class="inner">
							<p>Asignación</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
							<a href="usuarios.aspx" style="text-decoration:none; color:white;">
						  <p>Asignación de nuevos registros o cambio de estado</p>
								</a>
						</div>
					</div>
				</div>
			</div>
            			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://iforum-sg.c.huawei.com/dddd/latin/images/2021/2/16/38d4d37a-93f7-46e0-8a7b-379f78a46218.gif)">
						<div class="inner">
							<p>Apertura</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
							<a href="aperturanueva.aspx" style="text-decoration:none; color:white;">
								<asp:Button ID="btnApertura" CssClass="botontranspar" runat="server" Text="Nuevo formularios con inicio y fecha" OnClick="btnApertura_Click" />
							 <p>de cierre con validación del Director</p>
								</a>
						</div>
					</div>
				</div>
			</div>
			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://media.istockphoto.com/photos/diverse-people-stacking-hand-together-picture-id1152125129?b=1&k=20&m=1152125129&s=170667a&w=0&h=9GqM_0ka0rGbJnIO2CQWERuWQMuuPxvZSPwmt_gk-OQ=)">
						<div class="inner">
							<p>Modelo de Madurez e Indicadores</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
							<a href="modelomadurez.aspx" style="text-decoration:none; color:white;">
							<p>Pantalla General e Indicadores</p>
								</a>
						</div>
					</div>
				</div>
			</div>
			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://wallpaperaccess.com/full/7061626.jpg)">
						<div class="inner">
							<p>Modificación de Evidencias Estado</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
							<a href="apertura2.aspx" style="text-decoration:none; color:white;">
							<p>Modificación de Formularios si serán requeridos,opcionales para su diferente nivel </p>
							</a>
						</div>
					</div>
				</div>
			</div>
			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://c1.wallpaperflare.com/preview/1016/316/1009/computer-business-office-technology.jpg)">
						<div class="inner">
							<p>Revisión de Evidencias y Comunicación</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
							<a href="solicitud.aspx/?valor=Fiscalizador" style="text-decoration:none; color:white">
						   <p>Revisión por fecha de cierre, Evidencias cumplidas y observaciones.</p>
							</a>
                        </div>
					</div>
				</div>
			</div>
		</div>
		</form>
 </body>
</html>
