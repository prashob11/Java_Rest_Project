package controllers;

import java.util.List;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import dao.RoomDAO;
import entities.Room;


@Path("/Rooms")
public class RoomsController {

	RoomDAO dao = new RoomDAO();
	
	@GET
    @Produces({ MediaType.APPLICATION_JSON })
    public List<Room> getRooms() {
        return dao.getRooms();
    }
	
}