import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.util.Date;


public class _5_Current_Date_Time {

	public static void main(String[] args) {
		Date now = new Date();
		System.out.println(now);
		LocalDateTime now1 = LocalDateTime.now();
		System.out.println(now1);
		LocalTime time = LocalTime.now();
		System.out.println(time);
		LocalDate date = LocalDate.now();
		System.out.println(date);
		date = date.plusDays(1);
		System.out.println(date);
	}

}
