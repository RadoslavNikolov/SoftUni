import java.util.Scanner;


public class _2_Generate_3Letter_Words {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		System.out.println("Enter characters:");
		String str = input.nextLine();
		StringBuilder output = new StringBuilder();
		
		for (int i1 = 0; i1 < str.length(); i1++) {
			for (int i2 = 0; i2 < str.length(); i2++) {
				for (int i3 = 0; i3 < str.length(); i3++) {
					output.append(str.charAt(i1)).append(str.charAt(i2)).append(str.charAt(i3)).append(' ');
				}
			}
		}		
		System.out.println(output);
	}
}
