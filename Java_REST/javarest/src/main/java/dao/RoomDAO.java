package dao;

import java.util.List;
import javax.persistence.criteria.CriteriaQuery;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import entities.Room;
import utils.HibernateUtil;

public class RoomDAO {

	SessionFactory sf = HibernateUtil.getSessionFactory();

	public List<Room> getRooms() {
		try (Session session = sf.openSession()) {

			CriteriaQuery<Room> cq = session.getCriteriaBuilder().createQuery(Room.class);
			cq.from(Room.class);
			List<Room> Rooms = session.createQuery(cq).getResultList();

			session.close();
			return Rooms;
		}
	}

}