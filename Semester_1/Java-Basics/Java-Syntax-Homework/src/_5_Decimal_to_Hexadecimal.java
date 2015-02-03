import java.util.Scanner;


public class _5_Decimal_to_Hexadecimal {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		System.out.print("Enter integer number: ");
		int num = input.nextInt();
		String hexNum = Integer.toHexString(num);
		System.out.printf("The number %d represented in Hex format is: %s", num, hexNum.toUpperCase());		
	}
}
