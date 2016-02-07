package _2014_09_03_Exam;

import com.sun.org.apache.xerces.internal.impl.xpath.regex.Match;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by radko on 16.1.2015 г..
 */
public class _3_Biggest3PrimeNumbers {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        List<Integer> integerList = new ArrayList<>();
        List<Integer> output = new ArrayList<>();
        String line = input.nextLine();
        String pattern = "-?\\d*\\.{0,1}\\d+";
        Pattern p = Pattern.compile(pattern);

        Matcher m = p.matcher(line);
        while (m.find()) {
            integerList.add(Integer.parseInt(m.group()));
        }
        for (Integer num  : integerList) {
            boolean prime = isPrime(num);
            if (prime == true && !(output.contains(num))) {
                output.add(num);
            }
        }
        Collections.sort(output);
        Collections.reverse(output);
        if (output.size()>=3) {
            int sum = output.get(0) + output.get(1) + output.get(2);
            System.out.println(sum);
        }else {
            System.out.println("No");
        }
    }

    private static boolean isPrime(Integer num) {
        int to = (int)Math.sqrt(num);
        boolean prime = true;
        for (int i = 2; i <= to; i++) {
            if (num % i == 0) {
                prime = false;
                break;
            }
        }
        return num > 1 && prime;
    }
}
