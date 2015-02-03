import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;


public class _8_Sum_Numbers_from_Text_File {

	public static void main(String[] args) {
		int sum = 0;
		try(BufferedReader br = new BufferedReader(new FileReader("Java-Loops-Methods-Classes-Homework\\Input.txt"))) {
	        //StringBuilder sb = new StringBuilder();
	        String line = br.readLine();

	        while (line != null) {
	        	sum += Integer.parseInt(line);
	            //sb.append(line);
	            //sb.append(System.lineSeparator());
	            line = br.readLine();
	        }
	    }catch (IOException e) {
			System.out.println("Error");
		}
		if (sum > 0) {
			System.out.println(sum);
		}
	}
}
