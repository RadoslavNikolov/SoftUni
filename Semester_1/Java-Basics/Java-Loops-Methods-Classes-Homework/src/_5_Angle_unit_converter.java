import java.text.DecimalFormat;
import java.text.DecimalFormatSymbols;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.Scanner;

/**
 * Created by isrmn on 4.12.2014 г..
 */
public class _5_Angle_unit_converter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in).useLocale(Locale.US);
        List<String> outputList= new ArrayList<>();
        double degrees;
        String typeOfDegrees;
        int n;
        Scanner input = new Scanner(scanner.nextLine());
        n = Integer.parseInt(input.next());
        for (int i = 0; i < n; i++) {
            input = new Scanner(scanner.nextLine());
            scanner.useDelimiter(" ");
            degrees = Double.parseDouble(input.next());
            typeOfDegrees = input.next();
            convertMethod(degrees, typeOfDegrees, outputList);
        }
        for (String str : outputList) {
            System.out.println(str);
        }
        

    }

    private static void convertMethod(double degrees, String typeOfDegrees, List<String> outputList) {
        StringBuilder output = new StringBuilder();
        double temp;
        DecimalFormat df = new DecimalFormat("0.000000"); // ("#.######") do not work properly. Print "0" instead of "0.000000"
        df.setDecimalFormatSymbols(new DecimalFormatSymbols(Locale.US)); // set "." as a decimal separator. Without this will print "," as a decimal separator
        //df.setRoundingMode(RoundingMode.DOWN); //This set the RoundingMode if want not default
        if (typeOfDegrees.equals("deg")) {
            temp = (degrees * Math.PI)/180.0;
            //String result = String.format("%.6f", temp); // This works  but I can not fix the wrong decimal separator
            //output.append(result);
            output.append(df.format(temp));
            output.append(" rad");

        }else {
            temp = (degrees * 180.0)/Math.PI;
            //String result = String.format("%.6f", temp);
            //output.append(result);
            output.append(df.format(temp));
            output.append(" deg");
        }
        outputList.add(String.valueOf(output));
    }


}
