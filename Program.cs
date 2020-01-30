using System;
using System.Linq;
using System.Collections.Generic;
using RandomDataGenerator.Randomizers;
using RandomDataGenerator.FieldOptions;
namespace PIII_Lab6
{
    class Osoba
    {
        public string Imie;
        public string Nazwisko;
        public int Id;

        public Osoba(string imie, string nazwisko, int id)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Id = id;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("PIII_Lab6");
            
            
            List<int> lista = Enumerable.Range(100, 100).ToList();
            //lista.ForEach(x => Console.WriteLine(x));
            #region
            foreach (var iteam in lista)
            {
                Console.WriteLine(iteam);
            }
            
            IEnumerable<int> podzielnePrzez3 = lista.Where(x => x % 3 == 0);
            foreach (var item in podzielnePrzez3)
            {
                Console.WriteLine(item);
            }
            
            int suma = podzielnePrzez3.Sum();
            Console.WriteLine(suma);
            
            double srednia = podzielnePrzez3.Average();
            Console.WriteLine(srednia);

            /*List<Osoba> osoby = 
            lista.Select(x => new Osoba()
            {
                Imie = x.ToString(),
                Nazwisko = "AAA",
                Id = x
            }).ToList();//.ForEach(x => Console.WriteLine($"{x.Id}: {x.Imie} {x.Nazwisko}"));

            osoby[45].Nazwisko = "BBB";
            osoby.Select(x => x.Nazwisko).Distinct().ToList().ForEach(Console.WriteLine);
            Osoba osobaB = osoby.Where(x => x.Nazwisko.StartsWith("B")).First();

            int iloscElementowNaStronie = 10;
            int nrstrony = 2;
            List<Osoba> strona = osoby.Skip(iloscElementowNaStronie * (nrstrony - 1)).Take(iloscElementowNaStronie).ToList();

            foreach(var item in strona)
            {
                Console.WriteLine($"{item.Id}: {item.Imie} {item.Nazwisko}");
            }
            */
            #endregion        

            var randomizerFirstName = RandomizerFactory.GetRandomizer(new FieldOptionsFirstName());
            var randomizerLastName = RandomizerFactory.GetRandomizer(new FieldOptionsLastName());

            List<Osoba> osoby = lista.Select(x => new Osoba(randomizerFirstName.Generate(), randomizerLastName.Generate(), x)).ToList();
            foreach(var item in osoby)
            {
                Console.WriteLine($"{item.Id}: {item.Imie} {item.Nazwisko}");
            }
        }
        // wposortowac losowo wygenerowanych osob najppierw po nazwisko potem po imienu 
    }
}
