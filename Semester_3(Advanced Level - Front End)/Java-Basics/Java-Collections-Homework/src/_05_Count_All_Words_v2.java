import java.util.Scanner;

/**
 * Created by isrmn on 10.12.2014 г..
 */
public class _05_Count_All_Words_v2 {
    public static void main(String[] args) {
        Scanner scaner = new Scanner(System.in);
        String input = scaner.nextLine();
        String[] arr = input.split("\\W+"); // or "[^\\w]+"
        int count = arr.length;
        System.out.println(count);
    }
}
