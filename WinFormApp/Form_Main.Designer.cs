namespace WinFormApp
{
    partial class Form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.Panel_Main = new System.Windows.Forms.Panel();
            this.Panel_Client = new System.Windows.Forms.Panel();
            this.Panel_ArrangementAndCombination = new System.Windows.Forms.Panel();
            this.Label_AppName = new System.Windows.Forms.Label();
            this.Label_Note = new System.Windows.Forms.Label();
            this.Label_ReturnToZero = new System.Windows.Forms.Label();
            this.Panel_Input = new System.Windows.Forms.Panel();
            this.Label_AC = new System.Windows.Forms.Label();
            this.Label_Total = new System.Windows.Forms.Label();
            this.ContextMenuStrip_Total = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Total_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Total_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.Label_Selection = new System.Windows.Forms.Label();
            this.ContextMenuStrip_Selection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Selection_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Selection_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.Panel_Output = new System.Windows.Forms.Panel();
            this.ContextMenuStrip_Output = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Output_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.Label_Equal = new System.Windows.Forms.Label();
            this.Label_Val = new System.Windows.Forms.Label();
            this.Label_Exp = new System.Windows.Forms.Label();
            this.Label_Time = new System.Windows.Forms.Label();
            this.Panel_Main.SuspendLayout();
            this.Panel_Client.SuspendLayout();
            this.Panel_ArrangementAndCombination.SuspendLayout();
            this.Panel_Input.SuspendLayout();
            this.ContextMenuStrip_Total.SuspendLayout();
            this.ContextMenuStrip_Selection.SuspendLayout();
            this.Panel_Output.SuspendLayout();
            this.ContextMenuStrip_Output.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel_Main
            // 
            this.Panel_Main.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Main.Controls.Add(this.Panel_Client);
            this.Panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_Main.Location = new System.Drawing.Point(0, 0);
            this.Panel_Main.Name = "Panel_Main";
            this.Panel_Main.Size = new System.Drawing.Size(450, 225);
            this.Panel_Main.TabIndex = 0;
            // 
            // Panel_Client
            // 
            this.Panel_Client.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Client.Controls.Add(this.Panel_ArrangementAndCombination);
            this.Panel_Client.Location = new System.Drawing.Point(0, 0);
            this.Panel_Client.Name = "Panel_Client";
            this.Panel_Client.Size = new System.Drawing.Size(450, 225);
            this.Panel_Client.TabIndex = 0;
            // 
            // Panel_ArrangementAndCombination
            // 
            this.Panel_ArrangementAndCombination.BackColor = System.Drawing.Color.Transparent;
            this.Panel_ArrangementAndCombination.Controls.Add(this.Label_AppName);
            this.Panel_ArrangementAndCombination.Controls.Add(this.Label_Note);
            this.Panel_ArrangementAndCombination.Controls.Add(this.Label_ReturnToZero);
            this.Panel_ArrangementAndCombination.Controls.Add(this.Panel_Input);
            this.Panel_ArrangementAndCombination.Controls.Add(this.Panel_Output);
            this.Panel_ArrangementAndCombination.Controls.Add(this.Label_Time);
            this.Panel_ArrangementAndCombination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel_ArrangementAndCombination.Location = new System.Drawing.Point(0, 0);
            this.Panel_ArrangementAndCombination.Name = "Panel_ArrangementAndCombination";
            this.Panel_ArrangementAndCombination.Size = new System.Drawing.Size(450, 225);
            this.Panel_ArrangementAndCombination.TabIndex = 0;
            this.Panel_ArrangementAndCombination.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_ArrangementAndCombination_Paint);
            // 
            // Label_AppName
            // 
            this.Label_AppName.AutoSize = true;
            this.Label_AppName.BackColor = System.Drawing.Color.Transparent;
            this.Label_AppName.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_AppName.ForeColor = System.Drawing.Color.White;
            this.Label_AppName.Location = new System.Drawing.Point(20, 25);
            this.Label_AppName.Name = "Label_AppName";
            this.Label_AppName.Size = new System.Drawing.Size(96, 28);
            this.Label_AppName.TabIndex = 0;
            this.Label_AppName.Text = "排列组合";
            this.Label_AppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_Note
            // 
            this.Label_Note.AutoSize = true;
            this.Label_Note.BackColor = System.Drawing.Color.Transparent;
            this.Label_Note.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label_Note.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Label_Note.ForeColor = System.Drawing.Color.White;
            this.Label_Note.Location = new System.Drawing.Point(22, 80);
            this.Label_Note.Name = "Label_Note";
            this.Label_Note.Size = new System.Drawing.Size(161, 17);
            this.Label_Note.TabIndex = 0;
            this.Label_Note.Text = "输入介于 ±1E15 之间的实数";
            this.Label_Note.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_ReturnToZero
            // 
            this.Label_ReturnToZero.BackColor = System.Drawing.Color.Transparent;
            this.Label_ReturnToZero.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_ReturnToZero.ForeColor = System.Drawing.Color.White;
            this.Label_ReturnToZero.Location = new System.Drawing.Point(395, 80);
            this.Label_ReturnToZero.Name = "Label_ReturnToZero";
            this.Label_ReturnToZero.Size = new System.Drawing.Size(30, 30);
            this.Label_ReturnToZero.TabIndex = 0;
            this.Label_ReturnToZero.Text = "C";
            this.Label_ReturnToZero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label_ReturnToZero.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_ReturnToZero_MouseClick);
            this.Label_ReturnToZero.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label_ReturnToZero_MouseDown);
            this.Label_ReturnToZero.MouseEnter += new System.EventHandler(this.Label_ReturnToZero_MouseEnter);
            this.Label_ReturnToZero.MouseLeave += new System.EventHandler(this.Label_ReturnToZero_MouseLeave);
            this.Label_ReturnToZero.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label_ReturnToZero_MouseUp);
            // 
            // Panel_Input
            // 
            this.Panel_Input.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Input.Controls.Add(this.Label_AC);
            this.Panel_Input.Controls.Add(this.Label_Total);
            this.Panel_Input.Controls.Add(this.Label_Selection);
            this.Panel_Input.Location = new System.Drawing.Point(25, 120);
            this.Panel_Input.Name = "Panel_Input";
            this.Panel_Input.Size = new System.Drawing.Size(200, 43);
            this.Panel_Input.TabIndex = 0;
            this.Panel_Input.LocationChanged += new System.EventHandler(this.Panel_Input_LocationChanged);
            this.Panel_Input.SizeChanged += new System.EventHandler(this.Panel_Input_SizeChanged);
            this.Panel_Input.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_Input_MouseDown);
            this.Panel_Input.MouseLeave += new System.EventHandler(this.Panel_Input_MouseLeave);
            this.Panel_Input.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_Input_MouseMove);
            this.Panel_Input.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel_Input_MouseUp);
            // 
            // Label_AC
            // 
            this.Label_AC.BackColor = System.Drawing.Color.Transparent;
            this.Label_AC.Font = new System.Drawing.Font("微软雅黑", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_AC.ForeColor = System.Drawing.Color.White;
            this.Label_AC.Location = new System.Drawing.Point(0, 0);
            this.Label_AC.Name = "Label_AC";
            this.Label_AC.Size = new System.Drawing.Size(35, 43);
            this.Label_AC.TabIndex = 0;
            this.Label_AC.Text = "A";
            this.Label_AC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Label_AC.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Label_AC_MouseClick);
            this.Label_AC.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label_AC_MouseDown);
            this.Label_AC.MouseEnter += new System.EventHandler(this.Label_AC_MouseEnter);
            this.Label_AC.MouseLeave += new System.EventHandler(this.Label_AC_MouseLeave);
            this.Label_AC.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Label_AC_MouseUp);
            // 
            // Label_Total
            // 
            this.Label_Total.AutoSize = true;
            this.Label_Total.BackColor = System.Drawing.Color.Transparent;
            this.Label_Total.ContextMenuStrip = this.ContextMenuStrip_Total;
            this.Label_Total.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.Label_Total.ForeColor = System.Drawing.Color.White;
            this.Label_Total.Location = new System.Drawing.Point(36, 22);
            this.Label_Total.Name = "Label_Total";
            this.Label_Total.Size = new System.Drawing.Size(48, 21);
            this.Label_Total.TabIndex = 0;
            this.Label_Total.Text = "Total";
            this.Label_Total.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Label_Total_KeyDown);
            this.Label_Total.LocationChanged += new System.EventHandler(this.Label_Total_LocationChanged);
            this.Label_Total.SizeChanged += new System.EventHandler(this.Label_Total_SizeChanged);
            this.Label_Total.TextChanged += new System.EventHandler(this.Label_Total_TextChanged);
            this.Label_Total.GotFocus += new System.EventHandler(this.Label_Total_GotFocus);
            this.Label_Total.LostFocus += new System.EventHandler(this.Label_Total_LostFocus);
            this.Label_Total.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label_Total_MouseDown);
            this.Label_Total.MouseLeave += new System.EventHandler(this.Label_Total_MouseLeave);
            this.Label_Total.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Label_Total_MouseMove);
            // 
            // ContextMenuStrip_Total
            // 
            this.ContextMenuStrip_Total.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip_Total.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Total_Copy,
            this.ToolStripMenuItem_Total_Paste});
            this.ContextMenuStrip_Total.Name = "ContextMenuStrip_ID";
            this.ContextMenuStrip_Total.Size = new System.Drawing.Size(117, 48);
            // 
            // ToolStripMenuItem_Total_Copy
            // 
            this.ToolStripMenuItem_Total_Copy.BackColor = System.Drawing.Color.Transparent;
            this.ToolStripMenuItem_Total_Copy.ForeColor = System.Drawing.Color.Black;
            this.ToolStripMenuItem_Total_Copy.Name = "ToolStripMenuItem_Total_Copy";
            this.ToolStripMenuItem_Total_Copy.Size = new System.Drawing.Size(116, 22);
            this.ToolStripMenuItem_Total_Copy.Text = "复制(C)";
            this.ToolStripMenuItem_Total_Copy.Click += new System.EventHandler(this.ToolStripMenuItem_Total_Copy_Click);
            // 
            // ToolStripMenuItem_Total_Paste
            // 
            this.ToolStripMenuItem_Total_Paste.BackColor = System.Drawing.Color.Transparent;
            this.ToolStripMenuItem_Total_Paste.ForeColor = System.Drawing.Color.Black;
            this.ToolStripMenuItem_Total_Paste.Name = "ToolStripMenuItem_Total_Paste";
            this.ToolStripMenuItem_Total_Paste.Size = new System.Drawing.Size(116, 22);
            this.ToolStripMenuItem_Total_Paste.Text = "粘贴(P)";
            this.ToolStripMenuItem_Total_Paste.Click += new System.EventHandler(this.ToolStripMenuItem_Total_Paste_Click);
            // 
            // Label_Selection
            // 
            this.Label_Selection.AutoSize = true;
            this.Label_Selection.BackColor = System.Drawing.Color.Transparent;
            this.Label_Selection.ContextMenuStrip = this.ContextMenuStrip_Selection;
            this.Label_Selection.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Selection.ForeColor = System.Drawing.Color.White;
            this.Label_Selection.Location = new System.Drawing.Point(36, 0);
            this.Label_Selection.Name = "Label_Selection";
            this.Label_Selection.Size = new System.Drawing.Size(79, 21);
            this.Label_Selection.TabIndex = 0;
            this.Label_Selection.Text = "Selection";
            this.Label_Selection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Label_Selection_KeyDown);
            this.Label_Selection.LocationChanged += new System.EventHandler(this.Label_Selection_LocationChanged);
            this.Label_Selection.SizeChanged += new System.EventHandler(this.Label_Selection_SizeChanged);
            this.Label_Selection.TextChanged += new System.EventHandler(this.Label_Selection_TextChanged);
            this.Label_Selection.GotFocus += new System.EventHandler(this.Label_Selection_GotFocus);
            this.Label_Selection.LostFocus += new System.EventHandler(this.Label_Selection_LostFocus);
            this.Label_Selection.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label_Selection_MouseDown);
            this.Label_Selection.MouseLeave += new System.EventHandler(this.Label_Selection_MouseLeave);
            this.Label_Selection.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Label_Selection_MouseMove);
            // 
            // ContextMenuStrip_Selection
            // 
            this.ContextMenuStrip_Selection.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip_Selection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Selection_Copy,
            this.ToolStripMenuItem_Selection_Paste});
            this.ContextMenuStrip_Selection.Name = "ContextMenuStrip_ID";
            this.ContextMenuStrip_Selection.Size = new System.Drawing.Size(117, 48);
            // 
            // ToolStripMenuItem_Selection_Copy
            // 
            this.ToolStripMenuItem_Selection_Copy.BackColor = System.Drawing.Color.Transparent;
            this.ToolStripMenuItem_Selection_Copy.ForeColor = System.Drawing.Color.Black;
            this.ToolStripMenuItem_Selection_Copy.Name = "ToolStripMenuItem_Selection_Copy";
            this.ToolStripMenuItem_Selection_Copy.Size = new System.Drawing.Size(116, 22);
            this.ToolStripMenuItem_Selection_Copy.Text = "复制(C)";
            this.ToolStripMenuItem_Selection_Copy.Click += new System.EventHandler(this.ToolStripMenuItem_Selection_Copy_Click);
            // 
            // ToolStripMenuItem_Selection_Paste
            // 
            this.ToolStripMenuItem_Selection_Paste.BackColor = System.Drawing.Color.Transparent;
            this.ToolStripMenuItem_Selection_Paste.ForeColor = System.Drawing.Color.Black;
            this.ToolStripMenuItem_Selection_Paste.Name = "ToolStripMenuItem_Selection_Paste";
            this.ToolStripMenuItem_Selection_Paste.Size = new System.Drawing.Size(116, 22);
            this.ToolStripMenuItem_Selection_Paste.Text = "粘贴(P)";
            this.ToolStripMenuItem_Selection_Paste.Click += new System.EventHandler(this.ToolStripMenuItem_Selection_Paste_Click);
            // 
            // Panel_Output
            // 
            this.Panel_Output.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Output.ContextMenuStrip = this.ContextMenuStrip_Output;
            this.Panel_Output.Controls.Add(this.Label_Equal);
            this.Panel_Output.Controls.Add(this.Label_Val);
            this.Panel_Output.Controls.Add(this.Label_Exp);
            this.Panel_Output.Location = new System.Drawing.Point(225, 120);
            this.Panel_Output.Name = "Panel_Output";
            this.Panel_Output.Size = new System.Drawing.Size(200, 43);
            this.Panel_Output.TabIndex = 0;
            this.Panel_Output.LocationChanged += new System.EventHandler(this.Panel_Output_LocationChanged);
            this.Panel_Output.SizeChanged += new System.EventHandler(this.Panel_Output_SizeChanged);
            // 
            // ContextMenuStrip_Output
            // 
            this.ContextMenuStrip_Output.BackColor = System.Drawing.Color.White;
            this.ContextMenuStrip_Output.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Output_Copy});
            this.ContextMenuStrip_Output.Name = "ContextMenuStrip_ID";
            this.ContextMenuStrip_Output.Size = new System.Drawing.Size(117, 26);
            // 
            // ToolStripMenuItem_Output_Copy
            // 
            this.ToolStripMenuItem_Output_Copy.BackColor = System.Drawing.Color.Transparent;
            this.ToolStripMenuItem_Output_Copy.ForeColor = System.Drawing.Color.Black;
            this.ToolStripMenuItem_Output_Copy.Name = "ToolStripMenuItem_Output_Copy";
            this.ToolStripMenuItem_Output_Copy.Size = new System.Drawing.Size(116, 22);
            this.ToolStripMenuItem_Output_Copy.Text = "复制(C)";
            this.ToolStripMenuItem_Output_Copy.Click += new System.EventHandler(this.ToolStripMenuItem_Output_Copy_Click);
            // 
            // Label_Equal
            // 
            this.Label_Equal.AutoSize = true;
            this.Label_Equal.BackColor = System.Drawing.Color.Transparent;
            this.Label_Equal.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.Label_Equal.ForeColor = System.Drawing.Color.White;
            this.Label_Equal.Location = new System.Drawing.Point(0, 16);
            this.Label_Equal.Name = "Label_Equal";
            this.Label_Equal.Size = new System.Drawing.Size(27, 27);
            this.Label_Equal.TabIndex = 0;
            this.Label_Equal.Text = "=";
            // 
            // Label_Val
            // 
            this.Label_Val.AutoSize = true;
            this.Label_Val.BackColor = System.Drawing.Color.Transparent;
            this.Label_Val.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.Label_Val.ForeColor = System.Drawing.Color.White;
            this.Label_Val.Location = new System.Drawing.Point(27, 16);
            this.Label_Val.Name = "Label_Val";
            this.Label_Val.Size = new System.Drawing.Size(42, 27);
            this.Label_Val.TabIndex = 0;
            this.Label_Val.Text = "Val";
            this.Label_Val.LocationChanged += new System.EventHandler(this.Label_Val_LocationChanged);
            this.Label_Val.SizeChanged += new System.EventHandler(this.Label_Val_SizeChanged);
            // 
            // Label_Exp
            // 
            this.Label_Exp.AutoSize = true;
            this.Label_Exp.BackColor = System.Drawing.Color.Transparent;
            this.Label_Exp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Exp.ForeColor = System.Drawing.Color.White;
            this.Label_Exp.Location = new System.Drawing.Point(69, 5);
            this.Label_Exp.Name = "Label_Exp";
            this.Label_Exp.Size = new System.Drawing.Size(37, 21);
            this.Label_Exp.TabIndex = 0;
            this.Label_Exp.Text = "Exp";
            this.Label_Exp.LocationChanged += new System.EventHandler(this.Label_Exp_LocationChanged);
            this.Label_Exp.SizeChanged += new System.EventHandler(this.Label_Exp_SizeChanged);
            // 
            // Label_Time
            // 
            this.Label_Time.BackColor = System.Drawing.Color.Transparent;
            this.Label_Time.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Label_Time.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Label_Time.ForeColor = System.Drawing.Color.White;
            this.Label_Time.Location = new System.Drawing.Point(0, 205);
            this.Label_Time.Name = "Label_Time";
            this.Label_Time.Size = new System.Drawing.Size(450, 20);
            this.Label_Time.TabIndex = 0;
            this.Label_Time.Text = "用时";
            this.Label_Time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(450, 225);
            this.Controls.Add(this.Panel_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Panel_Main.ResumeLayout(false);
            this.Panel_Client.ResumeLayout(false);
            this.Panel_ArrangementAndCombination.ResumeLayout(false);
            this.Panel_ArrangementAndCombination.PerformLayout();
            this.Panel_Input.ResumeLayout(false);
            this.Panel_Input.PerformLayout();
            this.ContextMenuStrip_Total.ResumeLayout(false);
            this.ContextMenuStrip_Selection.ResumeLayout(false);
            this.Panel_Output.ResumeLayout(false);
            this.Panel_Output.PerformLayout();
            this.ContextMenuStrip_Output.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Main;
        private System.Windows.Forms.Panel Panel_Client;
        private System.Windows.Forms.Panel Panel_Output;
        private System.Windows.Forms.Label Label_Equal;
        private System.Windows.Forms.Label Label_Exp;
        private System.Windows.Forms.Label Label_Val;
        private System.Windows.Forms.Panel Panel_Input;
        private System.Windows.Forms.Label Label_Note;
        private System.Windows.Forms.Label Label_AppName;
        private System.Windows.Forms.Label Label_Selection;
        private System.Windows.Forms.Label Label_Total;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip_Total;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Total_Copy;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Total_Paste;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip_Output;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Output_Copy;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip_Selection;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Selection_Copy;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Selection_Paste;
        private System.Windows.Forms.Panel Panel_ArrangementAndCombination;
        private System.Windows.Forms.Label Label_AC;
        private System.Windows.Forms.Label Label_Time;
        private System.Windows.Forms.Label Label_ReturnToZero;
    }
}