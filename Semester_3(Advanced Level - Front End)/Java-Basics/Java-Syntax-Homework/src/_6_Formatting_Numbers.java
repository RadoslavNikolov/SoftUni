import java.util.Locale;
import java.util.Scanner;


public class _6_Formatting_Numbers {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in).useLocale(Locale.US);
		System.out.print("Enter integer number a: ");
		int a = input.nextInt();
		System.out.print("Enter real number b: ");
		double b = input.nextDouble();
		System.out.print("Enter real number c: ");
		double c = input.nextDouble();
		System.out.printf("|%-10s|%s|%10.2f|%-10.3f|", Integer.toHexString(a).toUpperCase(), 
				String.format("%10s", Integer.toBinaryString(a)).replace(' ', '0'), b, c);
	}

}
