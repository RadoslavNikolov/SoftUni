import java.util.Locale;
import java.util.Scanner;


public class _1_Symmetric_Numbers_in_Range {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in).useLocale(Locale.US);
		System.out.print("Enter lower bound of the range: ");
		int start = input.nextInt();
		System.out.print("Enter upper bound of the range: ");
		int end = input.nextInt();
		input.nextLine();
		StringBuilder output = new StringBuilder();
		
		for (int i = start; i <= end; i++) {
			int temp = checkNumber(i);
			if (temp != 0) {
				output.append(temp).append(' '); 
			}
		}
		System.out.println(output);
	}

	private static int checkNumber(int num) {
		if (Integer.toString(num).equals(new StringBuilder(Integer.toString(num)).reverse().toString())) {
			return num;	
		}
		return 0;
	}

}
