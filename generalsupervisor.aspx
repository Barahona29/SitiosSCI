<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="generalsupervisor.aspx.cs" Inherits="proyecto2APSW.generalsupervisor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <link rel="stylesheet" href="css/general.css" />
   <title>Página General Supervisor</title>
 </head>
 <body>
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
  <h1> Bienvenido Supervisor</h1>
  <div class="cols">
			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://assets.website-files.com/5fe1bb54f8c10544e53974df/6093f4b7f9f06121831f89c4_Office_RPAS_screen.png)">
						<div class="inner">
							<p>Modelo de Madurez e Indicadores</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
							<p>Pantalla General e Indicadores</p>
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
						   <p>Revisión por fecha de cierre, Evidencias cumplidas y observaciones.</p>
                        </div>
					</div>
				</div>
			</div>
		</div>
 </body>
</html>
