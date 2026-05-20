using EnterpriseDT.Net.Ftp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Chilano.Iso2God;

public partial class FtpGames : Form
{
    private BackgroundWorker scanner;

    public FtpGames()
    {
        InitializeComponent();
        scanner = new BackgroundWorker();
        scanner.DoWork += Scanner_DoWork;
        scanner.RunWorkerCompleted += Scanner_RunWorkerCompleted;
    }

    private void FtpGames_Load(object sender, EventArgs e)
    {
        StartScan();
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        StartScan();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void StartScan()
    {
        if (scanner.IsBusy) return;
        listViewGames.Items.Clear();
        lblStatus.Text = "Connecting...";
        btnRefresh.Enabled = false;

        string ip = Properties.Settings.Default["FtpIP"].ToString();
        string user = Properties.Settings.Default["FtpUser"].ToString();
        string pass = Properties.Settings.Default["FtpPass"].ToString();
        string port = Properties.Settings.Default["FtpPort"].ToString();

        if (string.IsNullOrEmpty(ip))
        {
            MessageBox.Show("Please configure FTP settings first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblStatus.Text = "FTP not configured";
            btnRefresh.Enabled = true;
            return;
        }

        scanner.RunWorkerAsync(new string[] { ip, user, pass, port });
    }

    private void Scanner_DoWork(object sender, DoWorkEventArgs e)
    {
        string[] args = (string[])e.Argument;
        string ip = args[0];
        string user = args[1];
        string pass = args[2];
        int port = 21;
        int.TryParse(args[3], out port);

        FTPConnection ftp = new FTPConnection();
        ftp.ServerAddress = ip;
        ftp.ServerPort = port;
        ftp.UserName = user;
        ftp.Password = pass;
        ftp.AutoLogin = true;

        List<ListViewItem> items = new List<ListViewItem>();

        try
        {
            ftp.Connect();

            string ftpPath = "Hdd1/Content/0000000000000000";
            if (Properties.Settings.Default.FtpPathType == 0)
            {
                switch (Properties.Settings.Default.FtpPathDefaults)
                {
                    case 1: ftpPath = "Usb0/Content/0000000000000000"; break;
                    case 2: ftpPath = "Usb1/Content/0000000000000000"; break;
                }
            }
            else
            {
                ftpPath = Properties.Settings.Default["FtpPathCustom"].ToString();
            }

            try
            {
                ftp.ChangeWorkingDirectory(ftpPath);
                FTPFile[] files = ftp.GetFileInfos();
                foreach (var file in files)
                {
                    if (file.Dir)
                    {
                        string titleID = file.Name;
                        if (titleID.Length == 8) // Title IDs are usually 8 chars hex
                        {
                            string gameName = Utils.getCsvTitle(titleID, Main.file_listxbox360);
                            if (string.IsNullOrEmpty(gameName))
                                gameName = Utils.getCsvTitle(titleID, Main.file_listxbox);
                            if (string.IsNullOrEmpty(gameName))
                                gameName = "Unknown Game";

                            ListViewItem item = new ListViewItem(gameName);
                            item.SubItems.Add(titleID);
                            items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error accessing path " + ftpPath + ": " + ex.Message);
            }

            ftp.Close();
        }
        catch (Exception ex)
        {
            e.Result = ex;
            return;
        }

        e.Result = items;
    }

    private void Scanner_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        btnRefresh.Enabled = true;

        if (e.Result is Exception)
        {
            Exception ex = (Exception)e.Result;
            MessageBox.Show(ex.Message, "FTP Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblStatus.Text = "Error";
        }
        else if (e.Result is List<ListViewItem>)
        {
            List<ListViewItem> items = (List<ListViewItem>)e.Result;
            listViewGames.BeginUpdate();
            foreach (var item in items)
            {
                listViewGames.Items.Add(item);
            }
            listViewGames.EndUpdate();
            lblStatus.Text = "Found " + items.Count + " games.";
        }
    }
}
