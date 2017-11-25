package dao;

import java.util.List;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;

import org.hibernate.Session;
import org.hibernate.SessionFactory;

import entities.Region;
import utils.HibernateUtil;

public class RegionDAO {
	
	SessionFactory sf = HibernateUtil.getSessionFactory();

	
	public List<Region> getRegions() {
		Session session = sf.openSession();
		
		
		CriteriaQuery<Region> cq = session.getCriteriaBuilder().createQuery(Region.class);
		cq.from(Region.class);
		List<Region> regions = session.createQuery(cq).getResultList();	
		
		
		session.close();		
		return regions;		
	}
	
	
	public List<Region> getRegionsByCountryId(int countryId) {
		Session session = sf.openSession();
		
		CriteriaBuilder cb = session.getCriteriaBuilder();
		CriteriaQuery<Region> cq = cb.createQuery(Region.class);		
		Root<Region> regionRoot = cq.from(Region.class);
		Predicate predicate = cb.equal(regionRoot.get("country"), countryId);
		cq.where(predicate);		
	    List<Region> regions = session.createQuery(cq).getResultList();
		
		session.close();		
		return regions;	
	}

}
