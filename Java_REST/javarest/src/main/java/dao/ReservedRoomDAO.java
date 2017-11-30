package dao;

import java.io.Serializable;
import java.util.List;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;


import entities.ReservedRoom;
import utils.HibernateUtil;

public class ReservedRoomDAO {

	SessionFactory sf = HibernateUtil.getSessionFactory();

	
	public List<ReservedRoom> getReservedRooms() {
		Session session = sf.openSession();
		
		CriteriaQuery<ReservedRoom> cq = session.getCriteriaBuilder().createQuery(ReservedRoom.class);
		cq.from(ReservedRoom.class);
		List<ReservedRoom> ReservedRooms = session.createQuery(cq).getResultList();	
		
		session.close();		
		return ReservedRooms;		
	}
	
	public List<ReservedRoom> getReservedRoomsByReservationId(int reservationId) {
		Session session = sf.openSession();
		
		CriteriaBuilder cb = session.getCriteriaBuilder();
		CriteriaQuery<ReservedRoom> cq = cb.createQuery(ReservedRoom.class);		
		Root<ReservedRoom> reservedRoomRoot = cq.from(ReservedRoom.class);
		Predicate predicate = cb.equal(reservedRoomRoot.get("reservationId"), reservationId);
		cq.where(predicate);		
	    List<ReservedRoom> ReservedRooms = session.createQuery(cq).getResultList();
		
		session.close();		
		return ReservedRooms;	
	}
	
	public void deleteReservedRooms(int reservationId) {
		Session session = sf.openSession();
		Transaction trn = session.beginTransaction();

		List<ReservedRoom> rrl = getReservedRoomsByReservationId(reservationId);
		
		rrl.forEach(rr -> session.delete(rr));

		trn.commit();
		session.close();
		return;
	}
	
	public Serializable createReservedRoom(ReservedRoom rr) {
		Session session = sf.openSession();
		Transaction trn = session.beginTransaction();
	    
		Serializable id = session.save(rr);

		trn.commit();
	    session.close();
		return id;		
	}


}