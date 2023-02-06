using System.Drawing;

namespace CorvinMozi {
    public class Terem {

        public string nev { get; private set; }
        public Image nevadokep { get; private set; }
        public int sorok { get; private set; }
        public int szekek { get; private set; }
        public char[,] ulesek { get; private set; }

        public Terem(string nev, Image nevadokep, int sorok, int szekek, char[,] ulesek) {
            this.nev = nev;
            this.nevadokep = nevadokep;
            this.sorok = sorok;
            this.szekek = szekek;
            this.ulesek = ulesek;
        }

        public int TotalPayment() {
            int length = ulesek.GetLength(0);
            int length2 = ulesek.GetLength(1);
            int amount = 0;

            for (int i = 0; i < length; i++) {
                for (int j = 0; j < length2; j++) {
                    switch (ulesek[i, j]) {
                        case 'F':
                            amount += 1700;
                            break;
                        case 'D':
                            amount += 1200;
                            break;
                        default:
                            break;
                    }
                }
            }

            return amount;
        }

        public double AverageEmptyChairs() {
            int length = ulesek.GetLength(0);
            int length2 = ulesek.GetLength(1);
            double ures = 0;

            for (int i = 0; i < length; i++) {
                for (int j = 0; j < length2; j++) {
                    if (FreeSpaceAt(ulesek[i, j])) {
                        ures++;
                    }
                }
            }

            return ures / (length * length2);
        }

        public ChairData FreeChairs() {
            int length = ulesek.GetLength(0);
            int length2 = ulesek.GetLength(1) - 1;

            for (int i = 0; i < length; i++) {
                for (int j = 0; j < length2; j++) {
                    if (FreeSpaceAt(ulesek[i, j])) {
                        int n = j + 1;

                        if (FreeSpaceAt(ulesek[i, n])) {
                            return new ChairData(nev, i, j, n);
                        }
                    }
                }
            }

            return null;
        }

        private bool FreeSpaceAt(char at) {
            return at == ' ' || at == '\0';
        }

        public sealed class ChairData {

            public string RoomName { get; private set; }
            public int Line { get; private set; }
            public int FirstFreeChair { get; private set; }
            public int SecondFreeChair { get; private set; }

            public ChairData(string roomName, int line, int firstFreeChair, int secondFreeChair) {
                RoomName = roomName;
                Line = line;
                FirstFreeChair = firstFreeChair;
                SecondFreeChair = secondFreeChair;
            }
        }
    }
}
