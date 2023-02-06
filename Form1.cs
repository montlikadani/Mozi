using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CorvinMozi {
    public partial class Form1 : Form {

        private readonly Mozi mozi;
        private int currentMozi = 0;

        private readonly Image[] kepek = new Image[] { Properties.Resources.ures, Properties.Resources.gyerek, Properties.Resources.felnott };

        public Form1() {
            InitializeComponent();

            mozi = new Mozi(GetResourceFileByName("CorvinMozi.csv"));
            UpdatePanelItems();
        }

        public static string GetResourceFileByName(string name) {
            return string.Format("{0}Resources\\{1}", Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")), name);
        }

        private void UpdatePanelItems() {
            Terem terem = mozi.termek[currentMozi];

            Text = $"{terem.nev} terem";

            if (currentMozi == 0) {
                leftButton.Hide();
            } else if (currentMozi == mozi.termek.Count - 1) {
                rightButton.Hide();
            } else {
                leftButton.Show();
                rightButton.Show();
            }

            Control.ControlCollection controlCollection = panelPictureBox.Controls;

            iconBox.BackgroundImage = terem.nevadokep;
            controlCollection.Clear();

            int size = 25;

            for (int i = 0; i < terem.sorok; i++) {
                for (int j = 0; j < terem.szekek; j++) {
                    PictureBox pictureBox = new PictureBox() {
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = new KeyValuePair<int, int>(i, j),
                        Cursor = Cursors.Hand
                    };

                    switch (terem.ulesek[i, j]) {
                        case 'F':
                            pictureBox.BackgroundImage = kepek[2];
                            break;
                        case 'D':
                            pictureBox.BackgroundImage = kepek[1];
                            break;
                        default:
                            pictureBox.BackgroundImage = kepek[0];
                            break;
                    }

                    pictureBox.SetBounds(i * size, j * size, size, size);

                    pictureBox.Click += (o, e) => {
                        if (o is PictureBox clicked && clicked.Tag is KeyValuePair<int, int> pair) {
                            switch (terem.ulesek[pair.Key, pair.Value]) {
                                case 'F':
                                    terem.ulesek[pair.Key, pair.Value] = ' ';
                                    clicked.BackgroundImage = kepek[0];
                                    break;
                                case 'D':
                                    terem.ulesek[pair.Key, pair.Value] = 'F';
                                    clicked.BackgroundImage = kepek[2];
                                    break;
                                default:
                                    terem.ulesek[pair.Key, pair.Value] = 'D';
                                    clicked.BackgroundImage = kepek[1];
                                    break;
                            }
                        }
                    };

                    controlCollection.Add(pictureBox);
                }
            }
        }

        private void leftButton_Click(object sender, EventArgs e) {
            if (currentMozi-- < 1) {
                currentMozi = mozi.termek.Count - 1;
            }

            UpdatePanelItems();
        }

        private void rightButton_Click(object sender, EventArgs e) {
            if (currentMozi++ >= mozi.termek.Count) {
                currentMozi = 0;
            }

            UpdatePanelItems();
        }

        private void SaveButton_Click(object sender, EventArgs e) {
            mozi.Mentes();
        }

        private void ButtonStatistics_Click(object sender, EventArgs e) {
            try {
                string name = $"statisztika_{DateTime.Now:yyyymmdd}.txt";

                using (StreamWriter writer = new StreamWriter(name)) {
                    string separator = new string('-', 45);

                    writer.WriteLine($"{separator}\nAz egyes termek bevétele a jegyárusításból:\n{separator}");

                    double total = 0;

                    foreach (Terem terem in mozi.termek) {
                        double payment = terem.TotalPayment();
                        total += payment;

                        writer.WriteLine($"{terem.nev,25} terem: {payment,2} Ft");
                    }

                    writer.WriteLine($"{separator}\n{"összesen",30}: {total,2} Ft");
                    writer.WriteLine($"{separator}\nAz üres helyek és az összes helyek aránya:\n{separator}");

                    foreach (Terem terem in mozi.termek) {
                        writer.WriteLine($"{terem.nev,25} = {terem.AverageEmptyChairs() * 100,2:0.00}%".Replace('.', ','));
                    }

                    writer.WriteLine(separator);

                    if (mozi.termek.Where(terem => {
                        Terem.ChairData chairData = terem.FreeChairs();

                        if (chairData != null) {
                            writer.WriteLine(
                                $"A {chairData.RoomName} terem {chairData.Line + 1}. széksorában szabad egymás mellett a {chairData.FirstFreeChair + 1}. és {chairData.SecondFreeChair + 1}. szék!");
                            return true;
                        }

                        return false;
                    }).Count() == 0) {
                        writer.WriteLine("Egyik teremben sem található egymás melletti két üres szék!");
                    }

                    writer.WriteLine(separator);
                }

                System.Diagnostics.Process.Start("notepad.exe", $"{Directory.GetCurrentDirectory()}\\{name}");
            } catch (Exception ex) {
                MessageBox.Show($"Hiba lépett fel a statisztikai adatok mentésekor: {ex.Message}\n{ex.StackTrace}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
