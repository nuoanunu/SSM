﻿using SSM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSM.Models.Repository
{
    public class productRepository: IDisposable
    {
        SSMEntities context;
        public productRepository(SSMEntities contextt)
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
        public attributeOption getProductOption(int id) {
            return context.attributeOptions.Find(id);
        }
        public softwareProduct getById(int id)
        {

            return context.softwareProducts .Find(id);
        }
    }
}