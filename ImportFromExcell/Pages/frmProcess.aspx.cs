using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ImportFromExcell.Pages
{
    public partial class frmProcess : System.Web.UI.Page
    {
        protected void btnProcess_Click(object sender, EventArgs e)
        {
            string consString = ConfigurationManager.ConnectionStrings["GlobalBOConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(consString))
            {

                string s = "[recon].[gbo_reconcile_func]";
                SqlCommand Com = new SqlCommand(s, con);
                con.Open();
                Com.ExecuteNonQuery();
                con.Close();
            }

            lblMsg.Text = "Process Done";
        }
    }
}