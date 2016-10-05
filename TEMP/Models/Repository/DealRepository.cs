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