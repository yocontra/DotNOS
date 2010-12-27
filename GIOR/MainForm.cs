using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GIOR.Util;

namespace GIOR
{
    public partial class MainForm : Form
    {
        public LogHandler Logger = new LogHandler("Main");
        #region Singleton
        static MainForm _instance;
        static readonly object PadLock = new object();

        public static MainForm Instance
        {
            get
            {
                lock (PadLock)
                {
                    return _instance ?? (_instance = new MainForm());
                }
            }
        }
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }
        public void AddToCrackLog(string value)
        {
            if (!InvokeRequired)
            {
                Instance.logTextBox.Text += value;
            }
            else
            {
                Invoke(new Action<string>(AddToCrackLog), new object[] { value });
                return;
            }
        }
        private void FileSelectButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "EXE files (*.exe)|*.exe|DLL files (*.dll)|*.dll",
                InitialDirectory = "C:/",
                Title = "Select an Assembly"
            };
            Instance.fileSelectTextBox.Text = (dialog.ShowDialog() == DialogResult.OK) ? dialog.FileName : "";
            StartTransformer();
        }
        private void StartTransformer()
        {
            logTextBox.Text = "";
            fileSelectTextBox.Enabled = false;
            FileSelectButton.Enabled = false;
            Logger.Log("Starting Transformer!");
            HeavyWorker.RunWorkerAsync();
        }
        private void HeavyWorkerRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Logger.Log("Operation Completed!");
            fileSelectTextBox.Enabled = true;
            FileSelectButton.Enabled = true;
        }
        private void HeavyWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            Transformer trans = new Transformer(fileSelectTextBox.Text);
            trans.Load();
            trans.Transform();
            trans.Save();
        }
    }
}
