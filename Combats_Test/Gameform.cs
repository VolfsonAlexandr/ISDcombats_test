using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Combats_Test
{
    public partial class Gameform : Form
    {
        public Label[] NameLabels;
        public Label[] HpLabels;
        public ProgressBar[] HpProgressBars;
        public ComboBox[] Comboboxes;
        public Gameform(string username)
        {
            InitializeComponent();
            NameLabels = new[] { label1, label4 };
            HpLabels = new[] { label2, label3 };
            HpProgressBars = new[] { progressBar1, progressBar2 };
            Comboboxes = new[] { comboBox1, comboBox2 };
            Manager.gameform = this;
            Manager.CreateGamers(username, "Computer");
            Manager.SetEventHandlers();
            this.Show();
            BeginGame();
        }

        public void UpdateComponents()
        {
            for (int i = 0; i < 2; i++)
            {
                NameLabels[i].Text = Manager.Gamers[i].Name;
                HpLabels[i].Text = Manager.Gamers[i].Hp.ToString();
                HpProgressBars[i].Value = Manager.Gamers[i].Hp;
                Comboboxes[i].Enabled = false;
            }
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            button1.Enabled = false;
            button2.Enabled = true;
        }

        public void BeginGame()
        {
            MessageBox.Show("Игра началась!");
            Manager.Round = 0;
            Manager.Round++;
            UpdateComponents();
            button2.Text = "Начать раунд №" + Manager.Round;
        }
        public void EndRound()
        {
            listBox1.Items.Add("Здоровье игрока " + Manager.Gamers[0].Name + ": " + Manager.Gamers[0].Hp);
            listBox1.Items.Add("Здоровье игрока " + Manager.Gamers[1].Name + ": " + Manager.Gamers[1].Hp);
            Manager.Round++;
            UpdateComponents();
            button2.Text = "Начать раунд №" + Manager.Round;
        }

        public void EndGame()
        {
            MessageBox.Show("Игра завершена!");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager.SavePartOfBody();
            Manager.Battle();
        }

        public void Block(Gamer gamer, GamerArgs e)
        {
            MessageBox.Show(Manager.MessagesAfterRoundBlock());
            listBox1.Items.Add("Игрок " + Manager.DefensingGamer().Name + " заблокировал удар в ");
            listBox1.Items.Add(Manager.PartsOfBody[0].ToString() + " игрока " + Manager.AttakingGamer().Name);
            EndRound();
        }

        public void Wound(Gamer gamer, GamerArgs e)
        {
            MessageBox.Show(Manager.MessagesAfterRoundWound());
            listBox1.Items.Add("Игрок " + Manager.AttakingGamer().Name + " нанес удар в ");
            listBox1.Items.Add(Manager.PartsOfBody[1].ToString() + " игроку " + Manager.DefensingGamer().Name);
            Manager.HpLabelForDG().Text = Manager.DefensingGamer().Hp.ToString();
            Manager.HpProgressBarForDG().Value = Manager.DefensingGamer().Hp;
            EndRound();
        }

        public void Death(Gamer gamer, GamerArgs e)
        {
            listBox1.Items.Add("Игрок " + Manager.DefensingGamer().Name + " умер. Игра окончена.");
            MessageBox.Show(Manager.MessagesAfterRoundDeath());
            EndGame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Manager.Revers();
            listBox1.Items.Add("Раунд № " + Manager.Round + " начался!");
            MessageBox.Show(Manager.MessagesBeforeRound());
            button1.Text = Manager.TextsOnButton();
            button2.Enabled = false;
            Manager.ComboboxForSelect().Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
