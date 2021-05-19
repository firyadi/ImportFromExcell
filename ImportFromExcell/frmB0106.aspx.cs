using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ImportFromExcell
{
    public partial class FormB0106 : System.Web.UI.Page
    {
        protected void PasteToGridView(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[10] {
                    new DataColumn("AsOfDate", typeof(DateTime)),
                    new DataColumn("AcctNo", typeof(string)),
                    new DataColumn("AcctName",typeof(string)),
                    new DataColumn("InstrumentCd", typeof(string)),
                    new DataColumn("ISINCd", typeof(string)),
                    new DataColumn("InstrumentName",typeof(string)),
                    new DataColumn("CpartyAcctNo", typeof(string)),
                    new DataColumn("TotalQty", typeof(float)),
                    new DataColumn("SettledQty",typeof(float)),
                    new DataColumn("UnsettledQty", typeof(float))

            });

            int len = txtCopied.Text.Length;
            if (len < 200)
            {
                txtCopied.Text = "";
                lblMsg.Text = "";
            }
            else
            {
                string copiedContent = Request.Form[txtCopied.UniqueID];
                foreach (string row in copiedContent.Split('\n'))
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            dt.Rows.Add();
                            int i = 0;
                            foreach (string cell in row.Split('\t'))
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = cell;
                                i++;
                            }
                        }
                    }

                    catch (Exception er)
                    {
                        lblMsg.Text = "Reading Exception" + er;
                    }
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
                txtCopied.Text = "";
            }

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[10] {
                    new DataColumn("AsOfDate", typeof(DateTime)),
                    new DataColumn("AcctNo", typeof(string)),
                    new DataColumn("AcctName",typeof(string)),
                    new DataColumn("InstrumentCd", typeof(string)),
                    new DataColumn("ISINCd", typeof(string)),
                    new DataColumn("InstrumentName",typeof(string)),
                    new DataColumn("CpartyAcctNo", typeof(string)),
                    new DataColumn("TotalQty", typeof(float)),
                    new DataColumn("SettledQty",typeof(float)),
                    new DataColumn("UnsettledQty", typeof(float))
                  });

            foreach (GridViewRow row in GridView1.Rows)
            {
                DateTime AsOfDate = DateTime.Parse(row.Cells[0].Text);
                string AcctNo = row.Cells[1].Text;
                string AcctName = row.Cells[2].Text;
                string InstrumentCd = row.Cells[3].Text;
                string ISINCd = row.Cells[4].Text;
                string InstrumentName = row.Cells[5].Text;
                string CpartyAcctNo = row.Cells[6].Text;
                string TotalQty = row.Cells[7].Text;
                string SettledQty = row.Cells[8].Text;
                string UnsettledQty = row.Cells[9].Text;


                dt.Rows.Add(AsOfDate, AcctNo, AcctName, InstrumentCd, ISINCd, InstrumentName, CpartyAcctNo, TotalQty, SettledQty, UnsettledQty);
            }
            if (dt.Rows.Count > 0)
            {
                string consString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {

                    string s = "Truncate Table recon.tb_phillipholding";
                    SqlCommand Com = new SqlCommand(s, con);
                    con.Open();
                    Com.ExecuteNonQuery();
                    con.Close();


                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "recon.tb_phillipholding";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("AsOfDate", "[AsOfDate]");
                        sqlBulkCopy.ColumnMappings.Add("AcctNo", "[Acct No]");
                        sqlBulkCopy.ColumnMappings.Add("AcctName", "[Acct Name]");
                        sqlBulkCopy.ColumnMappings.Add("InstrumentCd", "[InstrumentCd]");
                        sqlBulkCopy.ColumnMappings.Add("ISINCd", "[ISINCd]");
                        sqlBulkCopy.ColumnMappings.Add("InstrumentName", "[Instrument Name]");
                        sqlBulkCopy.ColumnMappings.Add("CpartyAcctNo", "[Cparty Acct No]");
                        sqlBulkCopy.ColumnMappings.Add("TotalQty", "[Total Qty]");
                        sqlBulkCopy.ColumnMappings.Add("SettledQty", "[Settled Qty]");
                        sqlBulkCopy.ColumnMappings.Add("UnsettledQty", "[Unsettled Qty]");
                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }

                    lblMsg.Text = "Details Inserted Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
            }
        }
    }

    
}