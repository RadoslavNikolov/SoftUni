
import java.io.File;



public class Open_PDF_File {

	public static void main(String[] args) {
		try {
			if ((new File("C:\\Users\\radko\\Desktop\\JavaBasics-GitHub\\trunk\\Introprogramming-Java\\Just-Diff-Trials\\400 Must-have Words for the TOEFL.pdf").exists())) {
				Runtime.getRuntime().exec("rundll32 url.dll,FileProtocolHandler " + 
						"C:\\Users\\radko\\Desktop\\JavaBasics-GitHub\\trunk\\Introprogramming-Java\\Just-Diff-Trials\\400 Must-have Words for the TOEFL.pdf");
			}else {
				System.out.println("File does not exists");
			}
			
			System.out.println("Done");
				
		} catch (Exception ex) {
			ex.printStackTrace();
		}		
	}
}
