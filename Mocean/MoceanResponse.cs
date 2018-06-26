﻿using System.Net;

namespace Mocean
{
    public class MoceanResponse
    {
        //public HttpStatusCode Status { get; set; }
        public string HttpResponse { get; set; }
    }

    public class PaginatedResponse<T> where T : class
    {
        public int count { get; set; }
        public int page_size { get; set; }
        public int page_index { get; set; }
        public HALLinks _links { get; set; }
        public T _embedded { get; set; }
    }

    ////////
    // TODO: Handle HAL better
    public class Link
    {
        public string href { get; set; }
    }
    public class HALLinks
    {
        public Link self { get; set; }
        public Link next { get; set; }
        public Link prev { get; set; }
        public Link first { get; set; }
        public Link last { get; set; }
    }
}
