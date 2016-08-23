using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Globalization;
using System.Data.OleDb;


/// <summary>
/// Summary description for BOQClass
/// </summary>
public class BOQClass
{
    public BOQClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool BillItemInsert(DataBillItem dataKey)
    {
        bool retVal = false;
        NpgsqlConnection cnn = new NpgsqlConnection(UtilityClass.ConnectionString());
        NpgsqlCommand cmd = new NpgsqlCommand();
        try
        {
            cmd.Connection = cnn;
            cmd.CommandText =
                "insert into boq_item (polder_no, bill_no, item_no, bill_date, quantity, comments, entry_user, entry_date) values (:polder_no, :bill_no, :item_no, :bill_date, :quantity, :comments, :entry_user, :entry_date)";
            cmd.Parameters.Add("polder_no", NpgsqlDbType.Varchar).Value = dataKey.polder_no;
            cmd.Parameters.Add("bill_no", NpgsqlDbType.Varchar).Value = dataKey.bill_no;
            cmd.Parameters.Add("item_no", NpgsqlDbType.Varchar).Value = dataKey.item_no;
            cmd.Parameters.Add("bill_date", NpgsqlDbType.Date).Value = dataKey.bill_date;
            cmd.Parameters.Add("quantity", NpgsqlDbType.Numeric).Value = dataKey.quantity;
            cmd.Parameters.Add("comments", NpgsqlDbType.Varchar).Value = dataKey.comments;
            cmd.Parameters.Add("entry_user", NpgsqlDbType.Varchar).Value = dataKey.entry_user;
            cmd.Parameters.Add("entry_date", NpgsqlDbType.Timestamp).Value = dataKey.entry_date;

            //if (string.IsNullOrEmpty(plot.approv_reject_date))
            //{
            //    cmd.Parameters.Add("approv_reject_date", NpgsqlDbType.Date).Value = DBNull.Value;
            //}
            //else
            //{
            //    cmd.Parameters.Add("approv_reject_date", NpgsqlDbType.Date).Value = DateTime.ParseExact(plot.approv_reject_date, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
            //}
            //cmd.Parameters.Add("prop_occupency_type", NpgsqlDbType.Varchar).Value = plot.prop_occupency_type;
            //cmd.Parameters.Add("prop_road_width", NpgsqlDbType.Varchar).Value = plot.prop_road_width;
            //cmd.Parameters.Add("lspp_condition", NpgsqlDbType.Varchar).Value = plot.lspp_condition;
            //cmd.Parameters.Add("lspp_reason", NpgsqlDbType.Varchar).Value = plot.lspp_reason;
            //cmd.Parameters.Add("others_info", NpgsqlDbType.Varchar).Value = plot.others_info;
            //cmd.Parameters.Add("last_update_user", NpgsqlDbType.Varchar).Value = plot.last_update_user;
            //cmd.Parameters.Add("last_update_date", NpgsqlDbType.Timestamp).Value = plot.last_update_date;
            cnn.Open();
            cmd.ExecuteNonQuery();
            retVal = true;
        }
        catch (Exception ex)
        {
            retVal = false;
        }
        finally
        {
            cmd.Dispose();
            cnn.Close();
            cnn.Dispose();
        }
        return retVal;
    }
}