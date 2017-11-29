package controllers;

import java.util.List;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import dao.RegionDAO;
import entities.Region;

@Path("/Regions")
public class RegionsController {

	RegionDAO dao = new RegionDAO();
	
	@GET
    @Produces({ MediaType.APPLICATION_JSON })
    public List<Region> getRegions() {
        return dao.getRegions();
    }
	
	@GET
    @Path("/{countryId}")
    @Produces({ MediaType.APPLICATION_JSON })
    public List<Region> getRegionsByCountryId(@PathParam("countryId") int countryId) {
		return dao.getRegionsByCountryId(countryId);	
    }
	
	@GET
    @Path("/{countryId}/{regionId}")
    @Produces({ MediaType.APPLICATION_JSON })
    public List<Region> getRegion(@PathParam("regionId") int regionId) {
		return dao.getRegion(regionId);	
    }
}
