<%-- Reference Master Page to access --%>
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ProgramAnonymous.master" CodeFile="pgUserDetails.aspx.cs" Inherits="pgUserDetails" %>
<%-- Allows use of access controls the master page has exposed --%>
<%@ MasterType VirtualPath ="~/ProgramAnonymous.master" %>



<%-- Left Content Area on Master Page --%>
            <asp:Content ID="ContentArea1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <%--Username--%>
            <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />

            <%--City Label and Text Box--%>
            <asp:Label ID="lblCity" runat="server" Text="City: "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            <br />

            <%--State Label and Text Box--%>
            <asp:Label ID="lblState" runat="server" Text="State: "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtState" runat="server" Width="74px"></asp:TextBox>
            <br />

            <%--Favorite Programming Language--%>
            <asp:Label ID="lblFavProgram" runat="server" Text="Favorite Programming Language: "></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtFavProgram" runat="server"></asp:TextBox>
            <br />

            <%--Least Favorite Programming Language--%>
            <asp:Label ID="lblLeastProgram" runat="server" Text="Least Favorite Programming Language: "></asp:Label>
            <asp:TextBox ID="txtLeastProgram" runat="server"></asp:TextBox>
            <br />

            <%--Date Last Program Completed--%>
            <asp:Label ID="lblDate" runat="server" Text="Date Last Program Completed: "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
            <br />

            <%--UserID--%>
            <asp:Label ID="Label2" runat="server" Text="UserID: "></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUserID" runat="server" ReadOnly="True"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />

            <%--GridView Applications Completed--%>
            <asp:GridView ID="gvApplications" runat="server"></asp:GridView>
            <br />
            <%--Export Stats Button--%>
            <asp:Button ID="btnExport" runat="server" Text="Export Stats" OnClick="btnExport_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <%--Update Account Button--%>
            <asp:Button ID="btnUpdate" runat="server" Text="Update Account" PostBackUrl="~/pgConfirmDetails.aspx" OnClick="btnUpdate_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <%--Delete Account Button--%>
            <asp:Button ID="btnDelete" runat="server" Text="Delete Account" OnClick="btnDelete_Click" />
            
                      

            <%--End Left Content Area on Master Page--%>
                </asp:Content>
