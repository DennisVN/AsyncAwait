using System;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Coffee cup = PourCoffee();
            Console.WriteLine("Koffie is klaar");

            Task<Egg> eggsTask = FryEggsAsync(2);
            Task<Bacon> baconTask = FryBaconAsync(3);
            Task<Toast> toastTask = ToastBreadAsync(2);

            Toast toast = await toastTask;
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");
            Juice oj = PourOj();
            Console.WriteLine("oj is ready");

            Egg egss = await eggsTask;
            Console.WriteLine("Eggs are ready");
            Bacon bacon = await baconTask;
            Console.WriteLine("Bacon is ready");

            Console.WriteLine("Breakfast is ready!");

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

        private static async Task<Toast> ToastBreadAsync(int slices)
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

        private static async Task<Bacon> FryBaconAsync(int slices)
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

        private static async Task<Egg> FryEggsAsync(int howMany)
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
