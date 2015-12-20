package ww1;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;

public class FrontBookkeeper61764 implements IFrontBookkeeper {

	private List<Unit> allUntis;
	
	public FrontBookkeeper61764() {
		
		this.allUntis = new ArrayList<Unit>();
	}
	
	public List<Unit> getAllUnits() {
		
		return this.allUntis;
	}
	
	
	@Override
	public String updateFront(String[] news) {
	
		RenderNews(news);
		return null;
	}

	private void RenderNews(String[] news) {
		
		for(int i = 0; i < news.length; i++) {
			
			//news format 1
			if(news[i].contains("= [")) {
				AddUnits(news[i]);
			}
			//news format 3
			else if(news[i].contains("after soldier")) {
				AttachAfter(news[i]);
			}
			//news format 2
			else if(news[i].contains("attached to")) {
				AttachUnits(news[i]);
			}
			//news format 4
			else if(news[i].contains("died heroically")) {
			Remove(news[i]);
			}
			//news format 6  !!!
			else if(news[i].contains("show soldier")) {
				ShowSoldier(news[i]);
			}
			//news format 5 !!!
			else if(news[i].contains("show ")) {
				Show(news[i]);
			}
		}
		
		
	}
	
	// for news format 1
	private void AddUnits(String news) {
		
		String nameOfUnit = "";
		Integer iterator = 0;
		for(int i=0; i<news.length();i++) {
			
			if(news.charAt(i) == ' ') {
				iterator = i;
				break;
			}
			nameOfUnit += news.charAt(i);
		}
		
		Unit unit = new Unit();
		unit.setName(nameOfUnit);
		
		
		
		
		
		List<Integer> indexes = new ArrayList<Integer>();
		
		String strArr = news.substring(iterator+4,news.length()-1);
		
			
		String[] array = strArr.split("\\, ",-1); 
		
		
		
		if(strArr.length() > 0) {
			for(int j=0; j<array.length;j++) {
			
				indexes.add(Integer.parseInt(array[j]));
			}
		}
			
		unit.setIndexesOfSoldiers(indexes);
		
		this.allUntis.add(unit);
		
		
	}
	private Integer getUnitIndex(String name) {
		
		for(int i=0; i < this.allUntis.size(); i++) {
			
			if(this.allUntis.get(i).getName().toString().contentEquals(name)) {
				return i;
			}
		}
		
		return -1;
	}
	
	
	private void AttachUnits(String news) {
		//brigade1 attached to division1 # division1 == [1, 2, 3, 4, 5]
		
		String fromUnitName = "";
		String toUnitName = "";
		Integer iterator = 0;
		for(int i=0; i<news.length();i++) {
			
			if(news.charAt(i) == ' ') {
				iterator = i;
				break;
			}
			fromUnitName += news.charAt(i);
		}
		for(int i=iterator+13;i<news.length();i++) {
			toUnitName += news.charAt(i);
		}
		// up here just for parsing the news
		
	
		Unit toUnit = this.allUntis.get(getUnitIndex(toUnitName));
		Unit fromUnit = this.allUntis.get(getUnitIndex(fromUnitName));
		
		List<Integer> arrFromUnit = fromUnit.getIdexesOfSoldiers();
		
		// !!!!!!!!!
		if(fromUnit.attachedTo == null) 
		{
			
			for(int i=0; i < arrFromUnit.size(); i++) {
				
				toUnit.addIndexOfSoldier(arrFromUnit.get(i));
			}
			toUnit.setHasAttached(fromUnit);
			fromUnit.setAttachedTo(toUnit);
		}
		
		else {
			
			// Units can only be attached to at most one other unit.
			//Attempts to attach a unit a second time, should detach it from the previous one.
			
			Unit third = fromUnit.getAttachedTo();
			third.getIdexesOfSoldiers().removeAll(fromUnit.getIdexesOfSoldiers());
			third.hasAttached = null;
			fromUnit.attachedTo = null;
			
			toUnit.getIdexesOfSoldiers().addAll(fromUnit.getIdexesOfSoldiers());
			toUnit.setHasAttached(fromUnit);
			fromUnit.setAttachedTo(toUnit);
			
		}
		
		
	}

