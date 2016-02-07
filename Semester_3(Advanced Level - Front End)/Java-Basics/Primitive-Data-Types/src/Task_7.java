import java.util.Scanner;

import org.apache.commons.lang3.StringUtils;




public class Task_7 {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner inputScanner = new Scanner(System.in);
		System.out.print("Enter n: ");
		int n = Integer.parseInt(inputScanner.nextLine());
		System.out.println(n);
		
		for (int i = 0; i < n; i++) {
			if (i == 0) {
				String output = StringUtils.repeat('.', (2*n - 1)/2) + "*" + StringUtils.repeat('.', (2*n - 1)/2);
				System.out.println(output);
			}
			else if (i == n-1) {
				String output = StringUtils.repeat('*', 2*n-1);
				System.out.println(output);
			}
			else {
				String output = StringUtils.repeat('.', (2*n - 2 - (i*2-1))/2) + "*" + StringUtils.repeat('.', i*2-1) + "*" + StringUtils.repeat('.', (2*n - 2 - (i*2-1))/2);
				System.out.println(output);
			}
		}

	}

}
