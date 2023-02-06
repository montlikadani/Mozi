using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CorvinMozi {
    public sealed class Mozi {
    
        public readonly List<Terem> termek = new List<Terem>();

        public Mozi(string forras) {
            try {
                using (StreamReader reader = File.OpenText(forras)) {
                    while (!reader.EndOfStream) {
                        string name = reader.ReadLine();
                        string[] split = reader.ReadLine().Split(';');
                        int sorok = int.Parse(split[0]);
                        int szekekSzama = int.Parse(split[1]);
                        char[,] ulesek = new char[sorok, szekekSzama];

                        string line;
                        while (!string.IsNullOrEmpty(line = reader.ReadLine())) {
                            split = line.Split(';');

                            string ticketType = split[2];

                            ulesek[int.Parse(split[0]) - 1, int.Parse(split[1]) - 1] = ticketType.Length == 0 ? ' ' : char.Parse(ticketType);
                        }

                        termek.Add(new Terem(name, System.Drawing.Image.FromFile(Form1.GetResourceFileByName(name.Split(' ')[0] + ".jpg")), sorok, szekekSzama, ulesek));
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show($"Hiba lépett fel a fájl betöltésekor: {ex.Message}\n{ex.StackTrace}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        public void Mentes() {
            try {
                using (StreamWriter writer = File.CreateText($"{Directory.GetCurrentDirectory()}\\CorvinMozi.csv")) {
                    foreach (Terem terem in termek) {
                        writer.WriteLine($"{terem.nev}\n{terem.sorok};{terem.szekek}");

                        int secondLength = terem.ulesek.GetLength(1);
                        int firstLength = terem.ulesek.GetLength(0);

                        for (int i = 0; i < firstLength; i++) {
                            for (int j = 0; j < secondLength; j++) {
                                writer.WriteLine(string.Join(";", i, j, terem.ulesek[i, j]));
                            }
                        }

                        writer.WriteLine();
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show($"Hiba lépett fel a fájl mentésekor: {ex.Message}\n{ex.StackTrace}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Fájl mentése sikeres", "Mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
