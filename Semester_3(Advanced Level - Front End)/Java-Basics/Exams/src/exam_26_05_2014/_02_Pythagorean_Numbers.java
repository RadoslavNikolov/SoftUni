package exam_26_05_2014;

import java.util.Scanner;

/**
 * Created by isrmn on 19.1.2015 г..
 */
public class _02_Pythagorean_Numbers {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        int[] numbers = new int[n];
        int count = 0;
        for (int i = 0; i < n; i++) {
            numbers[i] = input.nextInt();
        }

        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                for (int k = 0; k < n; k++) {
                    int a = numbers[i];
                    int b = numbers[j];
                    int c = numbers[k];
                    if (a <= b) {
                        if (a*a + b*b == c*c) {
                            count++;
                            System.out.printf("%d*%d + %d*%d = %d*%d\n",a,a,b,b,c,c);
                        }
                    }
                }
            }
        }
        if (count == 0) {
            System.out.println("No");
        }
    }
}
