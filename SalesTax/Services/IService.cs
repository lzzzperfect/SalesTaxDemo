using System;
using SalesTax.Models;

namespace SalesTax.Services
{
    /// <summary>
    /// The service interface
    /// </summary>
	public interface IService
	{
        /// <summary>
        /// Calculate the result based on input items
        /// </summary>
        /// <param name="items">A list of items</param>
        /// <returns>The check out result</returns>
        public CheckOutResult Calculate(List<Item> items);
	}
}

