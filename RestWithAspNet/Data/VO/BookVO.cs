using RestWithAspNet.Hypermedia;
using RestWithAspNet.Hypermedia.Abstract;
using RestWithAspNet.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithAspNet.Model
{
    public class BookVO : ISupportHypermedia
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime LaunchDate { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}
