package controllers;

import java.util.List;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import dao.CityDAO;
import entities.City;

@Path("/Cities")
public class CitiesController {

	CityDAO dao = new CityDAO();
	
	@GET
    @Produces({ MediaType.APPLICATION_JSON })
    public List<City> getCities() {
        List<City> cities = new CityDAO().getCities();
        return cities;
    }
	
	@GET
    @Path("/{regionId}")
    @Produces({ MediaType.APPLICATION_JSON })
    public List<City> getCitiesByRegionId(@PathParam("regionId") int regionId) {
		return dao.getCitiesByRegionId(regionId);	
    }
	
	@GET
    @Path("/{regionId}/{Id}")
    @Produces({ MediaType.APPLICATION_JSON })
    public List<City> getCity(@PathParam("Id") int Id) {
		return dao.getCity(Id);	
    }
	
}
