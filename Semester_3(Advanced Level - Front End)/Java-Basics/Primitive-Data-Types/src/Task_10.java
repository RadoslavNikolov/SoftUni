import java.util.Scanner;


public class Task_10 {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner inputScanner = new Scanner(System.in);
		System.out.print("Enter a: ");
		int a = Integer.parseInt(inputScanner.nextLine());
		System.out.print("Enter b: ");
		int b = Integer.parseInt(inputScanner.nextLine());
		System.out.printf("a=%d ; b=%d \n\n",a,b);
		System.out.println("After reverse");		
		b=a+b;
		a=b-a;
		b=b-a;
		System.out.printf("a=%d ; b=%d",a,b);
	}

}
