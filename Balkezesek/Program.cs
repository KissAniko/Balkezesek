using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Balkezesek
{
    internal class Program
    {
        static List<Balkezes> balkezesek=new List<Balkezes>();
        static void Main(string[] args)
        {

            // Ellenőrzés:

             /*      var ellenorzes = File.ReadAllLines("balkezesek.csv");

                     foreach (var sor in ellenorzes)
                     {
                         Console.WriteLine(sor);

                     }  */
             
            List<Balkezes> balkezesek = new List<Balkezes>();
            string [] sorok = File.ReadAllLines("balkezesek.csv").Skip(1).ToArray();
            for (int i = 0; i < sorok.Length; i++)
            {
                string[] adat = sorok[i].Split(';');


                string nev= adat[0];
                string elso= adat[1];
                string utolso = adat[2];
                int suly = Convert.ToInt32(adat[3]);  
                int magassag = Convert.ToInt32(adat[4]);

                Balkezes balkezes = new Balkezes(nev, elso, utolso, suly, magassag);
                balkezesek.Add(balkezes);
            }


            // 3. feladat: Hány adatsor található a forrásállományban?

            Console.WriteLine($"3. feladat: {balkezesek.Count}");

            // 4. feladat: Írja ki a játékosok nevét és testmagasságát centiméterben (1 inch = 2,54 cm),
            //             akik utoljára 1999 októberében léptek pályára. Az eredményt egy tizedesjegyre kerekítse.


            Console.WriteLine("4. feladat:");

            foreach (var item in balkezesek)
            {
                if(item.UtolsoEv == 1999 && item.UtolsoHonap == 10)
                {
                    Console.WriteLine($"\t{item.Nev}, {Math.Round(item.Magassag - 2.54 , 1)} cm ");
                }

            }

            // 5. feladat: Kérjen be a felhasználótól egy évszámot.
            //             Az évszámra teljesülnie kell az 1991 <= évszám <= 1999 feltételeknek.
            //             Amennyiben a felhasználó hibás számot adott, írja ki: "Hibás adat. Kérek egy 
            //             1990 és 1999 közötti évszámot" és kérje be újra.


            Console.WriteLine("5. feladat:");
            int evszam = 0;
            do
            {
             Console.WriteLine("Kérek egy 1990 és 1999 közötti évszámot: ");
                evszam = Convert.ToInt32(Console.ReadLine());

                if(evszam >= 1990  && evszam <= 1999)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Hibás adat, kérek egy 1990 és 1999 közötti évszámot!");
                }
            }
            while(true);


            // 6. feladat: Mennyi az átlagsúlya a játékosoknak, akik az előző feladatban bekért évben pályára léptek?
            //             Az eredményt  két tizedesjegyre kerekítve írja ki.


            double atlagsuly = balkezesek.Where(x => x.ElsoEv <= evszam && x.UtolsoEv >= evszam).Average(x => x.Suly);
            Console.WriteLine($" 6. feladat: {Math.Round(atlagsuly, 2)} font");

        }
    }
}
