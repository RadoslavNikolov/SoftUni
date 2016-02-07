package exam_03_09_2014;

import java.util.Scanner;

/**
 * Created by isrmn on 16.1.2015 г..
 */
public class _1_Dozen_Eggs {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int sumEgs = 0;
        for (int i = 0; i < 7; i++) {
            String[] tempStr = input.nextLine().trim().toLowerCase().split(" ");
            if (tempStr[1].equals("eggs")) {
                sumEgs += Integer.parseInt(tempStr[0]);
            }else {
                sumEgs += (Integer.parseInt(tempStr[0])*12);
            }
        }
        System.out.println(sumEgs/12 + " dozens + " + sumEgs%12 + " eggs");

    }
    
}
