import java.util.Scanner;


public class Task_6 {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner inputScanner = new Scanner(System.in);
		System.out.print("Enter the first basis of the trapezoid: ");
		int firstBasis = Integer.parseInt(inputScanner.nextLine());
		System.out.print("Enter the second basis of the trapezoid: ");
		int secondBasis = Integer.parseInt(inputScanner.nextLine());
		System.out.print("Enter the height  of the trapezoid: ");
		int heightofTrapezoid = Integer.parseInt(inputScanner.nextLine());
		
		double areaOftrapezoid = ((firstBasis + secondBasis) / 2.0) * heightofTrapezoid;
		System.out.println("The area of the trapezoid is: " + areaOftrapezoid);
	}
}
