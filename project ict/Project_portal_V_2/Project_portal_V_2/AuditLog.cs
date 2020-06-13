using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.NetworkInformation;
using System.Xml;

namespace Project_portal_V_2
{
    public class AuditLog
    {
        DataOperation DOobj = new DataOperation();
        public void auditLog(string userID,string ipAddress,string action,string page,string timeDate,string longitude,string latitude,string status)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[AuditAndLog]
                               ([UserID]
                               ,[IPAddress]
                               ,[Action]
                               ,[Page]
                               ,[TimeDate]
                               ,[Longitude]
                               ,[Latitude]
                               ,[Status])
                         VALUES ('" + userID + "','" + ipAddress + "','" + action + "','"+page+"','" + timeDate + "','" + longitude + "','"+latitude+"','" + status + "')";
                DOobj.executequery(query);
            }
            catch
            {

            }
        }
    }
}