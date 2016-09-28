using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSM.Models.Repository
{
    public class DealRepository : IDisposable
    {
        SSMEntities context;
        public DealRepository(SSMEntities contextt)
        {
            context = contextt;
        }
        public bool createNewDeal(Deal newdeal, String responsiblesRole, int planID) {
            context.Deals.Add(newdeal);
            context.SaveChanges();
            int id = newdeal.id;
            String[] ids = responsiblesRole.Split(new[] { "[user]" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < ids.Length; i++) {
                if (context.AspNetUsers.Find(ids[i]) != null) {
                    Deal_SaleRep_Respon res = new Deal_SaleRep_Respon();
                    res.dealID = id;
                    res.userID = ids[i];
                    res.startDate = DateTime.Today;
                    context.Deal_SaleRep_Respon.Add(res);
                    context.SaveChanges();
                }
            }
            Deal_Product dp = new Deal_Product();
            dp.planID = planID;
            dp.dealID = id;
            dp.addedDate = DateTime.Today;
            context.Deal_Product.Add(dp);
            return true;
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}