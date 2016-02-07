package Java_Sample_Contest;

import java.util.Scanner;

/**
 * Created by radko on 18.1.2015 г..
 */
public class Magic_Car_Numbers {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int checkSum = input.nextInt();
        char[] letters = { 'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X' };
        int [] letterDig = {10,20,30,50,80,110,130,160,200,240};
        int sum = 0;
        StringBuilder output = new StringBuilder();
        int count = 0;

        for (int a = 0; a < 10; a++) {
            for (int b = 0; b < 10; b++) {
                for (int c = 0; c < 10; c++) {
                    for (int d = 0; d < 10; d++) {
                        if (
                            (a==b && a==c && a==d)||
                                    (b==c && b==d)||
                                    (a==b && a==c)||
                                    (a==b && c==d)||
                                    (a==c && b==d)||
                                    (a==d && b==c) ) {

                            for (int i = 0; i < 10; i++) {
                                for (int j = 0; j < 10; j++) {
                                    sum = 40 + a + b + c + d + letterDig[i] + letterDig[j];
                                    if (sum == checkSum) {
                                        count++;
                                        output.append("CA").append(a).append(b).append(c).append(d).append(letters[i]).append(letters[j]).append(", ");

                                    }
                                }
                            }
                        }

                    }
                }
            }
        }
        System.out.println(count);
//        System.out.println(output);
    }
}
