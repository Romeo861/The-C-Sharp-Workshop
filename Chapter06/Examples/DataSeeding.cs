﻿using System;
using System.Collections.Generic;
using System.Linq;
using Chapter06.Examples.GlobalFactory2021;

namespace Chapter06.Examples
{
    public static class DataSeeding
    {
        public const string ManufacturerName = "Test Factory";
        public const string TestProduct1Name = "Product1     ";
        /// <summary>
        /// Padding should be 13 spaces to the right as per our test data, db and filtering requirements
        /// </summary>
        public const string TestProduct2NameNotPadded = "Product2";
        public const decimal MaxPrice = 1000;

        public static void SeedDataNotSeededBefore()
        {
            var db = new globalfactory2021Context();
            var isDataAlreadySeeded = db.Manufacturers.Any(m => m.Name == ManufacturerName);
            if (isDataAlreadySeeded) return;

            SeedData(db);
        }

        private static void SeedData(globalfactory2021Context db)
        {
            var manufacturer = new Manufacturer
            {
                Country = "Test country",
                Name = ManufacturerName
            };

            var products = new List<Product>();
            var random = new Random();
            for (var i = 0; i < 10000; i++)
            {
                var product = new Product
                {
                    Name = (i % 2 == 0) ? TestProduct1Name : TestProduct2NameNotPadded.PadRight(13),
                    Manufacturer = manufacturer,
                    Price = (decimal) random.NextDouble() * MaxPrice
                };

                products.Add(product);
            }

            manufacturer.Products = products;

            db.Manufacturers.Add(manufacturer);
            db.SaveChanges();
            db.Dispose();
        }
    }
}
