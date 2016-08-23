using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Drawing;
using AspMap;
using AspMap.Web;
using AspMap.Data;
using AspMap.Web.Extensions;
using System.Text;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


/// <summary>
/// Summary description for MapAdmin
/// </summary>
public class MapAdmin
{
    DbAdmin dba = new DbAdmin();
    public MapAdmin()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void AddPolderMapLayer(AspMap.Web.Map map)
    {
        if (map.GetLayerIndex("polder_bnd") >= 0)
            map.RemoveLayer("polder_bnd");
        AspMap.Layer dbLayer = map.AddLayer(HttpContext.Current.Server.MapPath("App_Data/shapes/") + "Polder_84_old.shp");
        dbLayer.CoordinateSystem = CoordSystem.WGS1984;
        dbLayer.Visible = true;
        dbLayer.Name = "polder_bnd";
        dbLayer.Description = "Polder Boundary";
        dbLayer.LabelField = "polder_no";
        dbLayer.ShowLabels = true;
        dbLayer.LabelFont.Size = 14;
        //dbLayer.LabelFont.Outline = true;
        //dbLayer.LabelFont.OutlineColor = Color.Yellow;
        dbLayer.Symbol.FillStyle = FillStyle.Invisible;
        dbLayer.Symbol.FillColor = Color.Blue;
        //dbLayer.Opacity = 0.1;
        dbLayer.Symbol.LineColor = Color.Black;
        dbLayer.Symbol.Size = 2;
        //dbLayer.UseDefaultSymbol = false;
    }//end AddZoneMapLayer(AspMap.Web.Map map, string zoneCode)

    public void AddPhotoMapLayer(AspMap.Web.Map map)
    {
        if (map.GetLayerIndex("photo_pnt") >= 0)
            map.RemoveLayer("photo_pnt");
        AspMap.Layer dbLayer = map.AddLayer(HttpContext.Current.Server.MapPath("App_Data/shapes/") + "photo.shp");
        dbLayer.CoordinateSystem = CoordSystem.WGS1984;
        dbLayer.Visible = true;
        dbLayer.Name = "photo_pnt";
        dbLayer.Description = "";
        //dbLayer.LabelField = "polder_no";
        //dbLayer.ShowLabels = true;
        //dbLayer.LabelFont.Size = 14;
        //dbLayer.LabelFont.Outline = true;
        //dbLayer.LabelFont.OutlineColor = Color.Yellow;
        dbLayer.Symbol.PointStyle = PointStyle.Triangle;
        dbLayer.Symbol.FillColor = Color.Blue;
        //dbLayer.Opacity = 0.1;
        dbLayer.Symbol.LineColor = Color.Black;
        dbLayer.Symbol.Size = 14;
    }//end AddZoneMapLayer(AspMap.Web.Map map, string zoneCode)
    
