using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionSite.Services.Models {
    public class AuctionItemDTO {

        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal MinimumBid { get; set; }
        public int MaxNumberOfBids { get; set; }

        public IList<BidDTO> Bids { get; set; }
    }
}