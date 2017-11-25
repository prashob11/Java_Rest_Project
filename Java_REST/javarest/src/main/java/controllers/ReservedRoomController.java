package controllers;

import java.util.List;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import dao.ReservedRoomDAO;
import entities.Region;
import entities.Reservation;
import entities.ReservedRoom;


@Path("/ReservedRooms")
public class ReservedRoomController {
	ReservedRoomDAO dao=new ReservedRoomDAO();
	
	@GET
    @Produces({ MediaType.APPLICATION_JSON })
    public List<ReservedRoom> getReservations() {
        return dao.getReservedRooms();
    }
	
	@GET
    @Path("/{reservationId}")
    @Produces({ MediaType.APPLICATION_JSON })
    public List<ReservedRoom> getRegionsByCountryId(@PathParam("reservationId") int reservationId) {
		return dao.getRegionsByReservationId(reservationId);	
    }
}
