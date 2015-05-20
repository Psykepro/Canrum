using System;
using System.Collections.Generic;

namespace Main
{
    public static class Libraries
    {
        private static readonly List<string> libraries = new List<string>()
        {
            "System.Activities",
            "System.AddIn",
            "System.CodeDom",
            "System.Collections.Generic",
            "System.ComponentModel",
            "System.Configuration",
            "System.Data",
            "System.Deployment",
            "System.Device.Location",
            "System.Diagnostics",
            "System.DirectoryServices",
            "System.Dynamic",
            "System.EnterpriseServices",
            "System.Globalization",
            "System.IdentityModel",
            "System.IO",
            "System.Linq",
            "System.Management",
            "System.Media",
            "System.Messaging",
            "System.Net",
            "System.Numerics",
            "System.Printing",
            "System.Reflection",
            "System.Resources",
            "System.Runtime",
            "System.Security",
            "System.ServiceModel",
            "System.ServiceProcess",
            "System.Speech",
            "System.Text",
            "System.Threading",
            "System.Threading.Tasks.Dataflow",
            "System.Timers",
            "System.Transactions",
            "System.Web",
            "System.Windows",
            "System.Workflow",
            "System.Xaml"
        };

        static Libraries() { }

        public static string GetLibraryAsGift(int libraryIndex)
        {
            string libraryHolder = libraries[libraryIndex];

            return libraryHolder;
        }
    }
}