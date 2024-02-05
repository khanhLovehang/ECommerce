﻿using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using Shared.DataTransferObjects;
using System.Text;

namespace ECommerce
{
    public class CsvOutputFormatter : TextOutputFormatter
    {
        public CsvOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            if (typeof(UserDto).IsAssignableFrom(type) ||
                typeof(IEnumerable<UserDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }

        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();
            if (context.Object is IEnumerable<UserDto>)
            {
                foreach (var user in (IEnumerable<UserDto>)context.Object)
                {
                    FormatCsv(buffer, user);
                }
            }
            else
            {
                FormatCsv(buffer, (UserDto)context.Object);
            }
            await response.WriteAsync(buffer.ToString());
        }

        private static void FormatCsv(StringBuilder buffer, UserDto user)
        {
            buffer.AppendLine($"{user.UserId},\"{user.UserName},\"{user.Email}\"");
        }
    }
}
