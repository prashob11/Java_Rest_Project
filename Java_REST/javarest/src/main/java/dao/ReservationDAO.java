package dao;

import java.io.Serializable;
import java.util.List;

import javax.persistence.criteria.CriteriaQuery;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;

import utils.HibernateUtil;
import entities.Reservation;



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

	public Reservation getReservation(int id) {
		Session session = sf.openSession();

		Serializable reservationId = new Integer(id);
		
		Reservation r = session.get(Reservation.class, reservationId);
		if (r == null) {
			// not found, nothing to delete
		    session.close();
			return null;
		}
		

	    session.close();
		return r;	
	}

	public boolean deleteReservation(int id) {
		Session session = sf.openSession();
		Transaction trn = session.beginTransaction();
	    
		Serializable reservationId = new Integer(id);
		
		Reservation r = session.get(Reservation.class, reservationId);
		if (r == null) {
			// not found, nothing to delete
			trn.rollback();
		    session.close();
			return false;
		}
		
	    session.delete(r);
		trn.commit();
	    session.close();
		return true;	
	}


	public Serializable createReservation(Reservation r) {
		Session session = sf.openSession();
		Transaction trn = session.beginTransaction();
	    
		Serializable id = session.save(r);

		trn.commit();
	    session.close();
		return id;		
	}
	
	

}
