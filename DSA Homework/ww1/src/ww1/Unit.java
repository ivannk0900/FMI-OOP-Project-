package ww1;

import java.util.ArrayList;
import java.util.List;

public class Unit {
	
	List<Integer> indexesOfSoldiers;
	String name;
	//Boolean attachedStatus = false;
	Unit attachedTo;
	Unit hasAttached;
	
	public Unit() {
		
		this.indexesOfSoldiers = new ArrayList<Integer>();
		this.attachedTo = null;
		this.hasAttached = null;
	}
	
	public String getName() {
		
		return this.name;
	}
	public void setName(String value) {
		
		this.name = value;
	}
	
	public List<Integer> getIdexesOfSoldiers() {
		
		return this.indexesOfSoldiers;
	}
	
	public void setIndexesOfSoldiers(List<Integer> value) {
		this.indexesOfSoldiers = value;
	} 
	
	public void addIndexOfSoldier(Integer num) {
		this.indexesOfSoldiers.add(num);
	}
	
/*	public Boolean getAttachedStatus() {
		return this.attachedStatus;
	}
	public void setAttachedStatus(Boolean value) {
		this.attachedStatus = value;
	}
	*/
	public Unit getAttachedTo() {
		return this.attachedTo;
	}
	public void setAttachedTo(Unit unit) {
		this.attachedTo = unit;
	}
	
	public Unit getHasAttached() {
		return this.hasAttached;
	}
	public void setHasAttached(Unit unit) {
		this.hasAttached = unit;
	}
	
}
