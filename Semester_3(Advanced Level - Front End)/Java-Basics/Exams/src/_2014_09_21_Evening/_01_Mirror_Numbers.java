package _2014_09_21_Evening;

import java.util.Scanner;

/**
 * Created by toshiba on 23.1.2015 г..
 */
public class _01_Mirror_Numbers {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        int n = Integer.parseInt(input.nextLine());
//        input.nextLine();
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++) {
            numbers[i] = input.nextInt();
        }
        int count = 0;
        for (int i = 0; i < numbers.length; i++) {
            for (int j = i; j < numbers.length; j++) {
                String num1 = Integer.toString(numbers[i]);
                String num2 = Integer.toString(numbers[j]);
                String tempStr = new StringBuilder(num2).reverse().toString();
                if ((i != j) && (num1.equals(tempStr))) {
                    count++;
                    StringBuilder output = new StringBuilder();
                    output.append(num1).append("<!>").append(num2);
                    System.out.println(output);
                }
            }
        }
        if (count == 0) {
            System.out.println("No");
        }
    }
}
