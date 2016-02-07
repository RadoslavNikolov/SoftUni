
import org.apache.commons.lang3.StringUtils;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by isrmn on 11.12.2014 г..
 */
public class _09_Combine_List_of_Letters {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String str1 = scanner.nextLine();
        List<Character> list1 = new ArrayList<>();
        convertStringToList(str1, list1);
        String str2 = scanner.nextLine();
        List<Character> list2 = new ArrayList<>();
        convertStringToList(str2, list2);
        List<Character> list3 = new ArrayList<>();

        for (Character character : list1) {
            list3.add(character);
        }

        for (Character ch : list2) {
            if (!list1.contains(ch)) {
                list3.add(ch);
            }
        }

//        StringBuilder output = new StringBuilder();
//        for (Character character : list3) {
//            output.append(character);
//            output.append(" ");
//        }

        System.out.println(StringUtils.join(list3," "));
    }

    private static void convertStringToList(String str, List<Character> list) {
        for (char ch : str.toCharArray()) {
            if (ch != ' ') {
                list.add(ch);
            }
        }
    }
}
