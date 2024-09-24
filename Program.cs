using System;
namespace Method
{
    class Program
    {
        private string period;
        private double saldoIncome;
        private double saldoOutcome;
        private double nachisleno;
        private double pereraschet;
        private double itogoNachisleno;
        private double oplacheno;

        public void tablica(string period, double saldoIncome, double nachisleno, double pereraschet, double oplacheno)
        {
            this.period = period;
            this.saldoIncome = saldoIncome;
            this.nachisleno = nachisleno;
            this.pereraschet = pereraschet;
            this.itogoNachisleno = nachisleno + pereraschet;
            this.oplacheno = oplacheno;
            this.saldoOutcome = saldoIncome + itogoNachisleno - oplacheno;
        }

        private int roomNumber;
        private double roomSquare;
        public void account(int roomNumber, double roomSquare)
        {
            this.roomNumber = roomNumber;
            this.roomSquare = roomSquare;
        }

        public string printAccount()
        {
            return
                String.Format(
                    "Номер комнаты - {0} | - Площадь комнаты - {1}",
                    roomNumber, roomSquare
                    );
        }

        private int tarifNumber;
        private string tarifStart;
        public void tarif(int tarifNumber, string tarifStart)
        {
            this.tarifNumber = tarifNumber;
            this.tarifStart = tarifStart;
        }
        public string printTarif()
        {
            return
                String.Format(
                    "Номер тарифа - {0} |Дата старта тарифа - {1}",
                    tarifNumber, tarifStart
                    );
        }
        public string vedomost()
        {
            return
                String.Format(
                    "Период - {0} | Сальдо входящее - {1} | Начислено - {2} | Перерасчет - {3} | Итого начислено - {4}| Оплачено - {5}| Сальдо исходящее - {6}|",
                    period, saldoIncome, nachisleno, pereraschet, itogoNachisleno, oplacheno, saldoOutcome
                    );
        }


        static void Main(string[] args)
        {
            Program p1 = new Program();
            string per = "May 2024";
            p1.tablica(per, 1300, 750, 0, 650);
            string otchet = p1.vedomost();
            Console.WriteLine(otchet);
            string nextper = "June 2024";
            p1.tablica(nextper, 1400, 650, -100, 650);
            string nextRow = p1.vedomost();
            Console.WriteLine(nextRow);
            //string t = p1.tarif(777, per);
            p1.account(3978, 10000);
            //Console.WriteLine(t[1]);
            p1.tarif(777, per);
            string printT = p1.printTarif();
            Console.WriteLine(printT);
            string printA = p1.printAccount();
            Console.WriteLine(printA);

        }
    }
}