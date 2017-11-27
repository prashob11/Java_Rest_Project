package dao;

import java.util.List;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;

import org.hibernate.Session;
import org.hibernate.SessionFactory;


import entities.CreditCard;
import utils.HibernateUtil;

public class CreditCardDAO {

	SessionFactory sf = HibernateUtil.getSessionFactory();

	
	public List<CreditCard> getCreditCardType() {
		Session session = sf.openSession();
		
		
		CriteriaQuery<CreditCard> cq = session.getCriteriaBuilder().createQuery(CreditCard.class);
		cq.from(CreditCard.class);
		List<CreditCard> CreditCardType = session.createQuery(cq).getResultList();	
		
		
		session.close();		
		return CreditCardType;		
	}
	
	
	public List<CreditCard> getCreditcard(int id) {
		Session session = sf.openSession();
		
		CriteriaBuilder cb = session.getCriteriaBuilder();
		CriteriaQuery<CreditCard> cq = cb.createQuery(CreditCard.class);		
		Root<CreditCard> CreditCardRoot = cq.from(CreditCard.class);
		Predicate predicate = cb.equal(CreditCardRoot.get("cctId"), id);
		cq.where(predicate);		
	    List<CreditCard>  CreditCardType = session.createQuery(cq).getResultList();
		
		session.close();		
		return CreditCardType;	
	}
	

}
