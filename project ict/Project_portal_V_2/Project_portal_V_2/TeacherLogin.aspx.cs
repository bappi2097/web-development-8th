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
    public partial class TeacherLogin : System.Web.UI.Page
    {
        static List<Location> locations = new List<Location>();
        DataOperation DOobj = new DataOperation();
        AuditLog ALobj = new AuditLog();

        string page = "TeacherLogin.aspx";
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
            lblMessageLoginUserID.Visible = false;
            lblMessageLoginPassword.Visible = false;
            lblMessageLogin.Visible = false;
            SaveVisitorDetail("Unidentified", "TeacherLogin", "Visit");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblMessageLoginUserID.Visible = false;
            lblMessageLoginPassword.Visible = false;
            lblMessageLogin.Visible = false;
            if (string.IsNullOrWhiteSpace(txtLoginUserID.Text))
            {
                lblMessageLoginUserID.Visible = true;
                lblMessageLoginUserID.ForeColor = Color.Red;
                lblMessageLoginUserID.Text = "Please Input Username";
                if (string.IsNullOrWhiteSpace(txtLoginPassword.Text))
                {
                    lblMessageLoginPassword.Visible = true;
                    lblMessageLoginPassword.ForeColor = Color.Red;
                    lblMessageLoginPassword.Text = "Please Input Password";
                    SaveVisitorDetail(txtLoginUserID.Text, "TeacherLogin", "NullField");
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtLoginPassword.Text))
                {
                    lblMessageLoginPassword.Visible = true;
                    lblMessageLoginPassword.ForeColor = Color.Red;
                    SaveVisitorDetail(txtLoginUserID.Text, "TeacherLogin", "Failed");
                    lblMessageLoginPassword.Text = "Please Input Password";
                }
                else
                {
                    string query = @"SELECT COUNT(*)
                              FROM [dbo].[Teacher] WHERE [UserID]='" + txtLoginUserID.Text + "' AND [Password]='" + txtLoginPassword.Text + "'";
                    if (DOobj.loginCheck(query) == 1)
                    {
                        Session["UserID"] = txtLoginUserID.Text;
                        Session["Password"] = txtLoginPassword.Text;
                        SaveVisitorDetail(txtLoginUserID.Text, "TeacherLogin", "Succeed");
                        Response.Redirect("~/Teacher.aspx");
                    }
                    else
                    {
                        lblMessageLogin.Visible = true;
                        lblMessageLogin.ForeColor = Color.Red;
                        SaveVisitorDetail(txtLoginUserID.Text, "TeacherLogin", "Failed");
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
    }
}