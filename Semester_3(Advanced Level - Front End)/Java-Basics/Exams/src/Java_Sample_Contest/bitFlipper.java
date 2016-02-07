package _2014_05_26_Exam;

import java.math.BigInteger;
import java.util.Scanner;


public class bitFlipper {

    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        BigInteger number = new BigInteger(input.next());
        String binary = number.toString(2);

        while (binary.length() < 64) {
            binary = "0" + binary;
        }

        binary = binary.replaceAll("0{3}", "*").replaceAll("1{3}", "000").replaceAll("\\*", "111");
        BigInteger output = new BigInteger(binary, 2);
        System.out.println(output);
    }
}
