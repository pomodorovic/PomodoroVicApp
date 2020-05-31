using System;
using System.Configuration;
using System.Windows.Forms;

namespace PomodoroVicApp
{
	public partial class Pomodoro : Form
	{
		private System.DateTime dtmTiempoAuxiliar;
		private System.DateTime dtmTiempoActualizado;
		private int valorInicialPomodoro, valorBreakPomodoro;

		public Pomodoro()
		{
			InitializeComponent();
		}

		private void Pomodoro_Load(object sender, EventArgs e)
		{
			lblTiempo.Text = "00:00";
			valorInicialPomodoro = Convert.ToInt32(ConfigurationManager.AppSettings["valorInicialPomodoro"]);
			valorBreakPomodoro = Convert.ToInt32(ConfigurationManager.AppSettings["valorBreakPomodoro"]);

		}

		private void btnIniciar_Click(object sender, EventArgs e)
		{
			dtmTiempoAuxiliar = new DateTime(1901, 1, 1, 1, 0, 0);
			dtmTiempoActualizado = new DateTime(1901, 1, 1, 1, 0, 0);
			//dtmTiempoActualizado = dtmTiempoActualizado.AddSeconds(3);//3 segundos para desarrollo
			dtmTiempoActualizado = dtmTiempoActualizado.AddMinutes(valorInicialPomodoro);
			lblTiempo.Text = dtmTiempoActualizado.ToString("mm:ss");
			lblStatus.Text = "P " + valorInicialPomodoro + " niciado a : " + DateTime.Now.ToString("hh:mm:ss");
			timerControlTiempo.Start();
		}
		private void btnBreak_Click(object sender, EventArgs e)
		{
			dtmTiempoAuxiliar = new DateTime(1901, 1, 1, 1, 0, 0);
			dtmTiempoActualizado = new DateTime(1901, 1, 1, 1, 0, 0);
			//dtmTiempoActualizado = dtmTiempoActualizado.AddSeconds(2);//2 segundos para desarrollo
			dtmTiempoActualizado = dtmTiempoActualizado.AddMinutes(valorBreakPomodoro);
			lblTiempo.Text = dtmTiempoActualizado.ToString("mm:ss");
			lblStatus.Text = "P " + valorBreakPomodoro + " iniciado a : " + DateTime.Now.ToString("hh:mm:ss");
			timerControlTiempo.Start();
		}

		private void timerControlTiempo_Tick(object sender, EventArgs e)
		{
			dtmTiempoActualizado = dtmTiempoActualizado.Subtract(new TimeSpan(0, 0, 0, 1));
			lblTiempo.Text = dtmTiempoActualizado.ToString("mm:ss");
			//label1.Text = dtmTiempoAuxiliar.ToString("mm:ss");
			if (dtmTiempoActualizado <= dtmTiempoAuxiliar)
			{
				timerControlTiempo.Stop();
				MessageBox.Show("Fin del tiempo", "Fin Pomodoro!!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
			}
		}
	}
}
