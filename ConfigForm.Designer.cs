namespace QuickSupport_v2
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.KEY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.VALUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BENHVIEN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GROUP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TEXT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.simpleButton1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 469);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1183, 51);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(1079, 3);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 39);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Save";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1183, 469);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.KEY,
            this.VALUE,
            this.BENHVIEN_ID,
            this.GROUP,
            this.TEXT});
            this.gridView1.DetailHeight = 377;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // KEY
            // 
            this.KEY.Caption = "KEY";
            this.KEY.FieldName = "KEY";
            this.KEY.MinWidth = 23;
            this.KEY.Name = "KEY";
            this.KEY.OptionsColumn.ReadOnly = true;
            this.KEY.Visible = true;
            this.KEY.VisibleIndex = 2;
            this.KEY.Width = 90;
            // 
            // VALUE
            // 
            this.VALUE.Caption = "VALUE";
            this.VALUE.FieldName = "VALUE";
            this.VALUE.MinWidth = 23;
            this.VALUE.Name = "VALUE";
            this.VALUE.Visible = true;
            this.VALUE.VisibleIndex = 3;
            this.VALUE.Width = 494;
            // 
            // BENHVIEN_ID
            // 
            this.BENHVIEN_ID.Caption = "BENHVIEN_ID";
            this.BENHVIEN_ID.FieldName = "BENHVIEN_ID";
            this.BENHVIEN_ID.MinWidth = 23;
            this.BENHVIEN_ID.Name = "BENHVIEN_ID";
            this.BENHVIEN_ID.Visible = true;
            this.BENHVIEN_ID.VisibleIndex = 1;
            this.BENHVIEN_ID.Width = 286;
            // 
            // GROUP
            // 
            this.GROUP.Caption = "GROUP";
            this.GROUP.FieldName = "GROUP";
            this.GROUP.MinWidth = 23;
            this.GROUP.Name = "GROUP";
            this.GROUP.Visible = true;
            this.GROUP.VisibleIndex = 0;
            this.GROUP.Width = 286;
            // 
            // TEXT
            // 
            this.TEXT.Caption = "TEXT";
            this.TEXT.FieldName = "TEXT";
            this.TEXT.Name = "TEXT";
            this.TEXT.Visible = true;
            this.TEXT.VisibleIndex = 4;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 520);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ConfigForm";
            this.Text = "Config";
            this.Load += new System.EventHandler(this.ConfigForm_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn KEY;
        private DevExpress.XtraGrid.Columns.GridColumn VALUE;
        private DevExpress.XtraGrid.Columns.GridColumn BENHVIEN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn GROUP;
        private DevExpress.XtraGrid.Columns.GridColumn TEXT;
    }
}