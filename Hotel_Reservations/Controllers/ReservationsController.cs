using Hotel_Reservations.ws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Reservations
{
    public class ReservationsController : Controller
    {
        //private ModelReservations db = new ModelReservations();

        private ReservationsWSClient ws = new ReservationsWSClient();
        private ReservedRoomsWSClient rrws = new ReservedRoomsWSClient();

        private IEnumerable<Country> countries = new CountriesWsClient().GetAllCountries();
        private IEnumerable<RoomType> roomTypes = new RoomTypesWsClient().GetAllRoomTypes();
        private IEnumerable<CreditCardType> creditCardTypes = new CreditCardTypeWSClient().GetAllCreditCardTypes();

        // GET: Reservations
        [Authorize]
        public ActionResult Index()
        {
            //var reservations = db.Reservations.Include(r => r.Country1).Include(r => r.CreditCardType1).Include(r => r.Region1).Include(r => r.RoomType1);

            var reservations = ws.GetAllReservations();
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
            //Reservation reservation = db.Reservations.Find(id);
            Reservation reservation = ws.GetReservation(id.Value);
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
            ViewBag.country = new SelectList(countries, "countryId", "country1");
            ViewBag.CreditCardType = new SelectList(creditCardTypes, "cctId", "type");
            ViewBag.region = new SelectList(new List<Region>(), "regionId", "region1");
            ViewBag.roomType = new SelectList(roomTypes, "rtId", "roomType1");
            ViewBag.city = new SelectList(new List<City>(), "cityId", "city1");
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
                //ws code
                ws.CreateReservation(reservation);
                MakeReservations(reservation);

                return RedirectToAction("Index");

            }

            ViewBag.country = new SelectList(countries, "countryId", "country1", reservation.country);
            ViewBag.CreditCardType = new SelectList(creditCardTypes, "cctId", "type", reservation.CreditCardType);
            ViewBag.region = new SelectList(new List<Region>() { reservation.Region1 }, "regionId", "region1", reservation.region);
            ViewBag.roomType = new SelectList(roomTypes, "rtId", "roomType1", reservation.roomType);
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

            //Reservation reservation = db.Reservations.Find(id);
            Reservation reservation = ws.GetReservation(id.Value);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.country = new SelectList(countries, "countryId", "country1", reservation.country);
            ViewBag.CreditCardType = new SelectList(creditCardTypes, "cctId", "type", reservation.CreditCardType);
            ViewBag.region = new SelectList(new List<Region>() { reservation.Region1 }, "regionId", "region1", reservation.region);
            ViewBag.roomType = new SelectList(roomTypes, "rtId", "roomType1", reservation.roomType);
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
                ws.EditReservation(reservation);
                rrws.DeleteReservedRooms(reservation.reservationId);
                MakeReservations(reservation);
                return RedirectToAction("Index");
            }
            ViewBag.country = new SelectList(countries, "countryId", "country1", reservation.country);
            ViewBag.CreditCardType = new SelectList(creditCardTypes, "cctId", "type", reservation.CreditCardType);
            ViewBag.region = new SelectList(new List<Region>() { reservation.Region1 }, "regionId", "region1", reservation.region);
            ViewBag.roomType = new SelectList(roomTypes, "rtId", "roomType1", reservation.roomType);

            return View(reservation);
        }

        [Authorize]
        private void MakeReservations(Reservation reservation)
        {
            int reservationId = reservation.reservationId;
            int numberOfRooms = reservation.numberOfRooms;
            int roomType = reservation.roomType;

            //select rooms that are available
            var availableRooms = Validators.ReservationDatesValidation.GetAvailableRooms(reservation.checkin, reservation.checkout, roomType, reservationId);


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
                rrws.CreateReservedRoom(rr);
            }

            //db.SaveChanges();
        }

        // GET: Reservations/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Reservation reservation = db.Reservations.Find(id);
            Reservation reservation = ws.GetReservation(id.Value);
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
            rrws.DeleteReservedRooms(id);
            ws.DeleteReservation(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
