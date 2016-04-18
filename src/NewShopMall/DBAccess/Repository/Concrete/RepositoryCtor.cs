using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Http;

using ShopMall.DBAccess.DBContexts;
using ShopMall.DBAccess.Repository.Abstract;
using ShopMall.Models.ShopMallDBModels;
using ShopMall.Models.AccountDBModels;

namespace ShopMall.DBAccess.Repository.Concrete
{
    public partial class Repository : IRepository
    {
        private ApplicationDbContext ctx;
        private bool disposing = false;

        public Repository(ApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposing)
            {
                if (disposing)
                {
                    this.ctx.Dispose();
                }
            }
            this.disposing = true;

        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}