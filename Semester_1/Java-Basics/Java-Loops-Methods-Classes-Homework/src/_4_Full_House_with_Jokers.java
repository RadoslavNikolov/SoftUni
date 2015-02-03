/**
 * Created by isrmn on 3.12.2014 г..
 */
public class _4_Full_House_with_Jokers {
    public static void main(String[] args) {
        String[] faces = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        char[] suits = {'\u2663', '\u2666', '\u2665', '\u2660'};
        int count = 0;
        for (int i = 0; i < faces.length; i++) {
            for (int j = 0; j < faces.length; j++) {
                if (i == j) {
                    continue;
                }
                for (int s1 = 0; s1 < suits.length; s1++) {
                    for (int s2 = s1 + 1; s2 < suits.length; s2++) {
                        for (int s3 = s2 + 1; s3 < suits.length; s3++) {
                            for (int s4 = 0; s4 < suits.length; s4++) {
                                for (int s5 = s4 + 1; s5 < suits.length; s5++) {

                                    //used just for debug
                                    StringBuilder temp = new StringBuilder();
                                    temp.append("(" + faces[i] + suits[s1] + " ");
                                    temp.append(faces[i] + suits[s2] + " ");
                                    temp.append(faces[i] + suits[s3] + " ");
                                    temp.append(faces[j] + suits[s4] + " ");
                                    temp.append(faces[j] + suits[s5] + ")");

                                    for (int k = 0; k < Math.pow(2,5) ; k++) {
                                        StringBuilder output = new StringBuilder();
                                        for (int t = 4; t >= 0 ; t--) {
                                            int mask = 1 << t;
                                            int mask1 = k & mask;
                                            int bit = mask1 >> t;
                                            switch (t+1){
                                                case 5:
                                                    if (bit == 0){
                                                        output.append("(" + faces[i] + suits[s1] + " ");
                                                    }else{
                                                        output.append("(* ");
                                                    }
                                                    break;
                                                case 4:
                                                    if (bit == 0){
                                                        output.append(faces[i] + suits[s2] + " ");
                                                    }else{
                                                        output.append("* ");
                                                    }
                                                    break;
                                                case 3:
                                                    if (bit == 0){
                                                        output.append(faces[i] + suits[s3] + " ");
                                                    }else{
                                                        output.append("* ");
                                                    }
                                                    break;
                                                case 2:
                                                    if (bit == 0){
                                                        output.append(faces[j] + suits[s4] + " ");
                                                    }else{
                                                        output.append("* ");
                                                    }
                                                    break;
                                                case 1:
                                                    if (bit == 0){
                                                        output.append(faces[j] + suits[s5] + ")");
                                                    }else{
                                                        output.append("*)");
                                                    }
                                                    break;
                                            }
                                        }
                                        System.out.printf("%s ... ", output);
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        System.out.printf("\n%d full houses",count);
    }
}
