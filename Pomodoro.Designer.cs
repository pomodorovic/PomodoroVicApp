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
			this.timerControlTiempo = new System.Windows.Forms.Timer(this.components);
			this.lblStatus = new System.Windows.Forms.Label();
			this.ctmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemMinutosInicio = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemMinutosBreak = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemCancelar = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemPausarContinuarPomodoro = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemAlwaysOnTop = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemAutoSwitch = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemBlink = new System.Windows.Forms.ToolStripMenuItem();
			this.opacidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemTransp0 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemTransp25 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemTransp50 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemTransp75 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemMinimizarMostrarSystemTray = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemSalir = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemConfigurarTiempo = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
			this.ntfPomodoro = new System.Windows.Forms.NotifyIcon(this.components);
			this.ctmMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTiempo
			// 
			this.lblTiempo.AutoSize = true;
			this.lblTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTiempo.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblTiempo.Location = new System.Drawing.Point(6, 0);
			this.lblTiempo.Name = "lblTiempo";
			this.lblTiempo.Size = new System.Drawing.Size(215, 82);
			this.lblTiempo.TabIndex = 0;
			this.lblTiempo.Text = "00:00";
			this.lblTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblTiempo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTiempo_MouseDown);
			// 
			// timerControlTiempo
			// 
			this.timerControlTiempo.Interval = 1000;
			this.timerControlTiempo.Tick += new System.EventHandler(this.timerControlTiempo_Tick);
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(5, 85);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(49, 20);
			this.lblStatus.TabIndex = 3;
			this.lblStatus.Text = "00:00";
			this.lblStatus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblStatus_MouseDown);
			// 
			// ctmMenu
			// 
			this.ctmMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
			this.ctmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemMinutosInicio,
            this.menuItemMinutosBreak,
            this.toolStripMenuItem1,
            this.menuItemCancelar,
            this.menuItemPausarContinuarPomodoro,
            this.toolStripMenuItem2,
            this.configuraciónToolStripMenuItem,
            this.toolStripMenuItem3,
            this.menuItemAcercaDe,
            this.menuItemSalir,
            this.menuItemConfigurarTiempo});
			this.ctmMenu.Name = "ctmMenu";
			this.ctmMenu.Size = new System.Drawing.Size(311, 278);
			// 
			// menuItemMinutosInicio
			// 
			this.menuItemMinutosInicio.Name = "menuItemMinutosInicio";
			this.menuItemMinutosInicio.Size = new System.Drawing.Size(310, 32);
			this.menuItemMinutosInicio.Text = "Inicio minutos";
			this.menuItemMinutosInicio.Click += new System.EventHandler(this.menuItemMinutosInicio_Click);
			// 
			// menuItemMinutosBreak
			// 
			this.menuItemMinutosBreak.Name = "menuItemMinutosBreak";
			this.menuItemMinutosBreak.Size = new System.Drawing.Size(310, 32);
			this.menuItemMinutosBreak.Text = "Break minutos";
			this.menuItemMinutosBreak.Click += new System.EventHandler(this.menuItemMinutosBreak_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(307, 6);
			// 
			// menuItemCancelar
			// 
			this.menuItemCancelar.Name = "menuItemCancelar";
			this.menuItemCancelar.Size = new System.Drawing.Size(310, 32);
			this.menuItemCancelar.Text = "Cancelar Timer Pomodoro";
			this.menuItemCancelar.Click += new System.EventHandler(this.menuItemCancelar_Click);
			// 
			// menuItemPausarContinuarPomodoro
			// 
			this.menuItemPausarContinuarPomodoro.Name = "menuItemPausarContinuarPomodoro";
			this.menuItemPausarContinuarPomodoro.Size = new System.Drawing.Size(310, 32);
			this.menuItemPausarContinuarPomodoro.Text = "Pausar/Continuar Pomodoro";
			this.menuItemPausarContinuarPomodoro.Click += new System.EventHandler(this.menuItemPausarContinuarPomodoro_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(307, 6);
			// 
			// configuraciónToolStripMenuItem
			// 
			this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAlwaysOnTop,
            this.menuItemAutoSwitch,
            this.menuItemBlink,
            this.opacidadToolStripMenuItem,
            this.menuItemMinimizarMostrarSystemTray});
			this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
			this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(310, 32);
			this.configuraciónToolStripMenuItem.Text = "Configuración";
			// 
			// menuItemAlwaysOnTop
			// 
			this.menuItemAlwaysOnTop.Checked = true;
			this.menuItemAlwaysOnTop.CheckState = System.Windows.Forms.CheckState.Checked;
			this.menuItemAlwaysOnTop.Name = "menuItemAlwaysOnTop";
			this.menuItemAlwaysOnTop.Size = new System.Drawing.Size(353, 34);
			this.menuItemAlwaysOnTop.Text = "AlwaysOnTop";
			this.menuItemAlwaysOnTop.Click += new System.EventHandler(this.menuItemAlwaysOnTop_Click);
			// 
			// menuItemAutoSwitch
			// 
			this.menuItemAutoSwitch.Name = "menuItemAutoSwitch";
			this.menuItemAutoSwitch.Size = new System.Drawing.Size(353, 34);
			this.menuItemAutoSwitch.Text = "Autoiniciar Pomodoro/Break";
			this.menuItemAutoSwitch.Click += new System.EventHandler(this.menuItemAutoSwitch_Click);
			// 
			// menuItemBlink
			// 
			this.menuItemBlink.Checked = true;
			this.menuItemBlink.CheckState = System.Windows.Forms.CheckState.Checked;
			this.menuItemBlink.Name = "menuItemBlink";
			this.menuItemBlink.Size = new System.Drawing.Size(353, 34);
			this.menuItemBlink.Text = "Blink antes de finalizar";
			this.menuItemBlink.Click += new System.EventHandler(this.menuItemBlink_Click);
			// 
			// opacidadToolStripMenuItem
			// 
			this.opacidadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemTransp0,
            this.menuItemTransp25,
            this.menuItemTransp50,
            this.menuItemTransp75});
			this.opacidadToolStripMenuItem.Name = "opacidadToolStripMenuItem";
			this.opacidadToolStripMenuItem.Size = new System.Drawing.Size(353, 34);
			this.opacidadToolStripMenuItem.Text = "Opacidad";
			// 
			// menuItemTransp0
			// 
			this.menuItemTransp0.Name = "menuItemTransp0";
			this.menuItemTransp0.Size = new System.Drawing.Size(149, 34);
			this.menuItemTransp0.Text = "0%";
			this.menuItemTransp0.Click += new System.EventHandler(this.menuItemTransp0_Click);
			// 
			// menuItemTransp25
			// 
			this.menuItemTransp25.Name = "menuItemTransp25";
			this.menuItemTransp25.Size = new System.Drawing.Size(149, 34);
			this.menuItemTransp25.Text = "25%";
			this.menuItemTransp25.Click += new System.EventHandler(this.menuItemTransp25_Click);
			// 
			// menuItemTransp50
			// 
			this.menuItemTransp50.Name = "menuItemTransp50";
			this.menuItemTransp50.Size = new System.Drawing.Size(149, 34);
			this.menuItemTransp50.Text = "50%";
			this.menuItemTransp50.Click += new System.EventHandler(this.menuItemTransp50_Click);
			// 
			// menuItemTransp75
			// 
			this.menuItemTransp75.Name = "menuItemTransp75";
			this.menuItemTransp75.Size = new System.Drawing.Size(149, 34);
			this.menuItemTransp75.Text = "75%";
			this.menuItemTransp75.Click += new System.EventHandler(this.menuItemTransp75_Click);
			// 
			// menuItemMinimizarMostrarSystemTray
			// 
			this.menuItemMinimizarMostrarSystemTray.Name = "menuItemMinimizarMostrarSystemTray";
			this.menuItemMinimizarMostrarSystemTray.Size = new System.Drawing.Size(353, 34);
			this.menuItemMinimizarMostrarSystemTray.Text = "SystemTray Minimizar/Mostrar";
			this.menuItemMinimizarMostrarSystemTray.Click += new System.EventHandler(this.menuItemMinimizarMostrarSystemTray_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(307, 6);
			// 
			// menuItemAcercaDe
			// 
			this.menuItemAcercaDe.Name = "menuItemAcercaDe";
			this.menuItemAcercaDe.Size = new System.Drawing.Size(310, 32);
			this.menuItemAcercaDe.Text = "Acerca de ...";
			this.menuItemAcercaDe.Click += new System.EventHandler(this.menuItemAcercaDe_Click);
			// 
			// menuItemSalir
			// 
			this.menuItemSalir.Name = "menuItemSalir";
			this.menuItemSalir.Size = new System.Drawing.Size(310, 32);
			this.menuItemSalir.Text = "Salir";
			this.menuItemSalir.Click += new System.EventHandler(this.menuItemSalir_Click);
			// 
			// menuItemConfigurarTiempo
			// 
			this.menuItemConfigurarTiempo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
			this.menuItemConfigurarTiempo.Name = "menuItemConfigurarTiempo";
			this.menuItemConfigurarTiempo.Size = new System.Drawing.Size(310, 32);
			this.menuItemConfigurarTiempo.Text = "Configurar pomodoro...";
			// 
			// toolStripTextBox1
			// 
			this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.toolStripTextBox1.Name = "toolStripTextBox1";
			this.toolStripTextBox1.Size = new System.Drawing.Size(100, 31);
			// 
			// ntfPomodoro
			// 
			this.ntfPomodoro.Text = "notifyIcon1";
			this.ntfPomodoro.Visible = true;
			this.ntfPomodoro.DoubleClick += new System.EventHandler(this.ntfPomodoro_DoubleClick);
			this.ntfPomodoro.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ntfPomodoro_MouseMove);
			// 
			// Pomodoro
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(226, 112);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.lblTiempo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Pomodoro";
			this.ShowInTaskbar = false;
			this.Text = "PomodoroVic";
			this.Load += new System.EventHandler(this.Pomodoro_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pomodoro_KeyDown);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pomodoro_MouseDown);
			this.ctmMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblTiempo;
		private System.Windows.Forms.Timer timerControlTiempo;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.ContextMenuStrip ctmMenu;
		private System.Windows.Forms.ToolStripMenuItem menuItemMinutosInicio;
		private System.Windows.Forms.ToolStripMenuItem menuItemMinutosBreak;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem menuItemCancelar;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem configuraciónToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menuItemAlwaysOnTop;
		private System.Windows.Forms.ToolStripMenuItem menuItemAutoSwitch;
		private System.Windows.Forms.ToolStripMenuItem menuItemBlink;
		private System.Windows.Forms.ToolStripMenuItem opacidadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menuItemMinimizarMostrarSystemTray;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem menuItemAcercaDe;
		private System.Windows.Forms.ToolStripMenuItem menuItemSalir;
		private System.Windows.Forms.ToolStripMenuItem menuItemPausarContinuarPomodoro;
		private System.Windows.Forms.ToolStripMenuItem menuItemTransp0;
		private System.Windows.Forms.ToolStripMenuItem menuItemTransp25;
		private System.Windows.Forms.ToolStripMenuItem menuItemTransp50;
		private System.Windows.Forms.ToolStripMenuItem menuItemTransp75;
		private System.Windows.Forms.NotifyIcon ntfPomodoro;
		private System.Windows.Forms.ToolStripMenuItem menuItemConfigurarTiempo;
		private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
	}
}

