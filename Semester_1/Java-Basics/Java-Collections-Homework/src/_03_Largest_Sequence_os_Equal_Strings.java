import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by isrmn on 9.12.2014 г..
 */
public class _03_Largest_Sequence_os_Equal_Strings {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine().trim();
        String[] arr = input.split(" ");
        List<String> outputArr = new ArrayList<>();
        String previousElement;
        String tempStr = arr[0];
        outputArr.add(tempStr);

        for (int i = 0; i < arr.length - 1; i++) {
            previousElement = arr[i];
            if (previousElement.equals(arr[i+1])){
                tempStr = tempStr + " " + arr[i+1];
                if (i == arr.length - 2) {
                    tempStr.trim();
                    if (tempStr.length() > outputArr.get(0).length()) {
                        outputArr.clear();
                        outputArr.add(tempStr);
                    }
                }
            }else {
                tempStr.trim();
                if (tempStr.length() > outputArr.get(0).length()) {
                    outputArr.clear();
                    outputArr.add(tempStr);
                }
                tempStr = arr[i+1];
            }
        }
        for (String s : outputArr) {
            System.out.println(s);
        }
    }
}
