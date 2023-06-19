using Microsoft.VisualBasic;
using OnlineShoppingProject.Models;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingProject.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AspnetIdentityRoleBasedTutorial.Data;

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



        public async Task<List<SelectProductVM>> GetSelectSummaryDAL(int Id)
        {
          

           List<SelectProductVM> spv = new List<SelectProductVM>();

            var select = _context.TblGalleries
                .Join(_context.TblProducts,
                    t1 => t1.ProductId,
                    t2 => t2.ProductId,
                    (t1, t2) => new { t1, t2 })

                .Where(g => g.t2.ProductId == Id)
                .Select(g => new
                {
                    productId=g.t2.ProductId,
                    ProductName = g.t2.ProductName,
                    Image = g.t2.Image,
                    Rate = g.t2.Rate,
                    Image1 = g.t1.Image,
                    thumbImage=g.t1.ThumbImage
               
                })
                .ToList();


            if (select.Count > 0)
            {
                SelectProductVM sp = new SelectProductVM();
                sp.ProductId = select[0].productId;
                sp.ProductName = select[0].ProductName;
                sp.Image = select[0].Image;
                sp.Rate = select[0].Rate;

                foreach (var item in select)
                {
                    TblImageVM imageVM = new TblImageVM();
                    // imageVM.Id = item.productId;
                    imageVM.Image = item.Image1;
                    imageVM.ThumbImage = item.thumbImage;
                    sp.TblImages.Add(imageVM);
                }
                var Size = await _context.TblSizes.Select(r => r).ToListAsync();
                if (Size != null)
                {
                    foreach (var item in Size)
                    {
                        TblSize tblSize = new TblSize();
                        tblSize.SizeId = item.SizeId;
                        tblSize.TypesOfSize = item.TypesOfSize;
                        sp.TblSizes.Add(tblSize);
                    }
                }

                spv.Add(sp);
            }
          

            return spv;


        }
       
        //public async Task<List<TblSize>>GetTheSizesList()
        //{
        //    List<TblSize> tblSize = new List<TblSize>();
        //    var sizeList = await _context.TblSizes.Select(r=>r).ToListAsync();
        //    if (sizeList != null)
        //    {
        //        foreach (var item in sizeList)
        //        {
        //            TblSize Size = new TblSize();
        //            Size.SizeId = item.SizeId;
        //            Size.TypesOfSize = item.TypesOfSize;
        //            tblSize.Add(Size);
        //        }
        //    }
        //    return tblSize;
        //}
    }
}
