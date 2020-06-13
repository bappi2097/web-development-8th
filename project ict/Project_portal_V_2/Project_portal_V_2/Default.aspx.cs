using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data.SqlClient;
using System.Net;
using System.Web.Script.Serialization;
using System.Data;
using System.Activities;

namespace Project_portal_V_2
{
    public partial class _Default : Page
    {
        static List<Location> locations = new List<Location>();
        DataOperation DOobj = new DataOperation();
        AuditLog ALobj = new AuditLog();
        string page = "Parent.aspx";
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
            
            if (Session["UserName"] != null)
            {
                SaveVisitorDetail(Session["UserName"].ToString(), "VisitHome", "View");
                Session["UserName"] = null;
            }
            else
            {
                SaveVisitorDetail("Guest", "VisitHome", "View");
            }
            if (Session["UserID"] != null)
            {
                SaveVisitorDetail(Session["UserName"].ToString(), "VisitHome", "View");
                Session["UserID"] = null;
            }
            else
            {
                SaveVisitorDetail("Guest", "VisitHome", "View");
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