package controllers;

import java.util.List;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import dao.ReservationDAO;
import entities.Reservation;


@Path("/Reservations")
public class ReservationsController {

	ReservationDAO dao = new ReservationDAO();
	
	@GET
    @Produces({ MediaType.APPLICATION_JSON })
    public List<Reservation> getReservations() {
        return dao.getReservations();
    }
	

}
