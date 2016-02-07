package exam_03_09_2014;

        import java.util.Scanner;

/**
 * Created by isrmn on 16.1.2015 г..
 */
public class _02_Adding_Angles {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int qtyNumbers = Integer.parseInt(input.nextLine());
        int[] arrOfNumbers = new int[qtyNumbers];
        for (int i = 0; i < arrOfNumbers.length; i++) {
            arrOfNumbers[i] = input.nextInt();
        }
        int count=0;
        for (int i = 0; i < arrOfNumbers.length ; i++) {
            for (int j = i+1; j < arrOfNumbers.length; j++) {
                for (int k = j+1; k < arrOfNumbers.length ; k++) {
                    int a = arrOfNumbers[i];
                    int b = arrOfNumbers[j];
                    int c = arrOfNumbers[k];
                    int sum = a + b + c;
                    if (sum % 360 == 0) {
                        System.out.printf("%d + %d + %d = %d degrees\n",a,b,c,sum);
                        count++;
                    }
                }
            }
        }
        if (count == 0) {
            System.out.println("No");
        }
    }

}
