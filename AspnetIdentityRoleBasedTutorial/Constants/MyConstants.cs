namespace OnlineShoppingProject.Constants
{
    public static class MyConstants
    {
        public enum Roles
        {
            Admin,
            User
        }
        public enum Status
        {
            Active = 2,
            Deleted = 3,
        }

        public enum ProjectStatus
        {
            Ongoing = 2,
            OnHold = 3,
            Completed = 4,
            Canceled = 5
        }


        public enum PaymentType
        {
            Cash = 1,
            CreditCard = 2,
            PayPal = 3,

        }

        public enum Size
        {
         Small=1,
         Medium=2,
         Large=3,
         ExtraLarge=4,
        }
    }
}
