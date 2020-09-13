using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32.TaskScheduler;

namespace TaskRun
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs eventArgs)
        {
            Main(eventArgs.Args);
            Shutdown();
        }

        private void Main(string []args)
        {
            if (args.Length > 0)
            {
                TaskService taskService = new TaskService();

                foreach (var taskSpec in args)
                {
                    MessageBox.Show(taskSpec);
                    var task = taskService.FindTask(taskSpec);
                    task?.Run();
                }
            }
        }
    }
}
