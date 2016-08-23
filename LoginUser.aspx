<%@ Page Title="Log in" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="LoginUser.aspx.cs" Inherits="LoginUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    
    <link href="styles/jquery-ui-1.10.3.min.css" rel="stylesheet" />
    <script src="styles/jquery-ui-1.10.3.min.js"></script>
    <style>
        .margin-bottom {
            margin-bottom: 0px;
        }
    </style>
   
    <h1 style="color: red; font-weight: bold">CEIP-1</h1>
    <div class="row">
        <div class="col-md-5">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Use a local account to log in.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="UserName" CssClass="col-md-4 control-label">User name</asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="UserName" ValidationGroup="login" onkeypress="if(event.keyCode==13) return false;" placeholder="Enter User ID" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ValidationGroup="login" ControlToValidate="UserName"
                                CssClass="text-danger" ErrorMessage="The user name field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-4 control-label">Password</asp:Label>
                        <div class="col-md-8">
                            <asp:TextBox runat="server" ID="Password" ValidationGroup="login" onkeypress="if(event.keyCode==13) return false;" TextMode="Password" placeholder="Enter Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ValidationGroup="login" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                        </div>
                    </div>
                    <%--                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </div>
                        </div>
                    </div>--%>
                    <div class="form-group">
                        <div class="col-md-offset-4 col-md-8">
                            <asp:Button ID="btnLogin" CssClass="btn btn-primary" ValidationGroup="login" CausesValidation="true" Text="Log in" OnClick="btnLogin_Click" runat="server" />
                        </div>
                    </div>
                </div>
                <p>
                    <asp:HyperLink runat="server" ID="RegisterHyperLink" NavigateUrl="#" ViewStateMode="Disabled">Register</asp:HyperLink>
                    if you don't have a local account.
                </p>
                <p>
                    <asp:HyperLink runat="server" ID="HyperLink1">Forgot Password</asp:HyperLink>
                    Can't access your account?
                </p>
                <p>
                    <asp:HyperLink runat="server" ID="HyperLink2" Target="_blank" NavigateUrl="#" ViewStateMode="Disabled">User Manual</asp:HyperLink>
                    Need Help?
                </p>
            </section>
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
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
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
                    <img src="images/pbar.gif" style="vertical-align: middle" alt="Processing" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
</asp:Content>

