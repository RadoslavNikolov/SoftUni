import java.util.Scanner;

/**
 * Created by isrmn on 9.12.2014 г..
 */
public class _02_Sequences_of_Equal_Strings {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine().trim();
        String[] arr = input.split(" ");
        String previousElement;
        for (int i = 0; i < arr.length; i++) {
            previousElement = arr[i];
            if (i < arr.length - 1) {
                if (previousElement.equals(arr[i+1])){
                    System.out.print(previousElement + " ");
                }else {
                    System.out.println(previousElement);
                }
            }else {
                System.out.println(previousElement);
            }
        }
    }
}
