<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProgramAnonymous.master" CodeFile="pgConfirmDetails.aspx.cs" Inherits="pgConfirmDetails" %>
<%-- Allows use of access controls the master page has exposed --%>
<%@ MasterType VirtualPath ="~/ProgramAnonymous.master" %>

<%-- Allows use of access controls the master page has exposed --%>
<%@ PreviousPageType VirtualPath="~/pgUserDetails.aspx" %>

<%-- Left Content Area on Master Page --%>
            <asp:Content ID="ContentArea1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <%--Username Posting--%>
        <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblUsername" runat="server" Text="Label"></asp:Label>
                <br />


        <%--City Posting--%>
        <asp:Label ID="Label2" runat="server" Text="City: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCity" runat="server" Text="Label"></asp:Label>
                <br />


        <%--State Posting--%>
        <asp:Label ID="Label3" runat="server" Text="State: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblState" runat="server" Text="Label"></asp:Label>
                <br />


        <%--Favorite Programming Language Posting--%>
        <asp:Label ID="Label4" runat="server" Text="Favorite Programming Language: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblFavProgram" runat="server" Text="Label"></asp:Label>
                <br />


        <%--Least Favorite Programming Language Posting--%>
        <asp:Label ID="Label6" runat="server" Text="Least Favorite Programming Language: "></asp:Label>
    
        <asp:Label ID="lblLeastProgram" runat="server" Text="Label"></asp:Label>
                <br />


        <%--Date Posting--%>
        <asp:Label ID="Label5" runat="server" Text="Date Last Program Completed: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
                <br />

        <%--Date Posting--%>
        <asp:Label ID="Label7" runat="server" Text="UserID: "></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblUserID" runat="server" Text="Label"></asp:Label>
                <br />
        <%--Update Account Button--%>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <%--Cancel Update Button--%>
                <asp:Button ID="Button1" runat="server" Text="Cancel" PostBackUrl="~/pgUserDetails.aspx" OnClick="Button1_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <%--Cancel Update Button--%>
                <asp:Button ID="btnAccount" runat="server" Text="My Account" OnClick="btnAccount_Click" />
        <%--End Left Content Area on Master Page--%>
                </asp:Content>
