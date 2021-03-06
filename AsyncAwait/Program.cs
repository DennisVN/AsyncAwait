using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Coffee cup = PourCoffee();
            Console.WriteLine("Koffie is klaar");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var listOfTasks = new List<Task> { eggsTask, baconTask, toastTask };
            while (listOfTasks.Count > 0 )
            {
                Task finishedTask = await Task.WhenAny(listOfTasks);
                if (finishedTask == eggsTask)
                {
                    Console.WriteLine("Eikes zijn klaar");
                }
                else if (finishedTask == baconTask)
                {
                    Console.WriteLine("Spek is klaar");
                }
                else if(finishedTask == toastTask)
                {
                    Console.WriteLine("Toast is klaar");
                }
                listOfTasks.Remove(finishedTask);
            }

            Juice oj = PourOj();
            Console.WriteLine("De sudorans is klaar");

            Console.WriteLine("Breakfast is ready!");

            Console.ReadLine();
        }


        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            Toast toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
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
            Console.WriteLine("Start het toasten");
            await Task.Delay(3000);
            //Console.WriteLine("Shit is aangebrand ...");
            //throw new InvalidOperationException("The toaster is on fire !");
            Console.WriteLine("Haal toast uit den toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"Leg {slices} sneekes spek in de pan");
            Console.WriteLine("Eerste kant de spek aant bakken");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine(@" ¯\_(ツ)_/¯");
                Console.WriteLine("FLIPPING THE BACON");
            }
            Console.WriteLine("Andere kant van de spek bakken");
            await Task.Delay(3000);
            Console.WriteLine("Leg spek op het bord");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Pan voorverwarmen...");
            await Task.Delay(3000);
            Console.WriteLine($"Kraak {howMany} eikes");
            Console.WriteLine("Eike aan't bakken ...");
            await Task.Delay(3000);
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
