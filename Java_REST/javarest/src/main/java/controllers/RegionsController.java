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

import dao.RegionDAO;
import entities.Region;
import utils.SelectListItem;

@Path("/Regions")
public class RegionsController {

	RegionDAO dao = new RegionDAO();
	
	@GET
    @Produces({ MediaType.APPLICATION_JSON })
    public List<Region> getRegions() {
        return dao.getRegions();
    }
	
	@GET
    @Path("/byCountry/{countryId}")
    @Produces({ MediaType.APPLICATION_JSON })
    public List<Region> getRegionsByCountryId(@PathParam("countryId") int countryId) {
		return dao.getRegionsByCountryId(countryId);	
    }
	
	@GET
    @Path("/{regionId}")
    @Produces({ MediaType.APPLICATION_JSON })
    public List<Region> getRegion(@PathParam("regionId") int regionId) {
		return dao.getRegion(regionId);	
    }
	
	@GET
    @Path("/cl")
    @Produces({ MediaType.APPLICATION_JSON })
	public Response getRegionsForCascadingList(@QueryParam("countryId") String countryId,
			@QueryParam("regionId") String regionId) {
		
		if(StringUtils.isNullOrEmpty(countryId)) {
			return Response.noContent().build();
		}
		List<Region> regions = dao.getRegionsCascadingList(countryId, regionId);
		List<SelectListItem> sli = regions.stream()
				.map(r -> new SelectListItem(r.getRegion(), new Integer(r.getRegionId()).toString()))
				.collect(Collectors.toList());

		return Response.status(200).header("Access-Control-Allow-Origin", "*")
				.header("Access-Control-Allow-Headers", "origin, content-type, accept, authorization")
				.header("Access-Control-Allow-Credentials", "true")
				.header("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS, HEAD")
				.header("Access-Control-Max-Age", "1209600").entity(sli).build();
	}
}
