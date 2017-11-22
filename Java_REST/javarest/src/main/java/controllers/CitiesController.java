package controllers;

import java.util.List;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import dao.CityDAO;
import entities.City;;

@Path("/Cities")
public class CitiesController {

	@GET
    @Produces({ MediaType.APPLICATION_JSON })
    public List<City> getCities() {
        List<City> cities = new CityDAO().getCities();
        return cities;
    }
	
	@GET
    @Path("/{id}")
    @Produces({ MediaType.APPLICATION_JSON })
    public City getCity(@PathParam("id") int id) {
        return null;
    }
}
