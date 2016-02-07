package _2014_06_01_Exam;


import java.util.Scanner;

public class _01_stuck_Numbers {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        int[] numArray = new int[n];

        for (int i = 0; i < n; i++) {
            numArray[i] = input.nextInt();
        }

        int count = 0;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                for (int k = 0; k < n; k++) {
                    for (int l = 0; l < n; l++) {
                        int a = numArray[i];
                        int b = numArray[j];
                        int c = numArray[k];
                        int d = numArray[l];

                        if (a != b && a != c && a != d &&
                                b != c && b != d && c != d) {
                            String str1 = "" + a + b;
                            String str2 = "" + c + d;
                            if (str1.equals(str2)) {
                                System.out.printf("%d|%d==%d|%d\n",a,b,c,d);
                                count++;
                            }
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
