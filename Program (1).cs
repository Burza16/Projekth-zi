using System.Globalization;

namespace ProjectMunka
{
    internal class Program
    {
        class Auto
        {
            public string Marka;
            public string Modell;
            public string Kivitel;
            public int Evjarat;
            public int Ar;
            public string Rendszam;
            public string Klima;
            public string Uzemenyag;

            public Auto(string egySor)
            {
                string[] seged = egySor.Split(';');

                Marka = seged[0].Trim();
                Modell = seged[1].Trim();
                Kivitel = seged[2].Trim();
                Evjarat = int.Parse(seged[3]);
                Ar = int.Parse(seged[4]);
                Rendszam = seged[5].Trim();
                Klima = seged[6].Trim();
                Uzemenyag = seged[7].Trim();
            }
        }

        static void Main(string[] args)
        {
            List<Auto> autok = new List<Auto>();

            StreamReader beFajl = new StreamReader("IKT, asztali, adatbázis projektházi.txt");

            beFajl.ReadLine();

            while (!beFajl.EndOfStream)
            {
                autok.Add(new Auto(beFajl.ReadLine()));
            }

            beFajl.Close();

            Console.WriteLine($"Beolvasott autok szama: {autok.Count}");

            Console.WriteLine("\nAz autok adatai:");

            foreach (Auto elem in autok)
            {
                Console.WriteLine($"{elem.Marka} {elem.Modell}, {elem.Kivitel}, {elem.Evjarat}, {elem.Ar} Ft, {elem.Rendszam}, Klima: {elem.Klima}, Uzemenyag: {elem.Uzemenyag}");
            }

            int legdragabbAr = autok[0].Ar;
            int legdragabbIndex = 0;

            foreach (Auto elem in autok)
            {
                if (elem.Ar > legdragabbAr)
                {
                    legdragabbAr = elem.Ar;
                    legdragabbIndex = autok.IndexOf(elem);
                }
            }

            Console.WriteLine("\nA legdragabb auto:");
            Console.WriteLine($"{autok[legdragabbIndex].Marka} {autok[legdragabbIndex].Modell}, {autok[legdragabbIndex].Ar} Ft");

            Console.ReadKey();
        }
    }
}