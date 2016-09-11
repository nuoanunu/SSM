using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSM.Models.Repository
{
    public class orderRepository:IDisposable
    {

        SSMEntities2 context;
        public orderRepository(SSMEntities2 contextt)
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