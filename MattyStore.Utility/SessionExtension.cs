using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MattyStoreApp.Utility
{
   public static class SessionExtension
   {
        public static void SetObject(this ISession session, string  Key , object Value)
        {

            session.SetString(Key, JsonConvert.SerializeObject(Value));

        }

        public static T SetObject<T>(this ISession session, string Key)
        {

          var value =  session.GetString(Key);

            return value == null ? default (T) : JsonConvert.DeserializeObject<T>(value);
        }
    }


}
