package dao;

import java.util.List;

import javax.persistence.criteria.CriteriaQuery;

import org.hibernate.Session;
import org.hibernate.SessionFactory;


import entities.City;
import utils.HibernateUtil;

public class CityDAO {

	SessionFactory sf = HibernateUtil.getSessionFactory();

	
	public List<City> getCities() {
		Session session = sf.openSession();
		
		CriteriaQuery<City> cq = session.getCriteriaBuilder().createQuery(City.class);
		cq.from(City.class);
		List<City> cities = session.createQuery(cq).getResultList();	
		
		session.close();		
		return cities;		
	}
	

}
