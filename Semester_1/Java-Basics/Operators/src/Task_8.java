import java.util.Scanner;


public class Task_8 {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner inputScanner = new Scanner(System.in);
		System.out.print("Enter x: ");
		int x = Integer.parseInt(inputScanner.nextLine());
		System.out.print("Enter y: ");
		int y = Integer.parseInt(inputScanner.nextLine());
		
		boolean isInsideCircle = Math.sqrt(Math.pow(Math.abs(x),2) + Math.pow(Math.abs(y),2)) <= 5;
		System.out.println("The point is inside the circle: " + isInsideCircle);
	}
}