	private void AttachAfter(String news) {
		// brigade3 attached to division1 after soldier 2
		
		String fromUnitName = "";
		String toUnitName = "";
		
		Integer iterator = 0;
	    Integer afterIndex = news.indexOf("after");
	    Integer soldierIndex = news.indexOf("soldier");
	    
		Integer soldier = Integer.parseInt(news.substring(soldierIndex+8, news.length()));
		
		for(int i=0; i<news.length();i++) {
			
			if(news.charAt(i) == ' ') {
				iterator = i;
				break;
			}
			fromUnitName += news.charAt(i);
		}
		for(int i=iterator+13;i<afterIndex-1;i++) {
			toUnitName += news.charAt(i);
		}
		// up here just for parsing the news
		
		
		Unit toUnit = this.allUntis.get(getUnitIndex(toUnitName));
		Unit fromUnit = this.allUntis.get(getUnitIndex(fromUnitName));
		
		
		Integer indexOfSoldier = toUnit.getIdexesOfSoldiers().indexOf(soldier)+1;
		
		if(fromUnit.attachedTo == null) 
		{
			
			
			toUnit.getIdexesOfSoldiers().addAll(indexOfSoldier+1, fromUnit.indexesOfSoldiers);

			toUnit.setHasAttached(fromUnit);
			fromUnit.setAttachedTo(toUnit);
		
		}
		else {
			
			Unit third = fromUnit.getAttachedTo();
			third.getIdexesOfSoldiers().removeAll(fromUnit.getIdexesOfSoldiers());
			third.hasAttached = null;
			fromUnit.attachedTo = null;
			
			toUnit.getIdexesOfSoldiers().addAll(indexOfSoldier, fromUnit.getIdexesOfSoldiers());
			toUnit.setHasAttached(fromUnit);
			fromUnit.setAttachedTo(toUnit);
		}
		
	}
	
	private void Remove(String news) {
		// soldiers between 4 and 10 from division1 died heroically
		
		Integer from = 0;
		Integer to = 0;
	//	String unitName = "";
		
		Integer betweenIndex = news.indexOf("between");
		Integer andIndex = news.indexOf("and");
		Integer fromIndex = news.indexOf("from");
	//	Integer diedIndex = news.indexOf("died");
		
		from = Integer.parseInt(news.substring(betweenIndex+8, andIndex-1));
		to = Integer.parseInt(news.substring(andIndex+4,fromIndex-1));
		//unitName = news.substring(fromIndex+5,diedIndex-1);
		
		List<Integer> fromTo = new ArrayList<Integer>();
		for(int i=from; i<=to;i++) {
			fromTo.add(i);
		}
		

		for(int i=0; i < this.allUntis.size(); i++) {
			Unit curr = this.allUntis.get(i);
			curr.indexesOfSoldiers.removeAll(fromTo);
		}
		
		
		
	}
	
	private void Show(String news) {
		
		String unitName = "";
		for(int i = 5; i < news.length(); i++) {
			unitName += news.charAt(i);
		}
		
		
		
		Unit unit = this.allUntis.get(getUnitIndex(unitName));
				
		System.out.println(unit.indexesOfSoldiers);
		unitName = "";
	}

	private static String join(Collection<?> col, String delim) {
	    StringBuilder sb = new StringBuilder();
	    Iterator<?> iter = col.iterator();
	    if (iter.hasNext())
	        sb.append(iter.next().toString());
	    while (iter.hasNext()) {
	        sb.append(delim);
	        sb.append(iter.next().toString());
	    }
	    return sb.toString();
	}
	
	private void ShowSoldier(String news) {
		// show soldier 13
		
		Integer soldierIndex = news.indexOf("soldier");
		
		Integer soldier = Integer.parseInt(news.substring(soldierIndex+8,news.length()));
		
		List<String> all = new ArrayList<String>();
		
		for(int i=0; i < this.allUntis.size(); i++) {
			
			if(this.allUntis.get(i).getIdexesOfSoldiers().contains(soldier)) {
				all.add(this.allUntis.get(i).getName());
			}
		}
		
		String joined = join(all,", ");
		System.out.println(joined);
		
	}
}


