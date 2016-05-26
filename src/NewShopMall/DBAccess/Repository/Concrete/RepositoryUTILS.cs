using System.Linq;
using Microsoft.Data.Entity;
using ShopMall.DBAccess.Repository.Abstract;
using ShopMall.Models.ShopMallDBModels;
using ShopMall.Models.AccountDBModels;

namespace ShopMall.DBAccess.Repository.Concrete
{
    public partial class Repository: IRepository
    {
         public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
   }
}


