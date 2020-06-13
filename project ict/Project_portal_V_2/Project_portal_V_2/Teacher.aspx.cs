using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Activities;
namespace Project_portal_V_2
{
    public partial class Teacher : System.Web.UI.Page
    {
        static List<Location> locations = new List<Location>();
        DataOperation DOobj = new DataOperation();
        AuditLog ALobj = new AuditLog();

        string page = "Teacher.aspx";
        string timeDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
        protected void Page_Load(object sender, EventArgs e)
        {
            string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = Request.ServerVariables["REMOTE_ADDR"];

            }
            locations.Clear();
            string APIKey = "12599b251d1797695b0536766a05cef9c02f39f96b6c9c1a018c8e76bb2d60ba";
            string url = string.Format("http://api.ipinfodb.com/v3/ip-city/?key={0}&ip={1}&format=json", APIKey, "103.199.233.174");
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                Location location = new JavaScriptSerializer().Deserialize<Location>(json);
                locations.Add(location);

            }

            if (Session["UserID"] != null && Session["Password"] != null)
            {
                if (!Page.IsPostBack)
                {
                    SaveVisitorDetail(Session["UserID"].ToString(), "Access", "Succeed");
                    loadgrid();
                }
            }
            else
            {
                //ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Not A User');window.location='Admin.aspx';", false);
                SaveVisitorDetail(Session["UserID"].ToString(), "Access", "Failed");
                Response.Redirect("~/TeacherLogin.aspx");
                Response.Write("You Are Not User");
            }
        }
        public void SaveVisitorDetail(string userName, string action, string status)
        {
            string ipaddress = "";
            string countryname = "";
            string cityname = "";
            string statename = "";
            string latitude = "";
            string longitude = "";
            foreach (var value in locations)
            {
                ipaddress = value.IPAddress;
                latitude = value.Latitude;
                longitude = value.Longitude;
                countryname = value.CountryName;
                statename = value.RegionName;
                cityname = value.CityName;
            }
            ALobj.auditLog(userName, ipaddress, action, page, timeDate, longitude, latitude, status);

        }
        public void loadgrid()
        {
            SaveVisitorDetail(Session["UserID"].ToString(), "ShowStudentInfo", "Succeed");
            if (string.IsNullOrWhiteSpace(txtSearchStudentID.Text))
            {
                if (!(cmbSemester.SelectedValue.ToString() == "All"))
                {
                    if (!(cmbCourseID.SelectedValue.ToString() == "All"))
                    {
                        string query = @"SELECT [Student_ID]
                              ,[Course_ID]
                              ,[Quiz1]
                              ,[Quiz2]
                              ,[Quiz3]
                              ,[Mid]
                              ,[Final]
                              ,[Credit]
                              ,[Semester]
                          FROM [dbo].[Student] WHERE [Semester]='" + cmbSemester.SelectedValue.ToString() + "' AND [Course_ID] = '" + cmbCourseID.SelectedValue.ToString() + "'";

                        grdvwShowStudent.DataSource = DOobj.getData(query);
                        grdvwShowStudent.DataBind();
                    }
                    else
                    {
                        string query = @"SELECT [Student_ID]
                              ,[Course_ID]
                              ,[Quiz1]
                              ,[Quiz2]
                              ,[Quiz3]
                              ,[Mid]
                              ,[Final]
                              ,[Credit]
                              ,[Semester]
                          FROM [dbo].[Student] WHERE [Semester]='" + cmbSemester.SelectedValue.ToString() + "'";

                        grdvwShowStudent.DataSource = DOobj.getData(query);
                        grdvwShowStudent.DataBind();
                    }
                }
                else
                {
                    if (!(cmbCourseID.SelectedValue.ToString() == "All"))
                    {
                        string query = @"SELECT [Student_ID]
                              ,[Course_ID]
                              ,[Quiz1]
                              ,[Quiz2]
                              ,[Quiz3]
                              ,[Mid]
                              ,[Final]
                              ,[Credit]
                              ,[Semester]
                          FROM [dbo].[Student] WHERE  [Course_ID] = '" + cmbCourseID.SelectedValue.ToString() + "'";

                        grdvwShowStudent.DataSource = DOobj.getData(query);
                        grdvwShowStudent.DataBind();
                    }
                    else
                    {
                        string query = @"SELECT [Student_ID]
                              ,[Course_ID]
                              ,[Quiz1]
                              ,[Quiz2]
                              ,[Quiz3]
                              ,[Mid]
                              ,[Final]
                              ,[Credit]
                              ,[Semester]
                          FROM [dbo].[Student] ";

                        grdvwShowStudent.DataSource = DOobj.getData(query);
                        grdvwShowStudent.DataBind();
                    }
                }
            }
            else
            {
                if (!(cmbSemester.SelectedValue.ToString() == "All"))
                {
                    if (!(cmbCourseID.SelectedValue.ToString() == "All"))
                    {
                        string query = @"SELECT [Student_ID]
                              ,[Course_ID]
                              ,[Quiz1]
                              ,[Quiz2]
                              ,[Quiz3]
                              ,[Mid]
                              ,[Final]
                              ,[Credit]
                              ,[Semester]
                          FROM [dbo].[Student] WHERE [Student_ID]='" + txtSearchStudentID.Text + "' AND [Semester]='" + cmbSemester.SelectedValue.ToString() + "' AND [Course_ID] = '" + cmbCourseID.SelectedValue.ToString() + "'";

                        grdvwShowStudent.DataSource = DOobj.getData(query);
                        grdvwShowStudent.DataBind();
                    }
                    else
                    {
                        string query = @"SELECT [Student_ID]
                              ,[Course_ID]
                              ,[Quiz1]
                              ,[Quiz2]
                              ,[Quiz3]
                              ,[Mid]
                              ,[Final]
                              ,[Credit]
                              ,[Semester]
                          FROM [dbo].[Student] WHERE [Student_ID]='" + txtSearchStudentID.Text + "' AND [Semester]='" + cmbSemester.SelectedValue.ToString() + "'";

                        grdvwShowStudent.DataSource = DOobj.getData(query);
                        grdvwShowStudent.DataBind();
                    }
                }
                else
                {
                    if (!(cmbCourseID.SelectedValue.ToString() == "All"))
                    {
                        string query = @"SELECT [Student_ID]
                              ,[Course_ID]
                              ,[Quiz1]
                              ,[Quiz2]
                              ,[Quiz3]
                              ,[Mid]
                              ,[Final]
                              ,[Credit]
                              ,[Semester]
                          FROM [dbo].[Student] WHERE [Student_ID]='" + txtSearchStudentID.Text + "'  AND [Course_ID] = '" + cmbCourseID.SelectedValue.ToString() + "'";

                        grdvwShowStudent.DataSource = DOobj.getData(query);
                        grdvwShowStudent.DataBind();
                    }
                    else
                    {
                        string query = @"SELECT [Student_ID]
                              ,[Course_ID]
                              ,[Quiz1]
                              ,[Quiz2]
                              ,[Quiz3]
                              ,[Mid]
                              ,[Final]
                              ,[Credit]
                              ,[Semester]
                          FROM [dbo].[Student] WHERE [Student_ID]='" + txtSearchStudentID.Text + "'";

                        grdvwShowStudent.DataSource = DOobj.getData(query);
                        grdvwShowStudent.DataBind();
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] != null && Session["Password"] != null)
            {
                SaveVisitorDetail(Session["UserName"].ToString(), "Search", "Succeed");
                loadgrid();
                
            }
            else
            {
                //ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Not A User');window.location='Admin.aspx';", false);
                Response.Write("You Are Not User");
            }
        }

        protected void grdvwShowStudent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdvwShowStudent.EditIndex = e.NewEditIndex;
            loadgrid();
        }

        protected void grdvwShowStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblStudentID = (Label)grdvwShowStudent.Rows[e.RowIndex].FindControl("Label1");
            Label lblSemester = (Label)grdvwShowStudent.Rows[e.RowIndex].FindControl("Label9");
            Label lblCourse = (Label)grdvwShowStudent.Rows[e.RowIndex].FindControl("Label2");
            TextBox txtQuiz1 = (TextBox)grdvwShowStudent.Rows[e.RowIndex].FindControl("TextBox1");
            TextBox txtQuiz2 = (TextBox)grdvwShowStudent.Rows[e.RowIndex].FindControl("TextBox2");
            TextBox txtQuiz3 = (TextBox)grdvwShowStudent.Rows[e.RowIndex].FindControl("TextBox3");
            TextBox txtMid = (TextBox)grdvwShowStudent.Rows[e.RowIndex].FindControl("TextBox4");
            TextBox txtFinal = (TextBox)grdvwShowStudent.Rows[e.RowIndex].FindControl("TextBox5");
            string query = "UPDATE [dbo].[Student] SET  [Quiz1] = '" + txtQuiz1.Text + "' ,[Quiz2] = '" + txtQuiz2.Text + "',[Quiz3] = '" + txtQuiz3.Text + "' ,[Mid]='"+txtMid.Text+"', [Final] = '"+txtFinal.Text+"' WHERE [Student_ID] = '" + lblStudentID.Text + "' AND [Course_ID]='"+lblCourse.Text+"' AND [Semester]='"+lblSemester.Text+"'";
            if (DOobj.executequery(query) == 1)
            {
                grdvwShowStudent.EditIndex = -1;
                loadgrid();
                SaveVisitorDetail(Session["UserName"].ToString(), "InfoUpdate", "Succeed");
            }
            else
            {
                SaveVisitorDetail(Session["UserName"].ToString(), "InfoUpdate", "Failed");
            }
        }

        protected void grdvwShowStudent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdvwShowStudent.EditIndex = -1;
            loadgrid();
        }

        protected void cmbSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbSemester.SelectedValue))
            {
                if (!string.IsNullOrWhiteSpace(cmbCourseID.SelectedValue))
                {
                    string query = @"SELECT [Student_ID]
                              ,[Course_ID]
                              ,[Quiz1]
                              ,[Quiz2]
                              ,[Quiz3]
                              ,[Mid]
                              ,[Final]
                              ,[Credit]
                              ,[Semester]
                          FROM [dbo].[Student] WHERE [Student_ID]='" + txtSearchStudentID.Text + "' AND [Semester]='" + cmbSemester.SelectedValue.ToString() + "' AND [Course_ID] = '" + cmbCourseID.SelectedValue.ToString() + "'";

                    grdvwShowStudent.DataSource = DOobj.getData(query);
                    grdvwShowStudent.DataBind();
                }
                else
                {
                    string query = @"SELECT [Student_ID]
                              ,[Course_ID]
                              ,[Quiz1]
                              ,[Quiz2]
                              ,[Quiz3]
                              ,[Mid]
                              ,[Final]
                              ,[Credit]
                              ,[Semester]
                          FROM [dbo].[Student] WHERE [Student_ID]='" + txtSearchStudentID.Text + "' AND [Semester]='" + cmbSemester.SelectedValue.ToString() + "'";

                    grdvwShowStudent.DataSource = DOobj.getData(query);
                    grdvwShowStudent.DataBind();
                }
            }
        }

        protected void cmbCourseID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmbSemester.SelectedValue))
            {
                if (!string.IsNullOrWhiteSpace(cmbCourseID.SelectedValue))
                {
                    string query = @"SELECT [Student_ID]
                              ,[Course_ID]
                              ,[Quiz1]
                              ,[Quiz2]
                              ,[Quiz3]
                              ,[Mid]
                              ,[Final]
                              ,[Credit]
                              ,[Semester]
                          FROM [dbo].[Student] WHERE [Student_ID]='" + txtSearchStudentID.Text + "' AND [Semester]='" + cmbSemester.SelectedValue.ToString() + "' AND [Course_ID] = '" + cmbCourseID.SelectedValue.ToString() + "'";

                    grdvwShowStudent.DataSource = DOobj.getData(query);
                    grdvwShowStudent.DataBind();
                }
                else
                {
                    string query = @"SELECT [Student_ID]
                              ,[Course_ID]
                              ,[Quiz1]
                              ,[Quiz2]
                              ,[Quiz3]
                              ,[Mid]
                              ,[Final]
                              ,[Credit]
                              ,[Semester]
                          FROM [dbo].[Student] WHERE [Student_ID]='" + txtSearchStudentID.Text + "' AND [Semester]='" + cmbSemester.SelectedValue.ToString() + "'";

                    grdvwShowStudent.DataSource = DOobj.getData(query);
                    grdvwShowStudent.DataBind();
                }
            }
        }
    }
}