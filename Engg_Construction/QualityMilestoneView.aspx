<%@ Page Title="Quality-Milestone Progress" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="QualityMilestoneView.aspx.cs" Inherits="Engg_Construction_QualityMilestoneView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <link href="../styles/jquery-ui-1.10.3.min.css" rel="stylesheet" />
    <script src="../styles/jquery-ui-1.10.3.min.js"></script>
    <style>
        th {
            padding: 3px 6px;
            font-weight: bold;
            color: #fff;
            text-align: center;
            vertical-align: middle;
            background-color: #333;
        }

        td {
            padding: 3px 5px;
            color: #222;
        }
    </style>

    <div class="container" style="margin: 10px auto;">

        <div class="row" style="border: 1px solid gray; padding: 5px; background-color: ghostwhite">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" style="margin: 5px;">
                <ContentTemplate>
                    <div class="form-group">
                        <div class="input-group" style="width: auto; margin: 0 auto">
                            <span class="input-group-addon span-110" style="width: 220px; padding-left: 10px;">Package No. :</span>
                            <asp:DropDownList ID="ddlPackageNo" Width="210px" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPackageNo_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group" style="width: auto; margin: 0 auto">
                            <span class="input-group-addon span-100" style="width: 220px; padding-left: 10px;">Milestone Year :</span>
                            <asp:DropDownList ID="ddlQtyMilestoneYear" Width="210px" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlQtyMilestoneYear_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="input-group" style="width: auto; margin: 0 auto">
                            <span class="input-group-addon span-100" style="width: 220px; padding-left: 10px;">Milestone Quarter :</span>
                            <asp:DropDownList ID="ddlQtyMilestoneQuarter" Width="210px" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlQtyMilestoneQuarter_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        
        <%--package_no, qty_milestone_year_id, qty_milestone_quarter_id, qty_control_manual_draft_date, qty_control_manual_final_date, final_handover_punchlist_date, punchlist_satisfied_date, entry_date, entry_user--%>
                            
        <div class="row" style="border: 1px solid gray; padding: 5px 10px; text-align: center;">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblDataTitle" runat="server" Text="Label" Style="font-size: 15px; font-weight: bold;"></asp:Label>

                    <asp:GridView ID="gvDataView" runat="server" CellPadding="6" AutoGenerateColumns="False" Style="margin: 5px auto;">
                        <Columns>
                            <asp:BoundField HeaderText="Package No." DataField="package_name" SortExpression="package_name">
                                <ItemStyle HorizontalAlign="Left" Width="130px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Milestone Year" DataField="fiscal_year" SortExpression="fiscal_year">
                                <ItemStyle Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Milestone Quarter" DataField="quarter_name" SortExpression="quarter_name">
                                <ItemStyle HorizontalAlign="Left" Width="175px" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="Qty. Control Manual Draft" DataField="qty_control_manual_draft_date" DataFormatString="{0:dd-MM-yyyy}" SortExpression="qty_control_manual_draft_date" />
                            <asp:BoundField HeaderText="Remarks" DataField="remark_control_manual_draft">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            
                            <asp:BoundField HeaderText="Qty. Control Manual Final" DataField="qty_control_manual_final_date" DataFormatString="{0:dd-MM-yyyy}" SortExpression="qty_control_manual_final_date" />
                            <asp:BoundField HeaderText="Remarks" DataField="remark_control_manual_final">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="Final Handover Punchlist" DataField="final_handover_punchlist_date" DataFormatString="{0:dd-MM-yyyy}" SortExpression="final_handover_punchlist_date" />
                            <asp:BoundField HeaderText="Remarks" DataField="remark_final_handover_punchlist">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>

                            <asp:BoundField HeaderText="Punchlist Satisfied" DataField="punchlist_satisfied_date" DataFormatString="{0:dd-MM-yyyy}" SortExpression="punchlist_satisfied_date" />
                            <asp:BoundField HeaderText="Remarks" DataField="remark_punchlist_satisfied">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            
                            <asp:BoundField HeaderText="Entry Date" DataField="entry_date" DataFormatString="{0:dd-MMM-yyyy}" SortExpression="entry_date" />
                        </Columns>
                    </asp:GridView>


                        <%--<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                        <SortedDescendingHeaderStyle BackColor="#242121" />--%>
                    <%--qty_control_manual_draft_date, qty_control_manual_final_date, final_handover_punchlist_date, punchlist_satisfied_date,--%>
                    <%--txtQtyControlManualDraftDate, txtQtyControlManualFinalDate, txtFinalHandoverPunchlistDate, txtPunchlistSatisfiedDate--%>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


    </div>

    <div id="divMessage">
        <asp:Panel ID="modalDiv_Msg" Style="min-width: 350px; display: none; z-index: 2000;" CssClass="ui-dialog ui-widget ui-widget-content ui-corner-all ui-front ui-dialog-buttons ui-draggable ui-resizable" runat="server">
            <asp:Panel ID="modalDivDrag_Msg" runat="server" Style="height: 32px;" CssClass="ui-dialog-titlebar btn-primary ui-corner-all ui-helper-clearfix ui-draggable-handle small">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="modalHeaderTitle_Msg" CssClass="ui-dialog-title" runat="server" Text="Insert Quality Milestone"></asp:Label>
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
                    <img src="../images/pbar.gif" style="vertical-align: middle;" alt="Processing" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>

