namespace Chilano.Iso2God;

partial class FtpGames
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.listViewGames = new Chilano.Common.CListView();
        this.colName = new System.Windows.Forms.ColumnHeader();
        this.colTitleID = new System.Windows.Forms.ColumnHeader();
        this.btnRefresh = new System.Windows.Forms.Button();
        this.btnClose = new System.Windows.Forms.Button();
        this.statusStrip = new System.Windows.Forms.StatusStrip();
        this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
        this.statusStrip.SuspendLayout();
        this.SuspendLayout();
        // 
        // listViewGames
        // 
        this.listViewGames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right)));
        this.listViewGames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        this.colName,
        this.colTitleID});
        this.listViewGames.FullRowSelect = true;
        this.listViewGames.GridLines = true;
        this.listViewGames.HideSelection = false;
        this.listViewGames.Location = new System.Drawing.Point(12, 12);
        this.listViewGames.Name = "listViewGames";
        this.listViewGames.Size = new System.Drawing.Size(460, 297);
        this.listViewGames.TabIndex = 0;
        this.listViewGames.UseCompatibleStateImageBehavior = false;
        this.listViewGames.View = System.Windows.Forms.View.Details;
        // 
        // colName
        // 
        this.colName.Text = "Game Name";
        this.colName.Width = 300;
        // 
        // colTitleID
        // 
        this.colTitleID.Text = "Title ID";
        this.colTitleID.Width = 100;
        // 
        // btnRefresh
        // 
        this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        this.btnRefresh.Location = new System.Drawing.Point(12, 315);
        this.btnRefresh.Name = "btnRefresh";
        this.btnRefresh.Size = new System.Drawing.Size(75, 23);
        this.btnRefresh.TabIndex = 1;
        this.btnRefresh.Text = "Refresh";
        this.btnRefresh.UseVisualStyleBackColor = true;
        this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
        // 
        // btnClose
        // 
        this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.btnClose.Location = new System.Drawing.Point(397, 315);
        this.btnClose.Name = "btnClose";
        this.btnClose.Size = new System.Drawing.Size(75, 23);
        this.btnClose.TabIndex = 2;
        this.btnClose.Text = "Close";
        this.btnClose.UseVisualStyleBackColor = true;
        this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
        // 
        // statusStrip
        // 
        this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        this.lblStatus});
        this.statusStrip.Location = new System.Drawing.Point(0, 349);
        this.statusStrip.Name = "statusStrip";
        this.statusStrip.Size = new System.Drawing.Size(484, 22);
        this.statusStrip.TabIndex = 3;
        this.statusStrip.Text = "statusStrip1";
        // 
        // lblStatus
        // 
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new System.Drawing.Size(26, 17);
        this.lblStatus.Text = "Idle";
        // 
        // FtpGames
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(484, 371);
        this.Controls.Add(this.statusStrip);
        this.Controls.Add(this.btnClose);
        this.Controls.Add(this.btnRefresh);
        this.Controls.Add(this.listViewGames);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FtpGames";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Installed Games via FTP";
        this.Load += new System.EventHandler(this.FtpGames_Load);
        this.statusStrip.ResumeLayout(false);
        this.statusStrip.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    private Chilano.Common.CListView listViewGames;
    private System.Windows.Forms.ColumnHeader colName;
    private System.Windows.Forms.ColumnHeader colTitleID;
    private System.Windows.Forms.Button btnRefresh;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel lblStatus;
}
