package entities;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "RoomType")
public class RoomType implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -5589984072843750735L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)

	@Column(name = "rtId")
	private int rtId;
	
	@Column(name = "maxGuests")
	private int maxGuests;

	@Column(name = "roomType")
	private String roomType;

	public int getRtId() {
		return rtId;
	}

	public void setRtId(int rtId) {
		this.rtId = rtId;
	}

	public int getMaxGuests() {
		return maxGuests;
	}

	public void setMaxGuests(int maxGuests) {
		this.maxGuests = maxGuests;
	}

	public String getRoomType() {
		return roomType;
	}

	public void setRoomType(String roomType) {
		this.roomType = roomType;
	}


}

