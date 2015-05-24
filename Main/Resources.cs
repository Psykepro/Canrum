using System;
using System.Linq;

namespace Main
{
    public static class Resources
    {
        private static readonly string[] Libraries =
        {
            "System.Collections.Generic",
            "System.Globalization",
            "System.IO",
            "System.Linq",
            "System.Media",
            "System.Numerics",
            "System.Text.RegularExpressions;",
            "System.Threading",
            "System.Timers"
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

        private static readonly string[] Keywords =
        {
            "abstract","add","as","ascending","async","await","base","bool","break","by","byte","case","catch","char","checked","class","const","continue","decimal","default","delegate","descending","do","double","dynamic","else","enum","equals","explicit","extern","false","finally","fixed","float","for","foreach","from","get","globalgoto","group","if","implicit","in","int","interface","internal","into","is","join","let","lock","long","namespace","new","null","object","on","operator","orderby","out","override","params","partial","private","protected","public","readonly","ref","remove","return","sbyte","sealed","select","set","short","sizeof","stackalloc","static","string","struct","switch","this","throw","true","try","typeof","uint","ulong","unchecked","unsafe","ushort","using","value","var","virtual","void","volatile","where","while","yield"
        };

        public static bool KeywordsContain(string word)
        {
            return Keywords.Contains(word);
        }

        public static string GetRandomAward()
        {
            int randomIndex = (new Random()).Next(Libraries.Length);
            return Libraries[randomIndex];
        }

        public static string GetRandomBoss()
        {
            int randomIndex = (new Random()).Next(BossNames.Length - 1);
            return BossNames[randomIndex];
        }

        public static string GetFinalBoss()
        {
            return BossNames.Last();
        }
    }
}