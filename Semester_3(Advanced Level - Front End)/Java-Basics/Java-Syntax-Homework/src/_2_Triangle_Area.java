import java.util.Scanner;


public class _2_Triangle_Area {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		Point[] points = new Point[3];
		for (int i = 0; i < 3; i++) {
			points[i] = new Point();
			System.out.printf("Enter X coord for the %d point: ",i);
			points[i].x = input.nextInt();
			System.out.printf("Enter Y coord for the %d point: ",i);
			points[i].y = input.nextInt();
			input.nextLine();						
		}
		double area = 0.0;
		area = Math.abs((points[0].x*(points[1].y-points[2].y) + points[1].x*(points[2].y-points[0].y) + points[2].x*(points[0].y-points[1].y))/2.0);
		System.out.println("The area of the triangle is: " + area);
	}
	
}

class Point{
	int x;
	int y;
}
