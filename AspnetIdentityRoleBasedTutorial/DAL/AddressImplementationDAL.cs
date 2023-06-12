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


        public List<AddressVM> GetIDAddressDAL(string userId, int Id)
        {
            List<AddressVM> addresses = new List<AddressVM>();
            if (userId == null)
            {
                throw new ArgumentNullException("model");
            }


            var name = _context.AspNetUsers.Single(u => u.Id == userId).Name;
            var result = _context.AspNetUsers
                .Join(_context.TblAddresses,
                    t1 => t1.Id,
                    t2 => t2.CreatedBy,
                    (t1, t2) => new { t1, t2 })
                .Join(_context.TblProducts,
                    t3 => t3.t2.AddressId,
                    t4 => t4.ProductId,
                    (t3, t4) => new { t3, t4 })
                .GroupBy(r => new
                {
                    r.t3.t2.DeliverAddress,
                    r.t3.t1.Id,
                    r.t4.ProductId,
                    r.t3.t2.City,
                    r.t3.t2.State,
                    r.t3.t2.PinCode,
                    r.t3.t2.AddressId

                })
                .Select(g1 => new
                {
                    DeliveryAddress = g1.Key.DeliverAddress,
                    UserId = g1.Key.Id,
                    City = g1.Key.City,
                    State = g1.Key.State,
                    PinCode = g1.Key.PinCode,
                    AddressId = g1.Key.AddressId,

                })
                .Where(res => res.UserId == userId)
                .Distinct()
                .ToList();
            AddressVM add = new AddressVM();
            add.Name = name;
            foreach (var item in result)
            {
                NameVM address = new NameVM();
                address.DeliverAddress = item.DeliveryAddress;
                address.City = item.City;
                address.State = item.State;
                address.PinCode = item.PinCode;
                address.AddressId = item.AddressId;

                //address.ProductId = item.ProductId;
                //   address.CreatedBy = item.UserId;
                add.TblName.Add(address);



            }
            addresses.Add(add);
            return addresses;
        }



        public SelectProductVM GetSelectSummaryDAL(int Id)
        {
            SelectProductVM spv=new SelectProductVM();

          var select = _context.TblProducts.Single(r => r.ProductId == Id);
            spv.ProductName=select.ProductName;
            spv.Image=select.Image;
            spv.Rate=select.Rate;
            return spv;


        }
       

    }
}
