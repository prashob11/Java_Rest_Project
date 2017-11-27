package entities;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "Rooms")
public class Room implements Serializable {

	private static final long serialVersionUID = 6060459868763708186L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)

	@Column(name = "roomId")
	private int roomId;
	
	@Column(name = "type")
	private int type;

	@Column(name = "roomNumber")
	private String roomNumber;


	public int getRoomId() {
		return roomId;
	}

	public void setRoomId(int roomId) {
		this.roomId = roomId;
	}

	public int getType() {
		return type;
	}

	public void setType(int type) {
		this.type = type;
	}

	public String getRoomNumber() {
		return roomNumber;
	}

	public void setRoomNumber(String roomNumber) {
		this.roomNumber = roomNumber;
	}


}
