using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    public static string hostPath = @"C:\Windows\System32\Drivers\etc\hosts";
    public static List<string> lines = File.ReadAllLines(hostPath).Where(l => l.Contains("kyfw.12306.cn")).Select(l => l.StartsWith("#") ? l : "#" + l).ToList();
    public static List<string> otherlines = File.ReadAllLines(hostPath).Where(l => !l.Contains("kyfw.12306.cn")).ToList();
    public static int i = 0;
    public static int s = 2800;

    protected void Page_Load(object sender, EventArgs e)
    {
        var newlines = lines.Select(l => l).ToList();
        newlines[i] = newlines[i].Substring(1);

        var newline = newlines[i];

        var alllines = otherlines.Union(newlines).ToList();
        File.WriteAllLines(hostPath, alllines);

        if (i == lines.Count - 1)
            i = 0;
        else
            i = i + 1;

        Response.Clear();
        Response.Write(newline);
    }
}
