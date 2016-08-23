<%@ Page Title="Quality-Milestone Entry" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="QualityMilestoneEntry.aspx.cs" Inherits="Engg_Construction_QualityMilestoneEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <link href="../styles/jquery-ui-1.10.3.min.css" rel="stylesheet" />
    <script src="../styles/jquery-ui-1.10.3.min.js"></script>

    <div class="container" style="margin: 10px auto;">
        <div class="row" style="border: 1px solid gray; padding: 5px; background-color: ghostwhite">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="form-group" style="margin: 5px;">
                        <div class="input-group" style="width: auto; margin: 0 auto">
                            <span class="input-group-addon span-110" style="width: 220px; padding-left: 10px;">Package No. :</span>
                            <asp:DropDownList ID="ddlPackageNo" Width="210px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPackageNo_SelectedIndexChanged" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Panel ID="pnlDataEntry" Visible="false" runat="server" class="row" Style="border: 1px solid gray; padding: 15px 5px;">
                    <div class="form-group">
                        <div class="input-group" style="width: auto; margin: 0 auto">
                            <span class="input-group-addon span-100" style="width: 220px; padding-left: 10px;">Milestone Year :</span>
                            <asp:DropDownList ID="ddlQtyMilestoneYear" Width="210px" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group" style="width: auto; margin: 0 auto">
                            <span class="input-group-addon span-100" style="width: 220px; padding-left: 10px;">Milestone Quarter :</span>
                            <asp:DropDownList ID="ddlQtyMilestoneQuarter" Width="210px" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="input-group" style="width: auto; margin: 0 auto">
                            <span class="input-group-addon span-100" style="width: 220px; padding-left: 10px;">Qty. Control Manual Draft Date :</span>
                            <asp:TextBox ID="txtQtyControlManualDraftDate" CssClass="form-control" Width="120px" runat="server"></asp:TextBox>

                            <span class="input-group-addon span-100" style="min-width: 80px; text-align: right;">Remarks :</span>
                            <asp:TextBox ID="txtRemarkControlManualDraft" CssClass="form-control" Width="270px" runat="server"></asp:TextBox>
                        </div>
                        <ajaxToolkit:CalendarExtender ID="ceQtyControlManualDraftDate" runat="server" TargetControlID="txtQtyControlManualDraftDate" PopupButtonID="BCaseTxtStartDate" Format="dd-MMM-yyyy" />
                    </div>
                    <div class="form-group">
                        <div class="input-group" style="width: auto; margin: 0 auto">
                            <span class="input-group-addon span-100" style="width: 220px; padding-left: 10px;">Qty. Control Manual Final Date :</span>
                            <asp:TextBox ID="txtQtyControlManualFinalDate" CssClass="form-control"  Width="120px" runat="server"></asp:TextBox>

                            <span class="input-group-addon span-100" style="min-width: 80px; text-align: right;">Remarks :</span>
                            <asp:TextBox ID="txtRemarkControlManualFinal" CssClass="form-control" Width="270px" runat="server"></asp:TextBox>
                        </div>
                        <ajaxToolkit:CalendarExtender ID="ceQtyControlManualFinalDate" runat="server" TargetControlID="txtQtyControlManualFinalDate" PopupButtonID="BCaseTxtStartDate" Format="dd-MMM-yyyy" />
                    </div>
                    <div class="form-group">
                        <div class="input-group" style="width: auto; margin: 0 auto">
                            <span class="input-group-addon span-100" style="width: 220px; padding-left: 10px;">Final Handover Punchlist Date :</span>
                            <asp:TextBox ID="txtFinalHandoverPunchlistDate" CssClass="form-control"  Width="120px" runat="server"></asp:TextBox>

                            <span class="input-group-addon span-100" style="min-width: 80px; text-align: right;">Remarks :</span>
                            <asp:TextBox ID="txtRemarkFinalHandoverPunchlist" CssClass="form-control" Width="270px" runat="server"></asp:TextBox>
                        </div>
                        <ajaxToolkit:CalendarExtender ID="ceFinalHandoverPunchlistDate" runat="server" TargetControlID="txtFinalHandoverPunchlistDate" PopupButtonID="BCaseTxtStartDate" Format="dd-MMM-yyyy" />
                    </div>
                    <div class="form-group">
                        <div class="input-group" style="width: auto; margin: 0 auto">
                            <span class="input-group-addon span-100" style="width: 220px; padding-left: 10px;">Punchlist Satisfied Date :</span>
                            <asp:TextBox ID="txtPunchlistSatisfiedDate" CssClass="form-control"  Width="120px" runat="server"></asp:TextBox>

                            <span class="input-group-addon span-100" style="min-width: 80px; text-align: right;">Remarks :</span>
                            <asp:TextBox ID="txtRemarkPunchlistSatisfied" CssClass="form-control" Width="270px" runat="server"></asp:TextBox>
                        </div>
                        <ajaxToolkit:CalendarExtender ID="cePunchlistSatisfiedDate" runat="server" TargetControlID="txtPunchlistSatisfiedDate" PopupButtonID="BCaseTxtStartDate" Format="dd-MMM-yyyy" />
                    </div>
                    <div class="form-group" style="width: auto; margin: 0 auto; padding-left: 100px; text-align: center;">
                        <asp:Button ID="btnInsertQtyMilestone" runat="server" Text="Insert" CssClass="btn btn-primary" Width="80px" OnClick="btnInsertQtyMilestone_Click" OnClientClick="return confirm('Are you sure to insert quality milestone ?')" />
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div id="divMessage">
        <asp:Panel ID="modalDiv_Msg" Style="min-width: 350px; display: none; z-index: 2000;" CssClass="ui-dialog ui-widget ui-widget-content ui-corner-all ui-front ui-dialog-buttons ui-draggable ui-resizable" runat="server">
            <asp:Panel ID="modalDivDrag_Msg" runat="server" Style="height: 32px;" CssClass="ui-dialog-titlebar btn-primary ui-corner-all ui-helper-clearfix ui-draggable-handle small">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="modalHeaderTitle_Msg" runat="server" CssClass="ui-dialog-title" style="font-weight: bold;" Text="Insert Quality Milestone"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <button id="modalCancelButton_Msg" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-icon-only ui-dialog-titlebar-close" type="button" role="button" title="Close">
                    <span class="ui-button-icon-primary ui-icon ui-icon-closethick"></span>
                    <span class="ui-button-text">Close</span>
                </button>
            </asp:Panel>
            <asp:Panel ID="modalDivContent_Msg" runat="server" CssClass="ui-dialog-content ui-widget-content small" Style="background-color: white; margin-top: 2px; border-bottom: outset 2px lightgray; border-top: inset 2px lightgray; overflow: auto; padding: 20px 10px">
                <div style="width: 100%; margin-right: 5px; text-align: center">
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="modal_msg_text" ForeColor="Red" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </asp:Panel>
            <div style="text-align: center; background-color: aliceblue; padding: 3px;">
                <asp:Button ID="modalOkButton_Msg" runat="server" CssClass="btn btn-primary" Style="width: 70px; padding: 5px 10px; font-size: 14px;" Text="OK" />
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

