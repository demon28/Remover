namespace Remover.WinSocket
{
    partial class form_SocketDepth
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_HuoBiStart = new System.Windows.Forms.Button();
            this.btn_OkStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_HuoBiStart
            // 
            this.btn_HuoBiStart.Location = new System.Drawing.Point(32, 40);
            this.btn_HuoBiStart.Name = "btn_HuoBiStart";
            this.btn_HuoBiStart.Size = new System.Drawing.Size(103, 30);
            this.btn_HuoBiStart.TabIndex = 0;
            this.btn_HuoBiStart.Text = "火币平台开启";
            this.btn_HuoBiStart.UseVisualStyleBackColor = true;
            this.btn_HuoBiStart.Click += new System.EventHandler(this.btn_HuoBiStart_Click);
            // 
            // btn_OkStart
            // 
            this.btn_OkStart.Location = new System.Drawing.Point(179, 40);
            this.btn_OkStart.Name = "btn_OkStart";
            this.btn_OkStart.Size = new System.Drawing.Size(109, 30);
            this.btn_OkStart.TabIndex = 1;
            this.btn_OkStart.Text = "OK平台开启";
            this.btn_OkStart.UseVisualStyleBackColor = true;
            this.btn_OkStart.Click += new System.EventHandler(this.btn_OkStart_Click);
            // 
            // form_SocketDepth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 280);
            this.Controls.Add(this.btn_OkStart);
            this.Controls.Add(this.btn_HuoBiStart);
            this.Name = "form_SocketDepth";
            this.Text = "各大平台Socket取市场深度";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_SocketDepth_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_HuoBiStart;
        private System.Windows.Forms.Button btn_OkStart;
    }
}

