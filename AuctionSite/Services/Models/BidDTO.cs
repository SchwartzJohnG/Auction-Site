using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionSite.Services.Models {
    public class BidDTO {

        public int Id { get; set; }

        public string Name { get; set; }
        public decimal BidAmount { get; set; }

        public AuctionItemDTO Item { get; set; }
    }
}