package Java_Sample_Contest;

import java.util.Scanner;

/**
 * Created by radko on 18.1.2015 г..
 */
public class Sand_Glass {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        for (int i = 0; i < n; i++) {
            if (i == 0 || i == n-1) {
                printAsterixes(0,n);
            } else if ((i <= n/2) && (i > 0)) {
                printAsterixes(i,(n-2*i));
            } else if ((i > n/2) && (i < n-1)) {
                printAsterixes((n-i-1),(n-2*(n-i-1)));
            }
        }
    }

    private static void printAsterixes(int i, int n) {
        StringBuilder output = new StringBuilder();
        for (int j = 0; j < i; j++) {
            output.append('.');
        }
        for (int j = 0; j < n; j++) {
            output.append('*');
        }
        for (int j = 0; j < i; j++) {
            output.append('.');
        }
        System.out.println(output);
    }
}
