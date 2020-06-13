using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;

using System.Net;
using System.Web.Script.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Activities;
namespace Project_portal_V_2
{
    public partial class ParentLogin : System.Web.UI.Page
    {
        static List<Location> locations = new List<Location>();
        DataOperation DOobj = new DataOperation();
        AuditLog ALobj = new AuditLog();

        string page = "ParentLogin.aspx";
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
            if (!Page.IsPostBack)
            {
                lblMessageLogin.Visible = false;
                lblMessageRegistration.Visible = false;
                txtContactNumber.Text = "";
                txtParentConfirmPassword.Text = "";
                txtParentName.Text = "";
                txtParentPassword.Text = "";
                txtParentRelation.Text = "";
                txtParentUserName.Text = "";
                txtStudentID.Text = "";
                SaveVisitorDetail("Unidentified", "ParentLogin", "Visit");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblMessageLogin.Visible = false;
            if (string.IsNullOrWhiteSpace(txtLoginUserName.Text))
            {
                lblMessageLogin.Visible = true;
                lblMessageLogin.ForeColor = Color.Red;
                lblMessageLogin.Text = "Please Input Username";
                if (string.IsNullOrWhiteSpace(txtLoginPassword.Text))
                {
                    lblMessageLogin.Visible = true;
                    lblMessageLogin.ForeColor = Color.Red;
                    lblMessageLogin.Text = "Please Input UserName And Password";
                    SaveVisitorDetail(txtLoginUserName.Text, "ParentLogin", "NullField");
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtLoginPassword.Text))
                {
                    lblMessageLogin.Visible = true;
                    lblMessageLogin.ForeColor = Color.Red;
                    SaveVisitorDetail(txtLoginUserName.Text, "ParentLogin", "Failed");
                    lblMessageLogin.Text = "Please Input Password";
                }
                else
                {
                    string query = @"SELECT COUNT(*)
                              FROM [dbo].[Parent] WHERE [UserName]='" + txtLoginUserName.Text + "' AND [Password]='" + txtLoginPassword.Text + "'";
                    if (DOobj.loginCheck(query) == 1)
                    {
                        lblMessageLogin.Visible = false;
                        Session["UserName"] = txtLoginUserName.Text;
                        Session["Password"] = txtLoginPassword.Text;
                        SaveVisitorDetail(txtLoginUserName.Text, "ParentLogin", "Succeed");
                        Response.Redirect("~/Parent.aspx");
                    }
                    else
                    {
                        lblMessageLogin.Visible = true;
                        lblMessageLogin.ForeColor = Color.Red;
                        SaveVisitorDetail(txtLoginUserName.Text, "ParentLogin", "Failed");
                        lblMessageLogin.Text = "Wrong User Name Or Password";
                    }
                }
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

        protected void btnParentRegistrtion_Click(object sender, EventArgs e)
        {
            lblMessageRegistration.Visible = false;
            if (string.IsNullOrWhiteSpace(txtParentName.Text) || string.IsNullOrWhiteSpace(txtStudentID.Text) || string.IsNullOrWhiteSpace(txtParentUserName.Text) || string.IsNullOrWhiteSpace(txtParentPassword.Text) || string.IsNullOrWhiteSpace(txtParentConfirmPassword.Text) || string.IsNullOrWhiteSpace(txtParentRelation.Text) || string.IsNullOrWhiteSpace(txtContactNumber.Text))
            {

                lblMessageRegistration.Visible = true;
                lblMessageRegistration.ForeColor = Color.Red;
                lblMessageRegistration.Text = "This Field Can't Be Empty";
            }
            else
            {
                if (txtParentPassword.Text == txtParentConfirmPassword.Text)
                {

                    string query = @"SELECT COUNT(*)
                          FROM [dbo].[Student] WHERE [Student_ID]='" + txtStudentID.Text + "'";
                    if (DOobj.loginCheck(query) == 1)
                    {
                        query = @"INSERT INTO [dbo].[Parent]
                           ([StudentID]
                           ,[Name]
                           ,[Relation]
                           ,[ContactNumber]
                           ,[UserName]
                           ,[Password])
                     VALUES
                           ('" + txtStudentID.Text + "','" + txtParentName.Text + "','" + txtParentRelation.Text + "','" + txtContactNumber.Text + "','" + txtParentUserName.Text + "','" + txtParentPassword.Text + "')";
                        if (DOobj.executequery(query) == 1)
                        {
                            lblMessageRegistration.Visible = true;
                            lblMessageRegistration.ForeColor = Color.Green;
                            lblMessageRegistration.Text = "Registration Successfully Done";
                            txtContactNumber.Text = "";
                            txtParentConfirmPassword.Text = "";
                            txtParentName.Text = "";
                            txtParentPassword.Text = "";
                            txtParentRelation.Text = "";
                            txtParentUserName.Text = "";
                            txtStudentID.Text = "";
                        }
                        else
                        {
                            lblMessageRegistration.Visible = true;
                            lblMessageRegistration.ForeColor = Color.Red;
                            lblMessageRegistration.Text = "Input Another User Name";
                            txtParentUserName.Text = "";
                        }
                    }
                    else
                    {
                        lblMessageRegistration.Visible = true;
                        lblMessageRegistration.ForeColor = Color.Red;
                        lblMessageRegistration.Text = "Wrong Student ID";
                        txtStudentID.Text = "";
                        txtParentUserName.Text = txtStudentID.Text;
                    }
                }
                else
                {
                    lblMessageRegistration.Visible = true;
                    lblMessageRegistration.ForeColor = Color.Red;
                    lblMessageRegistration.Text = "Wrong Confirmation Password";
                    txtParentConfirmPassword.Text = "";
                    txtParentPassword.Text = "";
                }
            }
        }
    }
}