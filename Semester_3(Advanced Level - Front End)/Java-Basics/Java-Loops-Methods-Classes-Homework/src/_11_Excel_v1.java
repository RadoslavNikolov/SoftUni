import org.apache.poi.xssf.usermodel.XSSFCell;
import org.apache.poi.xssf.usermodel.XSSFRow;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;


public class _11_Excel_v1 {

	public static void main(String[] args) {
		try {
			FileInputStream fileInputStream = new FileInputStream("Java-Loops-Methods-Classes-Homework\\Incomes-Report.xlsx");
			//Create Workbook instance holding reference to .xlsx file
			XSSFWorkbook workbook = new XSSFWorkbook(fileInputStream);
			//Get first/desired sheet from the workbook
			XSSFSheet worksheet = workbook.getSheetAt(0);
			DateFormat df = new SimpleDateFormat("dd-MM-yyyy");
			
			
			XSSFRow row1 = worksheet.getRow(1);
			XSSFCell cellA2 = row1.getCell(0);
			String officeName = cellA2.getStringCellValue();
			XSSFCell cellB2 = row1.getCell((short) 1);
			String dateIncome = df.format(cellB2.getDateCellValue());
			XSSFCell cellC2 = row1.getCell(2);
			String incomeDescription = cellC2.getStringCellValue();
			XSSFCell cellD2 = row1.getCell(3);
			double income = cellD2.getNumericCellValue();
			XSSFCell cellE2 = row1.getCell(4);
			double vat = cellE2.getNumericCellValue();
			XSSFCell cellF2 = row1.getCell(5);
			double totalIncome = cellF2.getNumericCellValue();
			
			System.out.println("Name: " + officeName);
			System.out.println("Date of income: " + dateIncome);
			System.out.println("Description of income: " + incomeDescription);
			System.out.println("Amaunt of income: " + income);
			System.out.println("Amaunt of VAT: " + vat);
			System.out.println("Total amaunt of income: " + totalIncome);
			
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
		
		
	}

}
