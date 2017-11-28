package controllers;

import java.io.Serializable;
import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.PUT;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

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
	
	@GET
	@Path("/{id}")
	@Produces({ MediaType.APPLICATION_JSON })
	public Reservation getReservation(@PathParam("id") int id) {
		return dao.getReservation(id);
	}
	
	@DELETE
	@Path("/{id}")
	@Produces({ MediaType.APPLICATION_JSON })
	public Response deleteReservation(@PathParam("id") int id) {
		boolean deleted = dao.deleteReservation(id);
		return Response.status(deleted ? Response.Status.OK : Response.Status.NO_CONTENT).build();
	}
	
	@PUT
	@Produces({ MediaType.APPLICATION_JSON })
	@Consumes({ MediaType.APPLICATION_JSON })
	public Serializable createReservation(Reservation r) {		
		return dao.createReservation(r);
	}
}
