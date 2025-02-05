﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter08.Activities.Activity02
{
    public static class Demo
    {
        public static async Task Run()
        {
            var client = new CountriesClient();
            IEnumerable<Country> countries;

            Console.WriteLine("All:");
            countries = await client.Get();
            Print(countries);

            Console.WriteLine($"{Environment.NewLine}Lithuanian:");
            countries = await client.GetByLanguage("Lithuanian");
            Print(countries);

            Console.WriteLine($"{Environment.NewLine}Vilnius:");
            countries = await client.GetByCapital("Vilnius");
            Print(countries);
        }

        private static void Print(IEnumerable<Country> countries)
        {
            foreach (var country in countries.Take(2))
            {
                Console.WriteLine($"{country.name.common} {country.region} {string.Join(" ", country.capital ?? new List<string>())}");
            }
        }
    }
}
