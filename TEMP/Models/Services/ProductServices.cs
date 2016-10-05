using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSM.Models.Services
{
    public class ProductServices
    {
        public double getMonthValues(int month, int productID)
        {

            double result = 0;

            try
            {
                SSMEntities dbContext = new SSMEntities();
                softwareProduct product = (softwareProduct)dbContext.softwareProducts.Find(productID);
                if (product != null)
                {
                    List<MarketPlanPurchased> MPlist = product.MarketPlanPurchaseds.ToList();
                    foreach (MarketPlanPurchased mp in MPlist)
                    {
                        if (mp.order.createDate.Month == month)
                        {
                            result = result + mp.SoldPrice;
                        }
                    }
                }

            }
            catch (Exception e) { }

            return result;
        }
    }
}