import java.util.Scanner;

/**
 * Created by isrmn on 10.12.2014 г..
 */
public class _06_Count_Specified_Word {
    public static void main(String[] args) {
        System.out.print("Enter text: ");
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine().toLowerCase();
        System.out.print("Enter word to count: ");
        String patt = scanner.nextLine().toLowerCase();
        String[] arr = input.split("\\W+");
        int count = 0;
        for (String s : arr) {
            if (s.equals(patt)) {
                count++;
            }
        }

        System.out.println(count);
    }
}
