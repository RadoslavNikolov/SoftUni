
import java.text.ParseException;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.time.temporal.ChronoUnit;
import java.util.Scanner;


public class _7_Days_between_Two_Dates {

	public static void main(String[] args) throws ParseException {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		
		System.out.print("Enter date 1: ");
		String start =input.nextLine();
		System.out.print("Enter date 2: ");
		String end =input.nextLine();
		
		DateTimeFormatter df = DateTimeFormatter.ofPattern("d-M-yyyy");
		LocalDate date1 = LocalDate.parse(start, df);
		LocalDate date2 = LocalDate.parse(end, df);
		long diff = ChronoUnit.DAYS.between(date1, date2);
		System.out.println(diff);
	}

}
