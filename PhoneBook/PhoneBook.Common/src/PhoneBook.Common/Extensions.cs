using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Common
{
    public static class Extensions
    {
        public static T GetOptions<T>(this IConfiguration configuration, string section)
            where T: new()
        {
            var model = new T();
            configuration.GetSection(section).Bind(model);
            return model;
        }
    }
}
