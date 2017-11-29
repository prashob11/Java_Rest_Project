package controllers;

import java.util.List;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import dao.RoomTypeDAO;
import entities.City;
import entities.RoomType;


@Path("/RoomType")
public class RoomTypesController {

	RoomTypeDAO dao = new RoomTypeDAO();
	
	@GET
    @Produces({ MediaType.APPLICATION_JSON })
    public List<RoomType> getRoomType() {
        return dao.getRoomType();
    }

	@GET
    @Path("/{Id}")
    @Produces({ MediaType.APPLICATION_JSON })
    public List<RoomType> getRoomType(@PathParam("rtId") int rtId) {
		return dao.getRoomType(rtId);	
	}

}
