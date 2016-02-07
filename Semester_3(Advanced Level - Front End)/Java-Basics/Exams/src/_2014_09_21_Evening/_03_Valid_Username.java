package _2014_09_21_Evening;

import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by toshiba on 25.1.2015 г..
 */
public class _03_Valid_Username {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in).useLocale(Locale.US);
        Pattern p = Pattern.compile("[^\\\\/()\\s+]+");
        Matcher m = p.matcher(input.nextLine());
        List<String> splitedString = new ArrayList<>();
        int biggestSum = Integer.MIN_VALUE;
        String[] output = new String[2];
        while (m.find()) {
            splitedString.add(m.group());
        }

        List<String> validUsername = new ArrayList<>();
        for (String strItem : splitedString) {
            if (checkAccuracy(strItem) == true) {
                validUsername.add(strItem);
            }
        }

        for (int i = 0 , j = i+1; i < validUsername.size() - 1; i++,j++) {
            int sumWordsLenght = validUsername.get(i).length() + validUsername.get(j).length();
            if (sumWordsLenght > biggestSum) {
                biggestSum = sumWordsLenght;
                output[0] = validUsername.get(i);
                output[1] = validUsername.get(j);
            }
        }

        for (String str : output) {
            System.out.println(str);
        }
    }

    private static boolean checkAccuracy(String strItem) {
        boolean accuracy = false;
        char ch = Character.toLowerCase(strItem.charAt(0));
        if ((strItem.length() >= 3) && (strItem.length() <= 25))  {
            accuracy = true;
            if (ch >= 'a' && ch <= 'z') {
                accuracy = true;
                if (chechLetters(strItem)) {
                    accuracy = true;
                } else {
                    accuracy = false;
                }
            } else {
                accuracy = false;
            }
        } else {
            accuracy = false;
        }
        return accuracy;
    }

    private static boolean chechLetters(String strItem) {
        boolean accuracy = false;
        for (int i = 0; i < strItem.length(); i++) {
            char ch = Character.toLowerCase(strItem.charAt(i));
            if ( (ch >= 'a' && ch <= 'z') || (ch == '_') || (ch >= '0' && ch <= '9')) {
                accuracy = true;
            } else {
                accuracy = false;
            }
        }
        return accuracy;
    }
}
