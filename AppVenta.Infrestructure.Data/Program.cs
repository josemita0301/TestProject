using AppVenta.Infrestructure.Data.Context;
using System;

namespace AppVenta.Infrestructure.Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando la db si no existe");
            SaleContext db = new SaleContext();
            bool created = db.Database.EnsureCreated();

            if (created)
                Console.WriteLine("Creadaaa!!!");
            else
                Console.WriteLine("Ya existía!!");

            Console.ReadKey();
        }
    }
}
