import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by isrmn on 10.12.2014 г..
 */
public class _05_Count_All_Words_v1 {
    public static void main(String[] args) {
        Scanner scaner = new Scanner(System.in);
        Pattern p = Pattern.compile("[^\\W']+");
        int count = 0;
        String input = scaner.nextLine();
        Matcher m = p.matcher(input);
        while (m.find()) {
            count++;
        }

        System.out.println(count);
    }
}
