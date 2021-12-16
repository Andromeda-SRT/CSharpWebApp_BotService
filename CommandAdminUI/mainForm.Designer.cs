
namespace CommandAdminUI
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.changeCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createCommandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdataListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView_echo = new System.Windows.Forms.ListView();
            this.UID_command = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sourceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.commandTriggerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.commandAnswer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.commandAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.commandDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView_scripts = new System.Windows.Forms.ListView();
            this.UID_scripts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sourceNames = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scriptName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scriptTrigger = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scriptDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scriptAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.scriptCreationDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Thistle;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeCommandToolStripMenuItem,
            this.deleteCommandToolStripMenuItem,
            this.createCommandToolStripMenuItem,
            this.UpdataListToolStripMenuItem,
            this.aboutProgramToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // changeCommandToolStripMenuItem
            // 
            this.changeCommandToolStripMenuItem.Image = global::CommandAdminUI.Properties.Resources.edit;
            this.changeCommandToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.changeCommandToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changeCommandToolStripMenuItem.Name = "changeCommandToolStripMenuItem";
            this.changeCommandToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.changeCommandToolStripMenuItem.Text = "Редактировать";
            this.changeCommandToolStripMenuItem.Click += new System.EventHandler(this.changeCommandToolStripMenuItem_Click);
            // 
            // deleteCommandToolStripMenuItem
            // 
            this.deleteCommandToolStripMenuItem.Image = global::CommandAdminUI.Properties.Resources.trash;
            this.deleteCommandToolStripMenuItem.Name = "deleteCommandToolStripMenuItem";
            this.deleteCommandToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.deleteCommandToolStripMenuItem.Text = "Удалить";
            this.deleteCommandToolStripMenuItem.Click += new System.EventHandler(this.deleteCommandToolStripMenuItem_Click);
            // 
            // createCommandToolStripMenuItem
            // 
            this.createCommandToolStripMenuItem.Image = global::CommandAdminUI.Properties.Resources.add_command;
            this.createCommandToolStripMenuItem.Name = "createCommandToolStripMenuItem";
            this.createCommandToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.createCommandToolStripMenuItem.Text = "Создать команду";
            this.createCommandToolStripMenuItem.Click += new System.EventHandler(this.createCommandToolStripMenuItem_Click);
            // 
            // UpdataListToolStripMenuItem
            // 
            this.UpdataListToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.UpdataListToolStripMenuItem.Image = global::CommandAdminUI.Properties.Resources.refresh;
            this.UpdataListToolStripMenuItem.Name = "UpdataListToolStripMenuItem";
            this.UpdataListToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.UpdataListToolStripMenuItem.Text = "Обновить";
            this.UpdataListToolStripMenuItem.Click += new System.EventHandler(this.UpdataListToolStripMenuItem_Click_1);
            // 
            // aboutProgramToolStripMenuItem
            // 
            this.aboutProgramToolStripMenuItem.Image = global::CommandAdminUI.Properties.Resources.information;
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.aboutProgramToolStripMenuItem.Text = "О программе";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 24);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 426);
            this.tabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView_echo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 400);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Echo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView_echo
            // 
            this.listView_echo.BackColor = System.Drawing.Color.Thistle;
            this.listView_echo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UID_command,
            this.sourceName,
            this.commandTriggerName,
            this.commandAnswer,
            this.commandAuthor,
            this.commandDate});
            this.listView_echo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_echo.FullRowSelect = true;
            this.listView_echo.GridLines = true;
            this.listView_echo.HideSelection = false;
            this.listView_echo.Location = new System.Drawing.Point(3, 3);
            this.listView_echo.Name = "listView_echo";
            this.listView_echo.Size = new System.Drawing.Size(786, 394);
            this.listView_echo.TabIndex = 0;
            this.listView_echo.UseCompatibleStateImageBehavior = false;
            this.listView_echo.View = System.Windows.Forms.View.Details;
            // 
            // UID_command
            // 
            this.UID_command.Text = "UID";
            this.UID_command.Width = 38;
            // 
            // sourceName
            // 
            this.sourceName.Text = "Source";
            this.sourceName.Width = 52;
            // 
            // commandTriggerName
            // 
            this.commandTriggerName.Text = "Trigger";
            this.commandTriggerName.Width = 98;
            // 
            // commandAnswer
            // 
            this.commandAnswer.Text = "Answer";
            this.commandAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.commandAnswer.Width = 447;
            // 
            // commandAuthor
            // 
            this.commandAuthor.Text = "Author";
            this.commandAuthor.Width = 67;
            // 
            // commandDate
            // 
            this.commandDate.Text = "CreationDate";
            this.commandDate.Width = 78;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView_scripts);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 400);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Scripts";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView_scripts
            // 
            this.listView_scripts.BackColor = System.Drawing.Color.Thistle;
            this.listView_scripts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UID_scripts,
            this.sourceNames,
            this.scriptName,
            this.scriptTrigger,
            this.scriptDescription,
            this.scriptAuthor,
            this.scriptCreationDate});
            this.listView_scripts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_scripts.FullRowSelect = true;
            this.listView_scripts.GridLines = true;
            this.listView_scripts.HideSelection = false;
            this.listView_scripts.Location = new System.Drawing.Point(3, 3);
            this.listView_scripts.Name = "listView_scripts";
            this.listView_scripts.Size = new System.Drawing.Size(786, 394);
            this.listView_scripts.TabIndex = 0;
            this.listView_scripts.UseCompatibleStateImageBehavior = false;
            this.listView_scripts.View = System.Windows.Forms.View.Details;
            // 
            // UID_scripts
            // 
            this.UID_scripts.Text = "UID";
            this.UID_scripts.Width = 49;
            // 
            // sourceNames
            // 
            this.sourceNames.Text = "Source";
            // 
            // scriptName
            // 
            this.scriptName.Text = "Name";
            this.scriptName.Width = 50;
            // 
            // scriptTrigger
            // 
            this.scriptTrigger.Text = "Trigger";
            this.scriptTrigger.Width = 69;
            // 
            // scriptDescription
            // 
            this.scriptDescription.Text = "Body";
            this.scriptDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.scriptDescription.Width = 401;
            // 
            // scriptAuthor
            // 
            this.scriptAuthor.Text = "Author";
            this.scriptAuthor.Width = 82;
            // 
            // scriptCreationDate
            // 
            this.scriptCreationDate.Text = "CreationDate";
            this.scriptCreationDate.Width = 78;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.Text = "Command Administrator";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem changeCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createCommandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UpdataListToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView listView_echo;
        private System.Windows.Forms.ColumnHeader UID_command;
        private System.Windows.Forms.ColumnHeader sourceName;
        private System.Windows.Forms.ColumnHeader commandTriggerName;
        private System.Windows.Forms.ColumnHeader commandAnswer;
        private System.Windows.Forms.ColumnHeader commandAuthor;
        private System.Windows.Forms.ColumnHeader commandDate;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView_scripts;
        private System.Windows.Forms.ColumnHeader UID_scripts;
        private System.Windows.Forms.ColumnHeader scriptName;
        private System.Windows.Forms.ColumnHeader scriptTrigger;
        private System.Windows.Forms.ColumnHeader scriptDescription;
        private System.Windows.Forms.ColumnHeader scriptAuthor;
        private System.Windows.Forms.ColumnHeader scriptCreationDate;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader sourceNames;
    }
}

