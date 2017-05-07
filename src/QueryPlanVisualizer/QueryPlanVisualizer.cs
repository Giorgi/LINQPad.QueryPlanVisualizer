using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using ExecutionPlanVisualizer.Helpers;
using ExecutionPlanVisualizer.Properties;
using LINQPad;

namespace ExecutionPlanVisualizer
{
    public static class QueryPlanVisualizer
    {
        private const string ExecutionPlanPanelTitle = "Query Execution Plan";
        private static bool shouldExtract = true;

        public static IQueryable<T> DumpPlan<T>(this IQueryable<T> queryable, bool dumpData = false)
        {
            DumpPlanInternal(queryable, dumpData, true);

            return queryable;
        }

        public static void DumpPlanXml(string planXml)
        {
            try
            {
                var control = new QueryPlanUserControl();

                PanelManager.DisplayControl(control, ExecutionPlanPanelTitle);

                ProcessQueryPlan(planXml, control);
            }
            catch (Exception exception)
            {
                ShowError(exception.ToString());
            }
        }

        private static void DumpPlanInternal<T>(IQueryable<T> queryable, bool dumpData, bool addNewPanel)
        {
            if (Util.CurrentDataContext != null && !(Util.CurrentDataContext.Connection is SqlConnection))
            {
                ShowError("Query Plan Visualizer supports only Sql Server");
                return;
            }

            var databaseHelper = DatabaseHelperFactory.Create(Util.CurrentDataContext, queryable);

            if (dumpData)
            {
                queryable.Dump();
            }

            try
            {
                var planXml = databaseHelper.GetSqlServerQueryExecutionPlan(queryable);

                var control = PanelManager.GetOutputPanel(ExecutionPlanPanelTitle)?.GetControl() as QueryPlanUserControl;

                if (control == null || addNewPanel)
                {
                    control = new QueryPlanUserControl
                    {
                        DatabaseHelper = databaseHelper
                    };

                    if (queryable != null)
                    {
                        control.IndexCreated += (sender, args) =>
                        {
                            if (MessageBox.Show("Index created. Refresh query plan?", "", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                DumpPlanInternal(queryable, false, false);
                            }
                        };
                    }

                    PanelManager.DisplayControl(control, ExecutionPlanPanelTitle);
                }

                ProcessQueryPlan(planXml, control);
            }
            catch (Exception exception)
            {
                ShowError(exception.ToString());
            }
        }

        private static void ProcessQueryPlan(string planXml, QueryPlanUserControl control)
        {
            if (string.IsNullOrEmpty(planXml))
            {
                ShowError("Cannot retrieve query plan");
                return;
            }

            var queryPlanProcessor = new QueryPlanProcessor(planXml);

            var indexes = queryPlanProcessor.GetMissingIndexes();
            var planHtml = queryPlanProcessor.ConvertPlanToHtml();
            
            var files = ExtractFiles();
            files.Add(planHtml);

            var html = string.Format(Resources.template, files.ToArray());

            control.DisplayExecutionPlanDetails(planXml, html, indexes);
        }

        private static void ShowError(string text)
        {
            var control = new Label {Text = text};
            PanelManager.DisplayControl(control, ExecutionPlanPanelTitle);
        }

        private static List<string> ExtractFiles()
        {
            var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LINQPadQueryVisualizer");

            if (!Directory.Exists(folder))
            {
                shouldExtract = true;
                Directory.CreateDirectory(folder);
            }

            var qpJavascript = Path.Combine(folder, "qp.js");
            var qpStyleSheet = Path.Combine(folder, "qp.css");
            var jquery = Path.Combine(folder, "jquery.js");
            var icons = Path.Combine(folder, "qp_icons.png");

            if (shouldExtract)
            {
                Resources.qp_icons.Save(icons);

                File.WriteAllText(qpJavascript, Resources.qpJavascript);
                File.WriteAllText(qpStyleSheet, Resources.qpStyleSheet);
                File.WriteAllText(jquery, Resources.jquery);

                shouldExtract = false;
            }

            return new List<string> { qpStyleSheet, qpJavascript, jquery };
        }
    }
}