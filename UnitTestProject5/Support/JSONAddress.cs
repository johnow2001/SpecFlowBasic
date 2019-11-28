using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UseJSONAddress;

namespace UseJSONAddress
{
    public class JSONAddress
    {
        public String Address { get; set; }
        public String PostCode { get; set; }
        public List<String> Names { get; set; }
        public List<PreviousJob> PreviousJobs { get; set; }

        public class PreviousJob
        {
            public String CompanyName { get; set; }
            public String Year { get; set; }
        }
    }

}
