using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sbfl_lfg {
    static class Program {
        public static MainForm MainForm;
        private static Mutex _AppMutex;
        public static SbflClient BotClient;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            string guid = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), false).GetValue(0)).Value.ToString();
            string mutexName = string.Format("Global\\{0}", guid);
            bool createdNew;
            _AppMutex = new Mutex(true, mutexName, out createdNew);
            if (!createdNew)
                return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InitBotClient();

            RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            rkApp.SetValue("sbfl-lfg", Application.ExecutablePath.ToString());

            MainForm = new MainForm();
            Application.Run();
        }

        public static void InitBotClient() {
            while (true) {
                try {
                    NetworkCredential nc = new NetworkCredential(Properties.Settings.Default.SBFLUsername, Properties.Settings.Default.SBFLPassword);
                    BotClient = new SbflClient(nc);
                    BotClient.GetGames();
                    break;
                } catch (WebException) {
                    SettingsForm sf = new SettingsForm();
                    if (sf.ShowDialog() != DialogResult.OK)
                        return;
                }
            }
        }
    }
}
