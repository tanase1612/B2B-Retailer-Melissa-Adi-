<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerPage.aspx.cs" Inherits="B2BClient.CustomerPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" method="post" runat="server">
        <div>

            <asp:GridView ID="gvCustomer" OnSelectedIndexChanged="gvCustomers_SelectedIndexChanged"
                runat="server" DataKeyNames="Id"
                OnRowDeleting="gvCustomer_RowDeleting"
                OnRowEditing="gvCustomer_RowEditing" OnRowCancelingEdit="gvCustomer_RowCancelingEdit"
                OnRowUpdating="gvCustomer_RowUpdating" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                    <asp:CommandField ShowEditButton="True" />
                </Columns>

                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />

            </asp:GridView>

            <br />
            <asp:DetailsView ID="dvSelectedCustomer" runat="server" Height="50px"
                Width="125px" Style="margin-bottom: 0px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
            </asp:DetailsView>
            <br />
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>

        <asp:Button OnClick="btnAddCustomer_Click" Text="Add New Customer" runat="server" />
        <div hidden="hidden" id="addCustomer" runat="server">

            <asp:Label ID="Billing" runat="server">Billing</asp:Label><br />
            <asp:TextBox ID="tbBilling" runat="server" Width="200px"></asp:TextBox><br />
            <br />

            <asp:Label ID="CompanyName" runat="server">CompanyName</asp:Label><br />
            <asp:TextBox ID="tbCompanyName" runat="server" Width="200px"></asp:TextBox><br />
            <br />

            <asp:Label ID="EmailAddress" runat="server">EmailAddress</asp:Label><br />
            <asp:TextBox ID="tbEmailAddress" runat="server" Width="200px"></asp:TextBox><br />
            <br />

            <asp:Label ID="PhoneNumber" runat="server">PhoneNumber</asp:Label><br />
            <asp:TextBox ID="tbPhoneNumber" runat="server" Width="200px"></asp:TextBox><br />
            <br />

            <asp:Label ID="ShippingAddress" runat="server">ShippingAddress</asp:Label><br />
            <asp:TextBox ID="tbShippingAddress" runat="server" Width="200px"></asp:TextBox><br />
            <br />
            <asp:Button ID="btSubmit" runat="server" Text=" submit " Height="35px" OnClick="btSubmit_Click"></asp:Button>
            <asp:Button ID="btCancle" runat="server" Text=" Cancle " Height="35px" OnClick="btCancle_Click"></asp:Button>

        </div>
    </form>
</body>
</html>
