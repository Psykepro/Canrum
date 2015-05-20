using System;
using System.Collections.Generic;
using System.Linq;

namespace Main
{
    public static class Resources
    {
        private static readonly string[] Libraries =
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

        private static readonly string[] BossNames =
        {
            "Filkolev",
            "a_rusenov",
            "achebg",
            "Bi0GaMe",
            "vladislav.karamfilov",
            "iordan_93",
            "VGeorgiev",
            "nikbikbank",
            "RoYaL",
            "mpeshev",
            "Nakov"
        };

        public static string GetRandomLibrary()
        {
            int randomIndex = (new Random()).Next(Libraries.Length);
            return Libraries[randomIndex];
        }

        private static string GetRandomBossName(int level)
        {
            int randomIndex = Libraries.Count()-1;
            while (level != 5 && randomIndex == Libraries.Count()-1)
            {
                randomIndex = (new Random()).Next(Libraries.Length);
            }
            return BossNames[randomIndex];
        }
    }
}