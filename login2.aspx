<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login2.aspx.cs" Inherits="proyecto2APSW.login2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	  <link rel='stylesheet' href='https://fonts.googleapis.com/css?family=Open+Sans:600'>
	<link rel="stylesheet" href="css/login2.css">

 <title>Login</title>
</head>
<body>
	<form id="form1" runat="server">
<!-- partial:index.partial.html -->
<div class="login-wrap">
	<div class="login-html">
        <h1><img src="img/logolo.png"/></h1> 
		<input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab">Inicia Sesion</label>
		<input id="tab-2" type="radio" name="tab" class="sign-up"><label for="tab-2" class="tab">Registrate</label>
		<div class="login-form">
			<div class="sign-in-htm">
				<div class="group">
					<label for="user" class="label">Usuario</label>
					
                    <asp:TextBox ID="txtUser" CssClass="cajastexto" runat="server"></asp:TextBox>
				</div>
				<div class="group">
					<label for="pass" class="label">Contraseña</label>
					<asp:TextBox ID="txtPass" CssClass="cajastexto" runat="server" TextMode="Password"></asp:TextBox>
				</div>
				<br>
				<div class="group">
					
					<asp:Button ID="btnIniciarSes" runat="server" CssClass="botones" Text="Inicia Sesión" OnClick="btnIniciarSes_Click"></asp:Button>
				</div>
			</div>
			<div class="sign-up-htm">
				<div class="group">
					<label for="user" class="label">Nombre Completo</label>
					
                    <asp:TextBox ID="txtNombreReg" CssClass="cajastexto" runat="server"></asp:TextBox>
				</div>
				<div class="group">
					<label for="pass" class="label">Usuario</label>
					
                    <asp:TextBox ID="txtUserReg" CssClass="cajastexto" runat="server"></asp:TextBox>
				</div>
				<div class="group">
					<label for="pass" class="label">Contraseña</label>
					<asp:TextBox ID="txtPassReg" CssClass="cajastexto" runat="server" TextMode="Password"></asp:TextBox>
				
				</div>
				<div class="group">
					<label for="user" class="label">Correo Electrónico</label>
					<asp:TextBox ID="txtCorreoReg" CssClass="cajastexto" runat="server" OnTextChanged="txtCorreoReg_TextChanged"></asp:TextBox>

				</div>
					</br>
				<div class="group">
					
<asp:Button ID="btnRegistrar" runat="server" CssClass="botones" Text="Registrarse" OnClick="btnRegistrar_Click"></asp:Button>
				</div>
			
			</form>	
		</div>
	</div>
</div>
<!-- partial -->
  
</body>
</html>
