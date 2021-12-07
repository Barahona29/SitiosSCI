<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="generaldirector.aspx.cs" Inherits="proyecto2APSW.generaldirector" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <link rel="stylesheet" href="css/general.css" />
   <title>Pagina General Director</title>
		
 </head>
 <body>

	  <style>
	  .botontransp {
       background-color: transparent;
	  border: none;
    outline:none;
	color:white;
	width:90%;
	height:70%;
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
         <li><a href="generaldirector.aspx">Inicio</a></li>
         <li><a href="contactenos.html">Contactenos</a></li>
          <li><a href="login2.aspx">Cerrar Sesion</a></li>
     </div>
     </ul>
   </nav>


    <div class="wrapper">
  <h1>Bienvenido Director</h1>
  <div class="cols">
			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://lucasabogados.es/wp-content/uploads/apret%C3%B3n-manos-contrato.jpg)">
						<div class="inner">
							<p>Seguimiento</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
						  
                            <asp:Button ID="Button2" runat="server" CssClass="botontransp" Text="Aprobación o rechazo de " OnClick="Button2_Click" />
						<p>nuevos formularios.</p>
						</div>
					</div>
				</div>
			</div>
			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://i.pinimg.com/736x/6b/49/c8/6b49c81b79625c5dc97bf975e7cd10b6.jpg)">
						<div class="inner">
							<p>Modelo de Madurez e Indicadores</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
							 <asp:Button ID="Button1" CssClass="botontransp" runat="server" Text="Pantalla general e indicadores" OnClick="Button1_Click" />
		
						</div>
					</div>
				</div>
			</div>

			<div class="col" ontouchstart="this.classList.toggle('hover');">
				<div class="container">
					<div class="front" style="background-image: url(https://images.unsplash.com/photo-1516382799247-87df95d790b7?ixid=MnwxMjA3fDB8MHxzZWFyY2h8MXx8bWFnbmlmeWluZyUyMGdsYXNzfGVufDB8fDB8fA%3D%3D&ixlib=rb-1.2.1&w=1000&q=80)">
						<div class="inner">
							<p>Comunicación</p>
						</div>
					</div>
					<div class="back">
						<div class="inner">
							<a href="Muestra.aspx" style="text-decoration:none; color:white">
						   <p>Comunicación con otros encargados de departamento.</p>
								</a>

                        </div>
					</div>
				</div>
			</div>
		</div>
		 
		</form>
		  <script>

		  const valores = window.location.search;
          const datos = valores.split(';');
         

		  function deshabilitar() {


              if (datos[0] == "?valor=Supervisor") {


				  const variable = document.getElementById("ahref");
				  variable.innerHTML = "No disponible";
				  variable.removeAttribute("href");

				  const variable2 = document.getElementById("ahref2");
				  variable2.innerHTML = "No disponible";
				  variable2.removeAttribute("href");

				  const variable3 = document.getElementById("ahref3");
				  variable3.innerHTML = "No disponible";
				  variable3.removeAttribute("href");

				  const variable4 = document.getElementById("ahref4");
				  variable4.innerHTML = "No disponible";
				  variable4.removeAttribute("href");

				  const variable5 = document.getElementById("ahref5");
				  variable5.innerHTML = "No disponible";
				  variable5.removeAttribute("href");

				  const variable8 = document.getElementById("ahref8");
                  variable8.setAttribute('href', 'puntajecompleto.aspx?valores=' + datos[1] + ';' + datos[2]);
                
			  }
              else if (datos[0] == "?valor=Encargado")
			  {
                  const variable8 = document.getElementById("ahref8");
                  variable8.setAttribute('href', 'puntajecompleto.aspx?valores=' + datos[1] + ';' + datos[2]);
			  }
			  else {


                      const variable = document.getElementById("ahref");
                      variable.innerHTML = "No disponible";
                      variable.removeAttribute("href");

                      const variable2 = document.getElementById("ahref2");
                      variable2.innerHTML = "No disponible";
                      variable2.removeAttribute("href");

                      const variable3 = document.getElementById("ahref3");
                      variable3.innerHTML = "No disponible";
                      variable3.removeAttribute("href");

                      const variable4 = document.getElementById("ahref4");
                      variable4.innerHTML = "No disponible";
                      variable4.removeAttribute("href");

                      const variable5 = document.getElementById("ahref5");
                      variable5.innerHTML = "No disponible";
				  variable5.removeAttribute("href");

                  const variable6 = document.getElementById("ahref6");
                  variable6.innerHTML = "No disponible";
                  variable6.removeAttribute("href");


                  
                  }
			  }
		  

		  window.onload = deshabilitar;
			

	  </script>
	    				
 </body>
</html>
