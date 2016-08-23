<%@ Page Title="Map Viewer" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MapViewer.aspx.cs" Inherits="MapViewer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <link href="styles/jquery-ui-1.10.3.min.css" rel="stylesheet" />
    <script src="styles/jquery-ui-1.10.3.min.js"></script>

    <style>
        .ui-autocomplete {
            z-index: 10001;
        }

        .btnName {
            background-image: url('images/maps/label.png');
            background-repeat: no-repeat;
            background-position: center center;
            background-size: 26px;
        }

        .btnExport {
            background-image: url('images/maps/export.png');
            background-repeat: no-repeat;
            background-position: center center;
            background-size: 26px;
        }

        .btnMapExport {
            background-image: url('images/maps/map-batch.png');
            background-repeat: no-repeat;
            background-position: center center;
            background-size: 26px;
        }

        .divLayer {
            padding: 5px;
            background-color: #b5c7de;
        }

        .divLayerCheckBox {
            padding: 5px;
            display: block;
        }

            .divLayerCheckBox:hover {
                background-color: #284E98;
                cursor: pointer;
            }
        /*for info window*/
        .nav > li > a {
            padding: 3px 5px 3px 5px;
        }

        .stHead {
            border: 1px solid #333333;
            background-color: #999999;
            height: 24px;
            /*font-size: 1em;*/
            padding: 1px;
            font-weight: bold;
        }

        .stSubHead {
            border: 1px solid #333333;
            background-color: #999999;
            height: 22px;
            /*font-size: .9em;*/
            padding: 1px;
            font-weight: bold;
        }

        .stCommon {
            border: 1px solid #333333;
            background-color: #D5E2FF;
            height: 20px;
            /*font-size: .8em;*/
            padding: 1px;
        }

        .stCommonRight {
            border: 1px solid #333333;
            background-color: #D5E2FF;
            height: 20px;
            text-align: right;
            vertical-align: middle;
            /*font-size: .8em;*/
            padding: 1px 6px 1px 1px;
        }

        .stCommonLeft {
            border: 1px solid #333333;
            background-color: #D5E2FF;
            height: 20px;
            text-align: left;
            vertical-align: middle;
            /*font-size: .8em;*/
            padding: 1px 1px 1px 6px;
        }

        .infoWindow {
            padding: 5px 2px 2px 2px;
            background-color: aliceblue;
            margin: 2px;
        }
    </style>
 <div id="mapTool" class="container-fluid" style="height: 45px; background-color: aliceblue; border-top: solid 1px red; border-bottom: outset 2px red;">
        <table style="width: 100%">
            <tr>
                <td style="text-align: center">
                    <table style="margin: 0 auto">
                        <tr>
                            <td style="padding-top: 6px">
                                <asp:UpdatePanel ID="UpdatePanel3" RenderMode="Inline" runat="server">
                                    <ContentTemplate>
                                        <asp:ImageButton ID="ZoomFull" CausesValidation="false" CssClass="map-tool" runat="server" ImageUrl="~/images/maps/full_extent.png" ToolTip="Full Extent" OnClick="ZoomFull_Click"></asp:ImageButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <aspmap:MapToolButton ID="MtbZoomIn" CssClass="map-tool" runat="server" ImageUrl="~/images/maps/zoomin.png" ToolTip="Zoom In" Map="map" MapTool="ZoomIn"></aspmap:MapToolButton>
                            </td>
                            <td>
                                <aspmap:MapToolButton ID="MtbZoomOut" CssClass="map-tool" runat="server" ImageUrl="~/images/maps/zoomout.png" ToolTip="Map Out" Map="map" MapTool="ZoomOut"></aspmap:MapToolButton>
                            </td>
                            <td>
                                <aspmap:MapToolButton ID="MtbPan" CssClass="map-tool" runat="server" ImageUrl="~/images/maps/pan.png" ToolTip="Pan" Map="map" MapTool="Pan"></aspmap:MapToolButton>
                            </td>
                            <td>
                                <aspmap:MapToolButton ID="MtbChart" Visible="false" CssClass="map-tool" Argument="mapChart" runat="server" ImageUrl="~/images/maps/chart.png" ToolTip="Chart" Map="map" MapTool="Info"></aspmap:MapToolButton>
                            </td>
                            <td>
                                <aspmap:MapToolButton ID="MtbMapInfo" CssClass="map-tool" Argument="mapInfo" runat="server" ImageUrl="~/images/maps/identify.png" ToolTip="Identify" Map="map" MapTool="Info"></aspmap:MapToolButton>
                            </td>
                            <td style="padding-top: 6px">
                                <asp:ImageButton ID="ToolButtomExportMap" CausesValidation="false" Style="padding: 0; margin: 0" CssClass="map-tool" runat="server" ImageUrl="~/images/maps/save.png" OnClientClick="return confirm('Are you sure you want to export map in image fornmat?')" OnClick="ToolButtomExportMap_Click" ToolTip="Export Map Image"></asp:ImageButton>
                            </td>
                            <td style="padding-top: 6px">
                                <asp:ImageButton ID="ToolButtomPrintMap" CausesValidation="false" Style="padding: 0; margin: 0" CssClass="map-tool" runat="server" ImageUrl="~/images/maps/print.png" OnClientClick="return confirm('Are you sure you want to export map in pdf fornmat?')" OnClick="ToolButtomPrintMap_Click" ToolTip="Print Map"></asp:ImageButton>
                            </td>
                            <td>
                                <aspmap:MapToolButton ID="MtbDistanceTool" CssClass="map-tool" Argument="distance" runat="server" ImageUrl="~/images/maps/measure.png" Map="map" MapTool="Distance" ToolTip="Measure Distance" />
                            </td>
                            <td style="padding-top: 6px">
                                <asp:UpdatePanel ID="UpdatePanel15" RenderMode="Inline" runat="server">
                                    <ContentTemplate>
                                        <asp:ImageButton ID="ToolButtonClearMap" CausesValidation="false" Style="padding: 0; margin: 0" CssClass="map-tool" runat="server" ImageUrl="~/images/maps/erase.png" ToolTip="Clear Selected Features" OnClick="ToolButtonClearMap_Click"></asp:ImageButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div id="divDistance" style="border: 1px solid #660033; visibility: collapse; font-weight: normal; position: absolute; z-index: 1099; height: auto; width: auto; padding: 5px; background-color: #336699; color: #FFFFFF;"></div>
    </div>

    <div id="mapMain" class="container-fluid" style="padding-top: 0px;">
        <asp:UpdatePanel ID="UpdatePanel2" style="position: absolute; min-height: 100%; width: 100%; height: 100%;" runat="server">
            <ContentTemplate>
                <aspmap:Map ID="map" Width="100%" Height="100%" EnableZoomAnimation="true" ImageFormat="Png" MapUnit="Meter" ImageTempDirectory="MapImage" SmoothingMode="AntiAlias" FontQuality="ClearType" MapTool="Pan" EnableSession="True" ClientScript="StandardScript"
                    runat="server" OnInfoTool="map_InfoTool"></aspmap:Map>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="position: absolute; z-index: 1001; float: left; margin-top: 5px;">
            <div>
                <span aria-hidden="true" onclick="SetPanelSettings()" class="btn btn-primary glyphicon glyphicon-menu-hamburger" style="margin-top: 1px; height: 32px; width: 40px;"></span>
            </div>
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td class="zoom-bar-button">
                                    <asp:ImageButton ID="NorthWest" CssClass="btn btn-xs" ToolTip="Pan Top-Left" ImageUrl="~/images/zoombar/top-left.png" runat="server" OnClick="ZoomBar_Click" />
                                </td>
                                <td class="zoom-bar-button">
                                    <asp:ImageButton ID="North" CssClass="btn btn-xs" ToolTip="Pan Top" ImageUrl="~/images/zoombar/top.png" runat="server" OnClick="ZoomBar_Click" />
                                </td>
                                <td class="zoom-bar-button">
                                    <asp:ImageButton ID="NorthEast" CssClass="btn btn-xs" ToolTip="Pan Top-Right" ImageUrl="~/images/zoombar/top-right.png" runat="server" OnClick="ZoomBar_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="zoom-bar-button">
                                    <asp:ImageButton ID="West" CssClass="btn btn-xs" ToolTip="Pan Left" ImageUrl="~/images/zoombar/left.png" runat="server" OnClick="ZoomBar_Click" />
                                </td>
                                <td class="zoom-bar-button">
                                    <asp:ImageButton ID="FullExtent" CssClass="btn btn-xs" ToolTip="Full Extent" ImageUrl="~/images/zoombar/full.png" runat="server" OnClick="ZoomBar_Click" />
                                </td>
                                <td class="zoom-bar-button">
                                    <asp:ImageButton ID="East" CssClass="btn btn-xs" ToolTip="Pan Right" ImageUrl="~/images/zoombar/right.png" runat="server" OnClick="ZoomBar_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="zoom-bar-button">
                                    <asp:ImageButton ID="SouthWest" CssClass="btn btn-xs" ToolTip="Pan Bottom-Left" ImageUrl="~/images/zoombar/bottom-left.png" runat="server" OnClick="ZoomBar_Click" />
                                </td>
                                <td class="zoom-bar-button">
                                    <asp:ImageButton ID="South" CssClass="btn btn-xs" ToolTip="Pan Bottom" ImageUrl="~/images/zoombar/bottom.png" runat="server" OnClick="ZoomBar_Click" />
                                </td>
                                <td class="zoom-bar-button">
                                    <asp:ImageButton ID="SouthEast" CssClass="btn btn-xs" ToolTip="Pan Bottom-Right" ImageUrl="~/images/zoombar/bottom-right.png" runat="server" OnClick="ZoomBar_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td class="zoom-bar-button"></td>
                                <td class="zoom-bar-button">
                                    <asp:ImageButton ID="ZoomIn" CssClass="btn btn-xs" ToolTip="Zoom In" ImageUrl="~/images/zoombar/plus.png" runat="server" OnClick="ZoomBar_Click" />
                                </td>
                                <td class="zoom-bar-button"></td>
                            </tr>
                            <tr>
                                <td class="zoom-bar-button"></td>
                                <td class="zoom-bar-button" style="padding-top: 2px;">
                                    <asp:ImageButton ID="ZoomOut" CssClass="btn btn-xs" ToolTip="Zoom Out" ImageUrl="~/images/zoombar/minus.png" runat="server" OnClick="ZoomBar_Click" />
                                </td>
                                <td class="zoom-bar-button"></td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
      <div style="height: 400px; max-height: 400px!important; width: 330px; min-width: 330px!important; padding: 2px 2px 2px 1px">
        <asp:Panel ID="PanelSettings" Style="display: none; z-index: 2000" CssClass="ui-dialog ui-widget ui-widget-content ui-corner-all ui-front ui-dialog-buttons ui-draggable ui-resizable" Width="330px" runat="server">
            <asp:Panel ID="PanelSettingsDrag" Style="height: 32px;" CssClass="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix ui-draggable-handle small" runat="server">
                <asp:HiddenField ID="HiddenFieldPanelSettingsStatus" Value="1" runat="server" />
                <asp:HiddenField ID="HiddenFieldPanelSettingsPosition" Value="5;100" runat="server" />
                <span id="ui-id-14" class="ui-dialog-title">Settings</span>
                <button class="ui-button ui-widget ui-state-default ui-corner-all ui-button-icon-only ui-dialog-titlebar-close" type="button" onclick="SetPanelSettings()" role="button" title="Close">
                    <span class="ui-button-icon-primary ui-icon ui-icon-closethick"></span>
                    <span class="ui-button-text">Close</span>
                </button>
            </asp:Panel>
            <div style="background-color: wheat; height: 36px; padding-top: 5px; border-bottom: inset 1px gray;">
                <ul class="nav nav-pills small" role="tablist">
                    <li class="active"><a data-toggle="pill" href="#tab1">Layers</a></li>
                    <li><a data-toggle="pill" href="#tab6">Legend</a></li>
                </ul>
            </div>
            <div class="ui-dialog-content ui-widget-content" style="background-color: white; border-top: inset 1px gray; height: 300px; overflow: auto">
                <div class="tab-content">
                    <div id="tab1" class="tab-pane fade in active small">
                        <table style="width: 100%; border-collapse: collapse">
                            <tr>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <div class="divLayer" style="width: 100%;">
                                                <div class="divLayerCheckBox">
                                                    <asp:CheckBox ID="chk_polder_bnd" AutoPostBack="true" Text="Polder Boundary" OnCheckedChanged="CheckBoxMapLayer_CheckedChanged" runat="server" />
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <hr />
                                    <div class="divLayer" style="width: 100%;">
                                        <div class="divLayerCheckBox">
                                            <asp:RadioButton ID="rbt_groad" GroupName="BaseMap" Text="Google Road" AutoPostBack="true" OnCheckedChanged="RadioButtonBaseMap_CheckedChanged" runat="server" />
                                        </div>
                                        <div class="divLayerCheckBox">
                                            <asp:RadioButton ID="rbt_ghybrid" GroupName="BaseMap" Text="Google Hybrid" AutoPostBack="true" OnCheckedChanged="RadioButtonBaseMap_CheckedChanged" runat="server" />
                                        </div>
                                        <div class="divLayerCheckBox">
                                            <asp:RadioButton ID="rbt_gsatellite" GroupName="BaseMap" Text="Google Satellite" AutoPostBack="true" OnCheckedChanged="RadioButtonBaseMap_CheckedChanged" runat="server" />
                                        </div>
                                        <div class="divLayerCheckBox">
                                            <asp:RadioButton ID="rbt_gnone" GroupName="BaseMap" Text="None" Checked="true" AutoPostBack="true" OnCheckedChanged="RadioButtonBaseMap_CheckedChanged" runat="server" />
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="tab6" class="tab-pane fade small">
                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                            <ContentTemplate>
                                <table style="width: 100%; border-collapse: collapse">
                                    <tr>
                                        <td style="padding-bottom: 5px; border-bottom: solid 1px gray">
                                            <asp:Label ID="label5" Text="Map Legend" CssClass="control-label" ForeColor="#0000FF" Font-Bold="true" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMapLegendInfo" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div style="background-color: wheat; height: 80px; margin-top: 2px; padding: 3px; border-top: solid 3px gray; border-bottom: solid 1px gray;">
                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                    <ContentTemplate>
                        <table style="width: 100%; border-collapse: collapse">
                            <tr>
                                <td>
                                    <div class="input-group small" style="margin: 0px 0px 2px 0px; text-align: center">
                                        <asp:DropDownList ID="ddlActiveMapLayer" CssClass="form-control" Style="margin-top: 1px; padding-left: 2px; min-width: 90px!important; max-width: 90px!important" Height="32px" runat="server">
                                            <asp:ListItem Text="Polder Boundary" Value="polder_bnd"></asp:ListItem>                                           
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtSearchText" CssClass="form-control" Style="padding-left: 5px; padding-right: 5px; text-align: center; margin-top: 1px; min-width: 125px!important; max-width: 125px!important" placeholder="Enter search text" onfocus="SearchText();" Height="32px" runat="server"></asp:TextBox>
                                        <asp:CheckBox ID="chkExactMatch" CssClass="form-control btn btn-primary" Style="margin-top: 2px; margin-left: 2px" Checked="true" Height="32px" Width="40px" runat="server" />
                                        <asp:LinkButton ID="btnSearchInMap" ToolTip="Search on Active Map Layer" CssClass="form-control btn btn-primary glyphicon glyphicon-search" Style="margin-top: 1px; margin-left: 2px" Height="32px" Width="40px" OnClick="btnSearchInMap_Click" runat="server"></asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-top: solid 1px gray; padding-bottom: 2px;">
                                    <div class="form-inline form-group small" style="margin: 2px 0px 4px 0px; text-align: center">
                                        <asp:LinkButton ID="btnLabelShowHide" ToolTip="Show/Hide Map Label" CssClass="form-control btn btn-primary btnName" Height="30px" Width="40px" Style="margin-top: 1px;" runat="server" OnClick="btnLabelShowHide_Click"></asp:LinkButton>
                                        <asp:Button ID="btnApplyInMap" CausesValidation="false" CssClass="form-control btn btn-primary" Width="150px" Height="30px" runat="server" Text="Refresh Map" OnClick="btnApplyInMap_Click" />
                                        <asp:LinkButton ID="btnExportData" ToolTip="Export Active Map Layer Data to Excel" CssClass="form-control btn btn-primary btnExport" Height="30px" Width="40px" OnClientClick="return confirm('Are you sure you want to export data in excel?')" Style="margin-top: 1px;" runat="server" OnClick="btnExportData_Click"></asp:LinkButton>

                                    </div>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnExportData" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </asp:Panel>
        <ajaxToolkit:DragPanelExtender ID="PanelSettingsDragPanelExtender" TargetControlID="PanelSettings" BehaviorID="PanelSettingsBehavior" runat="server" DragHandleID="PanelSettingsDrag" Enabled="True"></ajaxToolkit:DragPanelExtender>
        <ajaxToolkit:DropShadowExtender ID="dse" runat="server" TargetControlID="PanelSettings" Opacity=".8" Rounded="false" TrackPosition="true" />
    </div>
    <div id="divMapInfo">
        <asp:Panel ID="modalDiv_MapInfo" Width="500px" Style="display: none; z-index: 2000" CssClass="ui-dialog ui-widget ui-widget-content ui-corner-all ui-front ui-dialog-buttons ui-draggable ui-resizable" runat="server">
            <asp:Panel ID="modalDivDrag_MapInfo" runat="server" Style="height: 32px;" CssClass="ui-dialog-titlebar ui-widget-header ui-corner-all ui-helper-clearfix ui-draggable-handle small">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="modalHeaderTitle_MapInfo" CssClass="ui-dialog-title" runat="server"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <button id="modalCancelButton_MapInfo" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-icon-only ui-dialog-titlebar-close" type="button" role="button" title="Close">
                    <span class="ui-button-icon-primary ui-icon ui-icon-closethick"></span>
                    <span class="ui-button-text">Close</span>
                </button>
            </asp:Panel>
            <asp:Panel ID="modalDivContent_MapInfo" runat="server" CssClass="ui-dialog-content ui-widget-content" Style="background-color: white; margin-top: 2px; border-top: inset 1px gray; height: 300px; overflow: auto;">
                <div style="width: 100%; margin-right: 5px">
                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblMapInfoData" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </asp:Panel>
        </asp:Panel>
        <asp:LinkButton ID="modalTargetButton_MapInfo" runat="server"></asp:LinkButton>
        <asp:LinkButton ID="modalOkButton_MapInfo" runat="server"></asp:LinkButton>
        <ajaxToolkit:ModalPopupExtender ID="modal_MapInfo" PopupControlID="modalDiv_MapInfo" PopupDragHandleControlID="modalDivDrag_MapInfo" CancelControlID="modalCancelButton_MapInfo" TargetControlID="modalTargetButton_MapInfo"
            OkControlID="modalOkButton_MapInfo" BackgroundCssClass="modal_bg" RepositionMode="RepositionOnWindowResizeAndScroll" DropShadow="true" runat="server">
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
    <div id="divMessage">
        <asp:Panel ID="modalDiv_Msg" Style="min-width: 250px; display: none; z-index: 2000" CssClass="ui-dialog ui-widget ui-widget-content ui-corner-all ui-front ui-dialog-buttons ui-draggable ui-resizable" runat="server">
            <asp:Panel ID="modalDivDrag_Msg" runat="server" Style="height: 32px;" CssClass="ui-dialog-titlebar btn-primary ui-corner-all ui-helper-clearfix ui-draggable-handle small">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="modalHeaderTitle_Msg" CssClass="ui-dialog-title" runat="server" Text="Message from gpmis"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <button id="modalCancelButton_Msg" class="ui-button ui-widget ui-state-default ui-corner-all ui-button-icon-only ui-dialog-titlebar-close" type="button" role="button" title="Close">
                    <span class="ui-button-icon-primary ui-icon ui-icon-closethick"></span>
                    <span class="ui-button-text">Close</span>
                </button>
            </asp:Panel>
            <asp:Panel ID="modalDivContent_Msg" runat="server" CssClass="ui-dialog-content ui-widget-content small" Style="background-color: white; margin-top: 2px; border-bottom: outset 2px lightgray; border-top: inset 2px lightgray; overflow: auto; padding: 20px 10px 20px 10px">
                <div style="width: 100%; margin-right: 5px; text-align: center">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
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
    <script type="text/javascript">
        $(document).ready(function () {
            var elem1 = $get("<%=HiddenFieldPanelSettingsStatus.ClientID%>");
             if (elem1.value == "1") {
                 var elem = $get("<%=PanelSettings.ClientID%>");
                $("#" + elem.id).animate({
                    width: 'show'
                });
            }
         });
    </script>
    <script type="text/javascript">
        function pageLoad() {
            // call the savePanelPosition when the panel is moved
            $find('PanelSettingsBehavior').add_move(savePanelPosition);
            var elem = $get("<%=HiddenFieldPanelSettingsPosition.ClientID%>");
             if (elem.value != "0") {
                 var temp = new Array();
                 temp = elem.value.split(';');
                 // set the position of the panel manually with the retrieve value
                 $find('<%=PanelSettingsDragPanelExtender.BehaviorID%>').set_location(new Sys.UI.Point(parseInt(temp[0]), parseInt(temp[1])));
            }


        }
        function savePanelPosition() {
            var elem = $find('PanelSettingsBehavior').get_element();
            var loc = $common.getLocation(elem);
            var elem1 = $get("<%=HiddenFieldPanelSettingsPosition.ClientID%>");
            // store the value in the hidden field
            elem1.value = loc.x + ';' + loc.y;
        }
    </script>
    <script type="text/javascript">
        function SetPanelSettings() {
            var elem = $get("<%=PanelSettings.ClientID%>");

            var elem1 = $get("<%=HiddenFieldPanelSettingsStatus.ClientID%>");
            //alert(elem1.value);
            if (elem1.value == "0") {
                $("#" + elem.id).animate({
                    width: 'show'
                });
                elem1.value = "1";
            }
            else {
                $("#" + elem.id).animate({
                    width: 'hide'
                });
                elem1.value = "0";

            }
            //$("#" & elem.id).animate({
            //    width: "toggle"
            //});
        }
    </script>
    <script type="text/javascript">
        function HideDragPanel(panelName) {
            var elem = $get("<%=PanelSettings.ClientID%>");
            $("#" + elem.id).animate({
                width: 'hide'
            });
            ($get("<%=HiddenFieldPanelSettingsStatus.ClientID%>")).value = "0";
        }
        function ShowDragPanel(panelName) {
            var elem = $get("<%=PanelSettings.ClientID%>");
            $("#" + elem.id).animate({
                width: 'show'
            });
            ($get("<%=HiddenFieldPanelSettingsStatus.ClientID%>")).value = "1";
        }
    </script>
    <script type="text/javascript">
        var map = AspMap.getMap('<% =map.ClientID %>');
        map.add_mouseMove(onMouseMove);
        map.add_distanceTool(onDistanceTool);
        function onDistanceTool(sender, e /* DistanceToolEventArgs */) {
            var label = document.getElementById('divDistance');
            if (!e.isFinished) {
                label.style.visibility = "visible";
                label.innerHTML = e.kilometers.toFixed(2) + " km  " + e.miles.toFixed(2) + " mi";
            }
            else {
                label.innerHTML = "";
                label.style.visibility = "collapse";
            }
        }
        function onMouseMove(sender, e /* MouseEventArgs */) {
            var tol = map.get_mapTool();
            var tolarg = map.get_mapToolArgument();
            var label = document.getElementById('divDistance');


            if (tol == AspMap.MapTool.Distance) {
                map.set_cursor("url('images/cursors/measure.cur'),default");
                label.style.marginLeft = (e.x + 10) + "px";
                label.style.marginTop = (e.y + 10) + "px";
            }
            else if (tol == AspMap.MapTool.Info) {
                if (tolarg == "zoomplus") {
                    map.set_cursor("crosshair");
                }
                else if (tolarg == "zoomminus") {
                    map.set_cursor("crosshair");
                }
                else if (tolarg == "zoomminus") {
                    map.set_cursor("crosshair");
                }
            }
            else if (tol == AspMap.MapTool.Pan) {
                //map.set_cursor("url('Site_Images/MapTools/pan.png'),default");
            }
            else if (tol == AspMap.MapTool.ZoomOut) {
                map.set_cursor("url('images/cursors/zoomout.cur'),default");
                //map.set_cursor("");
            }
            else if (tol == AspMap.MapTool.ZoomIn) {
                map.set_cursor("url('images/cursors/zoomin.cur'),default");
                //map.set_cursor("");
            }
            else if (tol == AspMap.MapTool.Point) {
                if (tolarg == "startpoint") {
                    map.set_cursor("crosshair");
                }
                else if (tolarg == "endpoint") {
                    map.set_cursor("crosshair");
                }
            }
            else {
                //map.set_cursor("default");
            }
        }
    </script>
</asp:Content>

