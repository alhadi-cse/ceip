using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Data;
using System.Drawing;

using AspMap;
using AspMap.Web;
using AspMap.Data;
using AspMap.Web.Extensions;


using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System.Globalization;



public partial class Monitoring : System.Web.UI.Page
{
    DbAdmin dba = new DbAdmin();
    MapAdmin ma = new MapAdmin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
            //AddMap();
            ma.AddPhotoMapLayer(map);
            labelMapLegend.Text = ma.RenderLegend(map);
            ma.SetMapExtentFull(map); 

            
        }

    }
    private void AddChart()
    {
        string[] str = CreateChart();
        labelChart.Text = str[0];
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax2", str[1], false); 
    }

    private void GetTagle4()
    {

        Table tbl = new Table();
        tbl.CssClass = "info-table table";
        tbl.Width = Unit.Percentage(90.0);
        tbl.CellPadding = 1;
        tbl.CellSpacing = 0;
        TableRow tr;
        TableCell tc;

        tr = new TableRow();
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.ColumnSpan = 16;
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Project Development Objectives";
        tr.Cells.Add(tc);
        tbl.Rows.Add(tr);

        tr = new TableRow();
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Indicator Name";
        tc.RowSpan = 2;
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Core";
        tc.RowSpan = 2;
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Unit of Measure";
        tc.RowSpan = 2;
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Base line";
        tc.RowSpan = 2;
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.ColumnSpan = 8;
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Cumulative Target Values";
        tr.Cells.Add(tc);


        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Frequency";
        tc.RowSpan = 2;
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Data Source/Meth.";
        tc.RowSpan = 2;
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Responsible for Data Collection";
        tc.RowSpan = 2;
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Remarks";
        tc.RowSpan = 2;
        tr.Cells.Add(tc);


        tbl.Rows.Add(tr);




        //third heading row
        tr = new TableRow();
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "YR1";
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "YR2";
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "YR3";
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "YR4";
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "YR5";
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "YR6";
        tr.Cells.Add(tc);

        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "YR7";
        tr.Cells.Add(tc);


        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "End Target";
        tr.Cells.Add(tc);

        tbl.Rows.Add(tr);



        //for database Calculation

        DataTable table = new DataTable();
        table = dba.GetDataTable("select * from tab_4");
        if (table != null && table.Rows.Count > 0)
        {
            foreach (DataRow dRow in table.Rows)
            {

                tr = new TableRow();
                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Left;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = dRow["indicator_name"].ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = dRow["core"].ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = dRow["unit"].ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = dRow["base_line"].ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = string.IsNullOrEmpty(dRow["yr1"].ToString()) ? "-" : dRow["yr1"].ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = string.IsNullOrEmpty(dRow["yr2"].ToString()) ? "-" : dRow["yr2"].ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = string.IsNullOrEmpty(dRow["yr3"].ToString()) ? "-" : dRow["yr3"].ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = string.IsNullOrEmpty(dRow["yr4"].ToString()) ? "-" : dRow["yr4"].ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = string.IsNullOrEmpty(dRow["yr5"].ToString()) ? "-" : dRow["yr5"].ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = string.IsNullOrEmpty(dRow["yr6"].ToString()) ? "-" : dRow["yr6"].ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = string.IsNullOrEmpty(dRow["yr7"].ToString()) ? "-" : dRow["yr7"].ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = dRow["end_target"].ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = dRow["frequency"].ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = dRow["data_source"].ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = dRow["responsible"].ToString();
                tr.Cells.Add(tc);

                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = dRow["remarks"].ToString();
                tr.Cells.Add(tc);

                tbl.Rows.Add(tr);

                tr = new TableRow();
                
                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.BackColor = Color.AliceBlue;
                tc.HorizontalAlign = HorizontalAlign.Left;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = "Achievement";
                tr.Cells.Add(tc);
                for (int i = 1; i <= 15; i++)
                {
                    tc = new TableCell();
                    tc.CssClass = "table-cell";
                    tc.BackColor = Color.AliceBlue;
                    tc.HorizontalAlign = HorizontalAlign.Center;
                    tc.VerticalAlign = VerticalAlign.Middle;
                    tc.Text = "";
                    tr.Cells.Add(tc);
                }



                   

                tbl.Rows.Add(tr);
            }

        }



        StringWriter sw = new StringWriter();
        tbl.RenderControl(new HtmlTextWriter(sw));
        labelTable.Text = sw.ToString();
    
    }
    private string[] CreateChart()
    {
        string[] retVal = new string[2];
        DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")
            .InitChart(new DotNet.Highcharts.Options.Chart { Width=1000, Height = 500, DefaultSeriesType = DotNet.Highcharts.Enums.ChartTypes.Column })
        .SetXAxis(new XAxis
        {
            Categories = new[] { "6.01", "6.02", "6.03", "6.04", "6.05", "6.06", "6.07" }
        })
        .SetTitle(new Title { Text = "Progress" })
        .SetSubtitle(new Subtitle { Text = "" })
        .SetSeries(new Series[]{ new Series
        {
            Data = new Data(new object[] { 10.0, 20.0, 15.0, 25.0, 30.0, 8.2, 2.0 }),
            Name = "Current Progress"},new Series
        {
            Data = new Data(new object[] { 100.0, 90.0, 80.0, 70.0, 50.0, 10.0, 5.0 }),
            Name = "Total"}
        });

        //chart.InFunction("DrawChart");
        //return chart.ToHtmlString();

        retVal[0] = chart.ChartContainerHtmlString().ToString(); // Let's render div container.

        retVal[1] = chart.ChartScriptHtmlString().ToString(); // Let's return the javascript chart code.

        return retVal;
    }
    private void AddMap()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("select package_no,polder_no,coalesce(sum(target_value),0) target_value,coalesce(sum(progress_value),0) progress_value");
        sb.Append(" from indicator_progress where progress_year='");
        sb.Append(ddlCurrentYear.SelectedValue);
        sb.Append("' and indicator_code='");
        sb.Append(HiddenIndicatorCode.Value);
        sb.Append("' group by package_no,polder_no");
        DataTable table = dba.GetDataTable(sb.ToString());
        if (table != null && table.Rows.Count > 0)
        {
            string exp = "iif([target_value]>0,([progress_value]/[target_value])*100.0,0.0)";

            table.Columns.Add(new DataColumn { ColumnName = "progress", DataType = typeof(double), Expression = exp });
            table.AcceptChanges();
            if (map.GetLayerIndex("polder_bnd") >= 0)
            {
                AspMap.Layer layer = map["polder_bnd"];
                layer.RemoveRelates();

                if (layer.AddRelate("polder_no", table, "polder_no"))
                {
                    //layer.Recordset.Export(@"E:\_aa\kala.shp");
                    if (layer.Renderer.Count > 0)
                        layer.Renderer.Clear();
                    string renderField = "progress";
                    AspMap.Feature feature;

                    //
                    feature = layer.Renderer.Add();
                    feature.Expression = "isnull(" + renderField + ") or " + renderField + "<0";
                    feature.Description = "No Value";
                    feature.Symbol.FillColor = Color.White;
                    feature.Symbol.LineColor = Color.Black;

                    //
                    feature = layer.Renderer.Add();
                    feature.Expression = renderField + ">=0 and " + renderField + "<60";
                    feature.Description = "0-60";
                    feature.Symbol.FillStyle = FillStyle.Solid;
                    feature.Symbol.FillColor = Color.FromArgb(255,0,0);
                    feature.Symbol.LineColor = Color.Black;
                    feature.Symbol.Size = 1;
                    //
                    feature = layer.Renderer.Add();
                    feature.Expression = renderField + ">=60 and " + renderField + "<70";
                    feature.Description = "60-70";
                    feature.Symbol.FillStyle = FillStyle.Solid;
                    feature.Symbol.FillColor = Color.FromArgb(255, 200, 0);
                    feature.Symbol.LineColor = Color.Black;
                    feature.Symbol.Size = 1;
                    //
                    feature = layer.Renderer.Add();
                    feature.Expression = renderField + ">=70 and " + renderField + "<80";
                    feature.Description = "70-80";
                    feature.Symbol.FillStyle = FillStyle.Solid;
                    feature.Symbol.FillColor = Color.FromArgb(182,255,143);
                    feature.Symbol.LineColor = Color.Black;
                    feature.Symbol.Size = 1;
                    //
                    feature = layer.Renderer.Add();
                    feature.Expression = renderField + ">=80 and " + renderField + "<90";
                    feature.Description = "80-90";
                    feature.Symbol.FillStyle = FillStyle.Solid;
                    feature.Symbol.FillColor = Color.FromArgb(51, 194, 255);
                    feature.Symbol.LineColor = Color.Black;
                    feature.Symbol.Size = 1;
                    //
                    feature = layer.Renderer.Add();
                    feature.Expression = renderField + ">=90";
                    feature.Description = "above or equal 90";
                    feature.Symbol.FillStyle = FillStyle.Solid;
                    feature.Symbol.FillColor = Color.FromArgb(0, 0, 255);
                    feature.Symbol.LineColor = Color.Black;
                    feature.Symbol.Size = 1;

                }

            }

        }
        labelMapLegend.Text= ma.RenderLegend(map);
        //GeoEvent geoEvent = new GeoEvent();
        ////geoEvent.Label = dRow["SiteName"].ToString();
        ////AspMap.Point pnt = new AspMap.Point(map.Extent.Center.X, map.Extent.Top);

        //// geoEvent1.Location = new AspMap.Point(map.Extent.Center.X + (map.Extent.Right - map.Extent.Center.X) / 4.0, map.Extent.Top - (map.Extent.Top - map.Extent.Bottom) / 100.0);
        //geoEvent.Location = new AspMap.Point(map.Extent.Center.X, map.Extent.Top - (map.Extent.Top - map.Extent.Bottom) / 100.0);
        ////AspMap.Point vv=map.FromMapPoint(geoEvent1.Location);

        ////InfoWindow info = new InfoWindow(geoEvent1.Location);
        ////info.Content = "Md. Kamal pasha";
        ////map.ShowInfoWindow(info);
        //Legend leg = new Legend();
        //leg.BackColor = Color.AliceBlue;
        //leg.ImageFormat = ImageFormat.Png;
        //leg.LegendFont.Name = "Arial";
        //leg.LegendFont.Size = 12;
        //leg.LegendFont.Bold = true;
        //leg.LegendFont.Quality = FontQuality.ClearType;
        //leg.Add("no site down at this moment");
        //geoEvent.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((byte[])leg.Image);


        //map.AnimationLayer.Add(geoEvent);
    }
    public void GetPhysicalTable( string indicatorCode,string indicatorName)
    {
        Table tbl = new Table();
        tbl.CssClass = "info-table table";
        tbl.Width = Unit.Percentage(90.0);
        tbl.CellPadding = 1;
        tbl.CellSpacing = 0;
        TableRow tr;
        TableCell tc;

        tr = new TableRow();
        //1-14 for heading row
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.ColumnSpan = 14;
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Information of " + indicatorName;
        tr.Cells.Add(tc);
        tbl.Rows.Add(tr);

        //for first row
        tr = new TableRow();
        //1
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Indicator";
        tc.RowSpan = 3;
        tr.Cells.Add(tc);
        //2
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Package No";
        tc.RowSpan = 3;
        tr.Cells.Add(tc);
        //3
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Polder No";
        tc.RowSpan = 3;
        tr.Cells.Add(tc);        
        //4
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Total Project Target";
        tc.RowSpan = 2;
        tr.Cells.Add(tc);
        //5
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Planned for the current FY";
        tc.RowSpan = 2;
        tr.Cells.Add(tc);
        //6-12
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Progress";
        tc.ColumnSpan= 7;
        tr.Cells.Add(tc);
        //12-14
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Achieved (%) against";
        tc.ColumnSpan = 2;
        tr.Cells.Add(tc);
        tbl.Rows.Add(tr);

        //2nd Row
        tr = new TableRow();
        //6
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Cumulative up to Last FY";
        tr.Cells.Add(tc);
        //7
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Q1 (Jul-Sep)";
        tr.Cells.Add(tc);
        tc = new TableCell();
        //8
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Q2 (Oct-Dec)";
        tr.Cells.Add(tc);
        //9
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Q3 (Jan-Mar)";
        tr.Cells.Add(tc);
        //10
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Q4 (Apr-Jun)";
        tr.Cells.Add(tc);
        //11
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "This FY, up to Current Q";
        tr.Cells.Add(tc);
        //12
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Cum from Inception";
        tr.Cells.Add(tc);
        //13
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Year’s Plan";
        tr.Cells.Add(tc);
        //14
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Project Target";
        tr.Cells.Add(tc);
        tbl.Rows.Add(tr);

        //3rd Row

        tr = new TableRow();
        //4
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Qty";
        tr.Cells.Add(tc);
        //5
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Qty";
        tr.Cells.Add(tc);
        //6
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Qty";
        tr.Cells.Add(tc);
        //7
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Qty";
        tr.Cells.Add(tc);
        //8
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Qty";
        tr.Cells.Add(tc);
        //9
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Qty";
        tr.Cells.Add(tc);
        //10
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Qty";
        tr.Cells.Add(tc);
        //11
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Qty";
        tr.Cells.Add(tc);
        //12
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "Qty";
        tr.Cells.Add(tc);
        //13
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "%";
        tr.Cells.Add(tc);
        //14        
        tc = new TableCell();
        tc.CssClass = "table-row-head";
        tc.HorizontalAlign = HorizontalAlign.Center;
        tc.VerticalAlign = VerticalAlign.Middle;
        tc.Text = "%";
        tr.Cells.Add(tc);
        tbl.Rows.Add(tr);

        StringBuilder sb = new StringBuilder();
        sb.Append("select package_no,polder_no,coalesce(sum(target_value),0) target_value,coalesce(sum(progress_value),0) progress_value");
        sb.Append(",coalesce(sum(projection_value),0) projection_value,sum(q1) q1,sum(q2) q2,sum(q3) q3,sum(q4) q4");
        sb.Append(" from ");
        sb.Append("(select package_no,polder_no,indicator_code,progress_year,progress_quarter,target_value,progress_value,projection_value,");
        sb.Append("case when progress_quarter='Q1' then progress_value else 0 end as q1,");
        sb.Append("case when progress_quarter='Q2' then progress_value else 0 end as q2,");
        sb.Append("case when progress_quarter='Q3' then progress_value else 0 end as q3,");
        sb.Append("case when progress_quarter='Q4' then progress_value else 0 end as q4");
        sb.Append(" from indicator_progress where ");
        sb.Append("progress_year='");
        sb.Append(ddlCurrentYear.SelectedValue);
        sb.Append("' and indicator_code='");
        sb.Append(indicatorCode);
        sb.Append("') as b");
        sb.Append(" group by package_no,polder_no");


        //sb.Append("select * from crosstab($$");
        //sb.Append("select package_no||polder_no||indicator_code||progress_year||");
        //sb.Append("progress_quarter as code,");
        //sb.Append("package_no,polder_no,indicator_code,progress_year,");
        //sb.Append("progress_quarter,sum(progress_value) as progress_value");
        //sb.Append(" from indicator_progress where progress_year='");
        //sb.Append(ddlCurrentYear.SelectedValue);
        //sb.Append("' and indicator_code='");
        //sb.Append(indicatorCode);
        //sb.Append("'");
        //sb.Append(" group by code,package_no,polder_no,indicator_code,progress_year,progress_quarter order by package_no,polder_no,");
        //sb.Append("indicator_code,progress_year,progress_quarter$$,$$select 'Q'||m from generate_series(1,4) m$$)");
        //sb.Append(" as ct (code text, package_no text,polder_no text,indicator_code text,progress_year text,");
        //sb.Append("\"Q1\" numeric,\"Q2\" numeric,\"Q3\" numeric,\"Q4\" numeric)");
       
        DataTable table=dba.GetDataTable(sb.ToString());

        if (table != null && table.Rows.Count > 0)
        {
            foreach (DataRow dRow in table.Rows)
            {
                tr = new TableRow();
                double totalProjectPlanned = 0.0;
                double totalCurrentYear = 0.0;
                double totalCurrentPlanned = 0.0;
                double totalPreviousYear = 0.0;
                string value = string.Empty;
                //1-for indicator name
                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = indicatorName;
                tr.Cells.Add(tc);
                //2-for package no
                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = dRow["package_no"].ToString();
                tr.Cells.Add(tc);
                //3-for polder no
                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                tc.Text = dRow["polder_no"].ToString();
                tr.Cells.Add(tc);
                //4-for project target
                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                //value = dRow["target_value"].ToString();
                value = dba.GetFieldValue("select sum(target_value) from indicator_progress where indicator_code='" + indicatorCode + "'");
                if (string.IsNullOrEmpty(value))
                {
                    tc.Text = "-";
                    totalProjectPlanned = totalProjectPlanned + 0.0;
                }
                else
                {
                    tc.Text = value;
                    totalProjectPlanned = totalProjectPlanned + double.Parse(value);
                }
                tr.Cells.Add(tc);
                //5-for Planned for the current FY
                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                value = dRow["target_value"].ToString();
                //value = dba.GetFieldValue("select sum(target_value) from indicator_target where indicator_code='" + HiddenIndicatorCode.Value + "' and target_year='" + ddlCurrentYear.SelectedValue + "'");
                if (string.IsNullOrEmpty(value))
                {
                    tc.Text = "-";
                    totalCurrentPlanned = totalCurrentPlanned + 0.0;
                }
                else
                {
                    tc.Text = value;
                    totalCurrentPlanned = totalCurrentPlanned + double.Parse(value);
                }
                tr.Cells.Add(tc);
                //6-for Cumulative up to Last FY
                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                //string sql = "select sum(progress_value) from indicator_progress where indicator_code='" + indicatorCode + "' and progress_date<='30-Jun-" + ddlCurrentYear.SelectedValue.Substring(0, 4) + "'";
                value = dba.GetFieldValue("select sum(progress_value) from indicator_progress where indicator_code='" + indicatorCode + "' and progress_date<='30-Jun-" + ddlCurrentYear.SelectedValue.Substring(0, 4) + "'");
                if (string.IsNullOrEmpty(value))
                {
                    tc.Text = "-";
                    totalPreviousYear = totalPreviousYear + 0.0;
                }
                else
                {
                    tc.Text = value;
                    totalPreviousYear = totalPreviousYear + double.Parse(value);
                }
                tr.Cells.Add(tc);
                //7-for Q1
                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                value = dRow["q1"].ToString();
                if (string.IsNullOrEmpty(value))
                {
                    tc.Text = "-";
                    totalCurrentYear = totalCurrentYear + 0.0;
                }
                else
                {
                    tc.Text = value;
                    totalCurrentYear = totalCurrentYear + double.Parse(value);
                }
                tr.Cells.Add(tc);
                //8-for Q2
                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                value = dRow["q2"].ToString();
                if (string.IsNullOrEmpty(value))
                {
                    tc.Text = "-";
                    totalCurrentYear = totalCurrentYear + 0.0;
                }
                else
                {
                    tc.Text = value;
                    totalCurrentYear = totalCurrentYear + double.Parse(value);
                }
                tr.Cells.Add(tc);
                //9-for Q3
                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                value = dRow["q3"].ToString();
                if (string.IsNullOrEmpty(value))
                {
                    tc.Text = "-";
                    totalCurrentYear = totalCurrentYear + 0.0;
                }
                else
                {
                    tc.Text = value;
                    totalCurrentYear = totalCurrentYear + double.Parse(value);
                }
                tr.Cells.Add(tc);
                //10-for Q4
                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                value = dRow["q4"].ToString();
                if (string.IsNullOrEmpty(value))
                {
                    tc.Text = "-";
                    totalCurrentYear = totalCurrentYear + 0.0;
                }
                else
                {
                    tc.Text = value;
                    totalCurrentYear = totalCurrentYear + double.Parse(value);
                }
                tr.Cells.Add(tc);
                //11-for This FY, up to Current Q
                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                if (totalCurrentYear > 0.0)
                    tc.Text = totalCurrentYear.ToString();
                else
                    tc.Text = "-";
                tr.Cells.Add(tc);
                //12-Cum from Inception
                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                if ((totalCurrentYear + totalPreviousYear) > 0.0)
                    tc.Text = (totalCurrentYear + totalPreviousYear).ToString();
                else
                    tc.Text = "-";
                tr.Cells.Add(tc);
                //13-for Year’s Plan
                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                if (totalCurrentPlanned > 0.0)
                    tc.Text = (Math.Round((totalCurrentYear / totalCurrentPlanned)*100.0,2)).ToString();
                else
                    tc.Text = "-";
                tr.Cells.Add(tc);
                //14-for Project Target
                tc = new TableCell();
                tc.CssClass = "table-cell";
                tc.HorizontalAlign = HorizontalAlign.Center;
                tc.VerticalAlign = VerticalAlign.Middle;
                if (totalProjectPlanned > 0.0)
                    tc.Text = (Math.Round(((totalCurrentYear + totalPreviousYear) / totalProjectPlanned)*100.0,2)).ToString();
                else
                    tc.Text = "-";
                tr.Cells.Add(tc);

                tbl.Rows.Add(tr);
            }

           

        }




        StringWriter sw = new StringWriter();
        tbl.RenderControl(new HtmlTextWriter(sw));
        labelTable.Text = sw.ToString();
    }

    protected void btnRefreshData_Click(object sender, EventArgs e)
    {
        GetPhysicalTable(HiddenIndicatorCode.Value, HiddenIndicatorName.Value);
        AddMap();
        AddChart();
    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {
        HiddenIndicatorCode.Value = e.Item.Value;
        HiddenIndicatorName.Value = e.Item.Text;
        
        AddMap();
        AddChart();
    }

    protected void ddlCurrentYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetPhysicalTable(HiddenIndicatorCode.Value, HiddenIndicatorName.Value);
        AddMap();
        AddChart();
    }
}