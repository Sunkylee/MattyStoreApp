using System;
using System.Collections.Generic;
using System.Text;

namespace MattyStoreApp.Utility
{
    public static class SD
    {
        public const string Proc_CoverType_Create = "usp_CreateCoverType";
        public const string Proc_CoverType_Get = "usp_GetCoverType";
        public const string Proc_CoverType_GetAll = "usp_GetCoverTypes";
        public const string Proc_CoverType_Update = "usp_UpdateCoverType";
        public const string Proc_CoverType_Delete = "usp_DeleteCoverType";


        public const string Role_User_Indi = "Individual Customer";
        public const string Role_User_Comp = "Company Customer";
        //Ability to manage the content of the website: Category, Cover Type, Products etc
        public const string Role_Admin = "Admin";

        public const string ssShoppingCart = "Shopping Cart Session";
        //Ability to change status of packages, take payments etc
        public const string Role_Employee = "Employee";

        public static double GetPriceBasedOnQuantity(int count, double price, double price50, double price100)
        {

            if (count < 50) 
            {

                return price;
            }
            else
            {
                if (count < 100)
                {
                    return price50;
                }
            }

            return price100;
        }

        public static string ConvertToRawHtml(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }


        //Order and Payment Status Static Details

        public const string StatusPending = "Pending";
        public const string StatusApproved = "Approved";
        public const string StatusInProcess = "Proccessing";
        public const string StatusShipped = "Shipped";
        public const string StatusCancelled = "Cancelled";
        public const string StatusRefunded = "Refunded";


        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusDelayedPayment = "ApprovedForDelayedPayment";
        public const string PaymentStatusRejected = "Rejected";

    }
}
