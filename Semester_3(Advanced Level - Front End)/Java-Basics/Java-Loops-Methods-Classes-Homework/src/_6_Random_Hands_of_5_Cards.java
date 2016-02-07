import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.Scanner;

/**
 * Created by isrmn on 4.12.2014 г..
 */
public class _6_Random_Hands_of_5_Cards {
    public static void main(String[] args) {
        /* This generate random cards without any repetition for all hands*/
        Random random = new Random();
        List<String> output = new ArrayList<>();
        Scanner input = new Scanner(System.in);
        int n = Integer.parseInt(input.next());
        String[] faces = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        char[] suits = {'\u2663', '\u2666', '\u2665', '\u2660'};

        while (output.size() < (n*5)) {
            int randomFaces = random.nextInt(faces.length);
            int randomSuits = random.nextInt(suits.length);
            StringBuilder str = new StringBuilder();
            str.append(faces[randomFaces] + suits[randomSuits]);
            if (!output.contains(str.toString())) {
                output.add(str.toString());
            }
        }

        for (int i = 0; i < n; i++) {
            StringBuilder str = new StringBuilder();
            for (int j = 0; j < 5; j++) {
                str.append(output.get(j + (i * 5)));
                str.append(" ");
            }

            System.out.println(str);
        }


    }
}
