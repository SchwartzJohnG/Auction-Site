using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionSite.Domain.Models {

    public class Bid {
        // FIELD
        //access modifier   type      _name    optional assignment statment   ;
        //private            int   _fieldName             = 10                ;

        // PROPERTY
        //access modifier   type     PropName       Get/Set definitions
          public             int       Id           { get; set; }

        public string Name { get; set; }
        public decimal BidAmount { get; set; }

        public AuctionItem Item { get; set; }
    }
}