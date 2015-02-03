import java.util.Scanner;


public class _6_Sum_Two_Numbers {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner scan = new Scanner(System.in);
		System.out.print("Enter integer number a:");
		int a = scan.nextInt();
		System.out.print("Enter integer number b:");
		int b = scan.nextInt();
		int result = sumNumbers(a,b);
		System.out.println(result);
	}

	private static int sumNumbers(int a, int b) {
		int sum = a + b;
		return sum;
	}
}
