﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace Shop_test
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.unobtrusive*",
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                "~/Scripts/knockout-{version}.js",
                "~/Scripts/knockout.validation.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/sammy-{version}.js",
                "~/Scripts/app/common.js",
                "~/Scripts/app/app.datamodel.js",
                "~/Scripts/app/app.viewmodel.js",
                "~/Scripts/app/home.viewmodel.js",
                "~/Scripts/app/_run.js"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство построения на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/Scripts/angular.js").Include(
                "~/Scripts/angular.js"));
            bundles.Add(new ScriptBundle("~/Scripts/jquery-ui-1.12.1.js").Include(
                "~/Scripts/jquery-ui-1.12.1.js"));
            bundles.Add(new ScriptBundle("~/Scripts/Routes_module.js").Include(
                "~/Scripts/Routes_module.js"));
            bundles.Add(new ScriptBundle("~/Scripts/ShopsController.js").Include(
                "~/Scripts/ShopsController.js"));
            bundles.Add(new ScriptBundle("~/Scripts/ProductsController.js").Include(
                "~/Scripts/ProductsController.js"));

            bundles.Add(new StyleBundle("~/Content/themes/base/jquery-ui.css").Include("~/Content/themes/base/jquery-ui.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap.css").Include("~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Content/Site.css").Include("~/Content/Site.css"));
        }
    }
}
