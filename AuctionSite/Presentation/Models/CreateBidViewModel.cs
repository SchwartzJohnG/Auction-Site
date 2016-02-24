using AuctionSite.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionSite.Presentation.Models {
    public class CreateBidViewModel {

        public AuctionItemDTO Item { get; set; }
        public BidDTO Bid { get; set; }
    }
}