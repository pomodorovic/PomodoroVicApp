using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Microsoft.Win32;

namespace PomodoroVicApp
{
	public partial class Pomodoro : Form
	{
		private TrackBarMenuItem trackBarTiempoInicio;
		private TrackBarMenuItem trackBarTiempoBreak;

		private System.DateTime dtmTiempoAuxiliar;
		private System.DateTime dtmTiempoActualizado;
		private int valorInicialPomodoro, valorBreakPomodoro, valorPomodoroEnEjecucion;
		private string pathLog;

		private Color COLOR_TRABAJO = Color.DarkOrange;//System.Drawing.Color.Navy
		private Color COLOR_DESCANSO = Color.SteelBlue;
		private Color COLOR_IDEAL_TRABAJO = Color.SpringGreen;//Color.Lime //Color.MediumVioletRed
		private Color COLOR_IDEAL_DESCANSO = Color.MediumVioletRed;// Color.DarkTurquoise;
		private Color COLOR_FIN = Color.Red;//Color.Maroon
		private Color COLOR_ALERTA = Color.Maroon;// Color.SlateBlue;

		private enum Causa { PorReinicio, PorCompletado, PorFinalizar, PorSalir, PorInicioPausa, PorCancelarPausa }

		private const int WM_NCLBUTTONDOWN = 0xA1;
		private IntPtr HT_CAPTION = (IntPtr)0x2;

		[System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

		[System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
		public static extern bool ReleaseCapture();

		public Pomodoro()
		{
			InitializeComponent();
		}

		private void Pomodoro_Load(object sender, EventArgs e)
		{
			//Codigo para obtener promedios de horas con minutos
			string[] tiempos = { "17:20", "18:05", "15:45", "19:10", "17:40" };
			TimeSpan tiempoTotal = new TimeSpan();
			foreach (var tiempo in tiempos)
			{
				tiempoTotal += TimeSpan.Parse(tiempo + ":00");
			}
			long averageTicks = (tiempoTotal.Ticks / tiempos.Length);
			Console.WriteLine("The average is {0}", new TimeSpan(averageTicks));

			// 
			// trackBarTiempoInicio
			// 
			this.trackBarTiempoInicio = new TrackBarMenuItem();
			this.trackBarTiempoInicio.Name = "toolStripTrackBarTiempoInicio";
			this.trackBarTiempoInicio.Maximum = 60;
			this.trackBarTiempoInicio.Minimum = 5;
			this.trackBarTiempoInicio.Size = new System.Drawing.Size(185, 69);
			this.trackBarTiempoInicio.SmallChange = 5;
			this.trackBarTiempoInicio.TickFrequency = 5;
			this.trackBarTiempoInicio.Value = 5;
			this.trackBarTiempoInicio.ValueChanged += new System.EventHandler(this.trackBarTiempoInicio_Scroll);

			// 
			// trackBarTiempoBreak
			// 
			this.trackBarTiempoBreak = new TrackBarMenuItem();
			this.trackBarTiempoBreak.Name = "toolStripTrackBarTiempoInicio";
			this.trackBarTiempoBreak.Maximum = 60;
			this.trackBarTiempoBreak.Minimum = 5;
			this.trackBarTiempoBreak.Size = new System.Drawing.Size(185, 69);
			this.trackBarTiempoBreak.SmallChange = 5;
			this.trackBarTiempoBreak.TickFrequency = 5;
			this.trackBarTiempoBreak.Value = 5;
			this.trackBarTiempoBreak.ValueChanged += new System.EventHandler(this.trackBarTiempoBreak_Scroll);

			//Detección de bloqueo de PC
			SystemEvents.SessionSwitch += SystemEvents_SessionSwitch;

			// 
			// menuItemMinutosInicio
			// 
			this.menuItemMinutosInicio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.trackBarTiempoInicio });
			this.menuItemMinutosBreak.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.trackBarTiempoBreak });


