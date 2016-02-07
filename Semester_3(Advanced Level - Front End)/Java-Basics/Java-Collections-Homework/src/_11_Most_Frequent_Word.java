import java.util.*;

/**
 * Created by isrmn on 10.12.2014 г..
 */
public class _11_Most_Frequent_Word {
    public static void main(String[] args) {
        Scanner scaner = new Scanner(System.in);
        String input = scaner.nextLine().toLowerCase();
        String[] arr = input.split("\\W+"); // or "[^\\w]+"
        Arrays.sort(arr);
        Map<String,Integer> words = new TreeMap<>();
        int count = 0;
        for (int i = 0; i < arr.length; i++) {
            if (i < arr.length - 1) {
                if (arr[i].equals(arr[i + 1])) {
                    if (i == arr.length - 2) {
                        count += 2;
                    } else {
                        count++;
                    }
                } else {
                    count++;
                    words.put(arr[i],count);
                    count = 0;
                }
            }else {
                if (arr.length <= 1) {
                    count++;
                }
                words.put(arr[i],count);
            }
        }

        int maxRepeat = Collections.max(words.values());

        for (Map.Entry<String, Integer> word : words.entrySet()) {
            if (word.getValue() == maxRepeat) {
                System.out.println(word.getKey() + " -> " + word.getValue() + " times");
            }
        }
    }
}
