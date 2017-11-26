package entities;
import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name = "CreditCardType")
public class CreditCard implements Serializable {

	private static final long serialVersionUID = -5612638336715962491L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name = "cctId")
	private int cctId;

	@Column(name = "type")
	private String type;

	@Column(name = "cardNumberPattern")
	private String cardNumberPattern;
	

	public int getcctId() {
		return cctId;
	}

	public void setcctId(int cctId) {
		this.cctId = cctId;
	}

	public String gettype() {
		return type;
	}

	public void settype(String type) {
		this.type = type;
	}

	public String getcardNumberPattern() {
		return cardNumberPattern;
	}

	public void setcardNumberPattern(String cardNumberPattern) {
		this.cardNumberPattern = cardNumberPattern;
	}

}

