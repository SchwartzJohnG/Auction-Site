using AuctionSite.Domain.Models;
using AuctionSite.Services.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper.QueryableExtensions;

namespace AuctionSite.App_Start {
        public class AutoMapperConfig {
            public static void RegisterMaps() {
            Mapper.CreateMap<AuctionItem, AuctionItemDTO>()
                .ForMember(ai => ai.Bids, opt => opt.Ignore())
                .AfterMap((src, dst) => {
                    if (src.Bids != null) {
                        dst.Bids = src.Bids.AsQueryable().ProjectTo<BidDTO>().ToList();
                        foreach (var i in dst.Bids) {
                            i.Item = dst;
                        }
                    }
                });
            Mapper.CreateMap<AuctionItemDTO, AuctionItem>()
                .ForMember(ai => ai.Bids, opt => opt.Ignore())
                .AfterMap((src, dst) => {
                    if (src.Bids != null) {
                        dst.Bids = src.Bids.AsQueryable().ProjectTo<Bid>().ToList();
                        foreach (var i in dst.Bids) {
                            i.Item = dst;
                        }
                    }
                });

            Mapper.CreateMap<Bid, BidDTO>();
            Mapper.CreateMap<BidDTO, Bid>();
        }
    }
}