using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Chukryong
{
    /// <summary>
    /// 
    /// </summary>
    internal static class Util
    {
        #region string

        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="startText"></param>
        /// <param name="endText"></param>
        /// <returns></returns>
        public static string Substring(this string origin, string startText, string endText)
        {
            return
                origin.Substring(origin.IndexOf(startText) + startText.Length,
                    origin.IndexOf(endText, origin.IndexOf(startText)) - origin.IndexOf(startText) - startText.Length)
                    .Trim();
        }

        #endregion


        #region logging

        public static void Logging(RichTextBox box, string log)
        {
            AppendText(box, Color.DarkRed, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            AppendText(box, Color.Black, string.Format(" - {0}\r\n", log));
        }

        public static void Logging(RichTextBox box, string log, Color color)
        {
            AppendText(box, Color.DarkRed, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            AppendText(box, color, string.Format(" - {0}\r\n", log));
        }

        public static void Logging(RichTextBox box, string log, string log1, Color color)
        {
            AppendText(box, Color.DarkRed, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            AppendText(box, Color.Black, string.Format(" - {0}", log));
            AppendText(box, color, string.Format(" - {0}\r\n", log1));
        }

        public static void Logging(RichTextBox box, string log, string error)
        {
            AppendText(box, Color.DarkRed, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            AppendText(box, Color.Black, string.Format(" - {0}", log));
            AppendText(box, Color.Red, string.Format(" - {0}\r\n", error));
        }

        private static void AppendText(RichTextBox box, Color color, string text)
        {
            int start = box.TextLength;
            box.AppendText(text);
            int end = box.TextLength;

            // Textbox may transform chars, so (end-start) != text.Length
            box.Select(start, end - start);
            {
                box.SelectionColor = color;
                // could set box.SelectionBackColor, box.SelectionFont too.
            }
            box.SelectionLength = 0; // clear

            Application.DoEvents();
        }

        #endregion

        internal static void ErrorLog(MethodBase methodBase, Exception ex, string p)
        {
            throw new NotImplementedException();
        }
    }
}
