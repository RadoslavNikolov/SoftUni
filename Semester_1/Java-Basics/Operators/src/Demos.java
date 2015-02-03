
public class Demos {

	public static void main(String[] args) {
		int z = 4 + 8;
		System.out.println(z);
		String firstName = "Radoslav";
		String lastName = "Nikolov";
		
		String fullName = firstName + " " + lastName;
		System.out.println(fullName);
		
		int squarePerimeter = 17;
		double squareSide = squarePerimeter / 4.0;
		double squareArea = squareSide * squareSide;
		System.out.println(squareSide);
		System.out.println(squareArea);
		
		int a = 5;
		int b = 4;
		System.out.println(a + b);
		System.out.println(a + b++);
		System.out.println(a + b);
		System.out.println(a + (++b));
		System.out.println(a + b);
		System.out.println(14 / a);
		System.out.println(14 % a);
	}

}
