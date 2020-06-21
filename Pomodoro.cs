using System;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Design;

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
			// 
			// menuItemMinutosInicio
			// 
			this.menuItemMinutosInicio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.trackBarTiempoInicio });
			this.menuItemMinutosBreak.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.trackBarTiempoBreak });


			pathLog = System.Environment.CurrentDirectory + "\\" + Application.ProductName + ".log";
			valorInicialPomodoro = Convert.ToInt32(ConfigurationManager.AppSettings["valorInicialPomodoro"]);
			valorBreakPomodoro = Convert.ToInt32(ConfigurationManager.AppSettings["valorBreakPomodoro"]);
			this.menuItemActivarLog.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["LogEnabled"]); ;
			menuItemMinutosInicio.Text = valorInicialPomodoro + " minutos de inicio";
			menuItemMinutosBreak.Text = valorBreakPomodoro + " minutos de descanso";
			trackBarTiempoInicio.Value = valorInicialPomodoro;

			this.Opacity = 1 - Convert.ToDouble(ConfigurationManager.AppSettings["opacidad"]);
			this.TopMost = Convert.ToBoolean(ConfigurationManager.AppSettings["TopMost"]);
			menuItemAlwaysOnTop.Checked = this.TopMost;
			this.menuItemAutoSwitch.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["AutoSwitch"]);
			this.menuItemBlink.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["Blink"]); ;
			lblTiempo.Text = "00:00";
			lblTiempo.ForeColor = System.Drawing.Color.Maroon;
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
			EscribitLogPomodoroSiAplica();
			menuItemMinutosInicio.Checked = true;
			menuItemMinutosBreak.Checked = false;
			menuItemIdentificarPomodoroIdeal.Checked = false;
			ProcesarPomodoro(valorInicialPomodoro);
		}
		private void menuItemMinutosBreak_Click(object sender, EventArgs e)
		{
			EscribitLogPomodoroSiAplica();
			menuItemMinutosInicio.Checked = false;
			menuItemMinutosBreak.Checked = true;
			menuItemIdentificarPomodoroIdeal.Checked = false;
			ProcesarPomodoro(valorBreakPomodoro);
		}
		private void menuItemIdentificarPomodoroIdeal_Click(object sender, EventArgs e)
		{
			EscribitLogPomodoroSiAplica();
			menuItemMinutosInicio.Checked = false;
			menuItemMinutosBreak.Checked = false;
			menuItemIdentificarPomodoroIdeal.Checked = true;
			lblTiempo.ForeColor = System.Drawing.Color.MediumVioletRed;
			dtmTiempoActualizado = new DateTime(2020, 1, 1, 0, 0, 0);
			lblStatus.Text = "P ideal iniciado a : " + DateTime.Now.ToString("hh:mm:ss");
			if (menuItemActivarLog.Checked)
			{
				using (StreamWriter escribirArchivo = new StreamWriter(pathLog, true))
				{
					escribirArchivo.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tP ideal iniciado");
				}
			}
			timerControlTiempo.Start();
		}
		private void EscribitLogPomodoroSiAplica()
		{
			if (menuItemActivarLog.Checked && lblTiempo.Text != "00:00")
			{
				if (menuItemMinutosInicio.Checked)
				{
					using (StreamWriter escribirArchivo = new StreamWriter(pathLog, true))
					{
						escribirArchivo.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tP " + valorPomodoroEnEjecucion + " reiniciado faltando " + lblTiempo.Text);
					}
				}
				else if (menuItemMinutosBreak.Checked)
				{
					using (StreamWriter escribirArchivo = new StreamWriter(pathLog, true))
					{
						escribirArchivo.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tP " + valorPomodoroEnEjecucion + " reiniciado faltando " + lblTiempo.Text);
					}
				}
				else if (menuItemIdentificarPomodoroIdeal.Checked)
				{
					using (StreamWriter escribirArchivo = new StreamWriter(pathLog, true))
					{
						escribirArchivo.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tP ideal finalizado en " + lblTiempo.Text);
					}
				}
			}
		}
		private void ProcesarPomodoro(int valorPomodoroAEjecutar)
		{
			valorPomodoroEnEjecucion = valorPomodoroAEjecutar;
			dtmTiempoAuxiliar = new DateTime(2020, 1, 1, 0, 0, 0);
			dtmTiempoActualizado = new DateTime(2020, 1, 1, 0, 0, 0);
			//dtmTiempoActualizado = dtmTiempoActualizado.AddSeconds(10);//o 3 segundos para desarrollo, para pruebas internas/unitarias
			dtmTiempoActualizado = dtmTiempoActualizado.AddMinutes(valorPomodoroAEjecutar);
			lblStatus.Text = "P " + valorPomodoroEnEjecucion + " iniciado a : " + DateTime.Now.ToString("hh:mm:ss");
			if (menuItemActivarLog.Checked)
			{
				using (StreamWriter escribirArchivo = new StreamWriter(pathLog, true))
				{
					escribirArchivo.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tP " + valorPomodoroEnEjecucion + " iniciado");
				}
			}
			timerControlTiempo.Start();
		}

		private void timerControlTiempo_Tick(object sender, EventArgs e)
		{
			if(menuItemIdentificarPomodoroIdeal.Checked )
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
				if (dtmTiempoActualizado.Minute >= 59 && menuItemBlink.Checked)
				{
					if (lblTiempo.ForeColor == System.Drawing.Color.MediumVioletRed)
					{
						lblTiempo.ForeColor = System.Drawing.Color.Red;
					}
					else
					{
						lblTiempo.ForeColor = System.Drawing.Color.MediumVioletRed;
					}
				}

				return;
			}
			if (dtmTiempoActualizado <= dtmTiempoAuxiliar)
			{
				timerControlTiempo.Stop();
				lblTiempo.ForeColor = System.Drawing.Color.Maroon;
				lblStatus.Text = "P " + valorPomodoroEnEjecucion + " finalizado en: " + DateTime.Now.ToString("hh:mm:ss");
				if (menuItemActivarLog.Checked)
				{
					using (StreamWriter escribirArchivo = new StreamWriter(pathLog, true))
					{
						escribirArchivo.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tP " + valorPomodoroEnEjecucion + " finalizado");
					}
				}

				ntfPomodoro.Icon = SystemIcons.Exclamation;
				ntfPomodoro.BalloonTipTitle = "Mensaje";
				ntfPomodoro.BalloonTipText = "Fin del Pomodoro " + valorPomodoroEnEjecucion;
				ntfPomodoro.BalloonTipIcon = ToolTipIcon.Info;
				ntfPomodoro.Visible = true;
				ntfPomodoro.ShowBalloonTip(30000);
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
						if (lblTiempo.ForeColor == System.Drawing.Color.SteelBlue)
						{
							lblTiempo.ForeColor = System.Drawing.Color.Maroon;
						}
						else
						{
							lblTiempo.ForeColor = System.Drawing.Color.SteelBlue;
						}
					}
					else
					{
						if (lblTiempo.ForeColor == System.Drawing.Color.Navy)
						{
							lblTiempo.ForeColor = System.Drawing.Color.Maroon;
						}
						else
						{
							lblTiempo.ForeColor = System.Drawing.Color.Navy;
						}
					}
				}
				else
				{
					if (valorPomodoroEnEjecucion == valorBreakPomodoro)
					{
						lblTiempo.ForeColor = System.Drawing.Color.SteelBlue;
					}
					else
					{
						lblTiempo.ForeColor = System.Drawing.Color.Navy;
					}
				}
			}
		}

		private void menuItemAcercaDe_Click(object sender, EventArgs e)
		{
			MessageBox.Show("PomodoroVic Timer" +
				Environment.NewLine + "Herramienta de apoyo para alertad acerca de tu productividad." +
				Environment.NewLine + "Autor: Victor Velepucha" +
				Environment.NewLine +
				Environment.NewLine + "Doble clic para alternar entre pomodoros." +
				Environment.NewLine + "Tiempo en color celeste para Pomodoro Trabajo." +
				Environment.NewLine + "Tiempo en color azul para Pomodoro descanso." +
				Environment.NewLine + "Tiempo en color rojo cuando ha finalizado.",
				"PomodoroVic!!!");
		}

		private void menuItemSalir_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Seguro desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
			if (result == DialogResult.Yes)
			{
				string valorPomodoroActual = (menuItemIdentificarPomodoroIdeal.Checked) ? "ideal" : valorPomodoroEnEjecucion.ToString();
				if (menuItemActivarLog.Checked)
				{
					using (StreamWriter escribirArchivo = new StreamWriter(pathLog, true))
					{
						escribirArchivo.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tP " + valorPomodoroActual + " finalizado en " + lblTiempo.Text);
					}
				}
				Application.Exit();
			}
		}

		private void menuItemCancelar_Click(object sender, EventArgs e)
		{
			if (lblTiempo.Text == "00:00")
				return;
			timerControlTiempo.Stop();
			string valorPomodoroActual = (menuItemIdentificarPomodoroIdeal.Checked) ? "ideal" : valorPomodoroEnEjecucion.ToString();
			if (menuItemActivarLog.Checked)
			{
				using (StreamWriter escribirArchivo = new StreamWriter(pathLog, true))
				{
					escribirArchivo.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tP " + valorPomodoroActual + " finalizado en " + lblTiempo.Text);
				}
			}
			lblTiempo.Text = "00:00";
			lblTiempo.ForeColor = System.Drawing.Color.Maroon;
			lblStatus.Text = "P " + valorPomodoroActual + " finalizado en :" + DateTime.Now.ToString("hh:mm:ss");
		}

		private void menuItemPausarContinuarPomodoro_Click(object sender, EventArgs e)
		{
			if (lblTiempo.Text == "00:00")
				return;
			string valorPomodoroActual = (menuItemIdentificarPomodoroIdeal.Checked) ? "ideal" : valorPomodoroEnEjecucion.ToString();
			if (menuItemPausarContinuarPomodoro.Checked)
			{
				menuItemPausarContinuarPomodoro.Checked = false;
				if (menuItemActivarLog.Checked)
				{
					using (StreamWriter escribirArchivo = new StreamWriter(pathLog, true))
					{
						escribirArchivo.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tP " + valorPomodoroActual + " retomado en " + lblTiempo.Text);
					}
				}
				lblStatus.Text = "P " + valorPomodoroActual + " retomado en :" + DateTime.Now.ToString("hh:mm:ss");
				timerControlTiempo.Start();
			}
			else
			{
				menuItemPausarContinuarPomodoro.Checked = true;
				lblStatus.Text = "P " + valorPomodoroActual + " pausado en :" + DateTime.Now.ToString("hh:mm:ss");
				timerControlTiempo.Stop();
				if (menuItemActivarLog.Checked)
				{
					using (StreamWriter escribirArchivo = new StreamWriter(pathLog, true))
					{
						escribirArchivo.WriteLine(System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\tP " + valorPomodoroActual + " pausado en " + lblTiempo.Text);
					}
				}
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
				menuItemCancelar_Click(null,null);
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
			menuItemMinutosInicio.Text = valorInicialPomodoro + " minutos de inicio";
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
