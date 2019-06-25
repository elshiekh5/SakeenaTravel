using System;
/// <summary>
/// The model class of ItemsOrdersDetailsModel.
/// </summary>
namespace DCCMSNameSpace
{
    public class ItemsOrdersDetailsModel
    {

		public int OrderID { get; set; }

		public int ItemID { get; set; }

		public string Title { get; set; }

		public string Price { get; set; }

		public int Quantity { get; set; }

        public string CurrentPrice { get; set; }
        public string Barcode { get; set; }
        public string ByUnit { get; set; }
        public string ByCarton { get; set; }
        public ItemsOrdersDetailsModel()
        {
            Title = "";
            CurrentPrice = "";
            Price = "";
            Barcode = "";
            ByUnit = "";
            ByCarton = "";
        }


    }
}
