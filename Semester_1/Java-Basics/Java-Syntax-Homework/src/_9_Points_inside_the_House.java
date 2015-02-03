import java.util.Locale;
import java.util.Scanner;


public class _9_Points_inside_the_House {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in).useLocale(Locale.US);
		System.out.print("Enter number of points to check: ");
		int n = input.nextInt();
		input.nextLine();
		Point1[] points = new Point1[n];
		boolean check;
		
		for (int i = 0; i < n; i++) {
			points[i] = new Point1();
			System.out.printf("Enter X coord for the %d point: ",i);
			points[i].x = input.nextDouble();
			System.out.printf("Enter Y coord for the %d point: ",i);
			points[i].y = input.nextDouble();
			input.nextLine();
			check = checkPoint(points[i]);
			if (check) {
				System.out.println("Inside");
			}else {
				System.out.println("Outside");
			}			
		}
	}

	private static boolean checkPoint(Point1 point) {
		boolean check;
		check = checkPointInsideTriangle(point) ||
				((point.x >= 12.5 && point.x <= 17.5) && (point.y >= 8.5 && point.y <= 13.5))||
				((point.x >= 20.0 && point.x <= 22.5) && (point.y >= 8.5 && point.y <= 13.5));		
		return check;
	}

	private static boolean checkPointInsideTriangle(Point1 point) {
		boolean check;
		check = (point.x * (8.5 - 8.5) + point.y * (22.5 - 12.5) + (12.5*8.5 - 22.5*8.5)) <= 0 &&
				(point.x * (8.5 - 3.5) + point.y * (17.5 - 22.5) + (22.5*3.5 - 17.5*8.5)) <= 0 &&
				(point.x * (3.5 - 8.5) + point.y * (12.5 - 17.5) + (17.5*8.5 - 12.5*3.5)) <= 0;
		return check;
	}
}
