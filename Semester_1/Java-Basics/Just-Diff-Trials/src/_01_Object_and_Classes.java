import java.sql.Date;
import java.text.ParseException;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;
import java.util.Scanner;


public class _01_Object_and_Classes {

	
	public static void main(String[] args) throws ParseException {
		/*Just Test using data from Problem.11 - Homework: Loops, Methods, Classes in Java-Basics course*/
		/* Create objects using constructor */		
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in).useLocale(Locale.US);
		System.out.print("Enter numbers of offices: ");
		int numOffices = input.nextInt();
		input.nextLine();
		Map<String, Object> map = new HashMap<String, Object>();
		Map<String, Double> officeTotalIncome = new HashMap<String, Double>();

		for (int i = 0; i < numOffices; i++) {
			String objectName = "office" + (i+1); // get name of object
			System.out.print("Enter the name of the office: ");
			IncomesReport object = new IncomesReport(input.nextLine().toLowerCase());
//			System.out.print("Enter the date of the income (dd-MM-yyyy): ");
//			SimpleDateFormat df = new SimpleDateFormat("dd-MM-yyyy");
//			object.date = Date.valueOf(input.next("dd-MM-yyyy"));  

			System.out.print("Enter the description of the income: ");
			object.description = input.nextLine().toLowerCase();
			System.out.print("Enter the amaunt of the income: ");
			object.income = input.nextDouble();
			input.nextLine();
			map.put(objectName, object);
			
		}
		
		for (Map.Entry<String, Object> entry : map.entrySet()) {
			IncomesReport obj = (IncomesReport) map.get(entry.getKey());
			obj.incomeVat(obj.income);
			obj.incomeTotal(obj.income, obj.vat);			
			obj.printOfficeDetails();
		}

		for (Map.Entry<String, Object> entry : map.entrySet()) {
			IncomesReport obj = (IncomesReport) map.get(entry.getKey());
			calcTotalIncome(obj.name,obj.totalIncome,officeTotalIncome);
		}
		
		for (Map.Entry<String, Double> entry : officeTotalIncome.entrySet()) {
			System.out.println(entry.getKey() + " Total -> " + entry.getValue());
		}
		
	}
	
	public static void calcTotalIncome(String name, Double totalIncome, Map<String, Double> officeTotalIncome){
			if (officeTotalIncome.containsKey(name)) {
				
				double total = officeTotalIncome.get(name);
				total+=totalIncome;
				officeTotalIncome.put(name, total);
			}else {
				officeTotalIncome.put(name, totalIncome);
			}
	}	
}

class IncomesReport{
	   String name;
	   Date date; 
	   String description;
	   double income;
	   double vat;
	   double totalIncome;
	  	   
	   // This is the constructor of the class IncomesReport
	   public IncomesReport(String name){
	      this.name = name;
	   }
	   
	   /* Assign the date of the office income*/
	   public void incomeDate(Date incomeDate){
		      date =  incomeDate;
		   }
	   
	   /* Assign the description of the income to the variable description.*/
	   public void incomeDescription(String incomeDescription){
	      description = incomeDescription;
	   }
	   
	   // Assign the income of the IncomesReport  to the variable age.
	   public void officeIncome(int officeIncome){
	      income =  officeIncome;
	   }
	   
	   /*Calculate VAT for given income*/
	   public void incomeVat(Double income){
	      vat = (income * 20.0)/100.0;
	   }
	   
	   /*calculate total income (income + vat)*/
	   public void incomeTotal(Double income, double vat){
	      totalIncome = income + vat;
	   }   
  
	   public void printOfficeDetails(){
	      System.out.println("Name:"+ name );
	      System.out.println("Date of income:" + date );
	      System.out.println("Description of the income:" + description );
	      System.out.println("The amount of the income:" + income);
	      System.out.println("VAT of the income:" + vat);
	      System.out.println("The total amount of the income (income + VAT):" + totalIncome);

	   }
}