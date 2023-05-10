using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Flow.Launcher.Plugin;
using Switcheroo.Core;

namespace Flow.Launcher.Plugin.SwitchOrLaunch
{
    public class SwitchOrLaunch : IPlugin
    {
        private PluginInitContext _context;
        private WindowFinder windowFinder;

        public void Init(PluginInitContext context)
        {
            _context = context;
            this.windowFinder = new WindowFinder();
        }

        public List<Result> Query(Query query)
        {
            // Debugger.Launch();
            var results = new List<Result>();
            List<AppWindowWithText> windows = this.windowFinder.GetWindows().Select(w => new AppWindowWithText(w)).ToList();
            var context = new WindowFilterContext<AppWindowWithText>() { Windows = windows };
            if (!string.IsNullOrEmpty(query.Search))
            {
                windows = new WindowFilterer().Filter(context, query.Search).Select(w => w.AppWindow).ToList();
            }

            foreach (var item in windows)
            {
                var r = new Result
                {
                    Title = item.WindowTitle,
                    SubTitle = item.ProcessTitle,
                    Action = _ =>
                    {
                        item.SwitchTo();
                        return true;
                    },
                    IcoPath = item.ExecutablePath,
                    SupportsAutoExecuteAction = true
                };
                results.Add(r);
            }
            return results;
        }
    }

    class AppWindowWithText : IWindowText
    {
        private readonly AppWindow appWindow;

        public AppWindowWithText(AppWindow appWindow)
        {
            this.appWindow = appWindow;
        }

        public string WindowTitle => appWindow.Title;
        public string ProcessTitle => appWindow.ProcessTitle;
        public string ExecutablePath => this.appWindow.ExecutablePath;

        public void SwitchTo()
        {
            this.appWindow.SwitchTo();
        }
    }
}