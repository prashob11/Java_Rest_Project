package utils;

import java.io.IOException;
import java.util.Date;

import org.codehaus.jackson.JsonParser;
import org.codehaus.jackson.JsonProcessingException;
import org.codehaus.jackson.map.DeserializationContext;
import org.codehaus.jackson.map.JsonDeserializer;



public class CustomDateDeserializer extends JsonDeserializer<Date> {


	@SuppressWarnings("deprecation")
	@Override
	public Date deserialize(JsonParser p, DeserializationContext c) throws IOException, JsonProcessingException {
		String date = p.getText();
		
		Date d = new Date();
		d.setTime((long)Long.parseLong(date));
		
		d.setHours(12);
		return d;
	}
}