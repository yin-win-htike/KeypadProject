using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeypadProject.Utility
{
    public static class TextDecoder
    {
        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "????";

            StringBuilder output = new StringBuilder();
            input = input.Trim();
            if (input.EndsWith('#'))// remove the last # charactor
                input = input.Remove(input.Length - 1, 1);

            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);// split by space
            foreach (string part in parts)
            {
                var segment = part;
                if (string.IsNullOrWhiteSpace(segment))
                    continue;

                // Backspace function
                if (segment.Contains("*"))
                    BackspaceFunction(ref segment);


                var currentKey = segment[0]; // get the 1st key
                var pressedCount = 1; 

              
                for (int i = 1; i < segment.Length; i++)
                {
                    var test = segment[i];
                    if (segment[i] == currentKey && (pressedCount + 1) <= ButtonMapper.ButtonMapping[currentKey.ToString()].Length)
                        pressedCount++; 
                    else
                    {
                           
                        output.Append(GetExactLetter(currentKey.ToString(), pressedCount - 1));

                        if (!Regex.IsMatch(segment[i].ToString(), @"^\d+$"))
                        {
                            output.Append(segment[i].ToString());
                            pressedCount = 0;
                            continue;
                        }


                        currentKey = segment[i];
                        pressedCount = 1;

                        if (i == segment.Length - 1)
                            output.Append(GetExactLetter(currentKey.ToString(), pressedCount - 1));
                    }
                }

                if (segment.Length == 1 || pressedCount > 1)
                    output.Append(GetExactLetter(currentKey.ToString(), pressedCount - 1));

            }

            return output.ToString();
        }

        private static void BackspaceFunction(ref string segment)
        {

            int asteriskCount = segment.Count(c => c == '*');
            while (asteriskCount > 0)
            {
                int asteriskIndex = segment.IndexOf("*");
                if (asteriskIndex > 0)
                {
                    segment = segment.Remove(asteriskIndex - 1, 2);
                }
                else if (asteriskIndex == 0)
                {
                    segment = segment.Remove(0, 1);
                }

                asteriskCount = segment.Count(c => c == '*');
                if (asteriskCount > 0)
                    BackspaceFunction(ref segment);
            }
        }

        private static char GetExactLetter(string currentKey, int pressedCount)
        {
            var charactors = ButtonMapper.ButtonMapping[currentKey.ToString()]; 
            return charactors[pressedCount % charactors.Length];


        }
    }
}
