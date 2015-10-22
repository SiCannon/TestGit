using System.IO;
using System.Web;
using System.Web.Optimization;
using dotless.Core;

namespace TestGit.Website.Plumbing
{
    public class LessTransform : IBundleTransform
    {
        string path;

        public LessTransform(string path)
        {
            this.path = HttpContext.Current.Server.MapPath(path);
        }

        public void Process(BundleContext context, BundleResponse response)
        {
            Directory.SetCurrentDirectory(path);
            
            response.Content = Less.Parse(response.Content);
            response.ContentType = "text/css";
        }
    }
}