package dao;

import java.util.List;
import java.util.Optional;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;

import org.hibernate.Session;
import org.hibernate.SessionFactory;

import com.mysql.cj.core.util.StringUtils;

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
	
	public List<Region> getRegion(int id) {
		Session session = sf.openSession();
		
		CriteriaBuilder cb = session.getCriteriaBuilder();
		CriteriaQuery<Region> cq = cb.createQuery(Region.class);		
		Root<Region> regionRoot = cq.from(Region.class);
		Predicate predicate = cb.equal(regionRoot.get("regionId"), id);
		cq.where(predicate);		
	    List<Region> region = session.createQuery(cq).getResultList();
		
		session.close();		
		return region;	
	}
	
	/**
	 * replaces C# GetRegions POST to get list of regions for given country
	 * 
	 * @param countryId
	 * @param regionId
	 * @return List<Region>
	 */
	public List<Region> getRegionsCascadingList(String countryId, String regionId) {
		int cId = Integer.parseInt(countryId);
		
		List<Region> regions = getRegionsByCountryId(cId);
		
        //if the region is already selected
        if (!StringUtils.isNullOrEmpty(regionId)) {
    		int rId = Integer.parseInt(regionId);
			Optional<Region> selectedRegion = regions.stream().
					filter(r -> r.getRegionId() == rId).
					findFirst();

            /* 
             * if region with given regionId is in the list 
             * then move it in the beginning of the list (for Edit page)
             */
            if (selectedRegion.isPresent())
            {
                Region region = selectedRegion.get();
                regions.remove(region);
                regions.add(0, region);
            }
        }		
		return regions;	
	}

}
