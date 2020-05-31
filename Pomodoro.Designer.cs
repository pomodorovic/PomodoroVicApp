namespace PomodoroVicApp
{
	partial class Pomodoro
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pomodoro));
			this.lblTiempo = new System.Windows.Forms.Label();
			this.btnIniciar = new System.Windows.Forms.Button();
			this.timerControlTiempo = new System.Windows.Forms.Timer(this.components);
			this.btnBreak = new System.Windows.Forms.Button();
			this.lblStatus = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblTiempo
			// 
			this.lblTiempo.AutoSize = true;
			this.lblTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTiempo.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblTiempo.Location = new System.Drawing.Point(0, 0);
			this.lblTiempo.Name = "lblTiempo";
			this.lblTiempo.Size = new System.Drawing.Size(215, 82);
			this.lblTiempo.TabIndex = 0;
			this.lblTiempo.Text = "00:00";
			this.lblTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnIniciar
			// 
			this.btnIniciar.Location = new System.Drawing.Point(14, 85);
			this.btnIniciar.Name = "btnIniciar";
			this.btnIniciar.Size = new System.Drawing.Size(101, 42);
			this.btnIniciar.TabIndex = 1;
			this.btnIniciar.Text = "Iniciar";
			this.btnIniciar.UseVisualStyleBackColor = true;
			this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
			// 
			// timerControlTiempo
			// 
			this.timerControlTiempo.Interval = 1000;
			this.timerControlTiempo.Tick += new System.EventHandler(this.timerControlTiempo_Tick);
			// 
			// btnBreak
			// 
			this.btnBreak.Location = new System.Drawing.Point(122, 86);
			this.btnBreak.Name = "btnBreak";
			this.btnBreak.Size = new System.Drawing.Size(93, 41);
			this.btnBreak.TabIndex = 2;
			this.btnBreak.Text = "Break";
			this.btnBreak.UseVisualStyleBackColor = true;
			this.btnBreak.Click += new System.EventHandler(this.btnBreak_Click);
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(5, 129);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(49, 20);
			this.lblStatus.TabIndex = 3;
			this.lblStatus.Text = "00:00";
			// 
			// Pomodoro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(232, 154);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.btnBreak);
			this.Controls.Add(this.btnIniciar);
			this.Controls.Add(this.lblTiempo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Pomodoro";
			this.Text = "PomodoroVic";
			this.Load += new System.EventHandler(this.Pomodoro_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblTiempo;
		private System.Windows.Forms.Button btnIniciar;
		private System.Windows.Forms.Timer timerControlTiempo;
		private System.Windows.Forms.Button btnBreak;
		private System.Windows.Forms.Label lblStatus;
	}
}

