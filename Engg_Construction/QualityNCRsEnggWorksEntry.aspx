﻿<%@ Page Title="Quality NCRs Engg Works Entry" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="QualityNCRsEnggWorksEntry.aspx.cs" Inherits="Engg_Engg_Construction_QualityNCRsEnggWorksEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="../styles/jquery-ui-1.10.3.min.css" rel="stylesheet" />
    <script src="../styles/jquery-ui-1.10.3.min.js"></script>

    <div class="container">
        <div class="row" style="border: solid 1px gray; margin-top: 10px; padding: 5px; background-color: ghostwhite">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="form-group" style="width: 320px; margin: 0 auto">
                        <div class="input-group">
                            <span class="input-group-addon span-110">Package No. :
                            </span>
                            <asp:DropDownList ID="ddlPackageNo" Width="210px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPackageNo_SelectedIndexChanged" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 5px;width: 320px; margin: 0 auto">
                        <div class="input-group">
                            <span class="input-group-addon span-110">Polder No. :
                            </span>
                            <asp:DropDownList ID="ddlPolderNo" Width="210px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPolderNo_SelectedIndexChanged" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 5px; width: 320px; margin: 0 auto">
                        <div class="input-group">
                            <span class="input-group-addon span-110">Main Tab :
                            </span>
                            <asp:DropDownList ID="ddlMainTab" Width="210px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMainTab_SelectedIndexChanged" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 5px; width: 320px; margin: 0 auto">
                        <div class="input-group">
                            <span class="input-group-addon span-110">Second Tab :
                            </span>
                            <asp:DropDownList ID="ddlSecondTab" Width="210px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSecondTab_SelectedIndexChanged" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                     <div class="form-group" style="padding-top: 5px; width: 320px; margin: 0 auto">
                        <div class="input-group">
                            <span class="input-group-addon span-110">Third Tab :
                            </span>
                            <asp:DropDownList ID="ddlThirdTab" Width="210px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlThirdTab_SelectedIndexChanged" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                     <div class="form-group" style="padding-top: 5px; width: 320px; margin: 0 auto">
                        <div class="input-group">
                            <span class="input-group-addon span-110">Indicator Name :
                            </span>
                            <asp:DropDownList ID="ddlIndicatorName" Width="210px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlIndicatorName_SelectedIndexChanged" runat="server"></asp:DropDownList>
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
                    <asp:Panel ID="PanelProgressEntry" Visible="false" runat="server">
                        <div class="form-group" style="padding-top: 5px; width: 320px; margin: 0 auto">
                            <div class="input-group">
                                <span class="input-group-addon span-100">Target Year :
                                </span>
                               <asp:DropDownList ID="ddlTargetYear" Width="210px" CssClass="form-control" runat="server">
                                   <asp:ListItem Text="Project Target" Value="-1"></asp:ListItem>
                                   <asp:ListItem Text="2014-2015" Value="2014-2015"></asp:ListItem>
                                   <asp:ListItem Text="2015-2016" Value="2015-2016" Selected="True"></asp:ListItem>
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
                               <asp:DropDownList ID="ddlTargetQuarter" Width="210px" CssClass="form-control" runat="server">
                                    <asp:ListItem Text="All" Value="-1"></asp:ListItem>
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
                                <span class="input-group-addon span-100">Remarks :
                                </span>
                                <asp:TextBox ID="txtRemarks" CssClass="form-control" Width="210px" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group" style="padding-top: 5px; padding-left:100px; width: 320px; margin: 0 auto">
                            <asp:Button ID="btnInsertTarget" CssClass="btn btn-primary" runat="server" OnClientClick="return confirm('Are you sure you want to insert target ?')" OnClick="btnInsertTarget_Click" Text="Insert Target" />
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
    <div id="divUpdateProgress" style="display: block;">
        <asp:UpdateProgress ID="UpdateProgress" DisplayAfter="0" runat="server">
            <ProgressTemplate>
                <div class="ProgressBackground"></div>
                <div class="ProgressProcess">
                    <img src="../images/pbar.gif" style="vertical-align: middle" alt="Processing" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>

