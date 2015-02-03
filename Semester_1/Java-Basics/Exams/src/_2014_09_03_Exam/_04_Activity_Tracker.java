package _2014_09_03_Exam;


import java.util.Scanner;
import java.util.TreeMap;

public class _04_Activity_Tracker {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        int n = input.nextInt();
        input.nextLine();
        TreeMap<Integer,TreeMap<String,Double>> tracker = new TreeMap<>();
        for (int i = 0; i < n; i++) {
            String line = input.nextLine();
            String[] tempStr = line.split("[ /]");

            int month = Integer.parseInt(tempStr[1]);
            String user = tempStr[3];
            Double distance = Double.parseDouble(tempStr[4]);

            if (!tracker.containsKey(month)) {
                tracker.put(month,new TreeMap<String, Double>());
                tracker.get(month).put(user,distance);
            } else {
                if (tracker.get(month).containsKey(user))  {
                    distance += tracker.get(month).get(user).doubleValue();
                }
                tracker.get(month).put(user, distance);
            }
        }

        for (Integer month : tracker.keySet()) {
            StringBuilder output = new StringBuilder();
            output.append(month).append(":");
            for (String name : tracker.get(month).keySet()) {
                int distance = (int)tracker.get(month).get(name).doubleValue();
                output.append(" ").append(name).append("(").append(distance).append("),");
            }
            System.out.println(output.substring(0, output.length() - 1));
        }
    }
}

