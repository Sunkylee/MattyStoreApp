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

        //Ability to change status of packages, take payments etc
        public const string Role_Employee = "Employee";

    }
}
