using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Reservations
{
    public class ReservationsController : Controller
    {
        private ModelReservations db = new ModelReservations();

        // GET: Reservations
        [Authorize]
        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.Country1).Include(r => r.CreditCardType1).Include(r => r.Region1).Include(r => r.RoomType1);
            return View(reservations.ToList());
        }

        // GET: Reservations/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Reservations/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.country = new SelectList(db.Countries, "countryId", "country1");
            ViewBag.CreditCardType = new SelectList(db.CreditCardTypes, "cctId", "type");
            ViewBag.region = new SelectList(db.Regions, "regionId", "region1");
            ViewBag.roomType = new SelectList(db.RoomTypes, "rtId", "roomType1");
            ViewBag.city = new SelectList(db.Cities, "cityId", "city1");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "reservationId,numberOfGuests,numberOfRooms,roomType,checkin,checkout,firstName,lastName,streetNumber,streetName,city,region,country,postalCode,phoneNumber,emailAddress,nameOnTheCard,CreditCardnumber,CreditCardType,CreditCardExpDate")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                MakeReservations(reservation);
                return RedirectToAction("Index");

            }

            ViewBag.country = new SelectList(db.Countries, "countryId", "country1", reservation.country);
            ViewBag.CreditCardType = new SelectList(db.CreditCardTypes, "cctId", "type", reservation.CreditCardType);
            ViewBag.region = new SelectList(db.Regions, "regionId", "region1", reservation.region);
            ViewBag.roomType = new SelectList(db.RoomTypes, "rtId", "roomType1", reservation.roomType);
            ViewBag.city = new SelectList(db.Cities, "cityId", "city1", reservation.city);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.country = new SelectList(db.Countries, "countryId", "country1", reservation.country);
            ViewBag.CreditCardType = new SelectList(db.CreditCardTypes, "cctId", "type", reservation.CreditCardType);
            ViewBag.region = new SelectList(db.Regions, "regionId", "region1", reservation.region);
            ViewBag.roomType = new SelectList(db.RoomTypes, "rtId", "roomType1", reservation.roomType);
            ViewBag.city = new SelectList(db.Cities, "cityId", "city1", reservation.city);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "reservationId,numberOfGuests,numberOfRooms,roomType,checkin,checkout,firstName,lastName,streetNumber,streetName,city,region,country,postalCode,phoneNumber,emailAddress,nameOnTheCard,CreditCardnumber,CreditCardType,CreditCardExpDate")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.ReservedRooms.RemoveRange(db.ReservedRooms.Where(rr => rr.reservationId == reservation.reservationId));
                db.SaveChanges();
                MakeReservations(reservation);
                return RedirectToAction("Index");
            }
            ViewBag.country = new SelectList(db.Countries, "countryId", "country1", reservation.country);
            ViewBag.CreditCardType = new SelectList(db.CreditCardTypes, "cctId", "type", reservation.CreditCardType);
            ViewBag.region = new SelectList(db.Regions, "regionId", "region1", reservation.region);
            ViewBag.roomType = new SelectList(db.RoomTypes, "rtId", "roomType1", reservation.roomType);
            ViewBag.city = new SelectList(db.Cities, "cityId", "city1", reservation.city);
            return View(reservation);
        }

        [Authorize]
        private void MakeReservations(Reservation reservation)
        {
            int reservationId = reservation.reservationId;
            int numberOfRooms = reservation.numberOfRooms;
            int roomType = reservation.roomType;

            //select rooms that are available
            var availableRooms = Validators.ReservationDatesValidation.GetAvailableRooms(db, reservation.checkin, reservation.checkout, roomType, reservationId);


            if (availableRooms.Count() < numberOfRooms)
            {
                throw new Exception("No available rooms for these dates");
            }

            //book available rooms
            var are = availableRooms.GetEnumerator();
            while (numberOfRooms-- > 0)
            {
                ReservedRoom rr = new ReservedRoom();
                rr.reservationId = reservationId;
                are.MoveNext();
                rr.roomId = are.Current;
                db.ReservedRooms.Add(rr);
            }

            db.SaveChanges();
        }

        // GET: Reservations/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.ReservedRooms.RemoveRange(db.ReservedRooms.Where(rr => rr.reservationId == reservation.reservationId));
            db.Reservations.Remove(reservation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult GetRegions(string countryId, string regionId)
        {

            List<SelectListItem> regions = new List<SelectListItem>();
            int cId = Convert.ToInt32(countryId);
            int rId = Convert.ToInt32(regionId);

            //select all regions for the given country
			db.Regions
	             .Where(r => r.country == cId)
	             .ToList()
	             .ForEach(r =>
	        {
		         regions.Add(new SelectListItem { Text = r.region1, Value = r.regionId.ToString() });
	        });

            //if the region is already selected
            if (regionId != null)
            {
                var sr = regions.Where(si => si.Value == regionId); 
                /* 
                 * if region with given regionId is in the list 
                 * then move it in the beginning of the list (for Edit page)
                 */
                if (sr.Count() == 1)
                {
                    var region = sr.First();
                    regions.Remove(region);
                    regions.Insert(0, region);
                }
            }

            return Json(regions, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetCities(string regionId, string prefix)
        {

            int rId = Convert.ToInt32(regionId);
            List<string> cities;
            if (String.IsNullOrEmpty(prefix))
            {
                cities = db.Cities
                    .Where(c => c.region == rId)
                    .Select(c => c.city1)
                    .ToList();
            }
            else
            {
                cities = db.Cities
                    .Where(c => c.region == rId)
                    .Select(c => c.city1)
                    .Where(c => c.ToLower().StartsWith(prefix))
                    .ToList();
            }



            return Json(cities, JsonRequestBehavior.AllowGet);
        }
    }
}
