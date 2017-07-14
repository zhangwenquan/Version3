﻿using Chem4Word.Core.UI.Forms;
using System;
using System.Reflection;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Chem4Word.Library
{
    public partial class LibraryHost : UserControl
    {
        private static string _product = Assembly.GetExecutingAssembly().FullName.Split(',')[0];
        private static string _class = MethodBase.GetCurrentMethod().DeclaringType.Name;

        public LibraryHost()
        {
            InitializeComponent();
        }

        public override void Refresh()
        {
            string module = $"{_product}.{_class}.{MethodBase.GetCurrentMethod().Name}()";
            try
            {
                Word.Application app = Globals.Chem4WordV3.Application;
                using (new UI.WaitCursor())
                {
                    libraryView1.MainGrid.DataContext = new LibraryViewModel();
                }
                app.System.Cursor = Word.WdCursorType.wdCursorNormal;
            }
            catch (Exception ex)
            {
                new ReportError(Globals.Chem4WordV3.Telemetry, Globals.Chem4WordV3.WordTopLeft, module, ex.Message, ex.StackTrace).ShowDialog();
            }
        }

        private void LibraryHost_Load(object sender, EventArgs e)
        {
        }
    }
}