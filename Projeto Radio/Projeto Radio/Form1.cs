using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace Projeto_Radio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")

            {

                MessageBox.Show("teste");
            }


        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //timeChecker();


        }
        WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

        private void playMusic(string picker)
        {
            string nomeMusica = picker;
            Control nomeMusicaCtn = ((TextBox)this.Controls.Find(nomeMusica, true)[0]);
            wplayer.URL = nomeMusicaCtn.Text;
            wplayer.controls.play();
            MessageBox.Show(nomeMusicaCtn.Text);
        }
        private void stopMusic()
        {
            wplayer.controls.stop();
        }
        private string verificar()
        {

            // int Valor = inicioPicker1.Value.Hour - DateTime.Now.Hour;
            int Valor = 99;
            int ValorAgora;
            string stringDate = string.Empty;
            foreach (Control control in this.Controls) {
                if (control is GroupBox) {

                    foreach (Control gb in control.Controls)
                    {
                        if (gb is DateTimePicker)
                        {
                            ValorAgora = ((DateTimePicker)gb).Value.Hour - DateTime.Now.Hour;
                            if (ValorAgora >= 0)
                            {
                                if (ValorAgora == 0)
                                {

                                    /* if (((DateTimePicker)gb).Value.Minute > DateTime.Now.Minute)
                                     {
                                         stringDate = ((DateTimePicker)gb).Name;
                                         goto Finish;                                        
                                     }*/
                                    stringDate = ((DateTimePicker)gb).Name;
                                    goto Finish;
                                }
                                if (ValorAgora < Valor)

                                {
                                    Valor = ValorAgora;
                                    stringDate = ((DateTimePicker)gb).Name;

                                }
                            }
                        }
                    }
                }

            }
            if (stringDate == string.Empty)
            {
                return "inicioPicker1";
            }

        Finish:
            return stringDate;

        }

        public int timeChecker()
        {
            string resultString = Regex.Match(verificar(), @"\d+").Value;

            string Inicio = "inicioPicker" + resultString;
            Control picker1 = ((DateTimePicker)this.Controls.Find(Inicio, true)[0]);
            int horasStart = ((DateTimePicker)picker1).Value.Hour;
            int minutosStart = ((DateTimePicker)picker1).Value.Minute;
            //DESCOBRIR NUMERO E TRANSFORMAR EM STRING
            string Final = "fimPicker" + resultString;
            Control picker2 = ((DateTimePicker)this.Controls.Find(Final, true)[0]);
            int minutosStop = ((DateTimePicker)picker2).Value.Minute;
            //int horasStop = ((DateTimePicker)picker2).Value.Minute;
            int minutosNow = DateTime.Now.Minute;
            int horasNow = DateTime.Now.Hour;


            string tempoLabel = "tempoLabel" + resultString;
            Control tempoLabelCtn = ((Label)this.Controls.Find(tempoLabel, true)[0]);

            string estadoLabel = "estadoLabel" + resultString;
            Control estadoLabelctn = ((Label)this.Controls.Find(estadoLabel, true)[0]);

            string nomeMusica = "nomeMusica" + resultString;
            Control nomeMusicaCtn = ((TextBox)this.Controls.Find(nomeMusica, true)[0]);

            if ((horasNow - horasStart) == 0)
            {
                ((Label)tempoLabelCtn).Text = "00:" + (minutosNow - minutosStart).ToString();
                if (minutosNow - minutosStart == 0)
                {
                    playMusic(nomeMusica);
                    estadoLabelctn.Text = "A correr....";
                    estadoLabelctn.ForeColor = Color.Green;
                }
                if (minutosStop - minutosNow == 0)
                {
                    stopMusic();
                    estadoLabelctn.Text = "Parado....";
                    estadoLabelctn.ForeColor = Color.Red;
                }
                return minutosNow - minutosStart;
            }
            else
            {
                tempoLabelCtn.Text = (horasNow - horasStart).ToString() + ":" + (minutosStart - minutosNow).ToString();
            }
            return 0;
        }

        public void fileChoser(int gpb)
        {
            string box = "nomeMusica" + gpb;
            Control boxCtn = ((TextBox)this.Controls.Find(box, true)[0]);
            OpenFileDialog folder = new OpenFileDialog();
            folder.Filter = "MP3|*.mp3";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                boxCtn.Text = folder.FileName;
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            timeChecker();

        }

        private void label6_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fileChoser(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stopMusic();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {
            Checker abrir = new Checker();
            abrir.Show();
        }

        private void nomeMusica1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            fileChoser(2);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            fileChoser(3);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            fileChoser(4);

        }

        private void button22_Click(object sender, EventArgs e)
        {
            fileChoser(5);

        }

        private void button19_Click(object sender, EventArgs e)
        {
            fileChoser(6);

        }

        private void button16_Click(object sender, EventArgs e)
        {
            fileChoser(7);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            fileChoser(8);
        }
    }
}
