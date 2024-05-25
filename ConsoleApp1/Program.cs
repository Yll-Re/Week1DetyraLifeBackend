using ClassLibrary1;


namespace ConsolApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto car1 = new Auto("Ferrari", 10000, 0);
            car1.addCarrosserie();
            car1.addDoors();
            car1.addEngine();
            car1.addEnterier();
            car1.addWheels();

            checkCar(car1);

            Auto car2 = new Auto("Redbull", 20000, 2);
            car2.addCarrosserie();
            car2.addDoors();
            //car2.addEngine();
            car2.addEnterier();
            //car2.addWheels();

            checkCar(car2);


            // Detyra 2 me tuple plus
            Tuple<int, int, int> result = busProblem();
            Console.WriteLine($"Children: {result.Item1}, Adults: {result.Item2}, Elderly: {result.Item3}");


            // Detyra me paga Neto/Bruto
            brutoToNeto(600); // Rroga kur e kryn life hahahahha
            netoToBruto(535.2);

        }

        // Normal qito functions i kisha bo jasht program.cs, ama sipas detyres duhet mi bo qitu? ose sdi me lexu mir

        static void checkCar(Auto car)
        {
            List<string> missingParts = car.getMissingParts();
            if (missingParts.Count == 0)
            {
                Console.WriteLine($"The {car.Name} is ready to be used and can be used in color {car.Color} with the price {car.Price} euro, it's production year is {car.ProductionDate}");
            }
            else
            {
                Console.WriteLine($"The {car.Name} is not ready to be used as it misses {string.Join(", ", missingParts)}");
            }
        }

        static Tuple<int, int, int> busProblem()
        {
            const double priceForChildrens = 0.1;
            const double priceForEldery = 2;
            const double priceForAdults = 5;

            const int maxBusSize = 100;
            const double maxMoney = 100;

            // Garant ka naj menyr ma mir
            for (int child = 0; child < maxBusSize; child++)
            {
                for (int elder = 0; elder < maxBusSize - child; elder++)
                {
                    int adult = maxBusSize - child - elder;
                    double totalMoney = priceForAdults * adult + priceForChildrens * child + priceForEldery * elder;
                    if (totalMoney == maxMoney)
                    {
                        return Tuple.Create(child, adult, elder);
                    }
                }
            }
            return Tuple.Create(-1, -1, -1);
        }

        static void brutoToNeto(double bruto)
        {
            // Perqindja per pension spo di anglisht me qito emra i lash si ne video
            const double punemarresiPension = 0.05;

            double pagaTatueshme = bruto - bruto * punemarresiPension;
            double TAP;

            if (pagaTatueshme <= 80)
            {
                TAP = pagaTatueshme * 0;
            }
            else if (pagaTatueshme > 80 && pagaTatueshme <= 250)
            {
                TAP = (pagaTatueshme - 80.01) * 0.04;
            }
            else if (pagaTatueshme > 250 && pagaTatueshme <= 450)
            {
                TAP = (250 - 80.01) * 0.04 + (pagaTatueshme - 250.01) * 0.08;
            }
            else
            {
                TAP = (250 - 80.01) * 0.04 + (450 - 250.01) * 0.08 + (pagaTatueshme - 450.01) * 0.10;
            }

            double pagaNeto = Math.Round(pagaTatueshme - TAP, 2); // Math.Round se dilshin p.sh 7272 cent

            Console.WriteLine($"Paga Neto: {pagaNeto}");
        }

        // Neto to bruto o me "magic numbers" pej videos nfund qe e kallxoj gjysen e kodit kinda
        static void netoToBruto(double pagaNeto)
        {
            double punedhensiPension = 0.05;
            double pagaTatueshme;
            double pagaBruto;

            if (pagaNeto <= 80)
            {
                punedhensiPension = pagaNeto / 19;
                pagaBruto = pagaNeto + punedhensiPension;

            }
            else if (pagaNeto > 80 && pagaNeto < 243.2)
            {
                pagaTatueshme = (pagaNeto - 3.2) / 0.96;
                pagaBruto = pagaTatueshme / (1 - punedhensiPension);
            }
            else if (pagaNeto >= 243.2 && pagaNeto < 427.4)
            {
                pagaTatueshme = 250 + ((pagaNeto - 243.2) / 0.92);
                pagaBruto = pagaTatueshme / (1 - punedhensiPension);
            }
            else
            {
                pagaTatueshme = 450 + (pagaNeto - 427.2) / 0.9;
                pagaBruto = pagaTatueshme / (1 - punedhensiPension);
            }

            pagaBruto = Math.Round(pagaBruto, 2);
            Console.WriteLine($"Paga bruto: {pagaBruto}");
        }
    }
}