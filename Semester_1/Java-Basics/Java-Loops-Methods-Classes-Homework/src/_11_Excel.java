import org.apache.poi.ss.usermodel.*;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;


public class _11_Excel {

	public static void main(String[] args) {
		try {
			FileInputStream fileInputStream = new FileInputStream("Java-Loops-Methods-Classes-Homework\\Incomes-Report.xlsx");
			//Create Workbook instance holding reference to .xlsx file
			XSSFWorkbook workbook = new XSSFWorkbook(fileInputStream);
			//Get first/desired sheet from the workbook
			XSSFSheet worksheet = workbook.getSheetAt(0);
			DateFormat df = new SimpleDateFormat("dd-MM-yyyy");
	        DataFormatter formatter = new DataFormatter(true);
			FormulaEvaluator evaluator = workbook.getCreationHelper().createFormulaEvaluator();
			//Iterate through each rows one by one
			java.util.Iterator<Row> rowIterator = worksheet.iterator();
			
			while (rowIterator.hasNext()) {
				Row row = rowIterator.next();
				//For each row, iterate through all the columns
				java.util.Iterator<Cell> cellIterator = row.cellIterator();
				if (row.getRowNum()==0) {
					continue;
				}
				while (cellIterator.hasNext()) {
					Cell cell = cellIterator.next();
					//Check the cell type and format accordingly
					
					switch (cell.getCellType()) {
					case Cell.CELL_TYPE_NUMERIC: 
						if (DateUtil.isCellDateFormatted(cell)) {
		                    System.out.printf("%s",String.format("%-25s", df.format(cell.getDateCellValue())));
		                } else {
		                	System.out.printf("%s",String.format("%-25s", cell.getNumericCellValue()));
		                }
						break;
					case Cell.CELL_TYPE_STRING: 
						System.out.printf("%s",String.format("%-25s", cell.getStringCellValue()));
						break;
					case Cell.CELL_TYPE_FORMULA: 
						System.out.printf("%s",String.format("%-25s", readFormattedCellValue(cell,formatter,evaluator)));
						break;
					default:
						break;
					}
				}
				System.out.println("");
			}			
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
		
		
	}

	public static String readFormattedCellValue(Cell cell, DataFormatter formatter, FormulaEvaluator evaluator) {
		try {
	        return formatter.formatCellValue(cell, evaluator);
	    }
	    catch (RuntimeException e) {
	        return e.getMessage(); // Error from evaluator, for example "Don't know how to evaluate name 'xxx'" if we have =xxx() in cell
	    }
	}

}

