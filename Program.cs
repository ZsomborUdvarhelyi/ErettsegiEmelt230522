using System.Text;

namespace Erettsegi
{
    internal class Program
    {
        static void Main()
        {
            var taborok = new List<Tabor>();
            using (var sr = new StreamReader(@"..\..\..\src\taborok.txt", Encoding.UTF8))
            {
                _ = sr.ReadLine();
                while (!sr.EndOfStream) taborok.Add(new Tabor(sr.ReadLine()));
            }

            //2. feladat
            Console.WriteLine("\n2. feladat:");
            Console.WriteLine($"Az adatsorok száma: {taborok.Count}");
            Console.WriteLine($"Az először rögzített tábor témája: {taborok.First().Tema}");
            Console.WriteLine($"Az utoljára rögzített tábor témája: {taborok.Last().Tema}");

            //3. feladat
            Console.WriteLine("\n3. feladat:");
            var zeneiTaborok = taborok.Where(t => t.Tema == "zenei").ToList();
            if (zeneiTaborok.Any())
            {
                foreach (var tabor in zeneiTaborok)
                {
                    Console.WriteLine($"Zenei tábor kezdődik {tabor.Honap1}. hó {tabor.Nap1}. napján.");
                }
            }
            else
            {
                Console.WriteLine("Nem volt zenei tábor.");
            }

            //4. feladat
            Console.WriteLine("\n4. feladat:");
            var legnepszerubbTabor = taborok.OrderByDescending(t => t.Diakok.Length).First();
            var legnepszerubbTaborok = taborok.Where(t => t.Diakok.Length == legnepszerubbTabor.Diakok.Length).ToList();
            Console.WriteLine("Legnépszerűbbek:");
            foreach (var tabor in legnepszerubbTaborok)
            {
                Console.WriteLine($"{tabor.Honap1} {tabor.Nap1} {tabor.Tema}");
            }

            //5. feladat
            int Sorszam(int honap, int nap)
            {
                int sorszam = nap;
                for (int i = 6; i < honap; i++)
                {
                    if (i == 6 || i == 8)
                    {
                        sorszam += 30;
                    }
                    else
                    {
                        sorszam += 31;
                    }
                }
                return sorszam;
            }

            //6. feladat
            Console.WriteLine("\n6. feladat:");
            Console.WriteLine("Hó: ");
            int ho = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nap: ");
            int nap = Convert.ToInt32(Console.ReadLine());
            int db = 0;
            int keresett = Sorszam(ho, nap);
            foreach (var tabor in taborok)
            {
                int kezdes = Sorszam(tabor.Honap1, tabor.Nap1);
                int vege = Sorszam(tabor.Honap2, tabor.Nap2);
                if (keresett >= kezdes && keresett <= vege)
                {
                    db++;
                }
            }
            Console.WriteLine($"Ekkor éppen {db} tábor tart.");

            // 7. feladat
            Console.WriteLine("\n7. feladat");
            Console.WriteLine("Adja meg egy tanuló betűjelét: ");
            string betu = Console.ReadLine();
            List<Tabor> jelentkezett = taborok.Where(t => t.Diakok.Contains(betu)).ToList();
            using (StreamWriter sw = new StreamWriter("egytanulo.txt"))
            {
                if (jelentkezett.Any())
                {
                    foreach (var item in jelentkezett)
                    {
                        Console.WriteLine($"{item.Honap1}.{item.Nap1}-{item.Honap2}.{item.Nap2}. {item.Tema}");
                        if (jelentkezett.Any(t =>
                        (t.Honap1 < item.Honap2 || (t.Honap1 == item.Honap2 && t.Nap1 <= item.Nap2)) &&
                        (t.Honap2 > item.Honap1 || (t.Honap2 == item.Honap1 && t.Nap2 >= item.Nap1)) &&
                        t != item))
                        {
                            Console.WriteLine("Nem mehet el mindegyik táborba.");
                        }
                        
                    }
                }
                else
                {
                    Console.WriteLine("Nem jelentkezett egyetlen táborba sem.");
                }
            }
        }
    }
}