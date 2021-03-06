﻿namespace PomodoroVicApp
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
			this.menuItemIdentificarPomodoroIdealTrabajo = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemIdentificarPomodoroIdealDescanso = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemFinalizar = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemPausarContinuarPomodoro = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.configuraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemAlwaysOnTop = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemAutoSwitch = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemBlink = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemActivarLog = new System.Windows.Forms.ToolStripMenuItem();
			this.opacidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemTransp0 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemTransp25 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemTransp50 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemTransp75 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemMinimizarMostrarSystemTray = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuItemAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemSalir = new System.Windows.Forms.ToolStripMenuItem();
			this.ntfPomodoro = new System.Windows.Forms.NotifyIcon(this.components);
			this.ctmMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTiempo
			// 
			this.lblTiempo.AutoSize = true;
			this.lblTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTiempo.ForeColor = System.Drawing.Color.SteelBlue;
			this.lblTiempo.Location = new System.Drawing.Point(0, 0);
			this.lblTiempo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.lblTiempo.Name = "lblTiempo";
			this.lblTiempo.Size = new System.Drawing.Size(458, 135);
			this.lblTiempo.TabIndex = 0;
			this.lblTiempo.Text = "0:00:00";
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
			this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblStatus.Location = new System.Drawing.Point(9, 132);
			this.lblStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(71, 29);
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
            this.menuItemIdentificarPomodoroIdealTrabajo,
            this.menuItemIdentificarPomodoroIdealDescanso,
            this.toolStripMenuItem4,
            this.menuItemFinalizar,
            this.menuItemPausarContinuarPomodoro,
            this.toolStripMenuItem2,
            this.configuraciónToolStripMenuItem,
            this.toolStripMenuItem3,
            this.menuItemAcercaDe,
            this.menuItemSalir});
			this.ctmMenu.Name = "ctmMenu";
			this.ctmMenu.Size = new System.Drawing.Size(585, 454);
			// 
			// menuItemMinutosInicio
			// 
			this.menuItemMinutosInicio.Name = "menuItemMinutosInicio";
			this.menuItemMinutosInicio.Size = new System.Drawing.Size(584, 48);
			this.menuItemMinutosInicio.Text = "x minutos de trabajo";
			this.menuItemMinutosInicio.Click += new System.EventHandler(this.menuItemMinutosInicio_Click);
			// 
			// menuItemMinutosBreak
			// 
			this.menuItemMinutosBreak.Name = "menuItemMinutosBreak";
			this.menuItemMinutosBreak.Size = new System.Drawing.Size(584, 48);
			this.menuItemMinutosBreak.Text = "y minutos de descanso";
			this.menuItemMinutosBreak.Click += new System.EventHandler(this.menuItemMinutosBreak_Click);
			// 
			// menuItemIdentificarPomodoroIdealTrabajo
			// 
			this.menuItemIdentificarPomodoroIdealTrabajo.Name = "menuItemIdentificarPomodoroIdealTrabajo";
			this.menuItemIdentificarPomodoroIdealTrabajo.Size = new System.Drawing.Size(584, 48);
			this.menuItemIdentificarPomodoroIdealTrabajo.Text = "Identificar Pomodoro Ideal Trabajo";
			this.menuItemIdentificarPomodoroIdealTrabajo.Click += new System.EventHandler(this.menuItemIdentificarPomodoroIdealTrabajo_Click);
			// 
			// menuItemIdentificarPomodoroIdealDescanso
			// 
			this.menuItemIdentificarPomodoroIdealDescanso.Name = "menuItemIdentificarPomodoroIdealDescanso";
			this.menuItemIdentificarPomodoroIdealDescanso.Size = new System.Drawing.Size(584, 48);
			this.menuItemIdentificarPomodoroIdealDescanso.Text = "Identificar Pomodoro Ideal Descanso";
			this.menuItemIdentificarPomodoroIdealDescanso.Click += new System.EventHandler(this.menuItemIdentificarPomodoroIdealDescanso_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(581, 6);
			// 
			// menuItemFinalizar
			// 
			this.menuItemFinalizar.Name = "menuItemFinalizar";
			this.menuItemFinalizar.Size = new System.Drawing.Size(584, 48);
			this.menuItemFinalizar.Text = "Finalizar Timer Pomodoro";
			this.menuItemFinalizar.Click += new System.EventHandler(this.menuItemFinalizar_Click);
			// 
			// menuItemPausarContinuarPomodoro
			// 
			this.menuItemPausarContinuarPomodoro.Name = "menuItemPausarContinuarPomodoro";
			this.menuItemPausarContinuarPomodoro.Size = new System.Drawing.Size(584, 48);
			this.menuItemPausarContinuarPomodoro.Text = "Pausar Pomodoro";
			this.menuItemPausarContinuarPomodoro.Click += new System.EventHandler(this.menuItemPausarContinuarPomodoro_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(581, 6);
			// 
			// configuraciónToolStripMenuItem
			// 
			this.configuraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAlwaysOnTop,
            this.menuItemAutoSwitch,
            this.menuItemBlink,
            this.menuItemActivarLog,
            this.opacidadToolStripMenuItem,
            this.menuItemMinimizarMostrarSystemTray});
			this.configuraciónToolStripMenuItem.Name = "configuraciónToolStripMenuItem";
			this.configuraciónToolStripMenuItem.Size = new System.Drawing.Size(584, 48);
			this.configuraciónToolStripMenuItem.Text = "Configuración";
			// 
			// menuItemAlwaysOnTop
			// 
			this.menuItemAlwaysOnTop.Checked = true;
			this.menuItemAlwaysOnTop.CheckState = System.Windows.Forms.CheckState.Checked;
			this.menuItemAlwaysOnTop.Name = "menuItemAlwaysOnTop";
			this.menuItemAlwaysOnTop.Size = new System.Drawing.Size(585, 54);
			this.menuItemAlwaysOnTop.Text = "AlwaysOnTop";
			this.menuItemAlwaysOnTop.Click += new System.EventHandler(this.menuItemAlwaysOnTop_Click);
			// 
			// menuItemAutoSwitch
			// 
			this.menuItemAutoSwitch.Name = "menuItemAutoSwitch";
			this.menuItemAutoSwitch.Size = new System.Drawing.Size(585, 54);
			this.menuItemAutoSwitch.Text = "Autoiniciar Pomodoro/Break";
			this.menuItemAutoSwitch.Click += new System.EventHandler(this.menuItemAutoSwitch_Click);
			// 
			// menuItemBlink
			// 
			this.menuItemBlink.Checked = true;
			this.menuItemBlink.CheckState = System.Windows.Forms.CheckState.Checked;
			this.menuItemBlink.Name = "menuItemBlink";
			this.menuItemBlink.Size = new System.Drawing.Size(585, 54);
			this.menuItemBlink.Text = "Blink antes de finalizar";
			this.menuItemBlink.Click += new System.EventHandler(this.menuItemBlink_Click);
			// 
			// menuItemActivarLog
			// 
			this.menuItemActivarLog.Name = "menuItemActivarLog";
			this.menuItemActivarLog.Size = new System.Drawing.Size(585, 54);
			this.menuItemActivarLog.Text = "Activar Log";
			this.menuItemActivarLog.Click += new System.EventHandler(this.menuItemActivarLog_Click);
			// 
			// opacidadToolStripMenuItem
			// 
			this.opacidadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemTransp0,
            this.menuItemTransp25,
            this.menuItemTransp50,
            this.menuItemTransp75});
			this.opacidadToolStripMenuItem.Name = "opacidadToolStripMenuItem";
			this.opacidadToolStripMenuItem.Size = new System.Drawing.Size(585, 54);
			this.opacidadToolStripMenuItem.Text = "Opacidad";
			// 
			// menuItemTransp0
			// 
			this.menuItemTransp0.Name = "menuItemTransp0";
			this.menuItemTransp0.Size = new System.Drawing.Size(241, 54);
			this.menuItemTransp0.Text = "0%";
			this.menuItemTransp0.Click += new System.EventHandler(this.menuItemTransp0_Click);
			// 
			// menuItemTransp25
			// 
			this.menuItemTransp25.Name = "menuItemTransp25";
			this.menuItemTransp25.Size = new System.Drawing.Size(241, 54);
			this.menuItemTransp25.Text = "25%";
			this.menuItemTransp25.Click += new System.EventHandler(this.menuItemTransp25_Click);
			// 
			// menuItemTransp50
			// 
			this.menuItemTransp50.Name = "menuItemTransp50";
			this.menuItemTransp50.Size = new System.Drawing.Size(241, 54);
			this.menuItemTransp50.Text = "50%";
			this.menuItemTransp50.Click += new System.EventHandler(this.menuItemTransp50_Click);
			// 
			// menuItemTransp75
			// 
			this.menuItemTransp75.Name = "menuItemTransp75";
			this.menuItemTransp75.Size = new System.Drawing.Size(241, 54);
			this.menuItemTransp75.Text = "75%";
			this.menuItemTransp75.Click += new System.EventHandler(this.menuItemTransp75_Click);
			// 
			// menuItemMinimizarMostrarSystemTray
			// 
			this.menuItemMinimizarMostrarSystemTray.Name = "menuItemMinimizarMostrarSystemTray";
			this.menuItemMinimizarMostrarSystemTray.Size = new System.Drawing.Size(585, 54);
			this.menuItemMinimizarMostrarSystemTray.Text = "SystemTray Minimizar/Mostrar";
			this.menuItemMinimizarMostrarSystemTray.Click += new System.EventHandler(this.menuItemMinimizarMostrarSystemTray_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(581, 6);
			// 
			// menuItemAcercaDe
			// 
			this.menuItemAcercaDe.Name = "menuItemAcercaDe";
			this.menuItemAcercaDe.Size = new System.Drawing.Size(584, 48);
			this.menuItemAcercaDe.Text = "Acerca de ...";
			this.menuItemAcercaDe.Click += new System.EventHandler(this.menuItemAcercaDe_Click);
			// 
			// menuItemSalir
			// 
			this.menuItemSalir.Name = "menuItemSalir";
			this.menuItemSalir.Size = new System.Drawing.Size(584, 48);
			this.menuItemSalir.Text = "Salir";
			this.menuItemSalir.Click += new System.EventHandler(this.menuItemSalir_Click);
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
			this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(499, 174);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.lblTiempo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(5);
			this.Name = "Pomodoro";
			this.ShowInTaskbar = false;
			this.Text = "PomodoroVic";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pomodoro_FormClosing);
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
		private System.Windows.Forms.ToolStripMenuItem menuItemFinalizar;
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
		private System.Windows.Forms.ToolStripMenuItem menuItemIdentificarPomodoroIdealTrabajo;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem menuItemActivarLog;
		private System.Windows.Forms.ToolStripMenuItem menuItemIdentificarPomodoroIdealDescanso;
	}
}

