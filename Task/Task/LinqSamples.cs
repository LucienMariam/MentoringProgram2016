// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using SampleSupport;
using Task.Data;

// Version Mad01

namespace SampleQueries
{
	[Title("LINQ Module")]
	[Prefix("Linq")]
	public class LinqSamples : SampleHarness
	{

		private DataSource dataSource = new DataSource();

	    private void DumpObjects(IEnumerable array)
	    {
	        
	    }

		[Category("Restriction Operators")]
		[Title("Where - Task 1")]
		[Description("This sample uses the where clause to find all elements of an array with a value less than 5.")]
		public void Linq1()
		{
			int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

			var lowNums =
				from num in numbers
				where num < 5
				select num;

			Console.WriteLine("Numbers < 5:");
			foreach (var x in lowNums)
			{
				Console.WriteLine(x);
			}
		}

		[Category("Restriction Operators")]
		[Title("Where - Task 2")]
		[Description("This sample return return all presented in market products")]

		public void Linq2()
		{
			var products =
				from p in dataSource.Products
				where p.UnitsInStock > 0
				select p;

			foreach (var p in products)
			{
				ObjectDumper.Write(p);
			}
		}

	    [Category("Linq queries")]
	    [Title("Linq hometask #1")]
	    [Description("This sample returns client list with order sum more than X")]
	    public void Linq001()
	    {
	        decimal X = 4;
	        Func<IEnumerable<Customer>, decimal, IEnumerable<Customer>> getClientListWithOrderSumMoreThanX =
	            delegate(IEnumerable<Customer> array, decimal x)
	            {
	                return array.Where(t => t.Orders.Sum(y => y.Total) > X);
	            };
	        var results = getClientListWithOrderSumMoreThanX(dataSource.Customers, X);

            foreach (var p in results)
            {
                ObjectDumper.Write(p);
            }
        }

	    [Category("Linq queries")]
	    [Title("Linq hometask #2")]
	    [Description("This sample returns client suppliers list with the same location as client has")]
	    public void Linq002()
	    {
	        Func<Customer, IEnumerable<Supplier>, IEnumerable<Supplier>> getSupplierListWithTheSameLocationAsClient =
	            delegate(Customer client, IEnumerable<Supplier> array)
	            {
	                return array.Where(x => x.Country == client.Country && x.City == client.City);
                };

	        var results = dataSource.Customers.ToDictionary(p => p.CustomerID,
	            p => getSupplierListWithTheSameLocationAsClient(p, dataSource.Suppliers));

            foreach (var p in dataSource.Customers)
            {
                ObjectDumper.Write("=== CLIENT FIELDS ===");
                ObjectDumper.Write(p.CustomerID);
                ObjectDumper.Write(p.Country);
                ObjectDumper.Write(p.City);
                ObjectDumper.Write("=== SUPPLIERS FIELDS ===");
                foreach (var element in results[p.CustomerID])
                {
                    ObjectDumper.Write(element.SupplierName);
                    ObjectDumper.Write(element.Country);
                    ObjectDumper.Write(element.City);
                }
            }
        }

	    [Category("Linq queries")]
	    [Title("Linq hometask #2 with Grouping")]
	    [Description("This sample returns client suppliers list with the same location as client has")]
	    public void Linq002_WithGrouping()
	    {
	        var resultsWithGrouping = dataSource.Customers.GroupBy(s => s, s => 
            dataSource.Suppliers.Where(t => t.Country == s.Country && t.City == s.City));

	        foreach (var p in resultsWithGrouping)
	        {
	            ObjectDumper.Write("=== CLIENT FIELDS ===");
	            ObjectDumper.Write(p.Key.CustomerID);
	            ObjectDumper.Write(p.Key.Country);
	            ObjectDumper.Write(p.Key.City);
	            ObjectDumper.Write("=== SUPPLIERS FIELDS ===");
	            foreach (var element in p.SelectMany(t => t))
	            {

	                ObjectDumper.Write(element.SupplierName);
	                ObjectDumper.Write(element.Country);
	                ObjectDumper.Write(element.City);
	            }
	        }
	    }

	    [Category("Linq queries")]
	    [Title("Linq hometask #3")]
	    [Description("This sample returns client list with the orders sum more than X")]
	    public void Linq003()
	    {
	        decimal X = 15;
	        var results = dataSource.Customers.Where(x => x.Orders.Any(t => t.Total > X));
            foreach (var p in results)
            {
                ObjectDumper.Write(p.CustomerID);
            }
        }

	    [Category("Linq queries")]
	    [Title("Linq hometask #4")]
	    [Description("This sample returns client list with the hiring dates")]
	    public void Linq004()
	    {
	        var results = dataSource.Customers.ToDictionary(s => s.CustomerID,
                s => s.Orders.OrderBy(t => t.OrderDate).Select(o => o.OrderDate).FirstOrDefault());
            foreach (var p in results)
            {
                ObjectDumper.Write("=== NEW ITEM ===");
                ObjectDumper.Write(p.Key);
                ObjectDumper.Write(p.Value);
            }
        }

	    [Category("Linq queries")]
	    [Title("Linq hometask #5")]
	    [Description("This sample returns client list with the hiring dates sorted by specific values")]
	    public void Linq005()
	    {
	        var results =
	            dataSource.Customers.ToDictionary(s => s,
	                s => s.Orders.OrderBy(t => t.OrderDate).Select(t=>t.OrderDate).FirstOrDefault()).
                    OrderBy(s => s.Value.Year).ThenBy(s => s.Value.Month).ThenByDescending(s => s.Key.Orders.Sum(o => o.Total))
                    .ThenBy(s => s.Key.CustomerID);

            foreach (var p in results)
            {
                ObjectDumper.Write("=== NEW ITEM ===");
                ObjectDumper.Write(p.Key);
                ObjectDumper.Write(p.Value);
            }
        }

