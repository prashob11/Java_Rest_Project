package dao;

import java.util.List;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Root;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;

import entities.Country;
import utils.HibernateUtil;

public class CountryDAO {

	SessionFactory sf = HibernateUtil.getSessionFactory();

	
	public List<Country> getCountries() {
		Session session = sf.openSession();
		Transaction tr = session.beginTransaction();
		
		CriteriaQuery<Country> cq = session.getCriteriaBuilder().createQuery(Country.class);
		cq.from(Country.class);
		List<Country> countries = session.createQuery(cq).getResultList();	
		
		tr.commit();
		sf.close();
		
		return countries;		
	}
	

}
