using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DCCMSNameSpace
{
   public class ShoppingCart
    {
       

       public static int GetItemsCount()
       {
           List<ItemsOrdersDetailsModel> CartList = null;
           int count = 0;
           //---------------------------------------------------------
           //Load Cart 
           //---------------------------------------------------------
           if (HttpContext.Current.Session["Cart"] != null)
           {
               CartList = (List<ItemsOrdersDetailsModel>)HttpContext.Current.Session["Cart"];
               count = CartList.Count;
           }
           //---------------------------------------------------------
           return count;
       }

       public static List<ItemsOrdersDetailsModel> GetCartList()
       {
           List<ItemsOrdersDetailsModel> CartList = null;
           if (HttpContext.Current.Session["Cart"] == null)
           {
               HttpContext.Current.Session["Cart"] = new List<ItemsOrdersDetailsModel>();
           }
           CartList = (List<ItemsOrdersDetailsModel>)HttpContext.Current.Session["Cart"];
           return CartList;
       }

       public static string GetListOfItemsIdInCart()
       {
           List<ItemsOrdersDetailsModel> CartList = GetCartList();
           int index=0;
           string listOfIds="";
           foreach (ItemsOrdersDetailsModel item in CartList)
           {
               if (index++ > 0)
               {
                   listOfIds += ",";
               }
               listOfIds += item.ItemID;

           }
           return listOfIds;
       }

       public static void AddToCart(int itemID, ref ItemsEntity item, ref ItemCategoriesEntity category)
       {
           Guid OwnerID = SitesHandler.GetOwnerIDAsGuid();
           //---------------------------------------------------------
           Languages langID = SiteSettings.GetCurrentLanguage();
           if (item ==null)
           {
           item = ItemsFactory.GetObject(itemID, langID, UsersTypes.User, OwnerID);
           }
           if (category == null)
           {
               category = ItemCategoriesFactory.GetObject(item.CategoryID, langID, OwnerID);
           }

           if (item != null && category != null)
           {
              List<ItemsOrdersDetailsModel> CartList  = GetCartList();
               //---------------------------------------------------------
               bool existIntoCart = false;
               foreach (ItemsOrdersDetailsModel p in CartList)
               {
                   if (p.ItemID == itemID)
                   {
                       p.Quantity += 1;
                       existIntoCart = true;
                       break;
                   }

               }
               if (!existIntoCart)
               {
                   ItemsOrdersDetailsModel newP = new ItemsOrdersDetailsModel();
                   newP.ItemID = itemID;
                   newP.Quantity = 1;
                   CartList.Add(newP);
               }
               //---------------------------------------------------------
               //Session["Cart"] = CartList;
           }
       }

       public static void RemoveFromCart(int itemID)
       {
           List<ItemsOrdersDetailsModel> CartList = GetCartList();
           int index = 0;
           foreach (ItemsOrdersDetailsModel p in CartList)
           {
               if (p.ItemID == itemID)
               {
                   CartList.RemoveAt(index);
                   return;
               }
               ++index;
           }
       }

       public static bool IsInCart(int itemID)
       {
           List<ItemsOrdersDetailsModel> CartList = GetCartList();
           foreach (ItemsOrdersDetailsModel p in CartList)
           {
               if (p.ItemID == itemID)
               {
                   return true;
               }
           }
           return false;
       }

       public static void ClearCart()
       {
           //-------------------------------------------------------------
           //Clear cart
           //-------------------------------------------------------------
           List<ItemsOrdersDetailsModel> CartList = GetCartList();
               CartList.Clear();
               CartList = null;
       }

    }
}
