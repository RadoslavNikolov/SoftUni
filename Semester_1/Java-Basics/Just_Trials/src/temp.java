import java.util.Scanner;

/**
 * Created by isrmn on 28.1.2015 г..
 */
public class temp {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        byte number = Byte.parseByte(input.nextLine());
        byte rotations = Byte.parseByte(input.nextLine());

        for (int i = 0; i < rotations; i++) {
            String direction = input.nextLine();
            //this is illegal comparison ot strings  ".equals" instead of "=="
            if (direction.equals("right")) {
                int rightMostBit = number & 1;
                number >>= 1;
                //number of shifts is wrong "5" instead of "6".The index count begin from "0"
                number |= rightMostBit << 5;
                //this is illegal comparison of strings  ".equals" instead of "=="
            } else if (direction.equals("left")) {
                //number of shifts is wrong "5" instead of "6".The index count begin from "0"
                int leftMostBit = (number >> 5) & 1;
                number <<= 1;
                //make bits 6 and 7 "0" because the number is represented as a 6 bits number
                number &= ~(3 << 6);
                number |= leftMostBit;
            }
        }

        System.out.println(number);
    }
}
