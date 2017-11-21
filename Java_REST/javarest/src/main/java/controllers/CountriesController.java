package controllers;

import java.util.List;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import dao.CountryDAO;
import entities.Country;

@Path("/Countries")
public class CountriesController {

	@GET
    @Produces({ MediaType.APPLICATION_JSON })
    public List<Country> getCountries() {
        List<Country> countries = new CountryDAO().getCountries();
        return countries;
    }
	
	@GET
    @Path("/{id}")
    @Produces({ MediaType.APPLICATION_JSON })
    public Country getCountry(@PathParam("id") int id) {
        return null;
    }
}
