using System.Web.Optimization;
using TestGit.Website.Plumbing;

namespace TestGit.Website.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var appbundle = new Bundle("~/bundles/less").Include("~/Styles/site.less");
            appbundle.Transforms.Add(new LessTransform("~/Styles"));
            appbundle.Transforms.Add(new CssMinify());
            bundles.Add(appbundle);

            var bootstrapbundle = new Bundle("~/bundles/bootstrap").Include("~/Styles/bootstrap/bootstrap.less");
            bootstrapbundle.Transforms.Add(new LessTransform("~/Styles/bootstrap"));
            bootstrapbundle.Transforms.Add(new CssMinify());
            bundles.Add(bootstrapbundle);
        }
    }
}