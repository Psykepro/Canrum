using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Microsoft.CSharp;

namespace Main
{
    public static class CodeManager
    {

        public static bool GetOutputFromCompiled(string[] libraries, string[] input, out string[] output)
        {
            var lines = GetProgramLines();

            string exeFileName = "program1.exe";
            bool compiledSuccessfully = CompileCode(lines, exeFileName, libraries);
            if (!compiledSuccessfully)
            {
                output = null;
                return false;
            }

            output = new string[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = RunAndGetOutput(exeFileName, input[i]);
            }
            return true;
        }

        private static string RunAndGetOutput(string exeFileName, string parameter)
        {
            string output;
            using (Process process = new Process())
            {
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.FileName = exeFileName;
                process.StartInfo.WorkingDirectory = ".";
                process.Start();
                string[] inputLines = parameter.Split('\n');
                foreach (string t in inputLines)
                {
                    process.StandardInput.WriteLine(t);
                }
                process.WaitForExit();
                output = process.StandardOutput.ReadToEnd();
                if (output.Length > 2)
                {
                    if (output.Last() == '\n') output = output.Substring(0, output.Length - 1);
                    if (output.Last() == '\r') output = output.Substring(0, output.Length - 1);
                }
            }
            return output;
        }

        private static List<string> GetProgramLines()
        {
            List<string> lines = new List<string> { String.Empty };

            string endCode = "compile";
            Console.WriteLine("You're writing directly in the Main() method. When you're done with the program, type {0} on the last line.\n", endCode);
            Console.SetBufferSize(300, 100);
            //string line = Console.ReadLine();

            /*while (line != endCode)
            {
                lines.Add(line);
                line = Console.ReadLine();
            }

            return lines;*/
            string line = String.Empty;
            int currLine = 0, initialY = Console.CursorTop;
            List<int> previousLinesX = new List<int>();

            while (true)
            {
                var key = Console.ReadKey(true);
                //if (onSpace == true && key.KeyChar == ' ') continue;
                if (key.KeyChar != '\r' &&
                    key.KeyChar != '\b' &&
                    key.KeyChar != '\t' &&
                    key.Key.ToString() != "LeftArrow" &&
                    key.Key.ToString() != "RightArrow" &&
                    key.Key.ToString() != "Home" &&
                    key.Key.ToString() != "End")
                {
                    Console.Write(key.KeyChar);
                    lines[currLine] += key.KeyChar;
                }
                else if (key.KeyChar == '\t')
                {
                    string tab = "    ";
                    Console.Write(tab);
                    lines[currLine] += tab;
                }
                //Console.WriteLine(key.Key.ToString());
                if (key.Key.ToString().Length == 1 && key.Key.ToString()[0] >= 'A' && key.Key.ToString()[0] <= 'Z')
                {
                    //if (onSpace == true) word = key.KeyChar.ToString();
                    //else word += key.KeyChar;
                    //onSpace = false;
                }
                else
                {

                    switch (key.Key.ToString())
                    {
                        case "Spacebar":
                            //onSpace = true;

                            //if (Resources.KeywordsContain(word))
                            //{
                            //    Console.Write(new string('\b', word.Length + 1));
                            //    Console.ForegroundColor = ConsoleColor.DarkCyan;
                            //    Console.Write(word + " ");
                            //    Console.ResetColor();
                            //}
                            //
                            break;

                        case "Backspace":
                            //if (onSpace) onSpace = false;
                            //else word = word.Substring(0, word.Length - 1);

                          if (Console.CursorLeft == 0)
                            {
                                if (currLine != 0)
                                {
                                    lines.RemoveAt(lines.Count - 1);
                                    currLine--;
                                    Console.SetCursorPosition(previousLinesX[currLine], initialY + currLine);
                                }
                            }
                            else
                            {
                                lines[currLine] = lines[currLine].Substring(0, lines[currLine].Length - 1);
                                Console.Write("\b \b");

                            }
                            break;

                        case "Enter":
                            //if(onSpace) Console.Write('\b');
                            if (lines.Last() == endCode)
                            {
                                return lines.Where(l => l != lines.Last()).ToList();
                            }
                            //onSpace = true;
                            FormatLine(lines[currLine], initialY + currLine);
                            if (lines.Count < currLine + 2)
                            {
                                lines.Add(String.Empty);
                                previousLinesX.Add(Console.CursorLeft);
                            }
                            else
                            {
                                previousLinesX[currLine] = Console.CursorLeft;
                            }
                            currLine++;
                            Console.WriteLine();
                            break;
                    }
                }
            }
        }

        private static void FormatLine(string line, int positionY)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            //Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, positionY);
            Console.Write("\r" + line);
            Thread.Sleep(100);
            Console.ResetColor();
            Console.Write("\r");

            string word = String.Empty;
            bool atWord = false;

            for (int i = 0; i < line.Length; i++)
            {
                Console.Write(line[i]);
                if (line[i] >= 'a' && line[i] <= 'z')
                {
                    if (!atWord)
                    {
                        atWord = true;
                        word = line[i].ToString();
                    }
                    else
                    {
                        word += line[i];
                    }
                }
                else
                {
                    if (atWord)
                    {
                        char lastChar = line[i];
                        if (Resources.KeywordsContain(word))
                        {
                            Console.Write(new string('\b', word.Length + 1));
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(word);
                            Console.ResetColor();
                            Console.Write(lastChar.ToString());
                        }
                        atWord = false;
                    }
                }
            }
            if (atWord)
            {
                if (Resources.KeywordsContain(word))
                {
                    Console.Write(new string('\b', word.Length));
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write(word);
                    Console.ResetColor();
                }
                atWord = false;
            }
        }

        private static bool CompileCode(List<string> sourceFile, String exeFile, string[] libraries)
        {
            CodeDomProvider provider = new CSharpCodeProvider();
            CompilerParameters cp = new CompilerParameters();
            List<string> codeLines = new List<string>();
            cp.GenerateExecutable = true;
            cp.OutputAssembly = exeFile;
            cp.IncludeDebugInformation = false;

            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.core.dll");

            cp.GenerateInMemory = false;
            cp.WarningLevel = 1;
            cp.TreatWarningsAsErrors = false;
            cp.CompilerOptions = "/optimize";

            cp.TempFiles = new TempFileCollection(".", false);

            if (provider.Supports(GeneratorSupport.EntryPointMethod))
            {
                cp.MainClass = "ProblemNamespace.ProblemClass";
            }
            if (libraries != null)
                codeLines.AddRange(libraries.Select(l => "using " + l + ";"));
            codeLines.AddRange(new[]
            {
                "using System;\n",
                "namespace ProblemNamespace\n",
                "{\n",
                "class ProblemClass\n",
                "{\n",
                "static void Main(string[] args)\n",
                "{\n"
            });
            codeLines.AddRange(sourceFile);
            codeLines.AddRange(new[]
            {
                //"Console.ReadKey();\n",
                "}\n",
                "}\n",
                "}\n"
            });

            string finalCode = String.Join("", codeLines);
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, finalCode);

            if (cr.Errors.Count > 0)
            {
                Console.WriteLine("Errors building {0} into {1}",
                    sourceFile, cr.PathToAssembly);
                foreach (CompilerError ce in cr.Errors)
                {
                    Console.WriteLine("  {0}", ce.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Source {0} built into {1} successfully.",
                    sourceFile, cr.PathToAssembly);
                Console.WriteLine("{0} temporary files created during the compilation.",
                    cp.TempFiles.Count);
            }

            return cr.Errors.Count <= 0;
        }
    }
}
