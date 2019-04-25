namespace CNN_UI
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.img_search_btn = new System.Windows.Forms.Button();
            this.img_download_btn = new System.Windows.Forms.Button();
            this.image_lvw = new System.Windows.Forms.ListView();
            this.img_pbx = new System.Windows.Forms.PictureBox();
            this.result_tbx = new System.Windows.Forms.TextBox();
            this.info_lbl = new System.Windows.Forms.Label();
            this.image_list = new System.Windows.Forms.ImageList(this.components);
            this.inputGroup = new System.Windows.Forms.GroupBox();
            this.outputGroup = new System.Windows.Forms.GroupBox();
            this.loading_pbx = new System.Windows.Forms.PictureBox();
            this.close_btn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.img_pbx)).BeginInit();
            this.inputGroup.SuspendLayout();
            this.outputGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loading_pbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // img_search_btn
            // 
            this.img_search_btn.Font = new System.Drawing.Font("나눔고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.img_search_btn.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.img_search_btn.Location = new System.Drawing.Point(21, 393);
            this.img_search_btn.Name = "img_search_btn";
            this.img_search_btn.Size = new System.Drawing.Size(206, 42);
            this.img_search_btn.TabIndex = 1;
            this.img_search_btn.Text = "이미지 분석";
            this.img_search_btn.UseVisualStyleBackColor = true;
            this.img_search_btn.Click += new System.EventHandler(this.img_search_btn_Click);
            // 
            // img_download_btn
            // 
            this.img_download_btn.Location = new System.Drawing.Point(233, 364);
            this.img_download_btn.Name = "img_download_btn";
            this.img_download_btn.Size = new System.Drawing.Size(184, 71);
            this.img_download_btn.TabIndex = 2;
            this.img_download_btn.Text = "이미지 다운로드";
            this.img_download_btn.UseVisualStyleBackColor = true;
            this.img_download_btn.Click += new System.EventHandler(this.img_download_btn_Click);
            // 
            // image_lvw
            // 
            this.image_lvw.Location = new System.Drawing.Point(24, 25);
            this.image_lvw.Name = "image_lvw";
            this.image_lvw.Size = new System.Drawing.Size(635, 409);
            this.image_lvw.TabIndex = 3;
            this.image_lvw.UseCompatibleStateImageBehavior = false;
            // 
            // img_pbx
            // 
            this.img_pbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.img_pbx.Location = new System.Drawing.Point(21, 26);
            this.img_pbx.Name = "img_pbx";
            this.img_pbx.Size = new System.Drawing.Size(396, 327);
            this.img_pbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_pbx.TabIndex = 4;
            this.img_pbx.TabStop = false;
            this.img_pbx.DragDrop += new System.Windows.Forms.DragEventHandler(this.img_pbx_DragDrop);
            this.img_pbx.DragEnter += new System.Windows.Forms.DragEventHandler(this.img_pbx_DragEnter);
            // 
            // result_tbx
            // 
            this.result_tbx.Font = new System.Drawing.Font("나눔고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.result_tbx.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.result_tbx.Location = new System.Drawing.Point(21, 364);
            this.result_tbx.Name = "result_tbx";
            this.result_tbx.ReadOnly = true;
            this.result_tbx.Size = new System.Drawing.Size(206, 22);
            this.result_tbx.TabIndex = 5;
            this.result_tbx.Text = "미동작 (0%)";
            this.result_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // info_lbl
            // 
            this.info_lbl.AutoSize = true;
            this.info_lbl.Font = new System.Drawing.Font("나눔고딕", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.info_lbl.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.info_lbl.Location = new System.Drawing.Point(93, 173);
            this.info_lbl.Name = "info_lbl";
            this.info_lbl.Size = new System.Drawing.Size(267, 16);
            this.info_lbl.TabIndex = 6;
            this.info_lbl.Text = "이미지를 이곳으로 드래그하여 가져오세요 :)";
            // 
            // image_list
            // 
            this.image_list.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.image_list.ImageSize = new System.Drawing.Size(16, 16);
            this.image_list.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // inputGroup
            // 
            this.inputGroup.BackColor = System.Drawing.Color.Transparent;
            this.inputGroup.Controls.Add(this.loading_pbx);
            this.inputGroup.Controls.Add(this.info_lbl);
            this.inputGroup.Controls.Add(this.result_tbx);
            this.inputGroup.Controls.Add(this.img_download_btn);
            this.inputGroup.Controls.Add(this.img_pbx);
            this.inputGroup.Controls.Add(this.img_search_btn);
            this.inputGroup.Font = new System.Drawing.Font("나눔고딕", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.inputGroup.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.inputGroup.Location = new System.Drawing.Point(25, 51);
            this.inputGroup.Name = "inputGroup";
            this.inputGroup.Size = new System.Drawing.Size(444, 453);
            this.inputGroup.TabIndex = 61;
            this.inputGroup.TabStop = false;
            this.inputGroup.Text = "머신러닝 기반 이미지 검색";
            // 
            // outputGroup
            // 
            this.outputGroup.BackColor = System.Drawing.Color.Transparent;
            this.outputGroup.Controls.Add(this.image_lvw);
            this.outputGroup.Font = new System.Drawing.Font("나눔고딕", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.outputGroup.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.outputGroup.Location = new System.Drawing.Point(487, 52);
            this.outputGroup.Name = "outputGroup";
            this.outputGroup.Size = new System.Drawing.Size(682, 453);
            this.outputGroup.TabIndex = 62;
            this.outputGroup.TabStop = false;
            this.outputGroup.Text = "이미지 수집현황";
            // 
            // loading_pbx
            // 
            this.loading_pbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loading_pbx.Image = global::CNN_UI.Properties.Resources.loading;
            this.loading_pbx.Location = new System.Drawing.Point(155, 138);
            this.loading_pbx.Name = "loading_pbx";
            this.loading_pbx.Size = new System.Drawing.Size(122, 100);
            this.loading_pbx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loading_pbx.TabIndex = 7;
            this.loading_pbx.TabStop = false;
            this.loading_pbx.Visible = false;
            // 
            // close_btn
            // 
            this.close_btn.Image = global::CNN_UI.Properties.Resources.close;
            this.close_btn.Location = new System.Drawing.Point(1169, 9);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(16, 16);
            this.close_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.close_btn.TabIndex = 8;
            this.close_btn.TabStop = false;
            this.close_btn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.close_btn_MouseClick);
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::CNN_UI.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1194, 528);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.outputGroup);
            this.Controls.Add(this.inputGroup);
            this.Font = new System.Drawing.Font("나눔고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "이미지 인식 및 검색 프로그램";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Main_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Main_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.img_pbx)).EndInit();
            this.inputGroup.ResumeLayout(false);
            this.inputGroup.PerformLayout();
            this.outputGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.loading_pbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button img_search_btn;
        private System.Windows.Forms.Button img_download_btn;
        private System.Windows.Forms.ListView image_lvw;
        private System.Windows.Forms.PictureBox img_pbx;
        private System.Windows.Forms.TextBox result_tbx;
        private System.Windows.Forms.Label info_lbl;
        private System.Windows.Forms.ImageList image_list;
        private System.Windows.Forms.GroupBox inputGroup;
        private System.Windows.Forms.GroupBox outputGroup;
        private System.Windows.Forms.PictureBox loading_pbx;
        private System.Windows.Forms.PictureBox close_btn;
    }
}

