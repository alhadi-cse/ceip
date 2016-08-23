using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using System.Globalization;

public partial class BoqReport : System.Web.UI.Page
{
    DbAdmin dba = new DbAdmin();
    BOQClass boq = new BOQClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Session["ReturnUrl"] = "BoqReport.aspx";
            Response.Redirect("LoginUser.aspx");
        }
        if (!IsPostBack)
        {
            dba.LoadDropDownList("select distinct polder_no from boq_info order by polder_no", ddlPolderNo, "polder_no", "polder_no", "---select polder---", true);
            ddlBillNo.Items.Add(new ListItem("---select bill no---", "-1"));
        }
    }
    protected void ddlPolderNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBillNo.Items.Count > 0)
            ddlBillNo.Items.Clear();
        //if (ddlItemNo.Items.Count > 0)
        //    ddlItemNo.Items.Clear();
        if (ddlPolderNo.SelectedValue.Equals("-1"))
        {
            ddlBillNo.Items.Add(new ListItem("---select bill no---", "-1"));
        }
        else
        {
            dba.LoadDropDownList("select distinct bill_no from boq_info where polder_no='" + ddlPolderNo.SelectedValue + "' order by bill_no", ddlBillNo, "bill_no", "bill_no", "---select bill no---", true);
        }
        //ddlItemNo.Items.Add(new ListItem("---select bill item---", "-1"));


    }
    protected void ddlBillNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlItemNo.Items.Count > 0)
        //    ddlItemNo.Items.Clear();
        //if (ddlBillNo.SelectedValue.Equals("-1"))
        //{
        //    ddlItemNo.Items.Add(new ListItem("---select bill item---", "-1"));
        //}
        //else
        //{
        //    dba.LoadDropDownList("select distinct item_no from boq_info where polder_no='" + ddlPolderNo.SelectedValue + "' and bill_no='" + ddlBillNo.SelectedValue + "' order by item_no", ddlItemNo, "item_no", "item_no", "---select bill item---", true);
        //}
    }
    protected void btnRefreshData_Click(object sender, EventArgs e)
    {
        string[] str = CreateChart();
        Literal2.Text = str[0];
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax2", str[1], false); 

    }

    private string[] CreateChart()
    {
        string[] retVal = new string[2];
        DotNet.Highcharts.Highcharts chart = new DotNet.Highcharts.Highcharts("chart")
        .InitChart(new DotNet.Highcharts.Options.Chart { Height = 500, DefaultSeriesType = DotNet.Highcharts.Enums.ChartTypes.Bar })
        .SetXAxis(new XAxis
        {
            Categories = new[] { "6.01", "6.02", "6.03", "6.04", "6.05", "6.06", "6.07" }
        })
        .SetTitle(new Title { Text = "Progress" })
        .SetSubtitle(new Subtitle { Text = ""})
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
}