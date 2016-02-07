import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.Iterator;

/**
 * Created by isrmn on 26.1.2015 г..
 */
public class Read_xls_file {
    public static void main(String[] args) {
        try {
            FileInputStream file = new FileInputStream("myTest.xlsx");

            //create workbook instance holding reference to .xlsx file
            XSSFWorkbook workbook = new XSSFWorkbook(file);

            //get first/desired sheet from the workbook
            XSSFSheet sheet = workbook.getSheetAt(0);

            //iterate trought each rows one by one
            Iterator<Row> rowIterator = sheet.iterator();
            while (rowIterator.hasNext()){
                Row row = rowIterator.next();
                Iterator<Cell> cellIterator = row.cellIterator();

                while (cellIterator.hasNext()) {
                    Cell cell = cellIterator.next();

                    //check the cell type and format accordingly
                    switch (cell.getCellType()) {
                        case Cell.CELL_TYPE_NUMERIC :
                            System.out.print((int)cell.getNumericCellValue() + "\t");
                            break;
                        case Cell.CELL_TYPE_STRING :
                            System.out.print(cell.getStringCellValue() + "\t");
                            break;
                    }
                }
                System.out.println();
            }
            file.close();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }

    }
}
