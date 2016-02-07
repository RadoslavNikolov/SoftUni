import org.apache.poi.ss.usermodel.Cell;
import org.apache.poi.ss.usermodel.Row;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

import java.io.*;
import java.util.*;

/**
 * Created by isrmn on 26.1.2015 г..
 */
public class Modify_xlsx_file {
    public static void main(String[] args) {
        try {
            FileInputStream file = new FileInputStream("myTest.xlsx");

            //create workbook instance holding reference to .xlsx file
            XSSFWorkbook workbook = new XSSFWorkbook(file);

            //get first/desired sheet from the workbook
            XSSFSheet sheet = workbook.getSheetAt(0);

            //this data needs to be written
            Map<String,Object[]> data = new HashMap<>();
            data.put("6", new Object[]{5, "aaa", "aaaa"});
            data.put("7", new Object[]{6, "bbb", "bbbb"});
            data.put("8", new Object[]{7, "ccc", "cccc"});
            data.put("9", new Object[]{8, "ddd", "dddd"});
            data.put("10", new Object[]{9, "eee", "eeee"});

            //set to iterate and add rows into file
            Set<String> newRows = data.keySet();

            //get the last row number to append new data
            int rowNumber = sheet.getLastRowNum()+1;
            for (String key : newRows) {

                //create a new Row in existing XLSX sheet
                Row row = sheet.createRow(rowNumber++);
                Object[] objArr = data.get(key);
                int celNumber = 0;

                for (Object obj : objArr) {
                    Cell cell = row.createCell(celNumber++);
                    if (obj instanceof String) {
                        cell.setCellValue((String)obj);
                    } else if (obj instanceof Integer) {
                        cell.setCellValue((int)obj);
                    }
                }
            }
            file.close();
            //open an Output Stream to save written data into XLSX file
            try {
                //write the workbook in file system
                FileOutputStream out = new FileOutputStream("Just_Trials\\myTest.xlsx");
                workbook.write(out);
                out.close();
                System.out.println("The file was mofied succesfully");
            } catch (Exception e) {
                e.printStackTrace();
            }

        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
