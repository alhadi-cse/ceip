<%@ Page Title="BOQ Report" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BoqReport.aspx.cs" Inherits="BoqReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="styles/jquery-ui-1.10.3.min.css" rel="stylesheet" />
    <script src="styles/jquery-ui-1.10.3.min.js"></script>
    <script src="styles/highcharts.js"></script>
    <script src="styles/exporting.js"></script>
    <div class="container">
        <div class="row" style="border: solid 1px gray; margin-top: 10px; padding: 5px; background-color: wheat">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="form-group" style="width: 320px; margin: 0 auto">
                        <div class="input-group">
                            <span class="input-group-addon span-100">Polder No. :
                            </span>
                            <asp:DropDownList ID="ddlPolderNo" Width="210px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPolderNo_SelectedIndexChanged" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 5px; width: 320px; margin: 0 auto">
                        <div class="input-group">
                            <span class="input-group-addon span-100">Bill No. :
                            </span>
                            <asp:DropDownList ID="ddlBillNo" Width="210px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlBillNo_SelectedIndexChanged" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div>
                        <asp:Button ID="btnRefreshData" CssClass="btn btn-primary" runat="server" OnClick="btnRefreshData_Click" Text="Refresh" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="row" style="text-align: center; border: solid 1px gray; padding: 2px;">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <asp:Literal ID="Literal2" Text="" runat="server"></asp:Literal>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>

