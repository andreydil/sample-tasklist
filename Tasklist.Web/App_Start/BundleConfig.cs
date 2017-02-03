using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace Tasklist.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/bootstrap-confirmation.min.js",
                "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.validation.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/angular1").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-animate.js",
                "~/Scripts/angular-route.js",
                "~/Scripts/angular-sanitize.js",
                "~/Scripts/angular-ui/ui-bootstrap.js",
                "~/Scripts/angular-bootstrap-confirm.js",
                "~/Scripts/toastr.js",
                "~/Scripts/spin.js",
                "~/Angular1SPA/app.js",
                "~/Angular1SPA/config.js",
                "~/Angular1SPA/config.exceptionHandler.js",
                "~/Angular1SPA/config.routes.js",
                "~/Angular1SPA/common/common.js",
                "~/Angular1SPA/common/logger.js",
                "~/Angular1SPA/common/spinner.js",
                "~/Angular1SPA/services/repository.js",
                "~/Angular1SPA/layout/layoutController.js",
                "~/Angular1SPA/projects/projectsController.js",
                "~/Angular1SPA/projects/addProjectController.js",
                "~/Angular1SPA/projects/editProjectController.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/bootstrap.min.css",
                 "~/Content/bootstrap.theme.min.css",
                 "~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/angular1css").Include(
                "~/Content/toastr.css"));
        }
    }
}
