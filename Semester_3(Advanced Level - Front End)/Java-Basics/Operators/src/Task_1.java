import java.util.Scanner;


public class Task_1 {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner inputScanner = new Scanner(System.in);
		System.out.print("Enter integer number: ");
		int number = Integer.parseInt(inputScanner.nextLine());
		boolean isEven = (number % 2 == 0);
		if (isEven) {
			System.out.printf("The number %d is even. \n", number);
		}else {
			System.out.printf("The number %d is odd. \n", number);
		}
	}
}
