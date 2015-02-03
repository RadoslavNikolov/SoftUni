package exam_26_05_2014;

import java.util.Scanner;

/**
 * Created by isrmn on 19.1.2015 г..
 */
public class _01_Video_Duration {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int sumMinutes = 0;
        while (true) {
            String line = input.nextLine().trim();
            if (line.equals("End")) {
                break;
            } else {
                String[] temp = line.split(":");
                int hours = Integer.parseInt(temp[0]);
                int min = Integer.parseInt(temp[1]);
                sumMinutes += (hours*60 + min);
            }
        }
        System.out.printf("%d:%02d",sumMinutes/60,sumMinutes%60);
    }
}
