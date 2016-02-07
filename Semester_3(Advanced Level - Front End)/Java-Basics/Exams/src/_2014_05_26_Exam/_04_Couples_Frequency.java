package _2014_05_26_Exam;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _04_Couples_Frequency {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        List<Integer> numbers = new ArrayList<>();
        List<String> couples = new ArrayList<>();
        Pattern p = Pattern.compile("-?\\d+(\\.\\d+)?");
        Matcher m = p.matcher(input.nextLine());
        while (m.find()) {
            numbers.add(Integer.parseInt(m.group()));
        }

        for (int i = 0; i < numbers.size() - 1; i++) {
            StringBuilder couplesNumbers = new StringBuilder();
            couplesNumbers.append(numbers.get(i)).append(" ").append(numbers.get(i + 1));
            couples.add(String.valueOf(couplesNumbers));
        }
        Map<String, Integer> counters = new LinkedHashMap<>();

        int counter = 0;
        for (String item : couples) {
            if (!counters.containsKey(item)) {
                counters.put(item, 1);
            } else {
                counters.put(item, counters.get(item) + 1);
            }
            counter++;
        }

        for (Map.Entry<String, Integer> entry : counters.entrySet()) {
            String temp1 = entry.getKey();
            double temp2 = ((double) entry.getValue() / counter) * 100;
            System.out.printf("%s -> %.2f%% \n", temp1, temp2);
        }
//        Comparator<Map.Entry<String,Integer>> valueComparator = (e1, e2) ->e1.getValue().compareTo(e2.getValue());
//        Map<String,Integer> sortedMap = counters.entrySet().stream().sorted(valueComparator.reversed()).collect(Collectors.toMap(Map.Entry::getKey,Map.Entry::getValue,(e1, e2) -> e1, LinkedHashMap::new));
//        for (Map.Entry<String, Integer> entry : sortedMap.entrySet()) {
////            System.out.printf("%s -> %d \n",entry.getKey(),entry.getValue());
//            String temp1 = entry.getKey();
//            double temp2 = ((double)entry.getValue()/counter)*100;
//            System.out.printf("%s -> %.2f%s \n",temp1,temp2, "%");
//        }
    }
}
