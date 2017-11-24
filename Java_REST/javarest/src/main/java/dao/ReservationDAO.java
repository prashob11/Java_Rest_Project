package dao;

import java.util.List;

import javax.persistence.criteria.CriteriaQuery;


import org.hibernate.Session;
import org.hibernate.SessionFactory;


import entities.Reservation;
import utils.HibernateUtil;

public class ReservationDAO {
	
	SessionFactory sf = HibernateUtil.getSessionFactory();

	
	public List<Reservation> getReservations() {
		Session session = sf.openSession();
		
		
		CriteriaQuery<Reservation> cq = session.getCriteriaBuilder().createQuery(Reservation.class);
		cq.from(Reservation.class);
		List<Reservation> reservations = session.createQuery(cq).getResultList();	
		
		
		session.close();		
		return reservations;		
	}
	

}
