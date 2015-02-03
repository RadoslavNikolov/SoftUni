import java.util.Scanner;


public class Task_3 {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner inputScanner = new Scanner(System.in);
		System.out.print("Enter integer number: ");
		int number = Integer.parseInt(inputScanner.nextLine());
		boolean isThirdDigitIs7 = ((number / 100) == 7);
		System.out.println("The third digit from right to left is 7: " + isThirdDigitIs7 + "!");
	}
}
