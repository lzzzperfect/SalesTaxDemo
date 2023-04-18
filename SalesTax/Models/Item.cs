using System;
namespace SalesTax.Models
{
	/// <summary>
	/// The item that customer bought
	/// </summary>
	public class Item
	{
        /// <summary>
        /// Gets or sets the count of this item
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the unit price of this item
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the name of this item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Kind of this item
        /// </summary>
		public Kind Kind { get; set; }

        /// <summary>
        /// Gets or sets whether this item is imported
        /// </summary>
		public bool IsImport { get; set; }

        /// <summary>
        /// Item constructor
        /// </summary>
        public Item()
		{
		}
	}
}

