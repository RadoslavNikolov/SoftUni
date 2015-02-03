package Java_Sample_Contest;

import java.util.Scanner;

/**
 * Created by radko on 18.1.2015 г..
 */
public class Cartesian_Coord_System {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        double x = input.nextDouble();
        double y = input.nextDouble();


        if (x==0.0 && y==0.0) {
            System.out.println("0");
        }
        else if (x==0.0 && y!=0.0) {
            System.out.println("5");
        }
        else if (x!=0.0 && y==0.0) {
            System.out.println("6");
        }
        else if (x>0.0 && y>0.0) {
            System.out.println("1");
        }
        else if (x>0.0 && y<0.0) {
            System.out.println("4");
        }
        else if (x<0.0 && y>0.0) {
            System.out.println("2");
        }
        else if (x<0.0 && y<0.0) {
            System.out.println("3");
        }
    }
}
