﻿using System;
using System.Threading;
using System.Windows.Forms;

namespace Chem4WordUpdater
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            bool created;
            using (new Mutex(true, "e02309d1-6734-4b66-a31d-76439a9ee978", out created))
            {
                if (created)
                {
                    RegistryHelper.WriteAction("Starting Updater");

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Updater(args));
                }
                else
                {
                    RegistryHelper.WriteAction("Updater is already running");
                }
            }
        }
    }
}