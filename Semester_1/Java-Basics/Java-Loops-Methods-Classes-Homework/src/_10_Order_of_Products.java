import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

/**
 * Created by isrmn on 2.12.2014 г..
 */
public class _10_Order_of_Products {
    public static void main(String[] args) throws FileNotFoundException {
        Scanner scanner = new Scanner(new File("Java-Loops-Methods-Classes-Homework\\Products.txt"));
        List<Product> products = new ArrayList<>();

        while(scanner.hasNextLine())
        {
            @SuppressWarnings("resource")
            Scanner input = new Scanner(scanner.nextLine());
            Product obj = new Product(input.next("\\w+"));
            obj.productPrice = Double.parseDouble(input.next());
            products.add(obj);
        }

        scanner = new Scanner(new File("Java-Loops-Methods-Classes-Homework\\Order.txt"));
        List<Product> order = new ArrayList<>();

        while(scanner.hasNextLine())
        {
            @SuppressWarnings("resource")

            Scanner input = new Scanner(scanner.nextLine());
            scanner.useDelimiter(" ");
            double temp = Double.parseDouble(input.next());
            Product obj = new Product(input.next());
            obj.productPrice = temp;
            order.add(obj);
        }

        double output = calculateMethod(products,order);
        System.out.printf("%.1f",output);

    }

    private static double calculateMethod(List<Product> products, List<Product> order) {
        double result = 0;
        for (Product item: order) {
            for (Product element: products) {
                if (item.name.equals(element.name)) {
                   result += (item.productPrice * element.productPrice);
                }
            }
        }
        return result;
    }


}

