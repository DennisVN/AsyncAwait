using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {

            Coffee cup = PourCoffee();
            Console.WriteLine("Koffie'ke is klaar sé ! ");

            Egg eggs = FryEggs(2);
            Console.WriteLine("Eitjes zijn klaar");

            Bacon bacon = FryBacon(3);
            Console.WriteLine("'T spek is klaar ");

            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("Den toast is ready");

            Juice oj = PourOj();
            Console.WriteLine("Fruitsapken is klaar ");
            Console.WriteLine("GET BREAKFAST, SMAKELIJK !  ");

            Console.ReadLine();
        }

        private static Juice PourOj()
        {
            Console.WriteLine("Fruitsapke Persen");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Confituur aan't smeren");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Boter aan't smeren");

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Leg een sneeke brood in den toaster");
            }
            Console.WriteLine("Start toasten ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Haal toast uit den toaster");

            return new Toast();
        }

        private static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"Leg {slices} sneekes spek in de pan");
            Console.WriteLine("Eerste kant de spek aant bakken");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine(@" ¯\_(ツ)_/¯");
                Console.WriteLine("BACON FLIP");
            }
            Console.WriteLine("Leg spek op het bord");

            return new Bacon();
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Pan voorverwarmen...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"Kraak {howMany} eikes");
            Console.WriteLine("Eike aan't bakken ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Leg eikes op't bord");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Koffieke inschenken");
            return new Coffee();
        }
    }
}
