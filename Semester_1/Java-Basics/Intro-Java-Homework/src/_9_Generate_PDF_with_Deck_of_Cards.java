import com.itextpdf.text.*;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.pdf.PdfPCell;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;

import java.io.FileOutputStream;
import java.io.IOException;



public class _9_Generate_PDF_with_Deck_of_Cards {

	public static void main(String[] args) {
		try {
			Document document = new Document();
			PdfWriter.getInstance(document, new FileOutputStream("Intro-Java-Homework/DeckOfCards.pdf"));
			document.open();
			addMetaData(document);
			addContend(document);
		} catch (Exception e) {
			e.printStackTrace();
		}
		
	}

	private static void addContend(Document document) throws DocumentException, IOException {
		Paragraph preface = new Paragraph();
		addEmpryLine(preface, 1);
		preface.add(new Paragraph("Deck of Cards"));
		addEmpryLine(preface, 1);
		document.add(preface);
		
		PdfPTable table = new PdfPTable(4);
		table.setWidthPercentage(100);
		table.getDefaultCell().setFixedHeight(180);
			
		BaseFont base = BaseFont.createFont("lib/lucida.ttf", BaseFont.IDENTITY_H, true);
		Font redCardsFont = new Font(base, 55, Font.NORMAL, BaseColor.RED);
		Font blackCardsFont = new Font(base, 55, Font.NORMAL, BaseColor.BLACK);
			
		String face = "";
		String suits = "";
		
		for (int i = 2; i <= 14; i++) {
			switch (i) {
			case 11: face = "J"; break;
			case 12: face = "Q"; break;
			case 13: face = "K"; break;
			case 14: face = "A"; break;
			default: face = "" + i; break;
			}
			
			for (int j = 1; j <= 4; j++) {
				PdfPTable nestedTable = new PdfPTable(1);
				switch (j) {
				case 1: suits = "\u2663"; printTable(table, nestedTable, face, suits, blackCardsFont); break;
				case 2: suits = "\u2666"; printTable(table, nestedTable, face, suits, redCardsFont); break;
				case 3: suits = "\u2660"; printTable(table, nestedTable, face, suits, blackCardsFont); break;
				case 4: suits = "\u2665"; printTable(table, nestedTable, face, suits, redCardsFont); break;
				default: 
					break;
				}
			}
		}
		document.add(table);
		document.close();	
	}
	
	private static void printTable(PdfPTable table, PdfPTable nestedTable, String face, String suits,
			Font cardsFont) {
		
		PdfPCell cell = new PdfPCell();
		cell = new PdfPCell(new Phrase(face, cardsFont));
		cell.setBorder(0); cell.setVerticalAlignment(Element.ALIGN_TOP); cell.setHorizontalAlignment(Element.ALIGN_LEFT);
		nestedTable.addCell(cell); 
		cell = new PdfPCell(new Phrase(suits, cardsFont));
		cell.setBorder(0); cell.setVerticalAlignment(Element.ALIGN_MIDDLE); cell.setHorizontalAlignment(Element.ALIGN_CENTER);
		nestedTable.addCell(cell);
		cell = new PdfPCell(new Phrase(face, cardsFont));
		cell.setBorder(0); cell.setVerticalAlignment(Element.ALIGN_TOP); cell.setHorizontalAlignment(Element.ALIGN_RIGHT);
		nestedTable.addCell(cell);
		PdfPCell cell1 = new PdfPCell();
		cell1.addElement(nestedTable);
		table.addCell(cell1);		
	}

	private static void addEmpryLine(Paragraph preface, int number) {
		for (int i = 0; i < number; i++) {
			preface.add(new Paragraph(" "));
		}
	}

	private static void addMetaData(Document document) {
		document.addTitle("Deck of cards");
		document.addSubject("Using iText");
		document.addKeywords("Java, PDF, iText");
		document.addAuthor("Radoslav Nikolov");
		document.addCreator("Radoslav Nikolov");
	}
	
}
