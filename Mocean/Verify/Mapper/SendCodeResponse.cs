﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mocean.Verify
{
    [XmlRoot("result")]
    public class SendCodeResponse : AbstractResponse
    {
        [JsonProperty("reqid")]
        [XmlElement("reqid")]
        public string ReqId { get; set; }
    }
}
