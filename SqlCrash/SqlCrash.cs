using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace SqlCrash
{
    public class Downloader
    {
        [SqlFunction(SystemDataAccess = SystemDataAccessKind.Read, DataAccess = DataAccessKind.Read)]
        public static void DownloadData()
        {
            using (WebClient wc = new WebClient())
            {
                var url = "http://google.com:9500";

                try
                {
                    var str = wc.DownloadString(url);
                }
                catch (WebException e) when (((HttpWebResponse)e.Response).StatusCode == (HttpStatusCode)600)
                {
                    //nothing
                }
            }
        }
    }
}
