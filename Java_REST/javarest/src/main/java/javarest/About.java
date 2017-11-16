package javarest;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;


@Path("/about")
public class About {
	@GET
	@Produces(MediaType.TEXT_HTML)
	public String getAbout() {
		return "Navjot Nikita Prasob Zhengyang: Project 2";
	}
}

