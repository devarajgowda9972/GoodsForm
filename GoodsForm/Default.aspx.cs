using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace GoodsForm
{
    public partial class _Default : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["GoodsDb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        void LoadData()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("sp_GetGoods", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertGoods", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Category", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text));
                cmd.Parameters.AddWithValue("@Availability", rbAvailable.Checked);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                LoadData();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.TryParse(txtId.Text, out id) ? id : 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateGoods", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Category", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text));
                cmd.Parameters.AddWithValue("@Availability", rbAvailable.Checked);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                LoadData();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteGoods", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(txtId.Text));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                LoadData();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            txtId.Text = row.Cells[1].Text;
            txtName.Text = row.Cells[2].Text;
            ddlCategory.SelectedValue = row.Cells[3].Text;
            txtQuantity.Text = row.Cells[4].Text;
            rbAvailable.Checked = row.Cells[5].Text.ToLower() == "true";
        }
    }
}
