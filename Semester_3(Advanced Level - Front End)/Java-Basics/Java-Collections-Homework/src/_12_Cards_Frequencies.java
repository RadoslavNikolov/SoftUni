import java.util.*;

/**
 * Created by isrmn on 10.12.2014 г..
 */
public class _12_Cards_Frequencies {
    public static void main(String[] args) {
        Scanner scaner = new Scanner(System.in);
        String input = scaner.nextLine().toUpperCase();
        String[] arr = input.split("\\W+"); // or "[^\\w]+"
//        Arrays.sort(arr);
//        Map<String,Integer> words = new TreeMap<>();
//        int count = 0;
//        for (int i = 0; i < arr.length; i++) {
//            if (i < arr.length - 1) {
//                if (arr[i].equals(arr[i + 1])) {
//                    if (i == arr.length - 2) {
//                        count += 2;
//                    } else {
//                        count++;
//                    }
//                } else {
//                    count++;
//                    words.put(arr[i],count);
//                    count = 0;
//                }
//            }else {
//                if (arr.length <= 1) {
//                    count++;
//                }
//                words.put(arr[i],count);
//            }
//        }
        Map<String,Integer> cards = new LinkedHashMap<>();

        for (String item : arr) {
            Integer count = cards.get(item);
            cards.put(item, (count == null) ? 1 : count + 1);
        }

        for (Map.Entry<String, Integer> item : cards.entrySet()) {
            double percentage = (100.0 * item.getValue()) / (arr.length);
            System.out.printf("%s -> %.2f%%\n",item.getKey(),percentage);
        }
    }
}
