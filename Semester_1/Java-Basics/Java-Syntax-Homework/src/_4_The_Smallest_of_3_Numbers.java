import java.util.Arrays;
import java.util.Locale;
import java.util.Scanner;


public class _4_The_Smallest_of_3_Numbers {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in).useLocale(Locale.US);
		double[] numbers = new double[3];
		for (int i = 0; i < numbers.length; i++) {
			System.out.print("Enter number: ");
			numbers[i] = input.nextDouble();
		}
		Arrays.sort(numbers);
		System.out.println("Thread smallest number is: " + numbers[0]);
	}

}
