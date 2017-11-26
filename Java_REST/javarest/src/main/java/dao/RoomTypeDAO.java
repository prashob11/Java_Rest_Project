package dao;

import java.util.List;
import javax.persistence.criteria.CriteriaQuery;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import entities.RoomType;
import utils.HibernateUtil;

public class RoomTypeDAO {

	SessionFactory sf = HibernateUtil.getSessionFactory();

	
	public List<RoomType> getRoomType() {
		Session session = sf.openSession();
		
		CriteriaQuery<RoomType> cq = session.getCriteriaBuilder().createQuery(RoomType.class);
		cq.from(RoomType.class);
		List<RoomType> RoomTypes = session.createQuery(cq).getResultList();	
		
		session.close();		
		return RoomTypes;		
	}

}