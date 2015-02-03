package _2014_05_27_Exam;

import java.util.Scanner;


public class _03_Longest_Odd_Even_Sequence {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        String[] strArr = input.nextLine().split("[ ()]+");
        int[] numArray = new int[strArr.length-1];
        for (int i = 0; i < numArray.length; i++) {
            numArray[i] = Integer.parseInt(strArr[i+1]);
        }

        int bestLenght = 0;
        int lenght = 1;
        boolean isZeroEven = false;

        for (int i = 1; i < numArray.length; i++) {

            if (numArray[i] == 0) {
                if (numArray[i-1] != 0) {
                    if ((numArray[i-1]%2) == 0) {
                        isZeroEven = false;
                        lenght++;
                    }else {
                        isZeroEven = true;
                        lenght++;
                    }
                }else {
                    if (isZeroEven == false) {
                        lenght++;
                        isZeroEven = true;
                    } else {
                        lenght++;
                        isZeroEven = false;
                    }
                }

            }else {
                if (numArray[i-1] != 0) {
                    if ((numArray[i]%2==0)!=(numArray[i-1]%2==0)) {
                        lenght++;
                    }else {
                        if (bestLenght < lenght) {
                            bestLenght = lenght;
                            lenght=1;
                        }
                    }
                } else {
                    if ((numArray[i]%2==0)!= isZeroEven) {
                        lenght++;

                    } else {
                        if (bestLenght < lenght) {
                            bestLenght = lenght;
                            lenght=1;
                        }
                    }
                }
            }


        }
        if (bestLenght < lenght) {
            bestLenght = lenght;
        }
        System.out.println(bestLenght);
    }
}
