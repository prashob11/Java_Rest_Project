package entities;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import org.codehaus.jackson.annotate.JsonProperty;

@Entity
@Table(name = "Countries")
public class Country implements Serializable {
	private static final long serialVersionUID = 1767113837094634625L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "countryId")
	private int countryId;

	@Column(name = "country")
	private String country;

	@Column(name = "postalPattern")
	private String postalPattern;

	public int getCountryId() {
		return countryId;
	}

	public void setCountryId(int countryId) {
		this.countryId = countryId;
	}

	@JsonProperty("country1")
	public String getCountry() {
		return country;
	}

	public void setCountry(String country) {
		this.country = country;
	}

	public String getPostalPattern() {
		return postalPattern;
	}

	public void setPostalPattern(String postalPattern) {
		this.postalPattern = postalPattern;
	}

}
