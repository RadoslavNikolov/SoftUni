import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by isrmn on 10.12.2014 г..
 */
public class _07_Count_Substring_Occurrences {
    public static void main(String[] args) {
        System.out.print("Enter text: ");
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine().toLowerCase();
        System.out.print("Enter word to count: ");
        String patt = scanner.nextLine().toLowerCase();
        Pattern p = Pattern.compile(patt);
        Matcher m = p.matcher(input);
        int count = 0;

        while (m.find()) {
            count++;
            int firstIndex = m.start();
            m.region(firstIndex + 1, input.length());
        }

        System.out.println(count);
    }
}
