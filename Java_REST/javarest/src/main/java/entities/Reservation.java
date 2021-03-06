package entities;

import java.util.Collection;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import org.codehaus.jackson.annotate.JsonProperty;
import org.codehaus.jackson.map.annotate.JsonDeserialize;
import org.codehaus.jackson.map.annotate.JsonSerialize;

import dao.CountryDAO;
import dao.CreditCardDAO;
import dao.RegionDAO;
import dao.ReservedRoomDAO;
import dao.RoomTypeDAO;
import utils.CustomDateDeserializer;
import utils.CustomDateSerializer;

@Entity
@Table(name = "Reservations")
public class Reservation {
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "reservationId")
	private int reservationId;

	@Column(name = "numberOfGuests")
	private int numberOfGuests;
	
	@Column(name = "numberOfRooms")
	private int numberOfRooms;

	@Column(name = "roomType")
	private int roomType;

	@JsonProperty("checkin")
	private Date checkin;

	@Column(name = "checkout")
	private Date checkout;

	@Column(name = "firstName")
	private String firstName;

	@Column(name = "lastName")
	private String lastName;

	@Column(name = "streetNumber")
	private String streetNumber;

	@Column(name = "streetName")
	private String streetName;

	@Column(name = "city")
	private String city;

	@Column(name = "region")
	private int region;

	@Column(name = "country")
	private int country;

	@Column(name = "postalCode")
	private String postalCode;

	@Column(name = "phoneNumber")
	private String phoneNumber;

	@Column(name = "emailAddress")
	private String emailAddress;

	@Column(name = "nameOnTheCard")
	private String nameOnTheCard;

	@JsonProperty("CreditCardnumber")
	@Column(name = "CreditCardnumber")
	private String creditCardnumber;

	@JsonProperty("CreditCardType")
	@Column(name = "CreditCardType")
	private int creditCardType;

	@JsonProperty("CreditCardExpDate")
	@Column(name = "CreditCardExpDate")
	private Date creditCardExpDate;

	@JsonProperty("Country1")
	public Country getCountry1() {
		return new CountryDAO().getCountry(this.country).get(0);
	}
	
	@JsonProperty("RoomType1")
	public RoomType getRoomType1() {
		return new RoomTypeDAO().getRoomType(this.roomType).get(0);
	}
	
	@JsonProperty("CreditCardType1")
	public CreditCard getCreditCardType1() {
		return new CreditCardDAO().getCreditcard(this.creditCardType).get(0);
	}
	
	@JsonProperty("Region1")
	public Region getRegion1() {
		return new RegionDAO().getRegion(this.region).get(0);
	}
	
	@JsonProperty("ReservedRooms")
	public Collection<ReservedRoom> ReservedRooms() {
		return new ReservedRoomDAO().getReservedRoomsByReservationId(this.reservationId);
	}
	
	public int getReservationId() {
		return reservationId;
	}

	public void setReservationId(int reservationId) {
		this.reservationId = reservationId;
	}

	public int getNumberOfRooms() {
		return numberOfRooms;
	}

	public void setNumberOfRooms(int numberOfRooms) {
		this.numberOfRooms = numberOfRooms;
	}
	
	public int getNumberOfGuests() {
		return numberOfGuests;
	}

	public void setNumberOfGuests(int numberOfGuests) {
		this.numberOfGuests = numberOfGuests;
	}

	public int getRoomType() {
		return roomType;
	}

	public void setRoomType(int roomType) {
		this.roomType = roomType;
	}
	
	@JsonSerialize(using = CustomDateSerializer.class)
	public Date getCheckin() {
		return checkin;
	}

	@JsonDeserialize(using = CustomDateDeserializer.class)
	public void setCheckin(Date checkin) {
		this.checkin = checkin;
	}

	@JsonSerialize(using = CustomDateSerializer.class)
	public Date getCheckout() {
		return checkout;
	}
	
	@JsonDeserialize(using = CustomDateDeserializer.class)
	public void setCheckout(Date checkout) {
		this.checkout = checkout;
	}

	public String getFirstName() {
		return firstName;
	}

	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}

	public String getLastName() {
		return lastName;
	}

	public void setLastName(String lastName) {
		this.lastName = lastName;
	}

	public String getStreetNumber() {
		return streetNumber;
	}

	public void setStreetNumber(String streetNumber) {
		this.streetNumber = streetNumber;
	}

	public String getStreetName() {
		return streetName;
	}

	public void setStreetName(String streetName) {
		this.streetName = streetName;
	}

	public String getCity() {
		return city;
	}

	public void setCity(String city) {
		this.city = city;
	}

	public int getRegion() {
		return region;
	}

	public void setRegion(int region) {
		this.region = region;
	}

	public int getCountry() {
		return country;
	}

	public void setCountry(int country) {
		this.country = country;
	}

	public String getPostalCode() {
		return postalCode;
	}

	public void setPostalCode(String postalCode) {
		this.postalCode = postalCode;
	}

	public String getPhoneNumber() {
		return phoneNumber;
	}

	public void setPhoneNumber(String phoneNumber) {
		this.phoneNumber = phoneNumber;
	}

	public String getEmailAddress() {
		return emailAddress;
	}

	public void setEmailAddress(String emailAddress) {
		this.emailAddress = emailAddress;
	}

	public String getNameOnTheCard() {
		return nameOnTheCard;
	}

	public void setNameOnTheCard(String nameOnTheCard) {
		this.nameOnTheCard = nameOnTheCard;
	}

	public String getCreditCardnumber() {
		return creditCardnumber;
	}

	public void setCreditCardnumber(String creditCardnumber) {
		this.creditCardnumber = creditCardnumber;
	}

	public int getCreditCardType() {
		return creditCardType;
	}

	public void setCreditCardType(int creditCardType) {
		this.creditCardType = creditCardType;
	}

	@JsonSerialize(using = CustomDateSerializer.class)
	public Date getCreditCardExpDate() {
		return creditCardExpDate;
	}
	
	@JsonDeserialize(using = CustomDateDeserializer.class)
	public void setCreditCardExpDate(Date creditCardExpDate) {
		this.creditCardExpDate = creditCardExpDate;
	}

	
}
