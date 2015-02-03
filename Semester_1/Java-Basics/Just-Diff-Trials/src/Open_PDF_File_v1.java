import java.awt.Desktop;
import java.io.File;


public class Open_PDF_File_v1 {

	public static void main(String[] args) {
		try {
			File pdfFile = new File("C:\\Users\\radko\\Desktop\\JavaBasics-GitHub\\trunk\\Introprogramming-Java\\Just-Diff-Trials\\400 Must-have Words for the TOEFL.pdf");
			
			if (pdfFile.exists()) {
				Desktop.getDesktop().open(pdfFile);;
			}else {
				System.out.println("File does not exists");
			}
			
			System.out.println("Done");
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		
	}

}
