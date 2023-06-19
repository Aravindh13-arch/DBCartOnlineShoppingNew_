using OnlineShoppingProject.DAL;
using OnlineShoppingProject.Models;
using OnlineShoppingProject.ViewModels;
using System.Collections.Generic;

namespace OnlineShoppingProject.BAL
{
    public class AddressImplementation
    {
        private AddressImplementationDAL addressImplementationDAL;
        public AddressImplementation(AddressImplementationDAL addressImplementationDAL)
        {
            this.addressImplementationDAL = addressImplementationDAL;
        }

        public List<AddressVM> GetIDAddressBAL(string userId, int Id)
        {
            return addressImplementationDAL.GetIDAddressDAL(userId, Id);
        }

        public async Task<List<SelectProductVM>> GetSelectSummaryBAL(int Id)
        {
            try
            {
                   return  await addressImplementationDAL.GetSelectSummaryDAL(Id);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
      
    }
}
