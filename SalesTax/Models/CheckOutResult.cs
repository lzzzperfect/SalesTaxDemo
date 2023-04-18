using System;
namespace SalesTax.Models
{
	/// <summary>
	/// The result that need to output when checkout
	/// </summary>
	public class CheckOutResult
	{
        /// <summary>
        /// Gets or sets the list of paid items
        /// </summary>
		public List<PaidItem> PaidItems { get; set; }

        /// <summary>
        /// Gets or sets total sales tax
        /// </summary>
        public decimal SalesTax { get; set; }

        /// <summary>
        /// Gets or sets the total price for all items
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// The constructor
        /// </summary>
        public CheckOutResult()
		{
		}
	}

	/// <summary>
	/// The details of item paid
	/// </summary>
	public class PaidItem
	{
        /// <summary>
        /// Gets or sets the count of this paid item
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the name of this paid item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the total price of this paid item, e.g. $2 for one apple, customer bought 2 apples, Price here is $4
        /// </summary>
        public decimal Price { get; set; }
    }
}

