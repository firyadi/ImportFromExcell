using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ImportFromExcell.Pages
{
    public partial class frmPci : System.Web.UI.Page
    {
        protected void PasteToGridView(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[17] {
                    new DataColumn("EODDate", typeof(DateTime)),
                    new DataColumn("AccountNumber", typeof(string)),
                    new DataColumn("CCY",typeof(string)),
                    new DataColumn("SDQty", typeof(string)),
                    new DataColumn("AcctTypeDesc", typeof(string)),
                    new DataColumn("TDQty",typeof(string)),
                    new DataColumn("ClosingPrice", typeof(string)),
                    new DataColumn("SDMktValue", typeof(float)),
                    new DataColumn("CUSIP",typeof(string)),
                    new DataColumn("SYMBOL", typeof(string)),
                    new DataColumn("ISIN", typeof(string)),
                    new DataColumn("StaleInd",typeof(string)),
                    new DataColumn("ClosingPriceDate", typeof(DateTime)),
                    new DataColumn("TDMktValue", typeof(float)),
                    new DataColumn("ListedMarket",typeof(string)),
                    new DataColumn("SecurityType", typeof(string)),
                    new DataColumn("SecurityDescription",typeof(string))

            });

            ClearNotification();
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

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[17]
                  { new DataColumn("EODDate", typeof(DateTime)),
                    new DataColumn("AccountNumber", typeof(string)),
                    new DataColumn("CCY",typeof(string)),
                    new DataColumn("SDQty", typeof(string)),
                    new DataColumn("AcctTypeDesc", typeof(string)),
                    new DataColumn("TDQty",typeof(string)),
                    new DataColumn("ClosingPrice", typeof(string)),
                    new DataColumn("SDMktValue", typeof(string)),
                    new DataColumn("CUSIP",typeof(string)),
                    new DataColumn("SYMBOL", typeof(string)),
                    new DataColumn("ISIN", typeof(string)),
                    new DataColumn("StaleInd",typeof(string)),
                    new DataColumn("ClosingPriceDate", typeof(DateTime)),
                    new DataColumn("TDMktValue", typeof(string)),
                    new DataColumn("ListedMarket",typeof(string)),
                    new DataColumn("SecurityType", typeof(string)),
                    new DataColumn("SecurityDescription",typeof(string))
                  });

            foreach (GridViewRow row in GridView1.Rows)
            {
                DateTime EODDate = DateTime.Parse(row.Cells[0].Text);
                string AccountNumber = row.Cells[1].Text;
                string CCY = row.Cells[2].Text;
                string SDQty = row.Cells[3].Text;
                string AcctTypeDesc = row.Cells[4].Text;
                string TDQty = row.Cells[5].Text;
                string ClosingPrice = row.Cells[6].Text;
                string SDMktValue = row.Cells[7].Text;
                string CUSIP = row.Cells[8].Text;
                string SYMBOL = row.Cells[9].Text.Replace("&nbsp;", "");
                string ISIN = row.Cells[10].Text;
                string StaleInd = row.Cells[11].Text;
                DateTime ClosingPriceDate = DateTime.Parse(row.Cells[12].Text);
                string TDMktValue = row.Cells[13].Text;
                string ListedMarket = row.Cells[14].Text.Replace("&nbsp;", "");
                string SecurityType = row.Cells[15].Text.Replace("&nbsp;", "");
                string SecurityDescription = row.Cells[16].Text.Replace("&nbsp;", "");


                dt.Rows.Add(EODDate, AccountNumber, CCY, SDQty, AcctTypeDesc, TDQty, ClosingPrice, SDMktValue, CUSIP, SYMBOL, ISIN, StaleInd, ClosingPriceDate, TDMktValue, ListedMarket, SecurityType, SecurityDescription);
            }
            if (dt.Rows.Count > 0)
            {
                string consString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {

                    string s = "Truncate Table recon.tb_cpholding";
                    SqlCommand Com = new SqlCommand(s, con);
                    con.Open();
                    Com.ExecuteNonQuery();
                    con.Close();


                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "recon.tb_cpholding";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("EODDate", "[EOD Date]");
                        sqlBulkCopy.ColumnMappings.Add("AccountNumber", "[Account Number]");
                        sqlBulkCopy.ColumnMappings.Add("CCY", "[CCY]");
                        sqlBulkCopy.ColumnMappings.Add("SDQty", "[SD Qty]");
                        sqlBulkCopy.ColumnMappings.Add("AcctTypeDesc", "[Acct Type Desc]");
                        sqlBulkCopy.ColumnMappings.Add("TDQty", "[TD Qty]");
                        sqlBulkCopy.ColumnMappings.Add("ClosingPrice", "[Closing Price]");
                        sqlBulkCopy.ColumnMappings.Add("SDMktValue", "[SD Mkt Value]");
                        sqlBulkCopy.ColumnMappings.Add("CUSIP", "[CUSIP]");
                        sqlBulkCopy.ColumnMappings.Add("SYMBOL", "[SYMBOL]");
                        sqlBulkCopy.ColumnMappings.Add("ISIN", "[ISIN]");
                        sqlBulkCopy.ColumnMappings.Add("StaleInd", "[Stale Ind]");
                        sqlBulkCopy.ColumnMappings.Add("ClosingPriceDate", "[Closing Price Date]");
                        sqlBulkCopy.ColumnMappings.Add("TDMktValue", "[TD Mkt Value]");
                        sqlBulkCopy.ColumnMappings.Add("ListedMarket", "[Listed Market]");
                        sqlBulkCopy.ColumnMappings.Add("SecurityType", "[Security Type]");
                        sqlBulkCopy.ColumnMappings.Add("SecurityDescription", "[Security Description]");
                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }

                    lblMsg.Text = "Details Inserted Successfully";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                }
            }
        }

        private void ClearNotification()
        {
            GridView1.DataSource = new string[] { };
            GridView1.DataBind();

            txtCopied.Text = "";
            lblMsg.Text = "";
        }
    }
}