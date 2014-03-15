using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SendToKindle
{
    public partial class _Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var url = "http://weekly.manong.io/issues/1";
            var postData = "t=test";
            CaptureUrlInfo(GetWebContent(url, postData));
        }

        private string GetWebContent(string url, string postData)
        {
            var webClient = new WebClient();
            var result = webClient.UploadData(url, Encoding.GetEncoding("utf-8").GetBytes(postData));

            return Encoding.GetEncoding("utf-8").GetString(result);
        }

        private void CaptureUrlInfo(string input)
        {
            string pattern=@"(<a\s.*href=""?\s*)([^""]*)(""?.*>)([^<]+)(</a>)";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            var mathes = regex.Matches(input);
            if(mathes.Count>0)
            {
                foreach (Match match in mathes)
                {
                    //Response.Write(match.Value);
                    //Response.Write("<br>");
                    Response.Write(match.Groups[2].Value);
                    Response.Write("<br>");
                    Response.Write(match.Groups[4].Value);
                    Response.Write("<br>");

                }
            }
        }
    }
}
