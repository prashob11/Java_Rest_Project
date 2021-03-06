package dao;

import java.util.List;

import javax.persistence.criteria.CriteriaBuilder;
import javax.persistence.criteria.CriteriaQuery;
import javax.persistence.criteria.Predicate;
import javax.persistence.criteria.Root;

import org.hibernate.Session;
import org.hibernate.SessionFactory;

import entities.City;
import utils.HibernateUtil;

public class CityDAO {

	SessionFactory sf = HibernateUtil.getSessionFactory();

	public List<City> getCities() {
		try (Session session = sf.openSession()) {

			CriteriaQuery<City> cq = session.getCriteriaBuilder().createQuery(City.class);
			cq.from(City.class);
			List<City> cities = session.createQuery(cq).getResultList();

			session.close();
			return cities;
		}
	}

	public List<City> getCitiesByRegionId(int regionId) {
		try (Session session = sf.openSession()) {

			CriteriaBuilder cb = session.getCriteriaBuilder();
			CriteriaQuery<City> cq = cb.createQuery(City.class);
			Root<City> cityRoot = cq.from(City.class);
			Predicate predicate = cb.equal(cityRoot.get("region"), regionId);
			cq.where(predicate);
			List<City> cities = session.createQuery(cq).getResultList();

			session.close();
			return cities;
		}
	}

	public List<City> getCity(int id) {
		try (Session session = sf.openSession()) {
			CriteriaBuilder cb = session.getCriteriaBuilder();
			CriteriaQuery<City> cq = cb.createQuery(City.class);
			Root<City> cityRoot = cq.from(City.class);
			Predicate predicate = cb.equal(cityRoot.get("cityId"), id);
			cq.where(predicate);
			List<City> city = session.createQuery(cq).getResultList();

			session.close();
			return city;
		}
	}
}
