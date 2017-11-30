package controllers;

import java.util.List;
import java.util.stream.Collectors;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import com.mysql.cj.core.util.StringUtils;

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
    @Path("/byRegion/{regionId}")
    @Produces({ MediaType.APPLICATION_JSON })
    public List<City> getCitiesByRegionId(@PathParam("regionId") int regionId) {
		return dao.getCitiesByRegionId(regionId);	
    }
	
	@GET
    @Path("/{Id}")
    @Produces({ MediaType.APPLICATION_JSON })
    public List<City> getCity(@PathParam("Id") int Id) {
		return dao.getCity(Id);	
    }
	
	@GET
    @Path("/cl")
    @Produces({ MediaType.APPLICATION_JSON })
	public Response getCitiesForCascadingList(@QueryParam("regionId") int regionId,
			@QueryParam("prefix") String prefix) {
		

		List<City> cities = dao.getCitiesByRegionId(regionId);
		List<String> sli = cities.stream()
				.map(c -> c.getCity())
				.filter(c -> StringUtils.isNullOrEmpty(prefix)?
						true 
						: 
						c.toLowerCase().startsWith(prefix))
				.collect(Collectors.toList());

		return Response.status(200).header("Access-Control-Allow-Origin", "*")
				.header("Access-Control-Allow-Headers", "origin, content-type, accept, authorization")
				.header("Access-Control-Allow-Credentials", "true")
				.header("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS, HEAD")
				.header("Access-Control-Max-Age", "1209600").entity(sli).build();
	}
	
}
