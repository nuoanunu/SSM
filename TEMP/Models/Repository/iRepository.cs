using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSM.Models.Repository
{
    public interface iRepository : IDisposable
    {
        void insert();
        void update();
        void delete();
        void getById();
    }
}