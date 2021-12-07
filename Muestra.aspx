<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Muestra.aspx.cs" Inherits="proyecto2APSW.Muestra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <link rel="stylesheet" href="css/muestra.css" />
   <title>Comunicación</title>
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
         <li><a href="Apertura.aspx">Apertura</a></li>
         <li><a href="login2.aspx">Cerrar Sesión</a></li>
       </div>
     </ul>
   </nav>
<div class="central">
   <div class="caja">
     <div class="reporte">
                 <li><a href="https://accounts.google.com/signin/v2/challenge/pwd?continue=https%3A%2F%2Fmyaccount.google.com%2Fsigninoptions%2Fpassword%3Fhl%3Des&service=accountsettings&hl=es&osid=1&rart=ANgoxce52Se1KKi9cdlaGx_so6XkdDHSEt1lTcTz2915KNGQNhz2rzWPYAeImFKwvOkBk57VNOz-pbaDQzZR_-5QRb_0m9J6mw&TL=AM3QAYawdsjeTL6OTL380Oi6IZaT79TkXIUTsHCvt-5YfMgIPJSoJKWnvEM7-XE-&flowName=GlifWebSignIn&cid=1&flowEntry=ServiceLogin">Bandeja de Entrada</a></li>
      </div>
 <h1>Aceptación o Incumplimiento</h1>
        </h2> Para&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtCorreoPara" runat="server"></asp:TextBox>
         <br>
         <br>Copia&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtCorreoCopia" runat="server"></asp:TextBox>
          <br>
          <br>Asunto&nbsp;&nbsp;<asp:TextBox ID="txtAsunto" runat="server"></asp:TextBox>
        <br><br>
         <div class="vertical3">
<label class="label">Descripción</label>
</div>
<div class="vertical3">
    <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine"></asp:TextBox>
</div>
<br>
       <asp:Button ID="btnCorreo" runat="server" Text="Enviar correo" OnClick="btnCorreo_Click"/>
<br><br>
</div>
</div>


          <div class="fondo">
            <div class="contraste">
                <div class="div-tabla1">
                    <h2>Personal Encargado de Enviar Evidencias</h2>
                    <br><br>
                   
       <div class="contenedor-tabla">
           <asp:Table ID="Table1" runat="server">

           </asp:Table>
           </div>
                    </div>
                </div>
              </div>
         </form>
</body>
</html>
