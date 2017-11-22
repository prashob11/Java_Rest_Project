package dao;

import java.util.List;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;

import org.hibernate.Session;
import org.hibernate.SessionFactory;


import entities.Country;
import utils.HibernateUtil;

public class CountryDAO {

	SessionFactory sf = HibernateUtil.getSessionFactory();

	
	public List<Country> getCountries() {
		Session session = sf.openSession();
		
		
		CriteriaQuery<Country> cq = session.getCriteriaBuilder().createQuery(Country.class);
		cq.from(Country.class);
		List<Country> countries = session.createQuery(cq).getResultList();	
		
		
		session.close();		
		return countries;		
	}
	
	
	public List<Country> getCountry(int id) {
		Session session = sf.openSession();
		
		CriteriaBuilder cb = session.getCriteriaBuilder();
		CriteriaQuery<Country> cq = cb.createQuery(Country.class);		
		Root<Country> countryRoot = cq.from(Country.class);
		Predicate predicate = cb.equal(countryRoot.get("countryId"), id);
		cq.where(predicate);		
	    List<Country> country = session.createQuery(cq).getResultList();
		
		session.close();		
		return country;	
	}
	

}
