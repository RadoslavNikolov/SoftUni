import java.util.Scanner;


public class Task_2 {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner inputScanner = new Scanner(System.in);
		System.out.print("Enter integer number: ");
		int number = Integer.parseInt(inputScanner.nextLine());
		boolean isDivisibleBy5And7 = ((number % 5 == 0) && (number % 7 == 0));
		System.out.println("Number " + number + " is divisible by 5 and 7: " + isDivisibleBy5And7 + "!");		
	}
}
