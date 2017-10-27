using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class GridSample : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Amala"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("StudentmarksSp", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Sid", SqlDbType.Int).Value = Convert.ToInt32(tbsid.Text);
                // cmd.Parameters.Add("@Name", SqlDbType.VarChar, 90).Value = tbname.Text.ToString();
                // cmd.Parameters.Add("@SubjectName", SqlDbType.VarChar, 90).Value = tbsbname.Text.ToString();
                // cmd.Parameters.Add("@Marks", SqlDbType.Int).Value = Convert.ToInt32(tbmarks.Text); //why input string is not in currect format??
                try
                {
                    cn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        DataSet ds = new DataSet();
                        da.SelectCommand = cmd;
                        da.Fill(ds, "Sid");
                        da.Fill(ds, "Name"); da.Fill(ds, "SubjectName"); da.Fill(ds, "Marks");
                        gvsm.DataSource = ds;
                        gvsm.DataBind();


                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                tbsid.Text = dr["Sid"] as string;
                                tbname.Text = dr["Name"] as string;
                                tbsbname.Text = dr["SubjectName"] as string;
                                tbmarks.Text = dr["Marks"] as string;

                            }
                            dr.Close();
                        }

                    }
                }
                catch (Exception ex) { }
                finally
                {
                    cn.Close();
                }

            }
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {

        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Amala"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("StudentmarksSp1", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Sid", SqlDbType.Int).Value = Convert.ToInt32(tbsid.Text);
                cmd.Parameters.Add("@Name", SqlDbType.VarChar, 90).Value = tbname.Text.ToString();
                cmd.Parameters.Add("@SubjectName", SqlDbType.VarChar, 90).Value = tbsbname.Text.ToString();
                cmd.Parameters.Add("@Marks", SqlDbType.Int).Value = Convert.ToInt32(tbmarks.Text); //why input string is not in currect format??
                try
                {
                    cn.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        DataSet ds = new DataSet();
                        da.SelectCommand = cmd;
                        da.Fill(ds, "Sid");
                        da.Fill(ds, "Name"); da.Fill(ds, "SubjectName"); da.Fill(ds, "Marks");
                        gvsm.DataSource = ds;
                        gvsm.DataBind();


                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                tbsid.Text = dr["Sid"] as string;
                                tbname.Text = dr["Name"] as string;
                                tbsbname.Text = dr["SubjectName"] as string;
                                tbmarks.Text = dr["Marks"] as string;

                            }
                            dr.Close();
                        }
                    }
                }
                catch (Exception ex) { }
                finally
                {
                    cn.Close();
                }
            }
        }
    }
}