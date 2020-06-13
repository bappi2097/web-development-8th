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
using System.Drawing;

namespace Project_portal_V_2
{
    public partial class Admin : System.Web.UI.Page
    {
        static List<Location> locations = new List<Location>();
        DataOperation DOobj = new DataOperation();
        AuditLog ALobj = new AuditLog();
        
        string page = "Admin.aspx";
        string myip = "103.199.233.234";
        string IPaddress = "";
        string timeDate = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessageAdminPassword.Visible = false;
            string ipAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = Request.ServerVariables["REMOTE_ADDR"];
            }
            locations.Clear();
            string APIKey = "12599b251d1797695b0536766a05cef9c02f39f96b6c9c1a018c8e76bb2d60ba";
            string url = string.Format("http://api.ipinfodb.com/v3/ip-city/?key={0}&ip={1}&format=json", APIKey, myip);
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                Location location = new JavaScriptSerializer().Deserialize<Location>(json);
                locations.Add(location);

            }


            if (Session["UserName"] != null && Session["Password"] != null)
            {
                string query = @"SELECT COUNT(*) FROM [dbo].[Admin] WHERE [UserName]='" + Session["UserName"].ToString() + "' AND [Password]='" + Session["Password"].ToString() + "'";

                if (DOobj.loginCheck(query) == 1)
                {
                    SaveVisitorDetail(Session["UserName"].ToString(), "Access", "Succeed");
                    if (IPaddress == myip)
                    {
                        if (!Page.IsPostBack)
                        {
                            SaveVisitorDetail(Session["UserName"].ToString(), "IPAddrress", "Correct");
                            loadgrid();
                        }
                    }
                    else
                    {
                        SaveVisitorDetail(Session["UserName"].ToString(), "IPAddrress", "Incorroct");
                    }
                }
                else
                {
                    //ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Not A User');window.location='Admin.aspx';", false);
                    SaveVisitorDetail("NotUser", "Access", "Failed");
                    Response.Redirect("~/AdminLogin.aspx");
                    Response.Write("You Are Not Admin");
                }
            }
            else
            {
                //ClientScript.RegisterStartupScript(Page.GetType(), "Message", "alert('Not A User');window.location='Admin.aspx';", false);
                SaveVisitorDetail("NotUser", "Access", "Failed");
                Response.Redirect("~/AdminLogin.aspx");
                Response.Write("You Are Not Admin");
            }
        }
        public void SaveVisitorDetail(string userName,string action,string status)
        {
            string ipaddress = "";
            string countryname = "";
            string cityname = "";
            string statename = "";
            string latitude = "";
            string longitude = "";
            foreach (var value in locations)
            {
                IPaddress = value.IPAddress;
                ipaddress = value.IPAddress;
                latitude = value.Latitude;
                longitude = value.Longitude;
                countryname = value.CountryName;
                statename = value.RegionName;
                cityname = value.CityName;
            }
            ALobj.auditLog(userName,ipaddress,action,page,timeDate,longitude,latitude,status);
        }

        public void loadgrid()
        {
            string query = @"SELECT [UserID]
                          ,[IPAddress]
                          ,[Action]
                          ,[Page]
                          ,[TimeDate]
                          ,[Longitude]
                          ,[Latitude]
                          ,[Status]
                      FROM [dbo].[AuditAndLog]";
            grdViewAuditAndLogging.DataSource = DOobj.getData(query);
            grdViewAuditAndLogging.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
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
            if (Session["UserName"] != null && Session["Password"] != null)
            {
                string query = @"SELECT [UserID]
                          ,[IPAddress]
                          ,[Action]
                          ,[Page]
                          ,[TimeDate]
                          ,[Longitude]
                          ,[Latitude]
                          ,[Status]
                      FROM [dbo].[AuditAndLog] WHERE [" + cmbSearchBy.SelectedValue.ToString()+"] = '"+txtSearchUserID.Text+ "' ORDER BY [ID] DESC";
                SaveVisitorDetail(Session["UserName"].ToString(), "Search", "Succeed");
                grdViewAuditAndLogging.DataSource = DOobj.getData(query);
                grdViewAuditAndLogging.DataBind();
            }
            else
            {
                SaveVisitorDetail(Session["UserName"].ToString(), "Search", "Failed");
            }
        }

        protected void btnBackup_Click(object sender, EventArgs e)
        {
            lblMessageAdminPassword.Visible = false;
            if (!string.IsNullOrWhiteSpace(txtAdminPassword.Text))
            {
                if (Session["Password"].ToString() == txtAdminPassword.Text)
                {
                    SaveVisitorDetail(Session["UserName"].ToString(), "AuthenticationForBackup", "Succeed");
                    string query = @"BACKUP DATABASE Parent_portal_DB_V_1 TO DISK = 'E:\\Backup\\AuditAndLog_" + DateTime.Now.ToString("MM-dd-yyyy")+ ".bak'";
                    if(DOobj.executequery(query)==1)
                    {
                        lblMessageAdminPassword.ForeColor = Color.Green;
                        lblMessageAdminPassword.Visible = true;
                        lblMessageAdminPassword.Text = "Backup Successfully Done";
                        SaveVisitorDetail(Session["UserName"].ToString(), "BackupSaving", "Succeed");
                    }
                    else
                    {
                        lblMessageAdminPassword.ForeColor = Color.Red;
                        lblMessageAdminPassword.Visible = true;
                        lblMessageAdminPassword.Text = "Backup Unsuccessful";
                        SaveVisitorDetail(Session["UserName"].ToString(), "BackupSaving", "Failed");
                    }
                }
                else
                {
                    lblMessageAdminPassword.ForeColor = Color.Red;
                    lblMessageAdminPassword.Visible = true;
                    lblMessageAdminPassword.Text = "Wrong Password";
                    SaveVisitorDetail(Session["UserName"].ToString(), "AuthenticationForBackup", "Failed");
                }
            }
            else
            {
                lblMessageAdminPassword.ForeColor = Color.Red;
                lblMessageAdminPassword.Visible = true;
                lblMessageAdminPassword.Text = "Empty Field";
                SaveVisitorDetail(Session["UserName"].ToString(), "AuthenticationForBackup", "Failed");
            }
            
        }
    }
}
public class Location
{
    public string IPAddress { get; set; }
    public string CountryName { get; set; }
    public string CountryCode { get; set; }
    public string CityName { get; set; }
    public string RegionName { get; set; }
    public string ZipCode { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string TimeZone { get; set; }
}
