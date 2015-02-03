package _2014_06_01_Exam;


import java.util.Scanner;

public class _02_Sum_Cards {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String[] tempStrArray = input.nextLine().split(" ");
        String[] strArray = new String[tempStrArray.length];

        for (int i = 0; i < tempStrArray.length; i++) {
            String str = tempStrArray[i];
            strArray[i] = str.substring(0, str.length() - 1);
        }
        int count = 0;
        int sum = 0;
        int tempSum = getSum(strArray[0]);
        for (int i = 1; i < strArray.length ; i++) {
            if (strArray[i].equals(strArray[i - 1])) {
                count++;
                tempSum += getSum(strArray[i]);
            } else  {
                if (count > 0) {
                    sum += tempSum*2;
                    count = 0;
                    tempSum = getSum(strArray[i]);
                }else  {
                    sum += tempSum;
                    tempSum = getSum(strArray[i]);
                }
            }
        }
        if (count > 0) {
            sum += tempSum*2;

        }else  {
            sum += tempSum;
        }
        System.out.println(sum);
    }

    private static int getSum(String str) {
        int numValue = 0;
        switch (str) {
            case "2":
                numValue = 2;
                break;
            case "3":
                numValue = 3;
                break;
            case "4":
                numValue = 4;
                break;
            case "5":
                numValue = 5;
                break;
            case "6":
                numValue = 6;
                break;
            case "7":
                numValue = 7;
                break;
            case "8":
                numValue = 8;
                break;
            case "9":
                numValue = 9;
                break;
            case "10":
                numValue = 10;
                break;
            case "J":
                numValue = 12;
                break;
            case "Q":
                numValue = 13;
                break;
            case "K":
                numValue = 14;
                break;
            case "A":
                numValue = 15;
                break;
            default:
                break;
        }
        return  numValue;
    }

}


