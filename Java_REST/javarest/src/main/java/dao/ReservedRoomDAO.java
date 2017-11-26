package dao;

import java.util.List;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;

import org.hibernate.Session;
import org.hibernate.SessionFactory;


import entities.City;
import entities.Region;
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
	
	public List<ReservedRoom> getRegionsByReservationId(int reservationId) {
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


}