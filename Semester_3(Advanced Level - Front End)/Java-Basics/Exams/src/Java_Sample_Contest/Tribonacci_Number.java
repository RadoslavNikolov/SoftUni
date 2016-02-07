package Java_Sample_Contest;

import java.math.BigInteger;
import java.util.Scanner;

/**
 * Created by radko on 18.1.2015 г..
 */
public class Tribonacci_Number {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        BigInteger num1 = input.nextBigInteger();
        BigInteger num2 = input.nextBigInteger();
        BigInteger num3 = input.nextBigInteger();
        int n = input.nextInt();
        if (n == 1) {
            System.out.println(num1);
        } else if (n == 2) {
            System.out.println(num2);
        } else if (n == 3) {
            System.out.println(num3);
        } else {
            for (int i = 4; i <= n; i++) {
                BigInteger tribonacciNum = num1.add(num2);
                tribonacciNum = tribonacciNum.add(num3);
                num1 = num2;
                num2 = num3;
                num3 = tribonacciNum;
            }
            System.out.println(num3);
        }

    }
}
