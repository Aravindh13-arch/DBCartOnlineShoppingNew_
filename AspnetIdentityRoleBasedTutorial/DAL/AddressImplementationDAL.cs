using Microsoft.VisualBasic;
using OnlineShoppingProject.Models;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineShoppingProject.DAL
{
    public class AddressImplementationDAL
    {
       private OnlineShopDbContext _context;

            public AddressImplementationDAL(OnlineShopDbContext Context)
            {
                _context = Context;
            }


        public List<AddressVM> GetIDAddressDAL(string CreatedBy, int ProductId)
        {
            List<AddressVM> addresses = new List<AddressVM>();
            if (CreatedBy == null)
            {
                throw new ArgumentNullException("model");
            }

            //var result = _context.TblUsers
            //    .Join(_context.TblAddresses,
            //        t1 => t1.UserId,
            //        t2 => t2.CreatedBy,
            //        (t1, t2) => new { t1, t2 })
            //    .Join(_context.TblProducts,
            //        t3 => t3.t2.AddressId,
            //        t4 => t4.ProductId,
            //        (t3, t4) => new { t3, t4 })
            //    .GroupBy(r => new
            //    {
            //        r.t3.t2.DeliverAddress,
            //        r.t3.t1.UserId,
            //        r.t4.ProductId
            //    })
            //    .Select(g1 => new
            //    {
            //        DeliveryAddress = g1.Key.DeliverAddress,
            //        UserId = g1.Key.UserId,
            //      //  ProductId = g1.Key.ProductId
            //    })
            //    .Where(res => res.UserId == CreatedBy)
            //    .Distinct()
            //    .ToList();

            //foreach (var item in result)
            //{
            //    AddressVM address = new AddressVM();
            //    address.DeliverAddress = item.DeliveryAddress;
            //   // address.ProductId = item.ProductId;
            //    address.CreatedBy = item.UserId;

            //    addresses.Add(address);
            //}

            return addresses;
        }


        //        public List<AddressVM> GetIDAddressDAL(int userId, int Id)
        //        {
        //        List<AddressVM> addres = new List<AddressVM>();
        //            if (userId == null)
        //            {
        //                throw new ArgumentNullException("model");
        //            }
        //            var result=  _context.TblUsers
        //.Join(_context.TblAddresses,
        //    t1 => t1.UserId,
        //    t2 => t2.CreatedBy,
        //    (t1, t2) => new {t1,t2 })
        //.Join(_context.TblProducts,
        //     t3=>t3.t2.AddressId,
        //    t4=>t4.ProductId,
        //    (t3, t4) => new { t3,t4 })
        //.GroupBy(r => new
        //{
        //   r.t3.t2.DeliverAddress,
        //   r.t3.t1.UserId, 
        //    r.t4.ProductId
        //})
        //.Select(g1=>new
        //{
        //    delivaryAddress=g1.Key.DeliverAddress,
        //    userId=g1.Key.UserId,
        //    productId=g1.Key.ProductId

        //}).Where(res => res.userId==userId).ToList();


        //        foreach (var Item in result)
        //        {
        //            AddressVM address = new AddressVM();
        //            address.DeliverAddress = Item.delivaryAddress;
        //            address.ProductId = Item.productId;
        //            address.CreatedBy = Item.userId;

        //            addres.Add(address);
        //        }


        //        return addres;
        //        }

    }

}
