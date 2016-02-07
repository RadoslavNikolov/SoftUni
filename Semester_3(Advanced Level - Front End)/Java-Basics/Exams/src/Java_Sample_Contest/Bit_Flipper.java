package Java_Sample_Contest;

import org.apache.commons.lang3.StringUtils;

import java.math.BigInteger;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class Bit_Flipper {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        BigInteger number = input.nextBigInteger();
        String line = number.toString(2);
        line = StringUtils.leftPad(line,64,"0");

        //another way to padLeft

//        while (line.length() < 65) {
//            line = "0" + line;
//        }

        String pattern = "111";
        Pattern p = Pattern.compile(pattern);
        Matcher m = p.matcher(line);
        line = m.replaceAll("222");
        pattern = "000";
        p = Pattern.compile(pattern);
        m = p.matcher(line);
        line = m.replaceAll("333");
        pattern = "222";
        p = Pattern.compile(pattern);
        m = p.matcher(line);
        line = m.replaceAll("000");
        pattern = "333";
        p = Pattern.compile(pattern);
        m = p.matcher(line);
        line = m.replaceAll("111");

        System.out.println(new BigInteger(line,2));
    }
}