	    [Category("Linq queries")]
	    [Title("Linq hometask #6")]
	    [Description("This sample returns client list with wrong entered parameters")]
	    public void Linq006()
	    {
	        var results = dataSource.Customers.Where(t => string.IsNullOrEmpty(t.PostalCode)
	                                                      || t.PostalCode.Any(x => x > '9' || x < '0') ||
	                                                      string.IsNullOrEmpty(t.Region)
	                                                      || t.Phone.First() != '(');
            foreach (var p in results)
            {
                ObjectDumper.Write("=== NEW ITEM ===");
                ObjectDumper.Write(p.CustomerID);
                ObjectDumper.Write(p.PostalCode);
                ObjectDumper.Write(p.Region);
                ObjectDumper.Write(p.Phone);
            }
        }

	    [Category("Linq queries")]
	    [Title("Linq hometask #7")]
	    [Description("This sample returns all products grouped by several parameters")]
	    public void Linq007()
	    {
            var results = dataSource.Products.GroupBy(p => p.Category)
                .GroupBy(p => p.GroupBy(s => s.UnitsInStock > 0))
                .GroupBy(p => p.LastOrDefault(), p => p.GroupBy(s => s.GroupBy(k => k.UnitPrice)));

            foreach (var p in results.SelectMany(x => x.SelectMany(y => y)))
            {
                ObjectDumper.Write(p.Key);
                foreach (var element in p.SelectMany(t => t))
                {

                    ObjectDumper.Write(element.ProductName);
                }
            }
        }

	    [Category("Linq queries")]
	    [Title("Linq hometask #8")]
	    [Description("This sample returns all products grouped by custom price categories")]
	    public void Linq008()
	    {
	        Func<decimal, string> definePriceCategory = delegate(decimal price)
	        {
	            if (price < 20)
	                return "cheap";
                if (price > 50)
                    return "expensive";
                return "medium";
	        };

	        var results = dataSource.Products.GroupBy(t => definePriceCategory(t.UnitPrice));
            foreach (var p in results.SelectMany(t => t))
            {
                ObjectDumper.Write("=== NEW ITEM ===");
                ObjectDumper.Write(p.ProductName);
                ObjectDumper.Write(p.Category);
                ObjectDumper.Write(p.UnitPrice);
            }
        }

	    [Category("Linq queries")]
	    [Title("Linq hometask #9")]
	    [Description("This sample returns average showings of cities")]
	    public void Linq009()
	    {
            var groupedCustomers = dataSource.Customers.GroupBy(t => t.City);

            Func<IEnumerable<Customer>, decimal> calculateAverageProfitOfTheCity = delegate(IEnumerable<Customer> array)
	        {
	            return array.SelectMany(t => t.Orders).Average(y => y.Total);
	        };
	       
            var averageProfitOfTheCity = groupedCustomers.ToDictionary(o => o.Key, o => calculateAverageProfitOfTheCity(o));

	        Func<IEnumerable<Customer>, double> calculateAverageNumberOfOrders = delegate(IEnumerable<Customer> array)
	        {
	            return array.Average(t => t.Orders.Length);
	        };

	        var averageIntencityInTheCity =
	            groupedCustomers.ToDictionary(o => o.Key, o => calculateAverageNumberOfOrders(o));


            for (int i = 0; i < averageProfitOfTheCity.Count(); i++)
	        {
                ObjectDumper.Write("=== NEW ITEM ===");
                ObjectDumper.Write(averageProfitOfTheCity.ElementAt(i).Key);
                ObjectDumper.Write(averageProfitOfTheCity.ElementAt(i).Value);
                ObjectDumper.Write(averageIntencityInTheCity.ElementAt(i).Value);
	        }
	    }

	    [Category("Linq queries")]
	    [Title("Linq hometask #10")]
	    [Description("This sample returns all client activity statistics")]
	    public void Linq010()
	    {
            foreach (var customer in dataSource.Customers)
            {
                var byMonth = customer.Orders.GroupBy(o => o.OrderDate.Month).ToDictionary(o => o.Key, o => o.Count()).OrderBy(o => o.Key);
                ObjectDumper.Write("=== Month Statistics ===");
                foreach (var element in byMonth)
                {
                    ObjectDumper.Write("=== NEW ITEM ===");
                    ObjectDumper.Write(element.Key);
                    ObjectDumper.Write(element.Value);
                }

                var byYear = customer.Orders.GroupBy(o => o.OrderDate.Year).ToDictionary(o => o.Key, o => o.Count()).OrderBy(o => o.Key); 
                ObjectDumper.Write("=== Year Statistics ===");
                foreach (var element in byYear)
                {
                    ObjectDumper.Write("=== NEW ITEM ===");
                    ObjectDumper.Write(element.Key);
                    ObjectDumper.Write(element.Value);
                }

                var byMonthYear = customer.Orders.GroupBy(o => new { o.OrderDate.Month, o.OrderDate.Year })
                    .ToDictionary(o => o.Key, o => o.Count()).OrderBy(o => o.Key.Year).ThenBy(o => o.Key.Month); 
                ObjectDumper.Write("=== MonthYearStatistics ===");
                foreach (var element in byMonthYear)
                {
                    ObjectDumper.Write("=== NEW ITEM ===");
                    ObjectDumper.Write(element.Key);
                    ObjectDumper.Write(element.Value);
                }
            }
        }
    }
}
