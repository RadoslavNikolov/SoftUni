import java.util.Scanner;


public class Task_7 {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner inputScanner = new Scanner(System.in);
		System.out.print("Enter your wieght: ");
		double weight = Double.parseDouble(inputScanner.nextLine());
		System.out.println("Your weight on the moon will be: " + (weight * 0.17));
	}
}
