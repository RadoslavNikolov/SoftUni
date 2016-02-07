package exam_27_05_2014;

import java.util.Locale;
import java.util.Scanner;


public class _01_Count_Beers {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in).useLocale(Locale.US);;
        int sumBeers = 0;

        while (true) {
            String line = input.nextLine().trim();
            if (line.equals("End")) {
                break;
            } else {
                String[] tempStr = line.split(" ");
                if (tempStr[1].equals("beers")) {
                    sumBeers += Integer.parseInt(tempStr[0]);
                }else {
                    sumBeers += (Integer.parseInt(tempStr[0])*20);
                }
            }
        }
        System.out.println(sumBeers/20 + " stacks + " + sumBeers%20 + " beers");
    }
}
