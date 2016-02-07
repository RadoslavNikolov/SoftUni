import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.DataFormatter;
import org.apache.poi.ss.usermodel.FormulaEvaluator;
import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.HashMap;
import java.util.Map;
import java.util.TreeMap;


public class _11_Excel_working {

	public static void main(String[] args) {
		Map<String, Object> map = new HashMap<String, Object>();
		Map<String, Double> officeTotalIncome = new TreeMap<String, Double>();
		try {
			FileInputStream fileInputStream = new FileInputStream("Java-Loops-Methods-Classes-Homework\\Incomes-Report.xlsx");
			//Create Workbook instance holding reference to .xlsx file
			XSSFWorkbook workbook = new XSSFWorkbook(fileInputStream);
			//Get first/desired sheet from the workbook
			XSSFSheet worksheet = workbook.getSheetAt(0);
			DateFormat df = new SimpleDateFormat("dd-MM-yyyy");
	        DataFormatter formatter = new DataFormatter(true);
			FormulaEvaluator evaluator = workbook.getCreationHelper().createFormulaEvaluator();
			
			int i = 1;
			//Iterate through each rows one by one
			java.util.Iterator<Row> rowIterator = worksheet.iterator();
			
			while (rowIterator.hasNext()) {
				Row row = rowIterator.next();
				//For each row, iterate through all the columns
				java.util.Iterator<Cell> cellIterator = row.cellIterator();
				if (row.getRowNum()==0) {
					continue;
				}else {
					String objectName = "office" + (i); // get name of object
					int count=1;
					Cell cell = cellIterator.next();
					IncomesReport object = new IncomesReport(cell.getStringCellValue());
					while (cellIterator.hasNext()) {
						cell = cellIterator.next();
						count++;
						switch (count) {
						case 2:
							object.date = df.format(cell.getDateCellValue());
							break;
						case 3: 
							object.description = cell.getStringCellValue();
							break;
						case 4:
							object.income = cell.getNumericCellValue();
							break;
						case 5:
							object.vat = Double.parseDouble(readFormattedCellValue(cell,formatter,evaluator));
							break;
						case 6:
							object.totalIncome = Double.parseDouble(readFormattedCellValue(cell,formatter,evaluator));
							break;
						default:
							break;
						}						
					}
					map.put(objectName, object);
				}
				i++;
			}			
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
		
		for (Map.Entry<String, Object> entry : map.entrySet()) {
			IncomesReport obj = (IncomesReport) map.get(entry.getKey());
			calcTotalIncome(obj.name,obj.totalIncome,officeTotalIncome);
		}
		
		double grandTotal = 0;
		
		for (Map.Entry<String, Double> entry : officeTotalIncome.entrySet()) {
			System.out.printf("%s Total -> %.2f \n",entry.getKey(),entry.getValue());
			grandTotal+=entry.getValue();
		}
		System.out.printf("Grand Total -> %.2f \n",grandTotal);		
	}

	
	public static String readFormattedCellValue(Cell cell, DataFormatter formatter, FormulaEvaluator evaluator) {
		try {
	        return formatter.formatCellValue(cell, evaluator);
	    }
	    catch (RuntimeException e) {
	        return e.getMessage(); // Error from evaluator, for example "Don't know how to evaluate name 'xxx'" if we have =xxx() in cell
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
	   String date; 
	   String description;
	   double income;
	   double vat;
	   double totalIncome;
	  	   
	   // This is the constructor of the class IncomesReport
	   public IncomesReport(String name){
	      this.name = name;
	   }
	   
	   // Assign the date of the office income
	   public void incomeDate(String incomeDate){
		      date =  incomeDate;
		   }
	   
	   //Assign the description of the income to the variable description.
	   public void incomeDescription(String incomeDescription){
	      description = incomeDescription;
	   }
	   
	   // Assign the income of the IncomesReport  to the variable age.
	   public void officeIncome(Double officeIncome){
	      income =  officeIncome;
	   }
	   
	   // Assign VAT of the income
	   public void incomeVat(Double incomeVAT){
	      vat = incomeVAT;
	   }
	   
	   // Assign total income
	   public void incomeTotal(Double incomeTotal){
	      totalIncome = incomeTotal;
	   }   

}
