import java.util.Scanner;


public class Task_4 {

	public static void main(String[] args) {
		boolean isMale;
		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		System.out.print("Enter \"f\" for female or \"m\" for male: ");				
		String inputStr = input.nextLine();
		System.out.println(inputStr);
		
		isMale = inputStr.equals("m");

		System.out.println("You are \"male\":" + isMale);
	}

}
