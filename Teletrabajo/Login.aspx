﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Teletrabajo.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <br />
        <br />
        <div class="container col-md-12  col-xs-12 col-sm-12">
            <div class="panel panel-default">
                <div class="col-md-4 col-sm-8 col-xs-12 col-md-offset-4 col-sm-offset-2 col-xs-offset-0">
                    <div class="divRedondo">
                        <div class="panel-heading">
                            <div class="panel-title text-center">
                                <asp:Label ID="Label1" runat="server" Text="Bienvenido" Font-Bold="true" Font-Size="X-Large"></asp:Label>
                            </div>
                        </div>
                        <div class="panel-body">
                            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Usuario o Contraseña Incorrecta" Visible="False"></asp:Label>
                            <asp:Label ID="lblNoUsuario" runat="server" ForeColor="Red" Text="El usuario no tiene permisos para entrar a esta aplicación" Visible="False"></asp:Label>
                            <label for="exampleInputEmail1">Usuario</label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control chat-input"></asp:TextBox>
                            </div>
                            <br />
                            <label for="exampleInputPassword1">Contraseña </label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="fa fa-lock"></i></span>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass=" form-control chat-input" TextMode="Password"></asp:TextBox>
                            </div>
                            <br />
                            <div style="text-align: center;">
                                <asp:Button ID="btIngresar" runat="server" Text="Iniciar sesión" CssClass="btn btn-primary btn-md" autofocus="true" OnClick="btIngresar_Click" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