			pathLog = System.Environment.CurrentDirectory + "\\" + Application.ProductName + ".log";
			valorInicialPomodoro = Convert.ToInt32(ConfigurationManager.AppSettings["valorInicialPomodoro"]);
			valorBreakPomodoro = Convert.ToInt32(ConfigurationManager.AppSettings["valorBreakPomodoro"]);
			this.menuItemActivarLog.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["LogEnabled"]); ;
			menuItemMinutosInicio.Text = valorInicialPomodoro + " minutos de trabajo";
			menuItemMinutosBreak.Text = valorBreakPomodoro + " minutos de descanso";
			trackBarTiempoInicio.Value = valorInicialPomodoro;

			this.Opacity = 1 - Convert.ToDouble(ConfigurationManager.AppSettings["opacidad"]);
			switch (this.Opacity)
			{
				case 0.25:
					menuItemTransp75_Click(null, null);
					break;
				case 0.5:
					menuItemTransp50_Click(null, null);
					break;
				case 0.75:
					menuItemTransp25_Click(null, null);
					break;
				case 1:
					menuItemTransp0_Click(null, null);
					break;
				default:
					menuItemTransp0_Click(null, null);
					break;
			}
			this.TopMost = Convert.ToBoolean(ConfigurationManager.AppSettings["TopMost"]);
			menuItemAlwaysOnTop.Checked = this.TopMost;
			this.menuItemAutoSwitch.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["AutoSwitch"]);
			this.menuItemBlink.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["Blink"]); ;
			lblTiempo.Text = "00:00";
			lblTiempo.ForeColor = COLOR_FIN;
			lblStatus.Text = "Doble clic para iniciar";
			valorPomodoroEnEjecucion = valorBreakPomodoro;
			ntfPomodoro.Icon = this.Icon;
			ntfPomodoro.Visible = false;
			ntfPomodoro.ContextMenuStrip = this.ctmMenu;
			PlaceLowerRight();
		}

		private void Pomodoro_MouseDown(object sender, MouseEventArgs e)
		{
			ProcesarVentana(sender, e);
		}
		private void lblTiempo_MouseDown(object sender, MouseEventArgs e)
		{
			ProcesarVentana(sender, e);
		}

		private void lblStatus_MouseDown(object sender, MouseEventArgs e)
		{
			ProcesarVentana(sender, e);
		}

		private void menuItemAlwaysOnTop_Click(object sender, EventArgs e)
		{
			if (menuItemAlwaysOnTop.Checked)
			{
				this.TopMost = false;
				menuItemAlwaysOnTop.Checked = false;
			}
			else
			{
				this.TopMost = true;
				menuItemAlwaysOnTop.Checked = true;
			}
		}

		private void menuItemAutoSwitch_Click(object sender, EventArgs e)
		{
			if (menuItemAutoSwitch.Checked)
			{
				menuItemAutoSwitch.Checked = false;
			}
			else
			{
				menuItemAutoSwitch.Checked = true;
			}
		}

		private void menuItemBlink_Click(object sender, EventArgs e)
		{
			if (menuItemBlink.Checked)
			{
				menuItemBlink.Checked = false;
			}
			else
			{
				menuItemBlink.Checked = true;
			}
		}

		private void menuItemMinutosInicio_Click(object sender, EventArgs e)
		{
			EscribirLogYStatusPomodoro(Causa.PorReinicio);
			menuItemPausarContinuarPomodoro.Checked = false;
			menuItemMinutosInicio.Checked = true;
			menuItemMinutosBreak.Checked = false;
			menuItemIdentificarPomodoroIdealTrabajo.Checked = false;
			menuItemIdentificarPomodoroIdealDescanso.Checked = false;
			valorPomodoroEnEjecucion = valorInicialPomodoro;
			dtmTiempoActualizado = new DateTime(2020, 1, 1, 0, 0, 0);
			//dtmTiempoActualizado = dtmTiempoActualizado.AddSeconds(10);//o 3 segundos para desarrollo, para pruebas internas/unitarias
		   dtmTiempoActualizado = dtmTiempoActualizado.AddMinutes(valorPomodoroEnEjecucion);
			lblTiempo.Text = dtmTiempoActualizado.ToString("mm:ss");
			lblStatus.Text = "P " + valorPomodoroEnEjecucion + " iniciado a : " + DateTime.Now.ToString("hh:mm:ss");
			timerControlTiempo.Start();
		}
		private void menuItemMinutosBreak_Click(object sender, EventArgs e)
		{
			EscribirLogYStatusPomodoro(Causa.PorReinicio);
			menuItemPausarContinuarPomodoro.Checked = false;
			menuItemMinutosInicio.Checked = false;
			menuItemMinutosBreak.Checked = true;
			menuItemIdentificarPomodoroIdealTrabajo.Checked = false;
			menuItemIdentificarPomodoroIdealDescanso.Checked = false;
			valorPomodoroEnEjecucion = valorBreakPomodoro;
			dtmTiempoActualizado = new DateTime(2020, 1, 1, 0, 0, 0);
			//dtmTiempoActualizado = dtmTiempoActualizado.AddSeconds(5);//o 3 segundos para desarrollo, para pruebas internas/unitarias
			dtmTiempoActualizado = dtmTiempoActualizado.AddMinutes(valorPomodoroEnEjecucion);
			lblTiempo.Text = dtmTiempoActualizado.ToString("mm:ss");
			lblStatus.Text = "P " + valorPomodoroEnEjecucion + " iniciado a : " + DateTime.Now.ToString("hh:mm:ss");
			timerControlTiempo.Start();
		}
		private void menuItemIdentificarPomodoroIdealTrabajo_Click(object sender, EventArgs e)
		{
			EscribirLogYStatusPomodoro(Causa.PorReinicio);
			menuItemPausarContinuarPomodoro.Checked = false;
			menuItemMinutosInicio.Checked = false;
			menuItemMinutosBreak.Checked = false;
			menuItemIdentificarPomodoroIdealTrabajo.Checked = true;
			menuItemIdentificarPomodoroIdealDescanso.Checked = false;
			lblTiempo.ForeColor = COLOR_IDEAL_TRABAJO;
			//dtmTiempoActualizado = new DateTime(2020, 1, 1, 0, 58, 50);//10 segundos antes de 1 hora, para desarrollo -> pruebas unitarias
			dtmTiempoActualizado = new DateTime(2020, 1, 1, 0, 0, 0);
			lblStatus.Text = "P I Trabajo iniciado a : " + DateTime.Now.ToString("hh:mm:ss");
			timerControlTiempo.Start();
		}
		private void menuItemIdentificarPomodoroIdealDescanso_Click(object sender, EventArgs e)
		{
			EscribirLogYStatusPomodoro(Causa.PorReinicio);
			menuItemPausarContinuarPomodoro.Checked = false;
			menuItemMinutosInicio.Checked = false;
			menuItemMinutosBreak.Checked = false;
			menuItemIdentificarPomodoroIdealTrabajo.Checked = false;
			menuItemIdentificarPomodoroIdealDescanso.Checked = true;
			lblTiempo.ForeColor = COLOR_IDEAL_DESCANSO;
			dtmTiempoActualizado = new DateTime(2020, 1, 1, 0, 58, 55);//10 segundos antes de 1 hora, para desarrollo -> pruebas unitarias
			//dtmTiempoActualizado = new DateTime(2020, 1, 1, 0, 0, 0);
			lblStatus.Text = "P I Descanso iniciado a : " + DateTime.Now.ToString("hh:mm:ss");
			timerControlTiempo.Start();
		}
		private void EscribirLogYStatusPomodoro(Causa categoria)
		{
			if (!menuItemActivarLog.Checked)//Si no esta activado el Log, salir
				return;
			string mensajeLog = string.Empty;
			string mensajeStatus = string.Empty;
			//string valorOperacionPomodoro = string.Empty;
			switch (categoria)
			{
				case Causa.PorReinicio:
					if (lblTiempo.Text == "00:00")
						return;
					dtmTiempoAuxiliar = new DateTime(2020, 1, 1, 0, valorPomodoroEnEjecucion, 0);
					dtmTiempoAuxiliar = dtmTiempoAuxiliar.Subtract(new TimeSpan(0, 0, dtmTiempoActualizado.Minute, dtmTiempoActualizado.Second));
					if (menuItemMinutosInicio.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Trabajo " + valorPomodoroEnEjecucion + " reiniciado en \t" + dtmTiempoAuxiliar.ToString("mm:ss");//lblTiempo.Text;
					}
					else if (menuItemMinutosBreak.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Descanso " + valorPomodoroEnEjecucion + " reiniciado en \t" + dtmTiempoAuxiliar.ToString("mm:ss");//lblTiempo.Text;
					}
					else if (menuItemIdentificarPomodoroIdealTrabajo.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Ideal Trabajo reiniciado en \t" + lblTiempo.Text;
					}
					else if (menuItemIdentificarPomodoroIdealDescanso.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Ideal Descanso reiniciado en \t" + lblTiempo.Text;
					}
					break;
				case Causa.PorCompletado://Pomodoro ideal trabajo o ideal descanso no aplica para este caso
					if (menuItemMinutosInicio.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Trabajo " + valorPomodoroEnEjecucion + " completado en \t" + valorPomodoroEnEjecucion + ":00";
					}
					else if (menuItemMinutosBreak.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Descanso " + valorPomodoroEnEjecucion + " completado en \t" + +valorPomodoroEnEjecucion + ":00";
					}
					mensajeStatus = "P " + valorPomodoroEnEjecucion + " completado en: " + DateTime.Now.ToString("hh:mm:ss");
					break;
				case Causa.PorFinalizar:
				case Causa.PorSalir:
					dtmTiempoAuxiliar = new DateTime(2020, 1, 1, 0, valorPomodoroEnEjecucion, 0);
					dtmTiempoAuxiliar = dtmTiempoAuxiliar.Subtract(new TimeSpan(0, 0, dtmTiempoActualizado.Minute, dtmTiempoActualizado.Second));
					if (menuItemMinutosInicio.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Trabajo " + valorPomodoroEnEjecucion + " finalizado en \t" + dtmTiempoAuxiliar.ToString("mm:ss");//lblTiempo.Text;
						mensajeStatus = "P " + valorPomodoroEnEjecucion + " finalizado en :" + DateTime.Now.ToString("hh:mm:ss");
					}
					else if (menuItemMinutosBreak.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Descanso " + valorPomodoroEnEjecucion + " finalizado en \t" + dtmTiempoAuxiliar.ToString("mm:ss");//lblTiempo.Text;
						mensajeStatus = "P " + valorPomodoroEnEjecucion + " finalizado en :" + DateTime.Now.ToString("hh:mm:ss");
					}
					else if (menuItemIdentificarPomodoroIdealTrabajo.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Ideal Trabajo finalizado en \t" + lblTiempo.Text;
						mensajeStatus = "P I Trabajo finalizado en : " + DateTime.Now.ToString("hh:mm:ss");
					}
					else if (menuItemIdentificarPomodoroIdealDescanso.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Ideal Descanso finalizado en \t" + lblTiempo.Text;
						mensajeStatus = "P I Descanso finalizado en : " + DateTime.Now.ToString("hh:mm:ss");
					}
					break;
				case Causa.PorInicioPausa:
					dtmTiempoAuxiliar = new DateTime(2020, 1, 1, 0, valorPomodoroEnEjecucion, 0);
					dtmTiempoAuxiliar = dtmTiempoAuxiliar.Subtract(new TimeSpan(0, 0, dtmTiempoActualizado.Minute, dtmTiempoActualizado.Second));
					if (menuItemMinutosInicio.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Trabajo " + valorPomodoroEnEjecucion + "  pausado en \t" + dtmTiempoAuxiliar.ToString("mm:ss");//lblTiempo.Text;
						mensajeStatus = "P " + valorPomodoroEnEjecucion + " pausado en :" + DateTime.Now.ToString("hh:mm:ss");
					}
					else if (menuItemMinutosBreak.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Descanso " + valorPomodoroEnEjecucion + "  pausado en \t" + dtmTiempoAuxiliar.ToString("mm:ss");//lblTiempo.Text;
						mensajeStatus = "P " + valorPomodoroEnEjecucion + " pausado en :" + DateTime.Now.ToString("hh:mm:ss");
					}
					else if (menuItemIdentificarPomodoroIdealTrabajo.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Ideal Trabajo pausado en \t" + lblTiempo.Text;
						mensajeStatus = "P I Trabajo pausado en : " + DateTime.Now.ToString("hh:mm:ss");
					}
					else if (menuItemIdentificarPomodoroIdealDescanso.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Ideal Descanso pausado en \t" + lblTiempo.Text;
						mensajeStatus = "P I Descanso pausado en : " + DateTime.Now.ToString("hh:mm:ss");
					}
					dtmTiempoAuxiliar = DateTime.Now;
					break;
				case Causa.PorCancelarPausa:
					var tiempoTranscurrido = (DateTime.Now - dtmTiempoAuxiliar);
					if (menuItemMinutosInicio.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Trabajo " + valorPomodoroEnEjecucion + "  retomado en \t" + tiempoTranscurrido.ToString(@"mm\:ss"); //tiempoTranscurrido.ToString(@"hh\:mm\:ss")
						mensajeStatus = "P " + valorPomodoroEnEjecucion + " retomado en :" + DateTime.Now.ToString("hh:mm:ss");
					}
					else if (menuItemMinutosBreak.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Descanso " + valorPomodoroEnEjecucion + "  retomado en \t" + tiempoTranscurrido.ToString(@"mm\:ss");
						mensajeStatus = "P " + valorPomodoroEnEjecucion + " retomado en :" + DateTime.Now.ToString("hh:mm:ss");
					}
					else if (menuItemIdentificarPomodoroIdealTrabajo.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Ideal Trabajo retomado en \t" + tiempoTranscurrido.ToString(@"mm\:ss");
						mensajeStatus = "P I Trabajo retomado en : " + DateTime.Now.ToString("hh:mm:ss");
					}
					else if (menuItemIdentificarPomodoroIdealDescanso.Checked)
					{
						mensajeLog = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tPomodoro Ideal Descanso retomado en \t" + tiempoTranscurrido.ToString(@"mm\:ss");
						mensajeStatus = "P I Descanso retomado en : " + DateTime.Now.ToString("hh:mm:ss");
					}
					break;
				default:
					break;
			}
			if(mensajeLog != String.Empty)
			{
				using (StreamWriter escribirArchivo = new StreamWriter(pathLog, true))
				{
					escribirArchivo.WriteLine(mensajeLog);
				}
			}
			if(mensajeStatus != String.Empty)
			{
				lblStatus.Text = mensajeStatus;
			}
		}

		private void timerControlTiempo_Tick(object sender, EventArgs e)
		{
			if(menuItemIdentificarPomodoroIdealTrabajo.Checked || menuItemIdentificarPomodoroIdealDescanso.Checked)
			{
				dtmTiempoActualizado = dtmTiempoActualizado.Add(new TimeSpan(0, 0, 0, 1));
				if(dtmTiempoActualizado.Hour>0)
				{
					lblTiempo.Text = dtmTiempoActualizado.ToString("h:mm:ss");
				}
				else
				{
					lblTiempo.Text = dtmTiempoActualizado.ToString("mm:ss");
				}
				if (dtmTiempoActualizado.Minute >= 59)
				{
					if (menuItemBlink.Checked)
					{
						if (menuItemIdentificarPomodoroIdealTrabajo.Checked)
						{
							if (lblTiempo.ForeColor == COLOR_IDEAL_TRABAJO)
							{
								lblTiempo.ForeColor = COLOR_ALERTA;
							}
							else
							{
								lblTiempo.ForeColor = COLOR_IDEAL_TRABAJO;
							}
						}
						else//Pomodoro Ideal Descanso
						{
							if (lblTiempo.ForeColor == COLOR_IDEAL_DESCANSO)
							{
								lblTiempo.ForeColor = COLOR_ALERTA;
							}
							else
							{
								lblTiempo.ForeColor = COLOR_IDEAL_DESCANSO;
							}
						}
					}
					if(dtmTiempoActualizado.Second==59)
					{
						string pomodoroIdeal;
						if (menuItemIdentificarPomodoroIdealTrabajo.Checked)
						{
							pomodoroIdeal = "trabajo";
						}
						else
						{
							pomodoroIdeal = "descanso";
						}
						MostrarMensajeBalon(SystemIcons.Exclamation, ToolTipIcon.Warning, "Información", "Pomodoro " + pomodoroIdeal + " tomá ya más de una hora", 3000);
					}
				}
				return;
			}
			if (lblTiempo.Text == "00:00")
			{
				timerControlTiempo.Stop();
				lblTiempo.ForeColor = COLOR_FIN;
				EscribirLogYStatusPomodoro(Causa.PorCompletado);
				MostrarMensajeBalon(SystemIcons.Exclamation, ToolTipIcon.Info, "Información", "Fin del Pomodoro " + valorPomodoroEnEjecucion, 3000);
				if (menuItemAutoSwitch.Checked)
				{
					//Ejecuta el metodo contrario
					if (valorPomodoroEnEjecucion == valorInicialPomodoro)
					{
						menuItemMinutosBreak_Click(null, null);
					}
					else
					{
						menuItemMinutosInicio_Click(null, null);
					}
				}
				Application.DoEvents();
			}
			else
			{
				dtmTiempoActualizado = dtmTiempoActualizado.Subtract(new TimeSpan(0, 0, 0, 1));
				lblTiempo.Text = dtmTiempoActualizado.ToString("mm:ss");
				if (dtmTiempoActualizado.Minute < 1 && menuItemBlink.Checked)
				{
					if (valorPomodoroEnEjecucion == valorBreakPomodoro)
					{
						if (lblTiempo.ForeColor == COLOR_DESCANSO)
						{
							lblTiempo.ForeColor = COLOR_ALERTA;
						}
						else
						{
							lblTiempo.ForeColor = COLOR_DESCANSO;
						}
					}
					else
					{
						if (lblTiempo.ForeColor == COLOR_TRABAJO)
						{
							lblTiempo.ForeColor = COLOR_ALERTA;
						}
						else
						{
							lblTiempo.ForeColor = COLOR_TRABAJO;
						}
					}
				}
				else
				{
					if (valorPomodoroEnEjecucion == valorBreakPomodoro)
					{
						lblTiempo.ForeColor = COLOR_DESCANSO;
					}
					else
					{
						lblTiempo.ForeColor = COLOR_TRABAJO;
					}
				}
			}
		}
		private void MostrarMensajeBalon(Icon icon, ToolTipIcon toolTipIcon, string titulo, string texto, int tiempoVisible)
		{
			//ntfPomodoro.Icon = icon;
			ntfPomodoro.BalloonTipTitle = titulo;
			ntfPomodoro.BalloonTipText = texto;
			ntfPomodoro.BalloonTipIcon = toolTipIcon;
			ntfPomodoro.Visible = true;
			ntfPomodoro.ShowBalloonTip(tiempoVisible);
		}

		private void menuItemAcercaDe_Click(object sender, EventArgs e)
		{
			MessageBox.Show("PomodoroVic Timer" +
				Environment.NewLine + "Herramienta de apoyo para medir tu productividad." +
				Environment.NewLine + "Autor: Victor Velepucha" +
				Environment.NewLine +
				Environment.NewLine + "Doble clic para alternar entre pomodoros." +
				Environment.NewLine + "Tiempo en " + COLOR_TRABAJO + " para Pomodoro Trabajo." +
				Environment.NewLine + "Tiempo en " + COLOR_DESCANSO + " para Pomodoro Descanso." +
				Environment.NewLine + "Tiempo en " + COLOR_IDEAL_TRABAJO + " para Pomodorlo Ideal Trabajo." + 
				Environment.NewLine + "Tiempo en " + COLOR_IDEAL_DESCANSO + " para Pomodorlo Ideal Descanso." + 
				Environment.NewLine + "Tiempo en " + COLOR_FIN + " cuando ha finalizado el Pomodoro.",
				"PomodoroVic!!!");
		}

		private void menuItemSalir_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Seguro desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
			if (result == DialogResult.Yes)
			{
				EscribirLogYStatusPomodoro(Causa.PorSalir);
				Application.Exit();
			}
		}

		private void menuItemFinalizar_Click(object sender, EventArgs e)
		{
			if (lblTiempo.Text == "00:00")
				return;
			timerControlTiempo.Stop();
			EscribirLogYStatusPomodoro(Causa.PorFinalizar);
			lblTiempo.Text = "00:00";
			lblTiempo.ForeColor = COLOR_FIN;
		}

		private void menuItemPausarContinuarPomodoro_Click(object sender, EventArgs e)
		{
			if (lblTiempo.Text == "00:00")
				return;
			if (menuItemPausarContinuarPomodoro.Checked)
			{
				timerControlTiempo.Start();
				menuItemPausarContinuarPomodoro.Checked = false;
				EscribirLogYStatusPomodoro(Causa.PorCancelarPausa);
			}
			else
			{
				timerControlTiempo.Stop();
				menuItemPausarContinuarPomodoro.Checked = true;
				EscribirLogYStatusPomodoro(Causa.PorInicioPausa);
			}
		}

		public void SystemEvents_SessionSwitch(object sender, SessionSwitchEventArgs e)
		{
			if (e.Reason == SessionSwitchReason.SessionLock)
			{
				menuItemPausarContinuarPomodoro_Click(null, null);
			}
			if (e.Reason == SessionSwitchReason.SessionUnlock)
			{
				menuItemPausarContinuarPomodoro_Click(null, null);
				MostrarMensajeBalon(SystemIcons.Exclamation, ToolTipIcon.Info, "Información", "Se reanuda pomodoro!!", 3000);
			}
		}


		private void Pomodoro_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				menuItemPausarContinuarPomodoro_Click(null, null);
				// prevent child controls from handling this event as well
				e.SuppressKeyPress = true;
			}
			else if (e.KeyCode == Keys.Escape)
			{
				menuItemFinalizar_Click(null,null);
				// prevent child controls from handling this event as well
				e.SuppressKeyPress = true;
			}
		}

		private void menuItemTransp0_Click(object sender, EventArgs e)
		{
			this.Opacity = 1 - 0;
			menuItemTransp0.Checked = true;
			menuItemTransp25.Checked = false;
			menuItemTransp50.Checked = false;
			menuItemTransp75.Checked = false;
		}

		private void menuItemTransp25_Click(object sender, EventArgs e)
		{
			this.Opacity = 1 - 0.25;
			menuItemTransp0.Checked = false;
			menuItemTransp25.Checked = true;
			menuItemTransp50.Checked = false;
			menuItemTransp75.Checked = false;
		}

		private void menuItemTransp50_Click(object sender, EventArgs e)
		{
			this.Opacity = 1 - 0.5;
			menuItemTransp0.Checked = false;
			menuItemTransp25.Checked = false;
			menuItemTransp50.Checked = true;
			menuItemTransp75.Checked = false;
		}

		private void menuItemTransp75_Click(object sender, EventArgs e)
		{
			this.Opacity = 1 - 0.75;
			menuItemTransp0.Checked = false;
			menuItemTransp25.Checked = false;
			menuItemTransp50.Checked = false;
			menuItemTransp75.Checked = true;
		}
		private void menuItemMinimizarMostrarSystemTray_Click(object sender, EventArgs e)
		{
			if( ! ntfPomodoro.Visible)
			{
				ntfPomodoro.Visible = true;
				this.Hide();
			}
			else
			{
				ntfPomodoro.Visible = false;
				this.Show();
			}
		}

		private void ntfPomodoro_DoubleClick(object sender, EventArgs e)
		{
			this.Show();
			ntfPomodoro.Visible = false;
			this.WindowState = FormWindowState.Normal;
		}

		private void ntfPomodoro_MouseMove(object sender, MouseEventArgs e)
		{
			this.ntfPomodoro.Text = lblTiempo.Text;
		}

		private void trackBarTiempoInicio_Scroll(object sender, EventArgs e)
		{
			valorInicialPomodoro = Convert.ToInt32(trackBarTiempoInicio.Value);
			menuItemMinutosInicio.Text = valorInicialPomodoro + " minutos de trabajo";
		}
		private void trackBarTiempoBreak_Scroll(object sender, EventArgs e)
		{
			valorBreakPomodoro = Convert.ToInt32(trackBarTiempoBreak.Value);
			menuItemMinutosBreak.Text = valorBreakPomodoro + " minutos de descanso";
		}

		private void menuItemActivarLog_Click(object sender, EventArgs e)
		{
			if (menuItemActivarLog.Checked)
			{
				menuItemActivarLog.Checked = false;
			}
			else
			{
				menuItemActivarLog.Checked = true;
			}
		}

		private void Pomodoro_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.trackBarTiempoBreak.ValueChanged -= new System.EventHandler(this.trackBarTiempoBreak_Scroll);
			SystemEvents.SessionSwitch -= SystemEvents_SessionSwitch;

		}

		private void ProcesarVentana(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, IntPtr.Zero);
			}
			if (e.Button == MouseButtons.Left && e.Clicks == 2)
			{
				//Ejecuta el metodo contrario
				if (valorPomodoroEnEjecucion == valorInicialPomodoro)
				{
					menuItemMinutosBreak_Click(null, null);
				}
				else
				{
					menuItemMinutosInicio_Click(null, null);
				}
			}
			if (e.Button == MouseButtons.Right)
			{
				ctmMenu.Show(lblTiempo, new Point(e.X, e.Y));
			}
		}

		private void PlaceLowerRight()
		{
			Screen rightmost = Screen.AllScreens[0];
			foreach (Screen screen in Screen.AllScreens)
			{
				if (screen.WorkingArea.Right > rightmost.WorkingArea.Right)
					rightmost = screen;
			}

			this.Left = rightmost.WorkingArea.Right - this.Width;
			this.Top = rightmost.WorkingArea.Bottom - this.Height;
		}
	}
	[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip |
								   ToolStripItemDesignerAvailability.ContextMenuStrip)]
	public class TrackBarMenuItem : ToolStripControlHost
	{
		private TrackBar trackBar;

		public TrackBarMenuItem() : base(new TrackBar())
		{
			this.trackBar = this.Control as TrackBar;
		}

		// Add properties, events etc. you want to expose...
		public int Maximum { get => trackBar.Maximum; set => trackBar.Maximum = value; }
		public int Minimum { get => trackBar.Minimum; set => trackBar.Minimum = value; }
		public int SmallChange { get => trackBar.SmallChange; set => trackBar.SmallChange = value; }
		public int TickFrequency { get => trackBar.TickFrequency; set => trackBar.TickFrequency = value; }
		public int Value { get => trackBar.Value; set => trackBar.Value = value; }
		/// <summary>
		/// Attach to events we want to re-wrap
		/// </summary>
		/// <param name="control"></param>
		protected override void OnSubscribeControlEvents(Control control)
		{
			base.OnSubscribeControlEvents(control);
			TrackBar trackBar = control as TrackBar;
			trackBar.ValueChanged += new EventHandler(trackBar_ValueChanged);
		}
		/// <summary>
		/// Detach from events.
		/// </summary>
		/// <param name="control"></param>
		protected override void OnUnsubscribeControlEvents(Control control)
		{
			base.OnUnsubscribeControlEvents(control);
			TrackBar trackBar = control as TrackBar;
			trackBar.ValueChanged -= new EventHandler(trackBar_ValueChanged);
		}
		/// <summary>
		/// Routing for event
		/// TrackBar.ValueChanged -> ToolStripTrackBar.ValueChanged
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void trackBar_ValueChanged(object sender, EventArgs e)
		{
			// when the trackbar value changes, fire an event.
			if (this.ValueChanged != null)
			{
				ValueChanged(sender, e);
			}
		}
		// add an event that is subscribable from the designer.
		public event EventHandler ValueChanged;
	}
}
