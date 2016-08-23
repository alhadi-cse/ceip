<%@ Page Title="Monitoring" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Monitoring.aspx.cs" Inherits="Monitoring" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="aspmap" Namespace="AspMap.Web" Assembly="AspMapNET" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <link href="styles/jquery-ui-1.10.3.min.css" rel="stylesheet" />
    <script src="styles/jquery-ui-1.10.3.min.js"></script>
    <script src="styles/highcharts.js"></script>
    <script src="styles/exporting.js"></script>
    <style>
        .menu {
            text-align: left;
        }

        .table-cell {
            border: 1px solid gray;
        }

        .table-row-head {
            border: 1px solid black;
            font-weight: bold;
            background-color: lightgray;
        }

        .info-table {
            border: 1px solid gray;
        }
    </style>
    <div class="row" style="position: relative; z-index: 1001; text-align: center; margin: auto; width: 100%; padding: 5px 10px">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" OnMenuItemClick="Menu1_MenuItemClick" BackColor="#B5C7DE" DynamicHorizontalOffset="5" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" StaticSubMenuIndent="10px">
                    <DynamicHoverStyle CssClass="menu" BackColor="#284E98" ForeColor="White" />
                    <DynamicMenuItemStyle CssClass="menu" HorizontalPadding="5px" VerticalPadding="10px" />
                    <DynamicMenuStyle CssClass="menu" BackColor="#B5C7DE" />
                    <DynamicSelectedStyle CssClass="menu" BackColor="#507CD1" />
                    <Items>
                        <asp:MenuItem Text="Key Outcomes and Outputs" Value="Key Outcomes and Outputs"></asp:MenuItem>
                        <asp:MenuItem Text="Procurement" Value="Procurement">
                            <asp:MenuItem Text="Goods" Value="Goods"></asp:MenuItem>
                            <asp:MenuItem Text="Works" Value="Works"></asp:MenuItem>
                            <asp:MenuItem Text="Services" Value="Services">
                                <asp:MenuItem Text="Consulting Firms" Value="Consulting Firms"></asp:MenuItem>
                                <asp:MenuItem Text="Individual Consultants" Value="Individual Consultants"></asp:MenuItem>
                            </asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Engineering" Value="Engineering">
                            <asp:MenuItem Text="Designs" Value="Designs"></asp:MenuItem>
                            <asp:MenuItem Text="Engg_Construction" Value="Engg_Construction">
                                <asp:MenuItem Text="Status" Value="Status"></asp:MenuItem>
                                <asp:MenuItem Text="Engineering Survey Progress" Value="21"></asp:MenuItem>
                                <asp:MenuItem Text="Quality" Value="Quality"></asp:MenuItem>
                                <asp:MenuItem Text="Embankment works" Value="Embankment works">
                                    <asp:MenuItem Text="Rehabilitated/constructed" Value="1"></asp:MenuItem>
                                    <asp:MenuItem Text="Re-sectioning" Value="2"></asp:MenuItem>
                                    <asp:MenuItem Text="Retired embankment" Value="3"></asp:MenuItem>
                                    <asp:MenuItem Text="Forwarding of embankment, Sea dyke" Value="4"></asp:MenuItem>
                                    <asp:MenuItem Text="Bank revetment works" Value="5"></asp:MenuItem>
                                    <asp:MenuItem Text="Slope protection of embankment" Value="6"></asp:MenuItem>
                                    <asp:MenuItem Text="Interior dyke" Value="7"></asp:MenuItem>
                                    <asp:MenuItem Text="Maintenance works" Value="8"></asp:MenuItem>
                                </asp:MenuItem>
                                <asp:MenuItem Text="Drainage works" Value="Drainage works">
                                    <asp:MenuItem Text="Drainage channels upgraded" Value="9"></asp:MenuItem>
                                    <asp:MenuItem Text="Structures" Value="10"></asp:MenuItem>
                                    <asp:MenuItem Text="Drainage channels re-excavated" Value="11"></asp:MenuItem>
                                    <asp:MenuItem Text="Maintenance works" Value="12"></asp:MenuItem>
                                </asp:MenuItem>
                                <asp:MenuItem Text="Regulators upgraded" Value="19"></asp:MenuItem>
                                <asp:MenuItem Text="Flushing inlets upgraded" Value="20"></asp:MenuItem>
                                <asp:MenuItem Text="Concrete works" Value="Concrete works">
                                    <asp:MenuItem Text="Demolishing of drainage sluices" Value="13"></asp:MenuItem>
                                    <asp:MenuItem Text="Demolishing of flushing inlets" Value="14"></asp:MenuItem>
                                    <asp:MenuItem Text="Engg_Construction of drainage sluices" Value="15"></asp:MenuItem>
                                    <asp:MenuItem Text="Engg_Construction of flushing inlets" Value="16"></asp:MenuItem>
                                    <asp:MenuItem Text="Repairing of flushing inlets" Value="17"></asp:MenuItem>
                                    <asp:MenuItem Text="Repairing of sluices" Value="18"></asp:MenuItem>
                                </asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="DLP/Maintenance Period" Value="DLP/Maintenance Period"></asp:MenuItem>
                            <asp:MenuItem Text="Post-DLP Sustainability" Value="Post-DLP Sustainability"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="BoQ" Value="BoQ"></asp:MenuItem>
                        <asp:MenuItem Text="Social" Value="Social">
                            <asp:MenuItem Text="RAP Development" Value="RAP Development">
                                <asp:MenuItem Text="Status" Value="Status"></asp:MenuItem>
                                <asp:MenuItem Text="Public Consultations" Value="Public Consultations"></asp:MenuItem>
                                <asp:MenuItem Text="Field Visits" Value="Field Visits"></asp:MenuItem>
                                <asp:MenuItem Text="Census" Value="Census"></asp:MenuItem>
                                <asp:MenuItem Text="Entitlement Matrix" Value="Entitlement Matrix"></asp:MenuItem>
                                <asp:MenuItem Text="Approval Status" Value="Approval Status"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="RAP Implementation" Value="RAP Implementation">
                                <asp:MenuItem Text="Land/Property Acquisition" Value="Land/Property Acquisition">
                                    <asp:MenuItem Text="Non-titled EPs" Value="Non-titled EPs"></asp:MenuItem>
                                    <asp:MenuItem Text="Titled EPs" Value="Titled EPs"></asp:MenuItem>
                                    <asp:MenuItem Text="Asset Verification" Value="Asset Verification"></asp:MenuItem>
                                    <asp:MenuItem Text="PVC &amp; JVC functioning" Value="PVC &amp; JVC functioning"></asp:MenuItem>
                                    <asp:MenuItem Text="Land acquired" Value="Land acquired"></asp:MenuItem>
                                    <asp:MenuItem Text="Structures acquired" Value="Structures acquired"></asp:MenuItem>
                                    <asp:MenuItem Text="Crops/trees/fisheries losses" Value="Crops/trees/fisheries losses"></asp:MenuItem>
                                    <asp:MenuItem Text="Compensation delivery system " Value="Compensation delivery system "></asp:MenuItem>
                                </asp:MenuItem>
                                <asp:MenuItem Text="RAP Finance" Value="RAP Finance">
                                    <asp:MenuItem Text="Funds at DC Office" Value="Funds at DC Office"></asp:MenuItem>
                                    <asp:MenuItem Text="Funds at Field Office" Value="Funds at Field Office"></asp:MenuItem>
                                    <asp:MenuItem Text="Moving Structure Transfer Grant" Value="Moving Structure Transfer Grant"></asp:MenuItem>
                                    <asp:MenuItem Text="Structure ReEngg_Construction Grant" Value="Structure ReEngg_Construction Grant"></asp:MenuItem>
                                    <asp:MenuItem Text="Loss of Business Payments" Value="Loss of Business Payments"></asp:MenuItem>
                                    <asp:MenuItem Text="Loss of Income by Wage Earner Payments" Value="Loss of Income by Wage Earner Payments"></asp:MenuItem>
                                    <asp:MenuItem Text="Vulnerable EP Grant" Value="Vulnerable EP Grant"></asp:MenuItem>
                                    <asp:MenuItem Text="Loss of Usufruct Payments" Value="Loss of Usufruct Payments"></asp:MenuItem>
                                </asp:MenuItem>
                                <asp:MenuItem Text="PAP Awareness/Satisfaction" Value="PAP Awareness/Satisfaction">
                                    <asp:MenuItem Text="LA&amp;R Policy Awareness" Value="LA&amp;R Policy Awareness"></asp:MenuItem>
                                    <asp:MenuItem Text="Compensation Process Awareness" Value="Compensation Process Awareness"></asp:MenuItem>
                                    <asp:MenuItem Text="Grievance Process Awareness" Value="Grievance Process Awareness"></asp:MenuItem>
                                    <asp:MenuItem Text="PCDP Procedure Satisfaction" Value="PCDP Procedure Satisfaction"></asp:MenuItem>
                                </asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Livelihood Restoration" Value="Livelihood Restoration">
                                <asp:MenuItem Text="Livelihood &amp; Skills Dev. Training to PAPs" Value="Livelihood &amp; Skills Dev. Training to PAPs"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Grievance Redress" Value="Grievance Redress">
                                <asp:MenuItem Text="GRC Establishment" Value="GRC Establishment"></asp:MenuItem>
                                <asp:MenuItem Text="GRC Functioning" Value="GRC Functioning"></asp:MenuItem>
                                <asp:MenuItem Text="Grievances" Value="Grievances">
                                    <asp:MenuItem Text="Lodged" Value="Lodged"></asp:MenuItem>
                                    <asp:MenuItem Text="Status" Value="Status"></asp:MenuItem>
                                </asp:MenuItem>
                                <asp:MenuItem Text="Overall Satisfaction Level" Value="Overall Satisfaction Level"></asp:MenuItem>
                            </asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Environmental" Value="Environmental">
                            <asp:MenuItem Text="Afforestation" Value="Afforestation">
                                <asp:MenuItem Text="Mangrove" Value="Mangrove">
                                    <asp:MenuItem Text="Seeded" Value="Seeded"></asp:MenuItem>
                                    <asp:MenuItem Text="Maintained During DLP" Value="Maintained During DLP"></asp:MenuItem>
                                    <asp:MenuItem Text="Maintenance Arrangements" Value="Maintenance Arrangements"></asp:MenuItem>
                                    <asp:MenuItem Text="Surviving After DLP" Value="Surviving After DLP"></asp:MenuItem>
                                </asp:MenuItem>
                                <asp:MenuItem Text="Tree Crops" Value="Tree Crops"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Water Quality" Value="Water Quality">
                                <asp:MenuItem Text="Surface Water" Value="Surface Water">
                                    <asp:MenuItem Text="Chemical" Value="Chemical"></asp:MenuItem>
                                    <asp:MenuItem Text="Physical" Value="Physical"></asp:MenuItem>
                                    <asp:MenuItem Text="Biological" Value="Biological"></asp:MenuItem>
                                </asp:MenuItem>
                                <asp:MenuItem Text="Ground Water" Value="Ground Water"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Soil Quality" Value="Soil Quality"></asp:MenuItem>
                            <asp:MenuItem Text="Site Environmental Mgmt Plans" Value="Site Environmental Mgmt Plans">
                                <asp:MenuItem Text="Borrow Pit Landscaped as per Specs" Value="Borrow Pit Landscaped as per Specs"></asp:MenuItem>
                            </asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Institutional" Value="Institutional">
                            <asp:MenuItem Text="Disclosures" Value="Disclosures">
                                <asp:MenuItem Text="Safeguards Instruments" Value="Safeguards Instruments"></asp:MenuItem>
                                <asp:MenuItem Text="GAAP" Value="GAAP"></asp:MenuItem>
                                <asp:MenuItem Text="Operational Risks" Value="Operational Risks"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Project Organization" Value="Project Organization">
                                <asp:MenuItem Text="Positions Filled" Value="Positions Filled"></asp:MenuItem>
                                <asp:MenuItem Text="PSC Meetings" Value="PSC Meetings"></asp:MenuItem>
                                <asp:MenuItem Text="PMU Meetings" Value="PMU Meetings"></asp:MenuItem>
                                <asp:MenuItem Text="Field Visits" Value="Field Visits"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Disaster Management Process" Value="Disaster Management Process"></asp:MenuItem>
                            <asp:MenuItem Text="Improved Coastal Monitoring" Value="Improved Coastal Monitoring"></asp:MenuItem>
                            <asp:MenuItem Text="Training" Value="Training">
                                <asp:MenuItem Text="BWDB" Value="BWDB">
                                    <asp:MenuItem Text="Resettlement" Value="Resettlement"></asp:MenuItem>
                                    <asp:MenuItem Text="M&amp;E / Project Management" Value="M&amp;E / Project Management"></asp:MenuItem>
                                    <asp:MenuItem Text="Coastal Monitoring" Value="Coastal Monitoring"></asp:MenuItem>
                                    <asp:MenuItem Text="Contract Management" Value="Contract Management"></asp:MenuItem>
                                    <asp:MenuItem Text="Other Topics" Value="Other Topics"></asp:MenuItem>
                                </asp:MenuItem>
                                <asp:MenuItem Text="WMO/Polder Committees" Value="WMO/Polder Committees"></asp:MenuItem>
                                <asp:MenuItem Text="PAPs" Value="PAPs"></asp:MenuItem>
                                <asp:MenuItem Text="Other Participants" Value="Other Participants"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="WMOs/Polder Committees" Value="WMOs/Polder Committees">
                                <asp:MenuItem Text="Formation" Value="Formation"></asp:MenuItem>
                                <asp:MenuItem Text="Functioning" Value="Functioning"></asp:MenuItem>
                            </asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Financial" Value="Financial">
                            <asp:MenuItem Text="Disbursements" Value="Disbursements"></asp:MenuItem>
                            <asp:MenuItem Text="Pending Invoice Amounts" Value="Pending Invoice Amounts"></asp:MenuItem>
                            <asp:MenuItem Text="Payment Processing Lags" Value="Payment Processing Lags"></asp:MenuItem>
                            <asp:MenuItem Text="Compensation Paid" Value="Compensation Paid">
                                <asp:MenuItem Text="Land" Value="Land"></asp:MenuItem>
                                <asp:MenuItem Text="Crops/trees/fisheries Loss" Value="Crops/trees/fisheries Loss"></asp:MenuItem>
                                <asp:MenuItem Text="Moving Structure Transfer Grant" Value="Moving Structure Transfer Grant"></asp:MenuItem>
                                <asp:MenuItem Text="Structure ReEngg_Construction Grant" Value="Structure ReEngg_Construction Grant"></asp:MenuItem>
                                <asp:MenuItem Text="Loss of Business Payments" Value="Loss of Business Payments"></asp:MenuItem>
                                <asp:MenuItem Text="Loss of Income by Wage Earner Payments" Value="Loss of Income by Wage Earner Payments"></asp:MenuItem>
                                <asp:MenuItem Text="Vulnerable EP Grant" Value="Vulnerable EP Grant"></asp:MenuItem>
                                <asp:MenuItem Text="Loss of Usufruct Payments" Value="Loss of Usufruct Payments"></asp:MenuItem>
                            </asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Agricultural" Value="Agricultural">
                            <asp:MenuItem Text="Cropping Intensity" Value="Cropping Intensity"></asp:MenuItem>
                            <asp:MenuItem Text="Crop Yields" Value="Crop Yields"></asp:MenuItem>
                            <asp:MenuItem Text="Production" Value="Production"></asp:MenuItem>
                            <asp:MenuItem Text="Irrigated Area" Value="Irrigated Area"></asp:MenuItem>
                            <asp:MenuItem Text="Cropping Pattern" Value="Cropping Pattern"></asp:MenuItem>
                            <asp:MenuItem Text="Agricultural Input Use" Value="Agricultural Input Use"></asp:MenuItem>
                            <asp:MenuItem Text="Fish Production and Yields" Value="Fish Production and Yields">
                                <asp:MenuItem Text="Fish Ponds" Value="Fish Ponds"></asp:MenuItem>
                                <asp:MenuItem Text="Rice-Fish Culture" Value="Rice-Fish Culture"></asp:MenuItem>
                                <asp:MenuItem Text="Shrimp" Value="Shrimp"></asp:MenuItem>
                                <asp:MenuItem Text="Fish Capture" Value="Fish Capture"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Livestock" Value="Livestock"></asp:MenuItem>
                        </asp:MenuItem>
                        <asp:MenuItem Text="Socio-Economic" Value="Socio-Economic">
                            <asp:MenuItem Text="Business Activity" Value="Business Activity">
                                <asp:MenuItem Text="Enterprises" Value="Enterprises"></asp:MenuItem>
                                <asp:MenuItem Text="Land Values" Value="Land Values"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Population" Value="Population"></asp:MenuItem>
                            <asp:MenuItem Text="Income Indicators" Value="Income Indicators">
                                <asp:MenuItem Text="Expenditure on non-essential items" Value="Expenditure on non-essential items"></asp:MenuItem>
                                <asp:MenuItem Text="Income by Source" Value="Income by Source"></asp:MenuItem>
                                <asp:MenuItem Text="Landholdings" Value="Landholdings"></asp:MenuItem>
                                <asp:MenuItem Text="Assets" Value="Assets"></asp:MenuItem>
                                <asp:MenuItem Text="Savings Accounts" Value="Savings Accounts"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Social Indicators" Value="Social Indicators">
                                <asp:MenuItem Text="Health Services" Value="Health Services"></asp:MenuItem>
                                <asp:MenuItem Text="Infant Malnutrition" Value="Infant Malnutrition"></asp:MenuItem>
                                <asp:MenuItem Text="School Attendance" Value="School Attendance"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Employment" Value="Employment"></asp:MenuItem>
                            <asp:MenuItem Text="Investment" Value="Investment"></asp:MenuItem>
                            <asp:MenuItem Text="Transport" Value="Transport"></asp:MenuItem>
                            <asp:MenuItem Text="IRR" Value="IRR"></asp:MenuItem>
                        </asp:MenuItem>
                    </Items>
                    <StaticHoverStyle CssClass="menu" BackColor="#284E98" ForeColor="White" />
                    <StaticMenuItemStyle CssClass="menu" HorizontalPadding="5px" VerticalPadding="10px" />
                    <StaticSelectedStyle BackColor="#507CD1" />
                </asp:Menu>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="row" style="border: solid 1px gray; margin-top: 10px; padding: 5px; background-color: wheat">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:HiddenField ID="HiddenIndicatorCode" runat="server" />
                <asp:HiddenField ID="HiddenIndicatorName" runat="server" />
                <div class="form-group" style="width: 320px; margin: 0 auto">
                    <div class="input-group">
                        <span class="input-group-addon span-50">Year :
                        </span>
                        <asp:DropDownList ID="ddlCurrentYear" Width="150px" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCurrentYear_SelectedIndexChanged" runat="server">
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

                <div>
                    <asp:Button ID="btnRefreshData" CssClass="btn btn-primary" runat="server" OnClick="btnRefreshData_Click" Text="Refresh" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="row" style="text-align: center; margin: auto; width: 100%; padding: 5px 10px">
        <div class="row" style="background-color: wheat; height: 46px; padding-top: 5px; border-bottom: inset 1px gray;">
            <ul class="nav nav-pills small" role="tablist">
                <li class="active"><a data-toggle="pill" href="#tab1">Table</a></li>
                <li><a data-toggle="pill" href="#tab2">Chart</a></li>
                <li><a data-toggle="pill" href="#tab3">Map</a></li>
            </ul>
        </div>
        <div class="row ui-dialog-content ui-widget-content" style="background-color: white; border-top: inset 1px gray; height: 700px; overflow: auto">
            <div class="tab-content">
                <div id="tab1" class="tab-pane fade in active small" style="padding: 10px">
                    <br />
                    <br />
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="labelTable" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div id="tab2" class="tab-pane fade in small">
                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                        <ContentTemplate>
                            <asp:Literal ID="labelChart" runat="server"></asp:Literal>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div id="tab3" class="tab-pane fade in small">
                    <table>
                        <tr>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <aspmap:Map ID="map" Width="800px" Height="600px" EnableZoomAnimation="true" ImageFormat="Png" MapUnit="Meter" ImageTempDirectory="MapImage" SmoothingMode="AntiAlias" FontQuality="ClearType" MapTool="Pan" EnableSession="True" ClientScript="StandardScript"
                                            runat="server"></aspmap:Map>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="width: 300px; vertical-align: top; text-align: left">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="labelMapLegend" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

