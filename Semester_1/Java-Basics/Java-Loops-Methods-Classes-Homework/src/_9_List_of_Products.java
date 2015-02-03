import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;


public class _9_List_of_Products {

	public static void main(String[] args) throws FileNotFoundException {
		@SuppressWarnings("resource")
		Scanner scanner = new Scanner(new File("Java-Loops-Methods-Classes-Homework\\Input1.txt"));
		List<Product> list = new ArrayList<>();

		
		while(scanner.hasNextLine())
		{
			@SuppressWarnings("resource")
			Scanner input = new Scanner(scanner.nextLine());
			Product obj = new Product(input.next("\\w+"));
			obj.productPrice = Double.parseDouble(input.next());
			list.add(obj);
		}
		
		//Collections.sort(list, new Product.OrderByAmount());
		List<Product> sortedList = new ArrayList<>();
		double temp = Double.MAX_VALUE;
		for (Product item: list) {
			if (item.productPrice < temp) {
				sortedList.add(0, item);
				temp = item.productPrice;
			}else {
				sortedList.add(item);
			}
		}

		for (Product item: sortedList) {
			System.out.printf("%.2f %s \n",item.productPrice,item.name);
		}
	}
}



class Product{
   String name;
   double productPrice;

   // This is the constructor of the class IncomesReport
   public Product(String name){
	  this.name = name;
   }
}
