package _2014_05_27_Exam;


import java.math.BigDecimal;
import java.util.*;

public class _02_Three_Largest_Numbers {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in).useLocale(Locale.US);;
        int n = input.nextInt();
        List<BigDecimal> numArray = new ArrayList<>();
        for (int i = 0; i < n; i++) {
            BigDecimal num = input.nextBigDecimal();
            numArray.add(num);
        }
        Collections.sort(numArray);
        Collections.reverse(numArray);

        int count =0;
        while (true) {
            System.out.println(numArray.get(count).toPlainString());
            count++;
            if (count == 3) {
                break;
            }
            if (count == numArray.size()) {
                break;
            }
        }
    }
}
