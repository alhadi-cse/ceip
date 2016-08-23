using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Drawing;
using AspMap;
using AspMap.Web;
using AspMap.Data;
using AspMap.Web.Extensions;
using System.Data;
using System.Globalization;

using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;

using System.Text;
using System.IO;
using System.Web.Services;
//using Ionic.Zip;

//using iText = iTextSharp.text;
//using iPdf = iTextSharp.text.pdf;


public partial class MapViewer : System.Web.UI.Page
{
    DbAdmin dba = new DbAdmin();
    MapAdmin ma = new MapAdmin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Page.Header.DataBind();
            //LogUtility.LogPageVisitInfo("Revenue");
            //if (Session["UserID"] == null)
            //{
            //    Session["ReturnUrl"] = "Sales.aspx";
            //    Response.Redirect("UserLogin.aspx");
            //}

           // hiddenModuleName.Value = "revenue";
            //(this.Master.FindControl("lblSitePath") as Label).Text = "Satyanweshi >> Revenue";
            //MapLegendList.OnClientClick = string.Format("ShowDragPanel('{0}');return false;", DragPanelMapLegend.ClientID);
            if (map.LayerCount > 0)
                map.RemoveAllLayers();
            if (map.BackgroundLayer != null)
                map.BackgroundLayer = null;
            if (map.Hotspots.Count > 0)
                map.Hotspots.Clear();
            if (map.MapShapes.Count > 0)
                map.MapShapes.Clear();
            if (map.Markers.Count > 0)
                map.Markers.Clear();
            map.MapUnit = MeasureUnit.Meter;
            map.ScaleBar.Visible = true;
            map.ScaleBar.Position = ScaleBarPosition.BottomLeft;
            map.ScaleBar.BarUnit = UnitSystem.Metric;
            //map.CoordinateSystem = CoordSystem.WGS1984;
            map.SmoothingMode = SmoothingMode.AntiAlias;
            map.ImageFormat = ImageFormat.Gif;
            map.ImageOpacity = 1;
            ma.AddPolderMapLayer(map);

