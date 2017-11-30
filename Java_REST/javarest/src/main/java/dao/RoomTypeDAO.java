package dao;

import java.util.List;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;

import org.hibernate.Session;
import org.hibernate.SessionFactory;

import entities.RoomType;
import utils.HibernateUtil;

public class RoomTypeDAO {

	SessionFactory sf = HibernateUtil.getSessionFactory();

	
	public List<RoomType> getRoomTypes() {
		Session session = sf.openSession();
		
		CriteriaQuery<RoomType> cq = session.getCriteriaBuilder().createQuery(RoomType.class);
		cq.from(RoomType.class);
		List<RoomType> RoomTypes = session.createQuery(cq).getResultList();	
		
		session.close();		
		return RoomTypes;		
	}

	public List<RoomType> getRoomType(int rtid) {
		Session session = sf.openSession();
		
		CriteriaBuilder cb = session.getCriteriaBuilder();
		CriteriaQuery<RoomType> cq = cb.createQuery(RoomType.class);		
		Root<RoomType> RoomTypeRoot = cq.from(RoomType.class);
		Predicate predicate = cb.equal(RoomTypeRoot.get("rtId"), rtid);
		cq.where(predicate);		
	    List<RoomType> RoomType = session.createQuery(cq).getResultList();
		
		session.close();		
		return RoomType;	
	}


}