
namespace CommandAdminUI.EditCommand
{
    partial class EditCommandForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCommandForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_updata = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_bodyScript = new System.Windows.Forms.GroupBox();
            this.btn_openFile = new System.Windows.Forms.Button();
            this.richTextBox_bodyScript = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_choiseSource = new System.Windows.Forms.GroupBox();
            this.checkBox_telegram = new System.Windows.Forms.CheckBox();
            this.checkBox_vk = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_trigger = new System.Windows.Forms.GroupBox();
            this.radioButton_triggerTypeMinus = new System.Windows.Forms.RadioButton();
            this.radioButton_triggerTypeExclamatory = new System.Windows.Forms.RadioButton();
            this.radioButton_triggerTypeSlesh = new System.Windows.Forms.RadioButton();
            this.radioButton_triggerTypeDot = new System.Windows.Forms.RadioButton();
            this.radioButton_word = new System.Windows.Forms.RadioButton();
            this.groupBox_answer = new System.Windows.Forms.GroupBox();
            this.richTextBox_answer = new System.Windows.Forms.RichTextBox();
            this.groupBox_name = new System.Windows.Forms.GroupBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox_bodyScript.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox_choiseSource.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox_trigger.SuspendLayout();
            this.groupBox_answer.SuspendLayout();
            this.groupBox_name.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Thistle;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.95599F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.24205F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.717949F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 409);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_cancel);
            this.flowLayoutPanel1.Controls.Add(this.btn_updata);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 376);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(806, 30);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Thistle;
            this.btn_cancel.Image = global::CommandAdminUI.Properties.Resources.cancel;
            this.btn_cancel.Location = new System.Drawing.Point(709, 3);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btn_cancel.Size = new System.Drawing.Size(94, 26);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_updata
            // 
            this.btn_updata.BackColor = System.Drawing.Color.Thistle;
            this.btn_updata.Image = global::CommandAdminUI.Properties.Resources.apply;
            this.btn_updata.Location = new System.Drawing.Point(605, 3);
            this.btn_updata.Name = "btn_updata";
            this.btn_updata.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btn_updata.Size = new System.Drawing.Size(98, 26);
            this.btn_updata.TabIndex = 1;
            this.btn_updata.Text = "Updata";
            this.btn_updata.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_updata.UseVisualStyleBackColor = false;
            this.btn_updata.Click += new System.EventHandler(this.btn_updata_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.41667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.58334F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox_bodyScript, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 11);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(806, 359);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // groupBox_bodyScript
            // 
            this.groupBox_bodyScript.Controls.Add(this.btn_openFile);
            this.groupBox_bodyScript.Controls.Add(this.richTextBox_bodyScript);
            this.groupBox_bodyScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_bodyScript.Location = new System.Drawing.Point(288, 3);
            this.groupBox_bodyScript.Name = "groupBox_bodyScript";
            this.groupBox_bodyScript.Size = new System.Drawing.Size(515, 353);
            this.groupBox_bodyScript.TabIndex = 0;
            this.groupBox_bodyScript.TabStop = false;
            this.groupBox_bodyScript.Text = "Body Script";
            // 
            // btn_openFile
            // 
            this.btn_openFile.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_openFile.Location = new System.Drawing.Point(3, 327);
            this.btn_openFile.Name = "btn_openFile";
            this.btn_openFile.Size = new System.Drawing.Size(509, 23);
            this.btn_openFile.TabIndex = 2;
            this.btn_openFile.Text = "Open File";
            this.btn_openFile.UseVisualStyleBackColor = true;
            this.btn_openFile.Click += new System.EventHandler(this.btn_openFile_Click);
            // 
            // richTextBox_bodyScript
            // 
            this.richTextBox_bodyScript.BackColor = System.Drawing.Color.Thistle;
            this.richTextBox_bodyScript.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox_bodyScript.Location = new System.Drawing.Point(3, 16);
            this.richTextBox_bodyScript.Name = "richTextBox_bodyScript";
            this.richTextBox_bodyScript.Size = new System.Drawing.Size(509, 309);
            this.richTextBox_bodyScript.TabIndex = 0;
            this.richTextBox_bodyScript.Text = "";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox_choiseSource, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(279, 353);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // groupBox_choiseSource
            // 
            this.groupBox_choiseSource.Controls.Add(this.checkBox_telegram);
            this.groupBox_choiseSource.Controls.Add(this.checkBox_vk);
            this.groupBox_choiseSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_choiseSource.Location = new System.Drawing.Point(3, 3);
            this.groupBox_choiseSource.Name = "groupBox_choiseSource";
            this.groupBox_choiseSource.Size = new System.Drawing.Size(273, 52);
            this.groupBox_choiseSource.TabIndex = 0;
            this.groupBox_choiseSource.TabStop = false;
            this.groupBox_choiseSource.Text = "Choise Source";
            // 
            // checkBox_telegram
            // 
            this.checkBox_telegram.AutoSize = true;
            this.checkBox_telegram.Location = new System.Drawing.Point(53, 20);
            this.checkBox_telegram.Name = "checkBox_telegram";
            this.checkBox_telegram.Size = new System.Drawing.Size(70, 17);
            this.checkBox_telegram.TabIndex = 1;
            this.checkBox_telegram.Text = "Telegram";
            this.checkBox_telegram.UseVisualStyleBackColor = true;
            // 
            // checkBox_vk
            // 
            this.checkBox_vk.AutoSize = true;
            this.checkBox_vk.Location = new System.Drawing.Point(7, 20);
            this.checkBox_vk.Name = "checkBox_vk";
            this.checkBox_vk.Size = new System.Drawing.Size(40, 17);
            this.checkBox_vk.TabIndex = 0;
            this.checkBox_vk.Text = "VK";
            this.checkBox_vk.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.groupBox_trigger, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBox_answer, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.groupBox_name, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 61);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.58824F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.84874F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.56303F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(273, 289);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // groupBox_trigger
            // 
            this.groupBox_trigger.Controls.Add(this.radioButton_triggerTypeMinus);
            this.groupBox_trigger.Controls.Add(this.radioButton_triggerTypeExclamatory);
            this.groupBox_trigger.Controls.Add(this.radioButton_triggerTypeSlesh);
            this.groupBox_trigger.Controls.Add(this.radioButton_triggerTypeDot);
            this.groupBox_trigger.Controls.Add(this.radioButton_word);
            this.groupBox_trigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_trigger.Location = new System.Drawing.Point(3, 3);
            this.groupBox_trigger.Name = "groupBox_trigger";
            this.groupBox_trigger.Size = new System.Drawing.Size(267, 53);
            this.groupBox_trigger.TabIndex = 0;
            this.groupBox_trigger.TabStop = false;
            this.groupBox_trigger.Text = "Trigger";
            // 
            // radioButton_triggerTypeMinus
            // 
            this.radioButton_triggerTypeMinus.AutoSize = true;
            this.radioButton_triggerTypeMinus.Location = new System.Drawing.Point(172, 20);
            this.radioButton_triggerTypeMinus.Name = "radioButton_triggerTypeMinus";
            this.radioButton_triggerTypeMinus.Size = new System.Drawing.Size(28, 17);
            this.radioButton_triggerTypeMinus.TabIndex = 4;
            this.radioButton_triggerTypeMinus.Text = "-";
            this.radioButton_triggerTypeMinus.UseVisualStyleBackColor = true;
            // 
            // radioButton_triggerTypeExclamatory
            // 
            this.radioButton_triggerTypeExclamatory.AutoSize = true;
            this.radioButton_triggerTypeExclamatory.Location = new System.Drawing.Point(137, 20);
            this.radioButton_triggerTypeExclamatory.Name = "radioButton_triggerTypeExclamatory";
            this.radioButton_triggerTypeExclamatory.Size = new System.Drawing.Size(28, 17);
            this.radioButton_triggerTypeExclamatory.TabIndex = 3;
            this.radioButton_triggerTypeExclamatory.Text = "!";
            this.radioButton_triggerTypeExclamatory.UseVisualStyleBackColor = true;
            // 
            // radioButton_triggerTypeSlesh
            // 
            this.radioButton_triggerTypeSlesh.AutoSize = true;
            this.radioButton_triggerTypeSlesh.Location = new System.Drawing.Point(100, 20);
            this.radioButton_triggerTypeSlesh.Name = "radioButton_triggerTypeSlesh";
            this.radioButton_triggerTypeSlesh.Size = new System.Drawing.Size(30, 17);
            this.radioButton_triggerTypeSlesh.TabIndex = 2;
            this.radioButton_triggerTypeSlesh.Text = "/";
            this.radioButton_triggerTypeSlesh.UseVisualStyleBackColor = true;
            // 
            // radioButton_triggerTypeDot
            // 
            this.radioButton_triggerTypeDot.AutoSize = true;
            this.radioButton_triggerTypeDot.Location = new System.Drawing.Point(65, 20);
            this.radioButton_triggerTypeDot.Name = "radioButton_triggerTypeDot";
            this.radioButton_triggerTypeDot.Size = new System.Drawing.Size(28, 17);
            this.radioButton_triggerTypeDot.TabIndex = 1;
            this.radioButton_triggerTypeDot.Text = ".";
            this.radioButton_triggerTypeDot.UseVisualStyleBackColor = true;
            // 
            // radioButton_word
            // 
            this.radioButton_word.AutoSize = true;
            this.radioButton_word.Checked = true;
            this.radioButton_word.Location = new System.Drawing.Point(7, 20);
            this.radioButton_word.Name = "radioButton_word";
            this.radioButton_word.Size = new System.Drawing.Size(51, 17);
            this.radioButton_word.TabIndex = 0;
            this.radioButton_word.TabStop = true;
            this.radioButton_word.Text = "Word";
            this.radioButton_word.UseVisualStyleBackColor = true;
            // 
            // groupBox_answer
            // 
            this.groupBox_answer.Controls.Add(this.richTextBox_answer);
            this.groupBox_answer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_answer.Location = new System.Drawing.Point(3, 125);
            this.groupBox_answer.Name = "groupBox_answer";
            this.groupBox_answer.Size = new System.Drawing.Size(267, 161);
            this.groupBox_answer.TabIndex = 1;
            this.groupBox_answer.TabStop = false;
            this.groupBox_answer.Text = "Answer";
            // 
            // richTextBox_answer
            // 
            this.richTextBox_answer.BackColor = System.Drawing.Color.Thistle;
            this.richTextBox_answer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_answer.Location = new System.Drawing.Point(3, 16);
            this.richTextBox_answer.Name = "richTextBox_answer";
            this.richTextBox_answer.Size = new System.Drawing.Size(261, 142);
            this.richTextBox_answer.TabIndex = 0;
            this.richTextBox_answer.Text = "";
            // 
            // groupBox_name
            // 
            this.groupBox_name.Controls.Add(this.textBox_name);
            this.groupBox_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_name.Location = new System.Drawing.Point(3, 62);
            this.groupBox_name.Name = "groupBox_name";
            this.groupBox_name.Size = new System.Drawing.Size(267, 57);
            this.groupBox_name.TabIndex = 2;
            this.groupBox_name.TabStop = false;
            this.groupBox_name.Text = "Word";
            // 
            // textBox_name
            // 
            this.textBox_name.BackColor = System.Drawing.Color.Thistle;
            this.textBox_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_name.Location = new System.Drawing.Point(3, 16);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(261, 20);
            this.textBox_name.TabIndex = 0;
            // 
            // EditCommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 409);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditCommandForm";
            this.Text = "EditForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox_bodyScript.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox_choiseSource.ResumeLayout(false);
            this.groupBox_choiseSource.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupBox_trigger.ResumeLayout(false);
            this.groupBox_trigger.PerformLayout();
            this.groupBox_answer.ResumeLayout(false);
            this.groupBox_name.ResumeLayout(false);
            this.groupBox_name.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_updata;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox_bodyScript;
        private System.Windows.Forms.RichTextBox richTextBox_bodyScript;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox groupBox_choiseSource;
        private System.Windows.Forms.CheckBox checkBox_telegram;
        private System.Windows.Forms.CheckBox checkBox_vk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox groupBox_trigger;
        private System.Windows.Forms.RadioButton radioButton_triggerTypeMinus;
        private System.Windows.Forms.RadioButton radioButton_triggerTypeExclamatory;
        private System.Windows.Forms.RadioButton radioButton_triggerTypeSlesh;
        private System.Windows.Forms.RadioButton radioButton_triggerTypeDot;
        private System.Windows.Forms.RadioButton radioButton_word;
        private System.Windows.Forms.GroupBox groupBox_answer;
        private System.Windows.Forms.RichTextBox richTextBox_answer;
        private System.Windows.Forms.GroupBox groupBox_name;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Button btn_openFile;
    }
}