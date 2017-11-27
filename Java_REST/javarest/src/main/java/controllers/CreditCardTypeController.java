package controllers;

import java.util.List;

import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;


import dao.CreditCardDAO;
import entities.CreditCard;


@Path("/CreditCardType")
public class CreditCardTypeController {

	CreditCardDAO dao = new CreditCardDAO();
	
	@GET
    @Produces({ MediaType.APPLICATION_JSON })
    public List<CreditCard>  getCreditCardType() {
        return dao. getCreditCardType();
    }
	
	@GET
    @Path("/{id}")
    @Produces({ MediaType.APPLICATION_JSON })
    public List<CreditCard> getCountry(@PathParam("id") int id) {
		return dao.getCreditcard(id);	
    }
}
