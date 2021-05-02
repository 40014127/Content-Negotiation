using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    public class MyCustomOutputFormatter : TextOutputFormatter
    {
        public MyCustomOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse
            ("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        public bool CanWriteType
        (OutputFormatterCanWriteContext context)
        {
            throw new NotImplementedException();
        }
        public override Task WriteResponseBodyAsync
        (OutputFormatterWriteContext context,
          Encoding selectedEncoding)
        {
            throw new NotImplementedException();
        }
    }
}
