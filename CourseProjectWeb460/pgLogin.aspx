<%-- Reference Master Page to access --%>
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProgramAnonymous.master" CodeFile="pgLogin.aspx.cs" Inherits="pgLogin" %>

<%-- Allows use of access controls the master page has exposed --%>
<%@ MasterType VirtualPath ="~/ProgramAnonymous.master" %>


<%-- Left Content Area on Master Page --%>
<asp:Content ID="ContentArea1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--Username Label and Text Box--%>
<asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
    <br />
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
    <br /><br />
    <%--Password Label and Text Box--%>
<asp:Label ID="Label2" runat="server" Text="Password: "></asp:Label>
    <br />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br /><br />
    <%--Sign In Button--%>
    <asp:Button ID="btnLogin" runat="server" Text="LOGIN" OnClick="btnLogin_Click" />
    <br /><br />
    <h5>New to PA? Create an Account</h5>
    <%--Create Account Button--%>
    <asp:Button ID="btnCreate" runat="server" Text="CREATE ACCOUNT" OnClick="btnCreate_Click" />
    <br /><br />
    <asp:Label ID="Label3" runat="server" Text="Test Account1: Username: Mickey Password: Mouse"></asp:Label>
    <br /><br />
    <asp:Label ID="Label4" runat="server" Text="Test Account2: Username: Minnie Password: Mouse"></asp:Label>
    </asp:Content>

