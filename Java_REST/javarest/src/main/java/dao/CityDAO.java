package dao;

import java.util.List;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Root;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;

import entities.City;
import utils.HibernateUtil;

public class CityDAO {

	SessionFactory sf = HibernateUtil.getSessionFactory();

	
	public List<City> getCities() {
		Session session = sf.openSession();
		Transaction tr = session.beginTransaction();
		
		CriteriaQuery<City> cq = session.getCriteriaBuilder().createQuery(City.class);
		cq.from(City.class);
		List<City> cities = session.createQuery(cq).getResultList();	
		
		tr.commit();
		sf.close();
		
		return cities;		
	}
	

}
