using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace POC.NetCore.Model
{
    public class HttpResponseMessageAPI
    {
        public Pessoa Data { get; set; }

        public HttpResponseMessage Response { get; set; }
    }
}
