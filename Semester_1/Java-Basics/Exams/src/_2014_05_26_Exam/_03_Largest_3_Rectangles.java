package _2014_05_26_Exam;

import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class _03_Largest_3_Rectangles {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        List<Integer> numbers = new ArrayList<>();
        List<Integer> areaRectangles = new ArrayList<>();
        List<Integer> largest3Rectangles = new ArrayList<>();
        Pattern p = Pattern.compile("\\d+");
        Matcher m = p.matcher(input.nextLine());
        while (m.find()) {
            numbers.add(Integer.parseInt(m.group()));
        }
        for (int i = 0; i < numbers.size() ; i+=2) {
            areaRectangles.add(numbers.get(i) *numbers.get(i+1));
        }
        for (int i = 0; i < areaRectangles.size()-2; i++) {
            largest3Rectangles.add(areaRectangles.get(i) + areaRectangles.get(i+1) + areaRectangles.get(i+2));
        }
        Collections.sort(largest3Rectangles, Collections.reverseOrder());
        System.out.println(largest3Rectangles.get(0));
    }
}
