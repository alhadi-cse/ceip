<%@ Page Title="Indicator Value Entry" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="IndicatorValueEntry.aspx.cs" Inherits="IndicatorValueEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="styles/jquery-ui-1.10.3.min.css" rel="stylesheet" />
    <script src="styles/jquery-ui-1.10.3.min.js"></script>

    <div class="container">
        <div class="row" style="border: solid 1px gray; margin-top: 10px; padding: 5px; background-color: wheat">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="form-group" style="width: 320px; margin: 0 auto">
                        <div class="input-group">
                            <span class="input-group-addon span-120">Package No. :
                            </span>
                            <asp:DropDownList ID="ddlPackageNo" CausesValidation="false" Width="210px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPackageNo_SelectedIndexChanged" runat="server">
                            </asp:DropDownList>
                            <span class="input-group-btn">
                                <asp:LinkButton ID="btnPackageNoRefresh" CausesValidation="false" ToolTip="Refresh Year" CssClass="btn btn-primary glyphicon glyphicon-refresh btn-link-image" OnClick="btnPackageNoRefresh_Click" runat="server"></asp:LinkButton>
                            </span>
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 5px; width: 320px; margin: 0 auto">
                        <div class="input-group">
                            <span class="input-group-addon span-120">Polder No. :
                            </span>
                            <asp:DropDownList ID="ddlPolderNo" CausesValidation="false" Width="210px" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                            <span class="input-group-btn">
                                <asp:LinkButton ID="btnPolderNoRefresh" CausesValidation="false" ToolTip="Refresh Year" CssClass="btn btn-primary glyphicon glyphicon-refresh btn-link-image" OnClick="btnPolderNoRefresh_Click" runat="server"></asp:LinkButton>
                            </span>
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 5px; width: 320px; margin: 0 auto">
                        <div class="input-group">
                            <span class="input-group-addon span-120">Main Tab :
                            </span>
                            <asp:DropDownList ID="ddlMainTab" CausesValidation="false" Width="210px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMainTab_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            <span class="input-group-btn">
                                <asp:LinkButton ID="btnMainTabRefresh" CausesValidation="false" ToolTip="Refresh Year" CssClass="btn btn-primary glyphicon glyphicon-refresh btn-link-image" OnClick="btnMainTabRefresh_Click" runat="server"></asp:LinkButton>
                            </span>
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 5px; width: 320px; margin: 0 auto">
                        <div class="input-group">
                            <span class="input-group-addon span-120">Second Tab :
                            </span>
                            <asp:DropDownList ID="ddlSecondTab" CausesValidation="false" Width="210px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSecondTab_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            <span class="input-group-btn">
                                <asp:LinkButton ID="btnSecondTabRefresh" CausesValidation="false" ToolTip="Refresh Year" CssClass="btn btn-primary glyphicon glyphicon-refresh btn-link-image" OnClick="btnSecondTabRefresh_Click" runat="server"></asp:LinkButton>
                            </span>
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 5px; width: 320px; margin: 0 auto">
                        <div class="input-group">
                            <span class="input-group-addon span-120">Third Tab :
                            </span>
                            <asp:DropDownList ID="ddlThirdTab" CausesValidation="false" Width="210px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlThirdTab_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            <span class="input-group-btn">
                                <asp:LinkButton ID="btnThirdTabRefresh" CausesValidation="false" ToolTip="Refresh Year" CssClass="btn btn-primary glyphicon glyphicon-refresh btn-link-image" OnClick="btnThirdTabRefresh_Click" runat="server"></asp:LinkButton>
                            </span>
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 5px; width: 320px; margin: 0 auto">
                        <div class="input-group">
                            <span class="input-group-addon span-120">Indicator Name :
                            </span>
                            <asp:DropDownList ID="ddlIndicatorName" CausesValidation="false" Width="210px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlIndicatorName_SelectedIndexChanged" runat="server"></asp:DropDownList>
                            <span class="input-group-btn">
                                <asp:LinkButton ID="btnIndicatorNameRefresh" CausesValidation="false" ToolTip="Refresh Year" CssClass="btn btn-primary glyphicon glyphicon-refresh btn-link-image" OnClick="btnIndicatorNameRefresh_Click" runat="server"></asp:LinkButton>
                            </span>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="row" style="text-align: center; border: solid 1px gray; padding: 2px; height: 30px">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <asp:HiddenField ID="HiddenMaxQuantity" runat="server" />
                    <asp:Label ID="lblMaxQuantity" Font-Bold="true" ForeColor="Red" Font-Size="Medium" runat="server"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="row" style="border: solid 1px gray; padding: 10px;">
            <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="PanelProgressEntry" Enabled="false" runat="server">
                        <div class="form-group" style="padding-top: 5px; width: 320px; margin: 0 auto">
                            <div class="input-group">
                                <span class="input-group-addon span-100">Year :
                                </span>
                                <asp:DropDownList ID="ddlProgressYear" Width="210px" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="2014-2015" Value="2014-2015"></asp:ListItem>
                                    <asp:ListItem Text="2015-2016" Value="2015-2016"></asp:ListItem>
                                    <asp:ListItem Text="2016-2017" Value="2016-2017"></asp:ListItem>
                                    <asp:ListItem Text="2017-2018" Value="2017-2018"></asp:ListItem>
                                    <asp:ListItem Text="2018-2019" Value="2018-2019"></asp:ListItem>
                                    <asp:ListItem Text="2019-2020" Value="2019-2020"></asp:ListItem>
                                    <asp:ListItem Text="2020-2021" Value="2020-2021"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group" style="padding-top: 5px; width: 320px; margin: 0 auto">
                            <div class="input-group">
                                <span class="input-group-addon span-100">Quarter :
                                </span>
                                <asp:DropDownList ID="ddlProgressQuarter" Width="210px" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="Q1 (July-September)" Value="Q1"></asp:ListItem>
                                    <asp:ListItem Text="Q2 (October-December)" Value="Q2"></asp:ListItem>
                                    <asp:ListItem Text="Q3 (January-March)" Value="Q3"></asp:ListItem>
                                    <asp:ListItem Text="Q4 (April-June)" Value="Q4"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group" style="padding-top: 5px; width: 320px; margin: 0 auto">
                            <div class="input-group">
                                <span class="input-group-addon span-100">Target :
                                </span>
                                <asp:TextBox ID="txtTargetValue" CssClass="form-control" Width="210px" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" style="padding-top: 5px; width: 320px; margin: 0 auto">
                            <div class="input-group">
                                <span class="input-group-addon span-100">Projection :
                                </span>
                                <asp:TextBox ID="txtProjectionValue" CssClass="form-control" Width="210px" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" style="padding-top: 5px; width: 320px; margin: 0 auto">
                            <div class="input-group">
                                <span class="input-group-addon span-100">Progress :
                                </span>
                                <asp:TextBox ID="txtProgressValue" CssClass="form-control" Width="210px" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" style="padding-top: 5px; width: 320px; margin: 0 auto">
                            <div class="input-group">
                                <span class="input-group-addon span-100">Remarks :
                                </span>
                                <asp:TextBox ID="txtRemarks" CssClass="form-control" Width="210px" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" style="padding-top: 5px; padding-left: 100px; width: 520px; margin: 0 auto">
                            <asp:Button ID="btnInsertProgress" CssClass="btn btn-primary" runat="server" OnClientClick="return confirm('Are you sure you want to insert data ?')" OnClick="btnInsertProgress_Click" Text="Insert Data" />
                            <asp:Button ID="btnViewProgress" CausesValidation="false" CssClass="btn btn-primary" runat="server" OnClick="btnViewProgress_Click" Text="View Data" />
                        </div>
                        <div class="form-group" style="padding-top: 5px; padding-left: 100px; width: 520px; margin: 0 auto">

                            <asp:GridView ID="gridViewProgress" CssClass="table-condensed" DataKeyNames="progress_year,progress_quarter" runat="server" Width="100%" OnRowEditing="gridViewProgress_RowEditing" OnRowCancelingEdit="gridViewProgress_RowCancelingEdit" OnRowUpdating="gridViewProgress_RowUpdating" OnRowDeleting="gridViewProgress_RowDeleting" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField ShowHeader="False">
                                        <EditItemTemplate>
                                            <asp:Button ID="gridViewProgressUpdate" CausesValidation="False" Height="30px" Width="30px" CommandName="Update" CssClass="btn btn-info glyphicon btn-grid-update" ToolTip="Update Data" runat="server" />
                                            <asp:Button ID="gridViewProgressCancel" CausesValidation="False" Height="30px" Width="30px" CommandName="Cancel" CssClass="btn btn-info glyphicon btn-grid-cancel" ToolTip="Cancel Edit" runat="server" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Button ID="gridViewProgressEdit" CausesValidation="False" Height="30px" Width="30px" CommandName="Edit" CssClass="btn btn-info glyphicon btn-grid-edit" ToolTip="Edit Data" runat="server" />
                                            <asp:Button ID="gridViewProgressDelete" CausesValidation="False" Height="30px" Width="30px" CommandName="Delete" OnClientClick="return confirm('Are you sure you want to delete this record?');" CssClass="btn btn-info glyphicon btn-grid-delete" ToolTip="Delete Data" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Target">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="gridViewProgressTextTarget" CssClass="form-control text-box-center" runat="server" Text='<%# Bind("target_value") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1Target" runat="server" Text='<%# Bind("target_value") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Projection">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="gridViewProgressTextProjection" CssClass="form-control text-box-center" runat="server" Text='<%# Bind("projection_value") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1Projection" runat="server" Text='<%# Bind("projection_value") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Progress">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="gridViewProgressTextProgress" CssClass="form-control text-box-center" runat="server" Text='<%# Bind("progress_value") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1Progress" runat="server" Text='<%# Bind("progress_value") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    
                                    <asp:TemplateField HeaderText="Quarter">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2QQ" runat="server" Text='<%# Bind("progress_quarter") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1QQ" runat="server" Text='<%# Bind("progress_quarter") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Year">
                                        <EditItemTemplate>
                                            <asp:Label ID="Label2YY" runat="server" Text='<%# Bind("progress_year") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="Label1YY" runat="server" Text='<%# Bind("progress_year") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

                            </asp:GridView>


                        </div>
                    </asp:Panel>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div id="divMessage">
        <asp:Panel ID="modalDiv_Msg" Style="min-width: 250px; display: none; z-index: 2000" CssClass="ui-dialog ui-widget ui-widget-content ui-corner-all ui-front ui-dialog-buttons ui-draggable ui-resizable" runat="server">
            <asp:Panel ID="modalDivDrag_Msg" runat="server" Style="height: 32px;" CssClass="ui-dialog-titlebar btn-primary ui-corner-all ui-helper-clearfix ui-draggable-handle small">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="modalHeaderTitle_Msg" CssClass="ui-dialog-title" runat="server" Text="Message from durbin"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <button id="modalCancelButton_Msg" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-icon-only ui-dialog-titlebar-close" type="button" role="button" title="Close">
                    <span class="ui-button-icon-primary ui-icon ui-icon-closethick"></span>
                    <span class="ui-button-text">Close</span>
                </button>
            </asp:Panel>
            <asp:Panel ID="modalDivContent_Msg" runat="server" CssClass="ui-dialog-content ui-widget-content small" Style="background-color: white; margin-top: 2px; border-bottom: outset 2px lightgray; border-top: inset 2px lightgray; overflow: auto; padding: 20px 10px 20px 10px">
                <div style="width: 100%; margin-right: 5px; text-align: center">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="modal_msg_text" ForeColor="Red" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </asp:Panel>
            <div style="text-align: center; background-color: aliceblue; padding-top: 5px;">
                <asp:Button ID="modalOkButton_Msg" runat="server" Width="80px" CssClass="btn btn-primary" Text="OK" />
            </div>
        </asp:Panel>
        <asp:LinkButton ID="modalTargetButton_Msg" runat="server"></asp:LinkButton>
        <ajaxToolkit:ModalPopupExtender ID="modal_Msg" PopupControlID="modalDiv_Msg" PopupDragHandleControlID="modalDivDrag_Msg" CancelControlID="modalCancelButton_Msg" TargetControlID="modalTargetButton_Msg"
            OkControlID="modalOkButton_Msg" BackgroundCssClass="modal_bg" RepositionMode="RepositionOnWindowResizeAndScroll" DropShadow="true" runat="server">
            <Animations>
                <OnShown>
                    <Fadein Duration="0.50" />
                </OnShown>
                <OnHiding>
                    <Fadeout Duration="0.75" />
                </OnHiding>
            </Animations>
        </ajaxToolkit:ModalPopupExtender>
    </div>
    <div id="divUpdateProgress">
        <asp:UpdateProgress ID="UpdateProgress" DisplayAfter="0" runat="server">
            <ProgressTemplate>
                <div class="ProgressBackground"></div>
                <div class="ProgressProcess">
                    <img src="images/pbar.gif" style="vertical-align: middle" alt="Processing" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>

