import java.util.Locale;
import java.util.Scanner;


public class _10_Paint_a_House_as_SVG {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in).useLocale(Locale.US);
		System.out.print("Enter number of points: ");
		int n = input.nextInt();
		input.nextLine();
		Point1[] points = new Point1[n];
		for (int i = 0; i < n; i++) {
			points[i] = new Point1();
			System.out.printf("Enter X coord for the %d point: ",i);
			points[i].x = input.nextDouble();
			System.out.printf("Enter Y coord for the %d point: ",i);
			points[i].y = input.nextDouble();
			input.nextLine();
		}
	}
	
//	public void paintComponent(Graphics g) {
//		super.
//		this.setBackgroung();
//	}
}

