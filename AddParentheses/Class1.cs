using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace AddParentheses
{

    public class Class1
    {
         static void Main()
        {
            string inPath = @"C:\Users\rstagemeyer\Documents\WordPress\Web Host\Workspace_Files\Maps\State_Coordinates\states.txt";
            string inPath2 = @"C:\Users\rstagemeyer\Documents\WordPress\Web Host\Workspace_Files\Maps\State_Coordinates\poly.txt";
            string[] lines = File.ReadAllLines(inPath2);

            string outPath = @"C:\Users\rstagemeyer\Documents\WordPress\Web Host\Workspace_Files\Maps\State_Coordinates\states_parsed.txt";
            string outPath2 = @"C:\Users\rstagemeyer\Documents\WordPress\Web Host\Workspace_Files\Maps\State_Coordinates\states_parsed2.txt";
            string outPath3 = @"C:\Users\rstagemeyer\Documents\WordPress\Web Host\Workspace_Files\Maps\State_Coordinates\states_parsed3.txt";
            string stateParsedTxt = "";
            using (StreamWriter strmWrt = new System.IO.StreamWriter(outPath3))
            {
                foreach (string line in lines)
                {
                    if (line.Contains("/state"))
                    {
                        strmWrt.WriteLine(stateParsedTxt);
                        strmWrt.WriteLine(line);
                        strmWrt.WriteLine("");
                    }
                    else if (line.Contains("state"))
                    {
                        strmWrt.WriteLine(line);
                        stateParsedTxt = "";
                    }
                    else
                    {
                        stateParsedTxt += line.Replace("(", "{lat: ").Replace(", ", ", lng: ").Replace(")", "}");
                    }

                    /*
                    if(line.Contains("</state>"))
                    {
                        strmWrt.WriteLine(stateParsedTxt);
                        strmWrt.WriteLine("");
                    }
                    else if (line.Contains("state name"))
                    {
                        stateParsedTxt = "";
                        string[] toks = line.Split('=');
                        string stateName = "";
                        if (toks.Length == 3)
                        {
                            stateName = toks[1].Substring(1, (toks[1].Length - 9));
                            strmWrt.WriteLine(stateName);
                        };
                    }
                    else if (line.Contains("point"))
                    {
                        string[] toks = line.Split('\"');
                        string lat = toks[1].Split('\"')[0];
                        string longitude = toks[3].Split('\"')[0];
                        //stateParsedTxt += "(" + lat + ", " + longitude + "),";
                        stateParsedTxt += "{lat: " + lat + ", lng: " + longitude + "},";
                    }
                    */

                }
            }
        }
    }
}