    //AspMap.Layer dbLayer = map.AddLayer(HttpContext.Current.Server.MapPath("App_Data/shapes/") + "Polder_84.shp");
    //        dbLayer.CoordinateSystem = CoordSystem.WGS1984;
    //        dbLayer.Visible = true;
    //        dbLayer.Name = "polder_bnd";
    //        dbLayer.Description = "Polder";
    //        dbLayer.LabelField = "p_name";
    //        dbLayer.ShowLabels = true;
    //        dbLayer.LabelFont.Bold = true;
    //        dbLayer.LabelFont.Size = 12;
    //        //dbLayer.LabelFont.Outline = true;
    //        //dbLayer.LabelFont.OutlineColor = Color.Yellow;
    //        dbLayer.Symbol.FillStyle = FillStyle.Invisible;
    //        dbLayer.Symbol.LineColor = Color.Red;
    //        dbLayer.Symbol.Size = 2;
    
    
    public void SetMapExtentFull(AspMap.Web.Map map)
    {
        AspMap.Rectangle ext = null;
        string layerName = string.Empty;
        string columnName = string.Empty;
        if (map.GetLayerIndex("polder_bnd") >= 0)
        {
            layerName = "polder_bnd";
            columnName = "polder_no";
            goto Found;
        }
    Found:
        if (string.IsNullOrEmpty(layerName))
        {
            ext = new AspMap.Rectangle(88.0, 27.0, 93.0, 20.0);

        }
        else
        {
            ext = map[layerName].SearchExpression("not isnull(" + columnName + ")").Extent;

        }
        //ext = map.CoordinateSystem.TransformRectangle(CoordSystem.WGS1984, ext);
        if (map.BackgroundLayer != null)
            ext = map.CoordinateSystem.TransformRectangle(CoordSystem.WGS1984, ext);
        map.Extent = ext;

        //Finish:
        //    Console.WriteLine("End of search.");


    }
    public void AddMapLabel(AspMap.Web.Map map, string layerName)
    {
        switch (layerName)
        {
            case "cluster_bnd":
                map["cluster_bnd"].LabelField = "cluster_name";
                map["cluster_bnd"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            case "region_bnd":
                map["region_bnd"].LabelField = "region_name";
                map["region_bnd"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            case "area_bnd":
                map["area_bnd"].LabelField = "area_name";
                map["area_bnd"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            case "territory_bnd":
                map["territory_bnd"].LabelField = "territory_name";
                map["territory_bnd"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            case "thana_bnd":
                map["thana_bnd"].LabelField = "thana_name";
                map["thana_bnd"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            case "union_bnd":
                map["union_bnd"].LabelField = "union_name";
                map["union_bnd"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            case "site_pnt":
                map["site_pnt"].LabelField = "site_code";
                map["site_pnt"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            case "down_site":
                map["down_site"].LabelField = "site_code";
                map["down_site"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            case "rsp_pnt":
                map["rsp_pnt"].LabelField = "rsp_code";
                map["rsp_pnt"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            case "dsr_pnt":
                map["dsr_pnt"].LabelField = "dsr_code";
                map["dsr_pnt"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            case "route_pnt":
                map["route_pnt"].LabelField = "route_code";
                map["route_pnt"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            case "el_pnt":
                map["el_pnt"].LabelField = "el_code";
                map["el_pnt"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            case "sim_pnt":
                map["sim_pnt"].LabelField = "sim_code";
                map["sim_pnt"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            case "cell_bnd":
                map["cell_bnd"].LabelField = "cell_code";
                map["cell_bnd"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            case "cell_pnt":
                map["cell_pnt"].LabelField = "cell_code";
                map["cell_pnt"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            case "cell_2g_pnt":
                map["cell_2g_pnt"].LabelField = "cell_name";
                map["cell_2g_pnt"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            case "cell_3g_pnt":
                map["cell_3g_pnt"].LabelField = "cell_name";
                map["cell_3g_pnt"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            case "drive_test_pnt":
                map["drive_test_pnt"].LabelField = "data_value";
                map["drive_test_pnt"].ShowLabels = map[layerName].ShowLabels ? false : true;
                break;
            default:
                break;
        }

        //if (map[layerName].Recordset.Fields.GetFieldIndex)

    }
    public void MoveDynamicMapLayer(AspMap.Web.Map map, string moduleName)
    {
        if (map.GetLayerIndex("cluster_bnd") >= 0)
            map.MoveLayer(map.GetLayerIndex("cluster_bnd"), 0);
        if (map.GetLayerIndex("region_bnd") >= 0)
            map.MoveLayer(map.GetLayerIndex("region_bnd"), 0);
        if (map.GetLayerIndex("area_bnd") >= 0)
            map.MoveLayer(map.GetLayerIndex("area_bnd"), 0);
        if (map.GetLayerIndex("territory_bnd") >= 0)
            map.MoveLayer(map.GetLayerIndex("territory_bnd"), 0);
        if (map.GetLayerIndex("area_bnd") >= 0)
            map.MoveLayer(map.GetLayerIndex("area_bnd"), 0);
        if (map.GetLayerIndex("thana_bnd") >= 0)
            map.MoveLayer(map.GetLayerIndex("thana_bnd"), 0);
        if (map.GetLayerIndex("union_bnd") >= 0)
            map.MoveLayer(map.GetLayerIndex("union_bnd"), 0);
        if (map.GetLayerIndex("cell_bnd") >= 0)
            map.MoveLayer(map.GetLayerIndex("cell_bnd"), 0);
        if (map.GetLayerIndex("site_pnt") >= 0)
            map.MoveLayer(map.GetLayerIndex("site_pnt"), 0);
        if (map.GetLayerIndex("coverage_site") >= 0)
            map.MoveLayer(map.GetLayerIndex("coverage_site"), 0);        
        if (map.GetLayerIndex("cell_2g_pnt") >= 0)
            map.MoveLayer(map.GetLayerIndex("cell_2g_pnt"), 0);
        if (map.GetLayerIndex("cell_3g_pnt") >= 0)
            map.MoveLayer(map.GetLayerIndex("cell_3g_pnt"), 0);
        if (map.GetLayerIndex("site_hvc_pnt") >= 0)
            map.MoveLayer(map.GetLayerIndex("site_hvc_pnt"), 0);
        if (map.GetLayerIndex("rsp_pnt") >= 0)
            map.MoveLayer(map.GetLayerIndex("rsp_pnt"), 0);
        if (map.GetLayerIndex("dsr_pnt") >= 0)
            map.MoveLayer(map.GetLayerIndex("dsr_pnt"), 0);
        if (map.GetLayerIndex("route_pnt") >= 0)
            map.MoveLayer(map.GetLayerIndex("route_pnt"), 0);
        if (map.GetLayerIndex("el_pnt") >= 0)
            map.MoveLayer(map.GetLayerIndex("el_pnt"), 0);
        if (map.GetLayerIndex("sim_pnt") >= 0)
            map.MoveLayer(map.GetLayerIndex("sim_pnt"), 0);
        if (map.GetLayerIndex("cms_pnt") >= 0)
            map.MoveLayer(map.GetLayerIndex("cms_pnt"), 0);
        if (map.GetLayerIndex("mouza_bnd") >= 0)
            map.MoveLayer(map.GetLayerIndex("mouza_bnd"), 0);
        if (map.GetLayerIndex("road_national") >= 0)
            map.MoveLayer(map.GetLayerIndex("road_national"), 0);
        if (map.GetLayerIndex("road_regional") >= 0)
            map.MoveLayer(map.GetLayerIndex("road_regional"), 0);
        if (map.GetLayerIndex("road_city") >= 0)
            map.MoveLayer(map.GetLayerIndex("road_city"), 0);
        if (map.GetLayerIndex("rivers") >= 0)
            map.MoveLayer(map.GetLayerIndex("rivers"), 0);
        if (map.GetLayerIndex("settlement_bnd") >= 0)
            map.MoveLayer(map.GetLayerIndex("settlement_bnd"), 0);
        if (map.GetLayerIndex("fiber_line") >= 0)
            map.MoveLayer(map.GetLayerIndex("fiber_line"), 0);
    }
    public void AddBaseMapsLayer(AspMap.Web.Map map, string mapType)
    {
        AspMap.Rectangle ext = map.Extent;
        GoogleMapsLayer gml = null;
        if (UtilityClass.UseGoogleMapKey())
            gml = new GoogleMapsLayer(UtilityClass.GoogleMapKey());
        else
            gml = new GoogleMapsLayer();
        switch (mapType)
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
        }//end switch (mapType)
        gml.Visible = true;
        //gml.Version = "3";
        //gml.UseSensor = true;
        map.ImageOpacity = 0.5;
        map.BackgroundLayer = gml;
        ext = CoordSystem.Transform(CoordSystem.WGS1984, ext, map.CoordinateSystem);
        map.ImageFormat = ImageFormat.Png;
        map.Extent = ext;
    }
    public DataTable RecordsetToDataTable(AspMap.Recordset rec)
    {
        DataTable dataTable = new DataTable();
        // Create a DataColumn and set various properties. 
        DataColumn column;
        for (int i = 0; i < rec.Fields.Count; i++)
        {
            column = new DataColumn();
            if (rec.Fields[i].Type == FieldType.Boolean)
                column.DataType = typeof(bool);
            else if (rec.Fields[i].Type == FieldType.Char)
                column.DataType = typeof(string);
            else if (rec.Fields[i].Type == FieldType.Date)
                column.DataType = typeof(DateTime);
            else if (rec.Fields[i].Type == FieldType.Double)
                column.DataType = typeof(double);
            else if (rec.Fields[i].Type == FieldType.Integer)
                column.DataType = typeof(int);
            else
                column.DataType = typeof(string);
            column.AllowDBNull = true;
            column.Caption = rec.Fields[i].Name;
            column.ColumnName = rec.Fields[i].Name;
            // Add the column to the table. 
            dataTable.Columns.Add(column);
            //dc = new DataColumn(records.Fields[i].Name,Type.); 
        }
        DataRow row;
        rec.MoveFirst();
        for (int i = 0; i < rec.RecordCount; i++)
        {
            row = dataTable.NewRow();
            for (int j = 0; j < rec.Fields.Count; j++)
            {
                try
                {
                    row[j] = rec[j].ToString();
                }
                catch
                {
                    //row[j] = DBNull.Value;
                }
            }
            // Be sure to add the new row to the 
            // DataRowCollection. 
            dataTable.Rows.Add(row);
            rec.MoveNext();
        }
        dataTable.AcceptChanges();
        return dataTable;
    }
    public DataTable RecordsetToDataTableAllString(AspMap.Recordset rec)
    {
        DataTable dataTable = new DataTable();
        // Create a DataColumn and set various properties. 
        DataColumn column;
        for (int i = 0; i < rec.Fields.Count; i++)
        {
            column = new DataColumn();
            column.DataType = typeof(string);
            column.AllowDBNull = true;
            column.Caption = rec.Fields[i].Name;
            column.ColumnName = rec.Fields[i].Name;
            // Add the column to the table. 
            dataTable.Columns.Add(column);
            //dc = new DataColumn(records.Fields[i].Name,Type.); 
        }
        DataRow row;
        rec.MoveFirst();
        for (int i = 0; i < rec.RecordCount; i++)
        {
            row = dataTable.NewRow();
            for (int j = 0; j < rec.Fields.Count; j++)
            {
                try
                {
                    row[j] = rec[j].ToString();
                }
                catch
                {
                    //row[j] = DBNull.Value;
                }
            }
            // Be sure to add the new row to the 
            // DataRowCollection. 
            dataTable.Rows.Add(row);
            rec.MoveNext();
        }
        dataTable.AcceptChanges();
        return dataTable;
    }
    public string RenderLegend(Map map)
    {
        StringWriter sw = new StringWriter();
        if (map != null && map.LayerCount > 0)
        {

            Table tbl = new Table();
            tbl.CellPadding = 2;
            tbl.CellSpacing = 0;
            TableRow tr;
            TableCell tc;
            foreach (AspMap.Layer layer in map)
            {
                if (layer.Visible)
                {
                    tr = new TableRow();
                    tc = new TableCell();
                    string text1 = layer.Description;
                    if (text1.Length == 0)
                        text1 = layer.Name;
                    text1 = "<b>" + text1 + "</b> (<b>Total- " + layer.Recordset.RecordCount.ToString() + " </b>)";
                    tc.Text = text1;
                    tr.Cells.Add(tc);
                    tbl.Rows.Add(tr);
                    tr = new TableRow();
                    tc = new TableCell();
                    Legend legend = new Legend();
                    legend.BackColor = Color.Transparent;
                    legend.LegendFont.Bold = true;
                    legend.Width = Unit.Percentage(100.0);
                    FeatureRenderer renderer = layer.Renderer;
                    int index = 0;
                    if (renderer.Count > 0)
                    {
                        do
                        {
                            Feature f = renderer[index];
                            if (!string.IsNullOrEmpty(f.Expression))
                            {
                                int recCount = layer.SearchExpression(f.Expression).RecordCount;
                                if (recCount <= 0)
                                    recCount = 0;
                                if (recCount >= 0)
                                {
                                    string text2 = f.Description;
                                    if (text2.Length == 0)
                                        text2 = text1;
                                    if (!string.IsNullOrEmpty(f.Expression))
                                    {
                                        text2 = text2 + " (Total-" + recCount.ToString() + ")";
                                    }
                                    legend.Add(text2, layer.LayerType, f.Symbol);
                                }
                            }
                            ++index;
                        }
                        while (index < renderer.Count);
                    }
                    else
                    {
                        legend.Add(string.Empty, layer.LayerType, layer.Symbol);
                    }
                    System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
                    image.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((Byte[])legend.Image);
                    tc.Controls.Add(image);
                    tr.Cells.Add(tc);
                    tbl.Rows.Add(tr);
                }
            }
            tbl.RenderControl(new HtmlTextWriter(sw));
        }
        return sw.ToString();
    }
    public PointStyle GetPointStyle(string pointName)
    {
        PointStyle ps = PointStyle.Triangle;
        switch (pointName.ToLower())
        {
            case "arrow": ps = PointStyle.Arrow; break;
            case "bitmap": ps = PointStyle.Triangle; break;
            case "circle": ps = PointStyle.Circle; break;
            case "circlewithlargecenter": ps = PointStyle.CircleWithLargeCenter; break;
            case "circlewithsmallcenter": ps = PointStyle.CircleWithSmallCenter; break;
            case "cross": ps = PointStyle.Cross; break;
            case "font": ps = PointStyle.Font; break;
            case "rhomb": ps = PointStyle.Rhomb; break;
            case "square": ps = PointStyle.Square; break;
            case "squarewithlargecenter": ps = PointStyle.SquareWithLargeCenter; break;
            case "squarewithsmallcenter": ps = PointStyle.SquareWithSmallCenter; break;
            case "star": ps = PointStyle.Star; break;
            case "triangle": ps = PointStyle.Triangle; break;
        }

        return ps;
    }// end PointStyle GetPointStyle(string pointName)
    public LineStyle GetLineStyle(string lineName)
    {
        LineStyle ls = LineStyle.Solid;
        switch (lineName.ToLower())
        {
            case "arrowboth": ls = LineStyle.ArrowBoth; break;
            case "arrowend": ls = LineStyle.ArrowEnd; break;
            case "arrowstart": ls = LineStyle.ArrowStart; break;
            case "dualroad": ls = LineStyle.DualRoad; break;
            case "dashdotdotroad": ls = LineStyle.DashDotDotRoad; break;
            case "dashdotroad": ls = LineStyle.DashDotRoad; break;
            case "dotroad": ls = LineStyle.DotRoad; break;
            case "dashroad": ls = LineStyle.DashRoad; break;
            case "road": ls = LineStyle.Road; break;
            case "railroad": ls = LineStyle.Railroad; break;
            case "dashdot": ls = LineStyle.DashDot; break;
            case "dot": ls = LineStyle.Dot; break;
            case "dash": ls = LineStyle.Dash; break;
            case "solid": ls = LineStyle.Solid; break;
            case "invisible": ls = LineStyle.Invisible; break;
        }

        return ls;
    }// end LineStyle GetLineStyle(string lineName)
    public FillStyle GetFillStyle(string fillName)
    {
        FillStyle fs = FillStyle.Invisible;
        switch (fillName.ToLower())
        {
            case "darkgray": fs = FillStyle.DarkGray; break;
            case "gray": fs = FillStyle.Gray; break;
            case "lightgray": fs = FillStyle.LightGray; break;
            case "diagonalcross": fs = FillStyle.DiagonalCross; break;
            case "cross": fs = FillStyle.Cross; break;
            case "downwarddiagonal": fs = FillStyle.DownwardDiagonal; break;
            case "upwarddiagonal": fs = FillStyle.UpwardDiagonal; break;
            case "vertical": fs = FillStyle.Vertical; break;
            case "horizontal": fs = FillStyle.Horizontal; break;
            case "solid": fs = FillStyle.Solid; break;
            case "invisible": fs = FillStyle.Invisible; break;
        }

        return fs;
    }// end FillStyle GetFillStyle(string fillName)


    public void ExportMapImage(AspMap.Web.Map map)
    {
        map.DrawRectangle(map.Extent, new Symbol { FillStyle = FillStyle.Invisible, Size = 1, LineColor = Color.LightGray });
        map.ImageTimeout = 2;
        string myImg = HttpContext.Current.Server.MapPath("~/Uploads/") + "map.jpg";
        if (map.SaveImage(myImg))
        {
            HttpContext.Current.Response.ContentType = "image/jpeg";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=map.jpg");
            //Response.TransmitFile(Server.MapPath("~/Upload/img.gif"));
            HttpContext.Current.Response.TransmitFile("~/Uploads/map.jpg");
            HttpContext.Current.Response.End();
        }
    }
    public AspMap.Point GetPointDistanceAngle(double lat, double lon, double angle, double distance)
    {
        double lat2;
        double lon2;
        double R = 6371.0; // km
        double d = distance / R;// d = angular distance covered on earth's surface
        double lat1 = DegreeToRadian(lat);
        double lon1 = DegreeToRadian(lon);


        double brng = DegreeToRadian(angle);

        AspMap.Point point = new AspMap.Point();
        lat2 = Math.Asin((Math.Sin(lat1) * Math.Cos(d)) + (Math.Cos(lat1) * Math.Sin(d) * Math.Cos(brng)));
        lon2 = lon1 + Math.Atan2((Math.Sin(brng) * Math.Sin(d) * Math.Cos(lat1)), (Math.Cos(d) - (Math.Sin(lat1) * Math.Sin(lat2))));
        lon2 = (lon2 + 3.0 * Math.PI) % (2.0 * Math.PI) - Math.PI;
        point.Y = RadianToDegree(lat2);
        point.X = RadianToDegree(lon2);
        return point;
    }
    private double DegreeToRadian(double angle)
    {
        return Math.PI * angle / 180.0;
    }
    private double RadianToDegree(double angle)
    {
        return angle * (180.0 / Math.PI);
    }
}