package _2014_09_21_Evening;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by toshiba on 25.1.2015 г..
 */
public class _04_Office_Staff {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        input.nextLine();
        TreeMap<String, LinkedHashMap<String,Integer>> officeList = new TreeMap<>();
        Pattern p = Pattern.compile("[^-\\s+|]+");
        for (int i = 0; i < n; i++) {
            List<String> tempList = new ArrayList<>();
            Matcher m = p.matcher(input.nextLine());
            while (m.find()) {
                tempList.add(m.group());
            }
            String company = tempList.get(0);
            String product = tempList.get(2);
            int amount = Integer.parseInt(tempList.get(1));

            if (!officeList.containsKey(company)) {
                officeList.put(company, new LinkedHashMap<String, Integer>());
                officeList.get(company).put(product,amount);
            } else {
                if (officeList.get(company).containsKey(product)) {
                    amount += officeList.get(company).get(product).intValue();
                }
                officeList.get(company).put(product,amount);
            }
        }

        for (String company : officeList.keySet()) {
            StringBuilder output = new StringBuilder();
            output.append(company).append(":");
            for (String product : officeList.get(company).keySet()) {
                int tempAmount = officeList.get(company).get(product).intValue();
                output.append(" ").append(product).append("-").append(tempAmount).append(",");
            }
            System.out.println(output.substring(0,output.length()-1));
        }
    }
}
