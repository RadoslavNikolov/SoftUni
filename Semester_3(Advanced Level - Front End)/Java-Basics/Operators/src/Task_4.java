import java.util.Scanner;


public class Task_4 {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner inputScanner = new Scanner(System.in);
		System.out.print("Enter integer number: ");
		int number = Integer.parseInt(inputScanner.nextLine());
		
		int thirdBit = (number >> 3) & 1;
		System.out.println("The third bit of the number " + number + " is: " + thirdBit);
	}
}
