
public class Demos {

	public static void main(String[] args) {
		// Declare some variables
		byte centuries = 20;
		short years = 2000;
		int days = 730480;
		long hours = 17531520;
		
		//print the result on the console
		System.out.println(centuries + " centuries is " + years + " years, or "
				+ days + " days, or " + hours + " hours.");
		
		//declare some variables nad print them
		float floatPI = 3.141592653589793238f;
		double doublePI = 3.141592653589793238f;
		System.out.println("Float PI is: " + floatPI);
		System.out.println("Double PI is: " + doublePI);
		
		float sum = 0.1f + 0.1f + 0.1f + 0.1f + 0.1f + 0.1f + 0.1f + 0.1f + 0.1f + 0.1f;
		float num = 1.0f;
		boolean equal = (sum == num);
		System.out.println("num = " + num + " sum = " + sum + " equal = " + equal);
		
		//boolean type
		int a = 1;
		int b = 2;
		boolean greaterAB = (a > b);
		boolean isEqualA1 = (a == 1);
		if (greaterAB) {
			System.out.println("A > B");
		}else {
			System.out.println("A <= B");
		}
		System.out.println("greaterAB = " + greaterAB);
		System.out.println("equalA1 = " + isEqualA1);
		System.out.println((a > b) ? "A > B" : "A <= B");
		
		//char type
		char symbol = 'a';
		System.out.println("The code of '" + symbol + "' is: " + (int)symbol);
		symbol = 'b';
		System.out.println("The code of '" + symbol + "' is: " + (int)symbol);
		symbol = 'c';
		System.out.println("The code of '" + symbol + "' is: " + (int)symbol);
		
		//String type
		String firstNameString = "Radoslav";
		String secondName = "Marinov";
		String fullName = firstNameString + " " + secondName;
		System.out.printf("Hello, %s! \n", firstNameString);
		System.out.printf("Your full name is %s. \n",fullName);
		
		//Object type
		Object container = 5;
		Object container2 = "Five";
		System.out.println("The value of container is: " + container);
		System.out.println("The value of container2 is: " + container2);
	}

}
