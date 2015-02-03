import java.util.Arrays;
import java.util.Locale;
import java.util.Scanner;

/**
 * Created by isrmn on 9.12.2014 г..
 */
public class _01_Sort_Array_of_Numbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in).useLocale(Locale.US);
        Scanner input = new Scanner(scanner.nextLine());
        int n = Integer.parseInt(input.next());
        int[] arr = new int[n];
        input = new Scanner(scanner.nextLine());
        scanner.useDelimiter(" ");
        for (int i = 0; i < n; i++) {
            arr[i]= Integer.parseInt(input.next());
        }
        Arrays.sort(arr);

        StringBuilder output = new StringBuilder();
        for (int item : arr) {
            output.append(item);
            output.append(" ");
        }
        System.out.println(output);
    }
}
