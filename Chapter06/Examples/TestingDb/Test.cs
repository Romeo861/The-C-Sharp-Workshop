﻿using System;
using System.Linq;
using Chapter06.Examples.TalkingWithDb.Orm;
using Chapter06.Exercises.Exercise04;

namespace Chapter06.Examples.TestingDb
{
    public static class Test
    {
        public static void Run(FactoryDbContext db)
        {
            var productsRepository = new Repository<Product>(db);
            var manufacturer = new Manufacturer() { Id = 1 };
            db.Manufacturers.Add(manufacturer);
            db.SaveChanges();

            var product = new Product { Name = "Test PP", ManufacturerId = 1, Price = 9.99m };
            var id = productsRepository.Create(product);

            product.Price = 19m;
            productsRepository.Update(product);

            var productAfterChanges = productsRepository.Get(id);
            Console.WriteLine($"Id: {productAfterChanges.Id}, " +
                              $"Name: {productAfterChanges.Name}, " +
                              $"Price: {productAfterChanges.Price}");

            var productToDelete = new Product { Name = "Test PP 2", ManufacturerId = 1, Price = 9.99m };
            var idToDelete = productsRepository.Create(productToDelete);
            var countBeforeDelete = productsRepository.Get().Count();
            productsRepository.Delete(idToDelete);
            var countAfter = productsRepository.Get().Count();
            Console.WriteLine($"Before: {countBeforeDelete}, after: {countAfter}");
        }
    }
}
