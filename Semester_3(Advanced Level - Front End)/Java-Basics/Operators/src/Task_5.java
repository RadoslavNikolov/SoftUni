import java.util.Scanner;


public class Task_5 {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner inputScanner = new Scanner(System.in);
		System.out.print("Enter side of rectangle: ");
		int sideOfRectangle = Integer.parseInt(inputScanner.nextLine());
		System.out.print("Enter height of rectangle: ");
		int heightOfRectangle = Integer.parseInt(inputScanner.nextLine());
		
		int perimeter = 2 * sideOfRectangle + 2 * heightOfRectangle;
		int area = sideOfRectangle * heightOfRectangle;
		System.out.println("The perimeter of the rectangle is: " + perimeter);
		System.out.println("The area of the rectangle is: " + area);
	}

}
