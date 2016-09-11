using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEMP.Models.Repository
{
    public class productRepository: IDisposable
    {
        SSMEntities2 context;
        public productRepository(SSMEntities2 contextt)
        {
            context = contextt;
        }
        public List<softwareProduct> getAll() {
            return context.softwareProducts.ToList();
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