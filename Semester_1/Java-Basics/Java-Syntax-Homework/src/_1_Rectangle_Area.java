import java.util.Scanner;


public class _1_Rectangle_Area {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		System.out.print("Enter a: ");
		int a = input.nextInt();
		System.out.print("Enter b: ");
		int b = input.nextInt();
		System.out.println("The Area of the rectangle is: " + (a*b));
	}
}