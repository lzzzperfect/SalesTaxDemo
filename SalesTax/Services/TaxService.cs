﻿using System;
using SalesTax.Models;

namespace SalesTax.Services
{
	/// <summary>
	/// The Tax service
	/// </summary>
	public class TaxService : IService
    {
		/// <summary>
		/// The Tax service contructor
		/// </summary>
		public TaxService()
		{
		}

        /// <summary>
        /// Calculate the tax result based on items
        /// </summary>
        /// <param name="items"></param>
        /// <returns>The checkout out result</returns>
        public CheckOutResult Calculate(List<Item> items)
        {
            CheckOutResult checkOutResult = new CheckOutResult();
            checkOutResult.PaidItems = new List<PaidItem>();

            decimal salesTax = 0;
            decimal total = 0;

            foreach (var item in items)
            {
                decimal curPriceForItem;
                decimal curTax = 0;

                if (item.IsImport)
                {
                    var importTax = item.UnitPrice * item.Count * 0.05m;
                    curTax += Math.Ceiling(importTax * 20) / 20;
                }

                if (item.Kind == Kind.Default)
                {
                    var defaultTax = item.UnitPrice * item.Count * 0.1m;
                    curTax += Math.Ceiling(defaultTax * 20) / 20;
                }

                salesTax += curTax;
                curPriceForItem = item.UnitPrice * item.Count + curTax;
                total += curPriceForItem;

                checkOutResult.PaidItems.Add(new PaidItem() { Count = item.Count, Name = item.Name, Price = curPriceForItem });
            }

            checkOutResult.SalesTax = salesTax;
            checkOutResult.Total = total;

            return checkOutResult;
        }
	}
}

