import org.apache.poi.xssf.usermodel.XSSFCell;
import org.apache.poi.xssf.usermodel.XSSFRow;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

import java.io.File;
import java.io.FileOutputStream;
import java.util.Map;
import java.util.Set;
import java.util.TreeMap;

/**
 * Created by isrmn on 26.1.2015 г..
 */
public class Create_and_write_xls_file {
    public static void main(String[] args) {
        //blank workbook
        XSSFWorkbook workbook = new XSSFWorkbook();

        //create a blank sheet
        XSSFSheet sheet = workbook.createSheet("Employee Data");

        //this data needs to be written
        Map<String,Object[]> data = new TreeMap<>();
        data.put("1", new Object[]{"ID", "NAME", "LASTNAME"});
        data.put("2", new Object[]{1, "Radoslav", "Nikolov"});
        data.put("3", new Object[]{2, "Nikola", "Nikolov"});
        data.put("4", new Object[]{3, "Ivana", "Nikolova"});
        data.put("5", new Object[]{4, "Mariela", "Nikolova"});

        //iterate over data and write to sheet
        Set<String> keyset = data.keySet();

        int rowNumber = 0;
        for (String key : keyset) {
            //create a row of excelsheet
            XSSFRow row = sheet.createRow(rowNumber++);
            Object[] objArr = data.get(key);

            int cellNumber = 0;
            for (Object obj : objArr) {
                XSSFCell cell = row.createCell(cellNumber++);
                if (obj instanceof String) {
                    cell.setCellValue((String) obj);
                } else if (obj instanceof Integer) {
                    cell.setCellValue((Integer) obj);
                }
            }
        }
        try {
            //write the workbook in file system
            FileOutputStream out = new FileOutputStream(new File("Just_Trials\\myTest.xlsx"));
            workbook.write(out);
            out.close();
            System.out.println("The file was created succesfully");
        } catch (Exception e) {
            e.printStackTrace();
        }

    }
}
