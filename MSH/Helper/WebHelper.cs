using MSH.Entities;
using System;

namespace MSH.Web.Helper
{
    public static class WebHelper
    {
        public static T SetBaseProperties<T>(T data) where T : BaseEntity
        {
            data.GUID = Guid.NewGuid().ToString();
            data.InsertDate = DateTime.Now;
            return data;
        }
    }
}
