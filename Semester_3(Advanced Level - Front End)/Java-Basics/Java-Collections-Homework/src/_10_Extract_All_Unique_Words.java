import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;

/**
 * Created by isrmn on 10.12.2014 г..
 */
public class _10_Extract_All_Unique_Words {
    public static void main(String[] args) {
        Scanner scaner = new Scanner(System.in);
        String input = scaner.nextLine().toLowerCase();
        String[] arr = input.split("\\W+"); // or "[^\\w]+"
        List<String> outputArr = new ArrayList<>();
        for (String str : arr) {
            if (!outputArr.contains(str)) {
                outputArr.add(str);
            }
        }
        Collections.sort(outputArr);

        StringBuilder output = new StringBuilder();
        for (String item : outputArr) {
            output.append(item);
            output.append(" ");
        }

        System.out.println(output);
    }
}
