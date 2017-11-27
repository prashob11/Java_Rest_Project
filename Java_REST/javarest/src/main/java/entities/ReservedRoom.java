package entities;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "ReservedRooms")
public class ReservedRoom implements Serializable{

	private static final long serialVersionUID = 6243726072784145477L;
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "rrId")
	private int rrId;

	@Column(name = "reservationId")
	private int reservationId;
	
	@Column(name = "roomId")
	private int roomId;
	
	public int getrrId() {
		return rrId;
	}

	public void setrrId(int rrId) {
		this.rrId = rrId;
	}

	public int getreservationId() {
		return reservationId;
	}

	public void setreservationId(int reservationId) {
		this.reservationId = reservationId;
	}

	public int getroomId() {
		return roomId;
	}

	public void roomId(int roomId) {
		this.roomId = roomId;
	}

	
}
