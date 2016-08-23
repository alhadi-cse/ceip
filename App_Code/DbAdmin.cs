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
/// Summary description for DbAdmin
/// </summary>


public class DbAdmin
{
    public DbAdmin()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetDataTable(string sql)
    {
        NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, UtilityClass.ConnectionString());
        DataTable dt = new DataTable();
        try
        {
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            var err = ex.Message;
            dt = null;
        }
        finally
        {
            da.Dispose();
        }
        return dt;
    }

    public string GetFieldValue(string sql)
    {
        string retValue;

        using (NpgsqlConnection connection = new NpgsqlConnection(UtilityClass.ConnectionString()))
        {
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            try
            {
                retValue = Convert.ToString(command.ExecuteScalar());
                if (string.IsNullOrEmpty(retValue))
                    retValue = string.Empty;
            }
            catch
            {
                retValue = string.Empty;
            }
            command.Dispose();
        }
        return retValue;
    }

    public void LoadDropDownList(string sql, DropDownList ddl, string textField, string valueField, string text, bool isAll)
    {

        if (ddl.Items.Count > 0)
            ddl.Items.Clear();

        ListItem lst;

        if (isAll)
        {
            lst = new ListItem {Text = text, Value = "-1"};
            ddl.Items.Add(lst);
        }

        DataTable dt = GetDataTable(sql);
        if (dt != null && dt.Rows.Count > 0)
        {
            foreach (DataRow row in dt.Rows)
            {
                lst = new ListItem {Text = row[textField].ToString(), Value = row[valueField].ToString()};
                ddl.Items.Add(lst);
            }
        }


        if (ddl.Items.Count > 0)
            ddl.SelectedIndex = 0;
    }

    public bool ProgressAvailable(DataProgress dataKey)
    {
        bool retVal = false;
        NpgsqlConnection cnn = new NpgsqlConnection(UtilityClass.ConnectionString());
        NpgsqlCommand cmd = new NpgsqlCommand();
        try
        {
            cmd.Connection = cnn;
            cmd.CommandText =
                "select count(*) from indicator_progress where package_no=:package_no and polder_no=:polder_no and indicator_code=:indicator_code and progress_year=:progress_year and progress_quarter=:progress_quarter";
            cmd.Parameters.Add("package_no", NpgsqlDbType.Varchar).Value = dataKey.PackageNo;
            cmd.Parameters.Add("polder_no", NpgsqlDbType.Varchar).Value = dataKey.PolderNo;
            cmd.Parameters.Add("indicator_code", NpgsqlDbType.Varchar).Value = dataKey.IndicatorCode;
            cmd.Parameters.Add("progress_year", NpgsqlDbType.Varchar).Value = dataKey.ProgressYear;
            cmd.Parameters.Add("progress_quarter", NpgsqlDbType.Varchar).Value = dataKey.ProgressQuarter;
            cnn.Open();
            retVal = !cmd.ExecuteScalar().ToString().Equals("0");
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

    public bool ProgressInsert(DataProgress dataKey)
    {
        bool retVal = false;
        NpgsqlConnection cnn = new NpgsqlConnection(UtilityClass.ConnectionString());
        NpgsqlCommand cmd = new NpgsqlCommand();
        try
        {
            cmd.Connection = cnn;
            cmd.CommandText =
                "insert into indicator_progress (package_no,polder_no,indicator_code,progress_year,progress_quarter,progress_date,target_value,progress_value,projection_value,remarks,entry_date,entry_user) values (:package_no,:polder_no,:indicator_code,:progress_year,:progress_quarter,:progress_date,:target_value,:progress_value,:projection_value,:remarks,:entry_date,:entry_user)";
            cmd.Parameters.Add("package_no", NpgsqlDbType.Varchar).Value = dataKey.PackageNo;
            cmd.Parameters.Add("polder_no", NpgsqlDbType.Varchar).Value = dataKey.PolderNo;
            cmd.Parameters.Add("indicator_code", NpgsqlDbType.Varchar).Value = dataKey.IndicatorCode;
            cmd.Parameters.Add("progress_year", NpgsqlDbType.Varchar).Value = dataKey.ProgressYear;
            cmd.Parameters.Add("progress_quarter", NpgsqlDbType.Varchar).Value = dataKey.ProgressQuarter;
            cmd.Parameters.Add("progress_date", NpgsqlDbType.Date).Value = dataKey.ProgressDate;
            cmd.Parameters.Add("target_value", NpgsqlDbType.Numeric).Value = dataKey.TargetValue;
            cmd.Parameters.Add("progress_value", NpgsqlDbType.Numeric).Value = dataKey.ProgressValue;
            cmd.Parameters.Add("projection_value", NpgsqlDbType.Numeric).Value = dataKey.ProjectionValue;
            cmd.Parameters.Add("remarks", NpgsqlDbType.Varchar).Value = dataKey.Remarks;
            cmd.Parameters.Add("entry_date", NpgsqlDbType.Timestamp).Value = dataKey.EntryDate;
            cmd.Parameters.Add("entry_user", NpgsqlDbType.Varchar).Value = dataKey.EntryUser;

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

    public bool ProgressUpdate(DataProgress dataKey)
    {
        bool retVal = false;
        NpgsqlConnection cnn = new NpgsqlConnection(UtilityClass.ConnectionString());
        NpgsqlCommand cmd = new NpgsqlCommand();
        try
        {
            cmd.Connection = cnn;
            cmd.CommandText =
                "update indicator_progress set target_value=:target_value,progress_value=:progress_value,projection_value=:projection_value where package_no=:package_no and polder_no=:polder_no and indicator_code=:indicator_code and progress_year=:progress_year and progress_quarter=:progress_quarter";
            cmd.Parameters.Add("target_value", NpgsqlDbType.Numeric).Value = dataKey.TargetValue;
            cmd.Parameters.Add("progress_value", NpgsqlDbType.Numeric).Value = dataKey.ProgressValue;
            cmd.Parameters.Add("projection_value", NpgsqlDbType.Numeric).Value = dataKey.ProjectionValue;
            cmd.Parameters.Add("package_no", NpgsqlDbType.Varchar).Value = dataKey.PackageNo;
            cmd.Parameters.Add("polder_no", NpgsqlDbType.Varchar).Value = dataKey.PolderNo;
            cmd.Parameters.Add("indicator_code", NpgsqlDbType.Varchar).Value = dataKey.IndicatorCode;
            cmd.Parameters.Add("progress_year", NpgsqlDbType.Varchar).Value = dataKey.ProgressYear;
            cmd.Parameters.Add("progress_quarter", NpgsqlDbType.Varchar).Value = dataKey.ProgressQuarter;
            //cmd.Parameters.Add("entry_date", NpgsqlDbType.Timestamp).Value = dataKey.EntryDate;
            //cmd.Parameters.Add("entry_user", NpgsqlDbType.Varchar).Value = dataKey.EntryUser;

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

    public bool ProgressDelete(DataProgress dataKey)
    {
        bool retVal = false;
        NpgsqlConnection cnn = new NpgsqlConnection(UtilityClass.ConnectionString());
        NpgsqlCommand cmd = new NpgsqlCommand();
        try
        {
            cmd.Connection = cnn;
            cmd.CommandText =
                "delete from indicator_progress where package_no=:package_no and polder_no=:polder_no and indicator_code=:indicator_code and progress_year=:progress_year and progress_quarter=:progress_quarter";
            cmd.Parameters.Add("package_no", NpgsqlDbType.Varchar).Value = dataKey.PackageNo;
            cmd.Parameters.Add("polder_no", NpgsqlDbType.Varchar).Value = dataKey.PolderNo;
            cmd.Parameters.Add("indicator_code", NpgsqlDbType.Varchar).Value = dataKey.IndicatorCode;
            cmd.Parameters.Add("progress_year", NpgsqlDbType.Varchar).Value = dataKey.ProgressYear;
            cmd.Parameters.Add("progress_quarter", NpgsqlDbType.Varchar).Value = dataKey.ProgressQuarter;
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

    public bool TargetInsert(DataTarget dataKey)
    {
        bool retVal = false;
        NpgsqlConnection cnn = new NpgsqlConnection(UtilityClass.ConnectionString());
        NpgsqlCommand cmd = new NpgsqlCommand();
        try
        {
            cmd.Connection = cnn;
            cmd.CommandText =
                "insert into indicator_target (package_no,polder_no,indicator_code,target_year,target_quarter,target_value,remarks,entry_date,entry_user) values (:package_no,:polder_no,:indicator_code,:target_year,:target_quarter,:target_value,:remarks,:entry_date,:entry_user)";
            cmd.Parameters.Add("package_no", NpgsqlDbType.Varchar).Value = dataKey.PackageNo;
            cmd.Parameters.Add("polder_no", NpgsqlDbType.Varchar).Value = dataKey.PolderNo;
            cmd.Parameters.Add("indicator_code", NpgsqlDbType.Varchar).Value = dataKey.IndicatorCode;
            cmd.Parameters.Add("target_year", NpgsqlDbType.Varchar).Value = dataKey.TargetYear;
            cmd.Parameters.Add("target_quarter", NpgsqlDbType.Varchar).Value = dataKey.TargetQuarter;
            cmd.Parameters.Add("target_value", NpgsqlDbType.Numeric).Value = dataKey.TargetValue;
            cmd.Parameters.Add("remarks", NpgsqlDbType.Varchar).Value = dataKey.Remarks;
            cmd.Parameters.Add("entry_date", NpgsqlDbType.Timestamp).Value = dataKey.EntryDate;
            cmd.Parameters.Add("entry_user", NpgsqlDbType.Varchar).Value = dataKey.EntryUser;

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


    public DateTime? CheckDateFormat(string strDate, string dateFormat = "dd-MMM-yyyy")
    {
        if (string.IsNullOrEmpty(strDate.Trim())) return null;

        DateTime outDate;

        dateFormat = string.IsNullOrEmpty(dateFormat) ? "dd-MMM-yyyy" : dateFormat;

        if (DateTime.TryParseExact(strDate, dateFormat, CultureInfo.InvariantCulture,
            DateTimeStyles.AdjustToUniversal, out outDate))
            return outDate;

        return null;
    }

    public bool QualityMilestoneInsert(QualityMilestone qtyMilestone)
    {
        bool retVal = false;
        NpgsqlConnection cnn = new NpgsqlConnection(UtilityClass.ConnectionString());
        NpgsqlCommand cmd = new NpgsqlCommand();
        try
        {
            StringBuilder sbSql = new StringBuilder();

            sbSql.Append("insert into tbl_engg_construction_quality_milestone (package_no, qty_milestone_year_id, qty_milestone_quarter_id, ");
            sbSql.Append("qty_control_manual_draft_date, qty_control_manual_final_date, final_handover_punchlist_date, punchlist_satisfied_date, ");
            sbSql.Append("remark_control_manual_draft, remark_control_manual_final, remark_final_handover_punchlist, remark_punchlist_satisfied, ");
            sbSql.Append("entry_date, entry_user) ");
            sbSql.Append("values (:package_no, :qty_milestone_year_id, :qty_milestone_quarter_id, ");
            sbSql.Append(":qty_control_manual_draft_date, :qty_control_manual_final_date, :final_handover_punchlist_date, :punchlist_satisfied_date, ");
            sbSql.Append(":remark_control_manual_draft, :remark_control_manual_final, :remark_final_handover_punchlist, :remark_punchlist_satisfied, ");
            sbSql.Append(":entry_date, :entry_user)");

            cmd.Connection = cnn;
            cmd.CommandText = sbSql.ToString();

            //"insert into tbl_engg_construction_quality_milestone (package_no, qty_milestone_year_id, qty_milestone_quarter_id, " +
            //"qty_control_manual_draft_date, qty_control_manual_final_date, final_handover_punchlist_date, punchlist_satisfied_date, " +
            //"remark_control_manual_draft, remark_control_manual_final, remark_final_handover_punchlist, remark_punchlist_satisfied, " +
            //"entry_date, entry_user) " +
            //"values (:package_no, :qty_milestone_year_id, :qty_milestone_quarter_id, " +
            //":qty_control_manual_draft_date, :qty_control_manual_final_date, :final_handover_punchlist_date, :punchlist_satisfied_date, " +
            //":remark_control_manual_draft, :remark_control_manual_final, :remark_final_handover_punchlist, :remark_punchlist_satisfied, " +
            //":entry_date, :entry_user)";

            cmd.Parameters.Add("package_no", NpgsqlDbType.Varchar).Value = qtyMilestone.PackageNo;
            cmd.Parameters.Add("qty_milestone_year_id", NpgsqlDbType.Varchar).Value = qtyMilestone.QtyMilestoneYear;
            cmd.Parameters.Add("qty_milestone_quarter_id", NpgsqlDbType.Varchar).Value =
                qtyMilestone.QtyMilestoneQuarter;

            cmd.Parameters.Add("qty_control_manual_draft_date", NpgsqlDbType.Date).Value =
                (object) qtyMilestone.QtyControlManualDraftDate ?? DBNull.Value;
            cmd.Parameters.Add("qty_control_manual_final_date", NpgsqlDbType.Date).Value =
                (object) qtyMilestone.QtyControlManualFinalDate ?? DBNull.Value;
            cmd.Parameters.Add("final_handover_punchlist_date", NpgsqlDbType.Date).Value =
                (object) qtyMilestone.FinalHandoverPunchlistDate ?? DBNull.Value;
            cmd.Parameters.Add("punchlist_satisfied_date", NpgsqlDbType.Date).Value =
                (object) qtyMilestone.PunchlistSatisfiedDate ?? DBNull.Value;


            cmd.Parameters.Add("remark_control_manual_draft", NpgsqlDbType.Varchar).Value =
                qtyMilestone.RemarkControlManualDraft;
            cmd.Parameters.Add("remark_control_manual_final", NpgsqlDbType.Varchar).Value =
                qtyMilestone.RemarkControlManualFinal;
            cmd.Parameters.Add("remark_final_handover_punchlist", NpgsqlDbType.Varchar).Value =
                qtyMilestone.RemarkFinalHandoverPunchlist;
            cmd.Parameters.Add("remark_punchlist_satisfied", NpgsqlDbType.Varchar).Value =
                qtyMilestone.RemarkPunchlistSatisfied;

            cmd.Parameters.Add("entry_date", NpgsqlDbType.Timestamp).Value =
                (object) qtyMilestone.EntryDate ?? DBNull.Value;
            cmd.Parameters.Add("entry_user", NpgsqlDbType.Varchar).Value = qtyMilestone.EntryUser;

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