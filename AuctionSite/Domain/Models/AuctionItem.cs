using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace AuctionSite.Domain.Models {
    public class AuctionItem {

        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal MinimumBid { get; set; }
        public int MaxNumberOfBids { get; set; }

        public IList<Bid> Bids { get; set; }
    }
}