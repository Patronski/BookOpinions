﻿namespace BookOpinions.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Image
    {
        public int Id { get; set; }

        public byte[] data { get; set; }

        public string ContentType { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
    }
}