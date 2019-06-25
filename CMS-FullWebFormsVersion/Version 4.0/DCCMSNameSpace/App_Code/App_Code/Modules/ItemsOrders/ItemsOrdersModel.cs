using System;
/// <summary>
/// The model class of ItemsOrdersModel.
/// </summary>
namespace DCCMSNameSpace
{
    public class ItemsOrdersModel
    {

		public int OrderID { get; set; }

		public Guid UserId { get; set; }

		public int Status { get; set; }

		public string Comment { get; set; }

		public DateTime DateAdded { get; set; }


		public string CustomerName { get; set; }
		public string CustomerEmail { get; set; }
		public string CustomerPhone { get; set; }
		public string CustomerMobile { get; set; }
		public string CustomerAddress { get; set; }



        public ItemsOrdersModel()
        {
            Comment = "";
            DateAdded = DateTime.Now;
            CustomerName = "";
            CustomerEmail = "";
            CustomerPhone = "";
            CustomerMobile = "";
            CustomerAddress = "";
        }
    }
}
