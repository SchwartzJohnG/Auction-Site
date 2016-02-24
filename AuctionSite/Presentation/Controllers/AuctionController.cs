using AuctionSite.Presentation.Models;
using AuctionSite.Services;
using AuctionSite.Services.Models;
using CoderCamps.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctionSite.Presentation.Controllers
{
    public class AuctionController : Controller
    {
        private AuctionService _auctionService;

        public AuctionController(AuctionService auctionService) {
            _auctionService = auctionService;
        }

        // GET: Auction
        public ActionResult Index()
        {
            return View(_auctionService.List());
        }

        // GET: Auction/Details/5
        public ActionResult Details(int id)
        {
            return View(_auctionService.Find(id));
        }

        // GET: Auction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auction/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(AuctionItemDTO item)
        {
            if (ModelState.IsValid) {

                _auctionService.Add(item);

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Auction/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_auctionService.Find(id));
        }

        // POST: Auction/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AuctionItemDTO item)
        {
            if (ModelState.IsValid) {
                
                _auctionService.Update(item);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult CreateBid(int id) {
            return View(new CreateBidViewModel() {
                Item = _auctionService.Find(id)
            });
        }

        [HttpPost]
        public ActionResult CreateBid(int id, BidDTO bid) {

            if (ModelState.IsValid) {

                if (_auctionService.AddBidToItem(id, bid)) {
                    return RedirectToAction("Index");
                }
                else {
                    ModelState.AddModelError("Status", "Auction is closed");
                }
            }

            return View(new CreateBidViewModel {
                Item = _auctionService.Find(id),
                Bid = bid
            });
        }
    }
}
