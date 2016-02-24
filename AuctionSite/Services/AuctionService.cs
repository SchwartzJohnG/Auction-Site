using AuctionSite.Domain.Models;
using AuctionSite.Services.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoderCamps.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionSite.Services {
    public class AuctionService {

        const string CACHE_LIST_KEY = "CACHE_LIST_KEY";

        private IGenericRepository _repo;

        public AuctionService(IGenericRepository repo) {
            _repo = repo;
        }

        public IList<AuctionItemDTO> List() {
            var results = (IList<AuctionItemDTO>)HttpRuntime.Cache[CACHE_LIST_KEY];
            if (results == null) {
                results = Mapper.Map<List<AuctionItemDTO>>((from ai in _repo.Query<AuctionItem>().Include(ai => ai.Bids)
                                                            select ai).ToList());
                HttpRuntime.Cache[CACHE_LIST_KEY] = results;
            }
            return results;
        }

        public AuctionItemDTO Find(int id) {
            return Mapper.Map<AuctionItemDTO>(FindInternal(id));
        }

        private AuctionItem FindInternal(int id) {
            return (from ai in _repo.Query<AuctionItem>().Include(ai => ai.Bids)
                    where ai.Id == id
                    select ai).FirstOrDefault();
        }

        public void Add(AuctionItemDTO item) {
            _repo.Add(Mapper.Map<AuctionItem>(item));
            _repo.SaveChanges();
        }

        public void Update(AuctionItemDTO item) {

            var dbItem = FindInternal(item.Id);

            Mapper.Map(item, dbItem);
            //dbItem.Name = item.Name;
            //dbItem.Description = item.Description;
            //dbItem.MaxNumberOfBids = item.MaxNumberOfBids;
            //dbItem.MinimumBid = item.MinimumBid;
            _repo.SaveChanges();
        }

        public bool AddBidToItem(int id, BidDTO bid) {

            var item = FindInternal(id);

            if (item.Bids.Count < item.MaxNumberOfBids) {
                item.Bids.Add(Mapper.Map<Bid>(bid));
                _repo.SaveChanges();

                return true;
            }

            return false;
        }
    }
}