            ma.SetMapExtentFull(map);

        }
    }
    protected void ToolButtomExportMap_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ToolButtomPrintMap_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ToolButtonClearMap_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ZoomFull_Click(object sender, ImageClickEventArgs e)
    {
        ma.SetMapExtentFull(map);
    }
    protected void ZoomBar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btn = (ImageButton)sender;
        switch (btn.ID)
        {
            case "East":
                map.Pan(CompassDirection.East, 20);
                break;
            case "West":
                map.Pan(CompassDirection.West, 20);
                break;
            case "North":
                map.Pan(CompassDirection.North, 20);
                break;
            case "South":
                map.Pan(CompassDirection.South, 20);
                break;
            case "NorthEast":
                map.Pan(CompassDirection.Northeast, 20);
                break;
            case "NorthWest":
                map.Pan(CompassDirection.Northwest, 20);
                break;
            case "SouthEast":
                map.Pan(CompassDirection.Southeast, 20);
                break;
            case "SouthWest":
                map.Pan(CompassDirection.Southwest, 20);
                break;
            case "FullExtent":
                ma.SetMapExtentFull(map);
                break;
            case "ZoomIn":
                map.ZoomIn(map.Extent.Center);
                break;
            case "ZoomOut":
                map.ZoomOut(map.Extent.Center);
                break;
            default:
                break;
        }
    }
    protected void btnSearchInMap_Click(object sender, EventArgs e)
    {

    }
    protected void btnLabelShowHide_Click(object sender, EventArgs e)
    {

    }
    protected void btnExportData_Click(object sender, EventArgs e)
    {

    }
    protected void CheckBoxMapLayer_CheckedChanged(object sender, EventArgs e)
    {

        CheckBox chk = (CheckBox)sender;
        if (chk != null)
        {
            string checkValue = chk.ID.Remove(0, 4).ToLower();
            //AddMapLayer(checkValue, chk.Checked);
            //switch (checkValue)
            //{
            //    case "p_pipes":
            //        AddMainPipes(chk.Checked);
            //        break;
            //    case "p_service":
            //        AddServicePipes(chk.Checked);
            //        break;
            //    case "p_townborderstation":
            //        AddTownBorderStation(chk.Checked);
            //        break;
            //    case "p_districtregulatorystation":
            //        //AddTerritory(chk.Checked);
            //        break;
            //    case "p_noncontrollablefitting":
            //        //AddThana(chk.Checked);
            //        break;
            //    case "p_controllablefitting":
            //       // AddUnion(chk.Checked);
            //        break;
            //    case "p_cathodicprotection":
            //        //AddSite(chk.Checked);
            //        break;
            //    case "p_tegroom":
            //        //AddSite(chk.Checked);
            //        break;
            //    case "p_valve":
            //        //AddSite(chk.Checked);
            //        break;
            //    case "p_riser":
            //        //AddSite(chk.Checked);
            //        break;
            //    default:
            //        break;
            //}
            //ma.MoveDynamicMapLayer(map);
            if (ddlActiveMapLayer.Items.FindByValue(checkValue) != null)
            {
                ddlActiveMapLayer.Items.FindByValue(checkValue).Enabled = chk.Checked;
                if (chk.Checked)
                    ddlActiveMapLayer.SelectedValue = checkValue;
            }
            lblMapLegendInfo.Text = ma.RenderLegend(map);
        }

    }
    protected void RadioButtonBaseMap_CheckedChanged(object sender, EventArgs e)
    {

        RadioButton rbt = (RadioButton)sender;
        if (rbt != null)
        {
            string checkValue = rbt.ID.Remove(0, 4).ToLower();
            //bool check = e.Node.Checked;
            AspMap.Rectangle ext = map.Extent;
            if (map.BackgroundLayer != null)
                ext = CoordSystem.Transform(map.CoordinateSystem, ext, CoordSystem.WGS1984);
            ////update check node
            //treeViewBaseMap.FindNode("base/gnone").Checked = false;
            //treeViewBaseMap.FindNode("base/groad").Checked = false;
            //treeViewBaseMap.FindNode("base/ghybrid").Checked = false;
            //treeViewBaseMap.FindNode("base/gsatellite").Checked = false;
            //treeViewBaseMap.FindNode("base/gterrain").Checked = false;
            switch (checkValue)
            {
                case "gnone":
                    //treeViewBaseMap.FindNode("base/" + e.Node.Value).Checked = true;
                    map.BackgroundLayer = null;
                    map.ImageOpacity = 1.0;
                    map.CoordinateSystem = CoordSystem.WGS1984;
                    map.ImageFormat = ImageFormat.Gif;
                    map.Extent = ext;
                    break;
                default:
                    if (rbt.Checked)
                    {
                        //treeViewBaseMap.FindNode("base/" + e.Node.Value).Checked = check;
                        GoogleMapsLayer gml = (GoogleMapsLayer)map.BackgroundLayer;
                        if (gml != null)
                        {
                            switch (checkValue)
                            {
                                case "groad":
                                    gml.MapType = GoogleMapType.Normal;
                                    break;
                                case "ghybrid":
                                    gml.MapType = GoogleMapType.Hybrid;
                                    break;
                                case "gsatellite":
                                    gml.MapType = GoogleMapType.Satellite;
                                    break;
                                case "gterrain":
                                    gml.MapType = GoogleMapType.Physical;
                                    break;
                                default:
                                    gml.MapType = GoogleMapType.Normal;
                                    break;
                            }//end switch (e.Node.Value)
                        }
                        else
                        {
                            ma.AddBaseMapsLayer(map, checkValue);
                        }//end if (gml != null)
                    }
                    else
                    {
                        //treeViewBaseMap.FindNode("base/gnone").Checked = true;
                        map.BackgroundLayer = null;
                        map.ImageOpacity = 1.0;
                        map.CoordinateSystem = CoordSystem.WGS1984;
                        map.ImageFormat = ImageFormat.Gif;
                        map.Extent = ext;
                    }//end  if (check)
                    break;
            }//end  switch (e.Node.Value)
        }
    }
    protected void btnApplyInMap_Click(object sender, EventArgs e)
    {

    }
    public DataTable GetSearchTemplateTable()
    {
        DataTable table = new DataTable();
        table.Columns.Add("code", typeof(string));
        table.Columns.Add("shape", System.Type.GetType("System.Byte[]"));
        table.AcceptChanges();
        return table;
    }
    public void AddSelectedMap(DataTable table, LayerType layerType)
    {
        if (map.GetLayerIndex("selected") >= 0)
            map.RemoveLayer("selected");
        Layer layer = map.AddLayer(new DataTableLayer(table, "shape"));
        layer.Opacity = 0.6;
        layer.CoordinateSystem = CoordSystem.WGS1984;
        layer.Name = "selected";
        layer.Description = "Selected";
        int zoomLevel = map.ZoomLevel;
        AspMap.Rectangle extent = layer.SearchExpression("not isnull(code)").Extent;
        AspMap.Point pnt = extent.Center;
        if (map.BackgroundLayer != null)
        {
            if (layer.LayerType == LayerType.Point)
                pnt = map.CoordinateSystem.TransformPoint(CoordSystem.WGS1984, pnt);
            else
                extent = map.CoordinateSystem.TransformRectangle(CoordSystem.WGS1984, extent);
        }
        if (layerType == LayerType.Point)
            map.CenterAt(pnt);
        else
        {
            //map.Extent = extent;
            //map.CenterAndZoom(extent.Center, zoomLevel);
        }
        // map.z
        //map.CenterAndZoom(extent.Center, zoomLevel + 4);
        //map.CenterAt(extent.Center);
        //map.ZoomOut(map.Extent.Center);
        //map.ZoomOut(map.Extent.Center);

        switch (layerType)
        {
            case LayerType.Point:
                //layer.Symbol.PointStyle = PointStyle.Square;
                //dbLayer.Symbol.TransparentColor = Color.White;
                //layer.Symbol.Bitmap = Server.MapPath("images/maps/") + "bts2g.gif";

                if (map.Markers.Count > 0)
                    map.Markers.Clear();

                //AspMap.Layer layer = Layer.Open(MapPath("MAPS/NORFOLK/points.shp"));

                AspMap.Recordset locations = layer.Recordset;
                //map["el_pnt"].Visible = false;
                while (!locations.EOF)
                {
                    Marker marker = new Marker(locations.Shape.Centroid, new MarkerSymbol("images/maps/marker-0.png", 25, 41), locations["code"].ToString());
                    map.Markers.Add(marker);

                    locations.MoveNext();
                }
                //map.Markers.EnableClusters = true;
                //map.Markers.ClusterDistance = 20; // pixels     



                //layer.Symbol.FillStyle = FillStyle.Solid;
                //layer.Symbol.FillColor = Color.Yellow;
                //layer.Symbol.LineStyle = LineStyle.Solid;
                //layer.Symbol.Size = 14;
                //layer.Symbol.LineColor = Color.Black;

                //map.CenterAndZoom(map.Extent.Center, 4);
                if (map.GetLayerIndex("selected") >= 0)
                    map.RemoveLayer("selected");
                break;
            case LayerType.Line:
                layer.Symbol.Size = 5;
                layer.Symbol.LineStyle = LineStyle.DashDotDotRoad;
                layer.Symbol.FillStyle = FillStyle.Solid;
                layer.Symbol.LineColor = Color.Black;
                layer.Symbol.FillColor = Color.Yellow;
                layer.Symbol.InnerColor = Color.Yellow;
                break;
            case LayerType.Polygon:
                layer.Symbol.Size = 2;
                layer.Symbol.FillStyle = FillStyle.DiagonalCross;
                layer.Symbol.LineColor = Color.Green;
                layer.Symbol.FillColor = Color.Tan;
                break;
        }
        if (map.BackgroundLayer != null)
        {
            if (layerType == LayerType.Polygon)
            {
                layer.Symbol.Size = 4;
                layer.Opacity = .5;
                layer.Symbol.LineColor = Color.Yellow;
            }
        }
    }
    protected void map_InfoTool(object sender, InfoToolEventArgs e)
    {
        string layerName = ddlActiveMapLayer.SelectedValue;
        if (map.GetLayerIndex("selected") >= 0)
            map.RemoveLayer("selected");
        AspMap.Point pnt = e.InfoPoint;
        if (map.BackgroundLayer != null)
            pnt = CoordSystem.WGS1984.TransformPoint(map.CoordinateSystem, pnt);
        if (map.GetLayerIndex(layerName) >= 0)
        {
            AspMap.Recordset rec = null;
            switch (map[layerName].LayerType)
            {
                case LayerType.Polygon:
                    rec = map[layerName].SearchShape(pnt, SearchMethod.PointInPolygon);
                    break;
                default:
                    rec = map[layerName].SearchNearest(pnt);
                    break;
            }
            if (rec != null && rec.RecordCount > 0)
            {


                DataTable dt = GetSearchTemplateTable();
                DataRow dr;
                dr = dt.NewRow();
                dr["code"] = rec["p_name"].ToString();
                dr["shape"] = Shape.ToWkb(rec.Shape);
                dt.Rows.Add(dr);
                dt.AcceptChanges();
                AddSelectedMap(dt, map[ddlActiveMapLayer.SelectedValue].LayerType);


                //if (map.Markers.Count > 0)
                //    map.Markers.Clear();
                //Marker marker = new Marker(rec.Shape.Centroid, new MarkerSymbol("images/maps/marker-0.png", 25, 41), "");
                //map.Markers.Add(marker);

                Table tbl = new Table();
                tbl.ID = "tabSum";
                tbl.CellPadding = 2;
                tbl.CellSpacing = 0;
                tbl.Width = Unit.Percentage(100.0);
                tbl.CssClass = "table table-bordered table-condensed small";
                TableRow tr;
                TableCell tc;
                tr = new TableRow();
                tc = new TableCell();
                tc.ColumnSpan = 2;
                tc.CssClass = "td-header-color";
                //tc.ForeColor = Color.Black;
                tc.Text = "Attribute for Polder " + rec["p_name"].ToString();
                modalHeaderTitle_MapInfo.Text = "Information for Polder " + rec["p_name"].ToString();
                tr.Cells.Add(tc);
                tbl.Rows.Add(tr);
                tr = new TableRow();
                tc = new TableCell();
                tc.CssClass = "tdDataLeft";
                tc.Text = "Polder Name";
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.CssClass = "tdDataRight";
                tc.Text = rec["p_name"].ToString();
                tr.Cells.Add(tc);
                tbl.Rows.Add(tr);

                StringWriter sw = new StringWriter();
                tbl.RenderControl(new HtmlTextWriter(sw));
                lblMapInfoData.Text = sw.ToString();
                modal_MapInfo.Show();




            }
        }
    }
}