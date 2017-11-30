package controllers;

import java.io.Serializable;
import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import dao.ReservedRoomDAO;
import entities.ReservedRoom;


@Path("/ReservedRooms")
public class ReservedRoomController {
	ReservedRoomDAO dao=new ReservedRoomDAO();
	
	@GET
    @Produces({ MediaType.APPLICATION_JSON })
    public List<ReservedRoom> getReservedRooms() {
        return dao.getReservedRooms();
    }
	
	@GET
    @Path("/{reservationId}")
    @Produces({ MediaType.APPLICATION_JSON })
    public List<ReservedRoom> getReservedRoomsByReservationId(@PathParam("reservationId") int reservationId) {
		return dao.getReservedRoomsByReservationId(reservationId);	
    }
	
	@DELETE
	@Path("/{reservationId}")
	@Produces({ MediaType.APPLICATION_JSON })
	public Response deleteReservedRooms(@PathParam("reservationId") int reservationId) {
		dao.deleteReservedRooms(reservationId);
		return Response.status(Response.Status.OK).build();
	}
	
	@POST
	@Produces({ MediaType.APPLICATION_JSON })
	@Consumes({ MediaType.APPLICATION_JSON })
	public Serializable createReservedRoom(ReservedRoom rr) {		
		return dao.createReservedRoom(rr);
	}
}
