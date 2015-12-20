package ww1;

import java.util.ArrayList;
import java.util.List;

public class StartUp {

	public static void main(String[] args) {
		
	String[] news = {
			
			"regiment_Stoykov = [1, 2, 3]",
			"show regiment_Stoykov",
			"regiment_Chaushev = [13]",
			"show soldier 13",
			"division_Dimitroff = []",
			"regiment_Stoykov attached to division_Dimitroff",
			"regiment_Chaushev attached to division_Dimitroff",
			"show division_Dimitroff",
			"show soldier 13",
			"brigade_Ignatov = []",
			"regiment_Stoykov attached to brigade_Ignatov",
			"regiment_Chaushev attached to brigade_Ignatov after soldier 3",
			"show brigade_Ignatov",
			"show division_Dimitroff",
			"brigade_Ignatov attached to division_Dimitroff",
			"show division_Dimitroff",
			"soldiers between 2 and 3 from division_Dimitroff died heroically",
			"show regiment_Stoykov",
			"show brigade_Ignatov",
			"show division_Dimitroff",
		};
	
	String[] news1 = {
		"brigade1 = [1, 2, 3]",
		"brigade2 = [4, 5, 6]",
		"brigade3 = [7, 8, 9]",
		"brigade1 attached to brigade2 after soldier 4",
		"soldiers between 2 and 3 from brigade2 died heroically",		
		"show brigade1"
			
	};
	
	FrontBookkeeper61764 abv = new FrontBookkeeper61764();
	abv.updateFront(news);
	
	
	}
	
	
}
