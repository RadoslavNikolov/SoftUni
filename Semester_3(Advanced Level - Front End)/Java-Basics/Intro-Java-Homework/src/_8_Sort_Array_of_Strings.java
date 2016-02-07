import java.util.Scanner;
import java.util.TreeSet;


public class _8_Sort_Array_of_Strings {

	public static void main(String[] args) {
		@SuppressWarnings("resource")
		Scanner input = new Scanner(System.in);
		System.out.print("Enter n:");
		int n = input.nextInt();
		input.nextLine();
		String[] strArray = new String[n];
		TreeSet<String> setOfStrings = new TreeSet<String>();


		for (int i = 0; i < n; i++) {
			String str = new String();
			do {
				System.out.print("Enter string:");
				str = input.nextLine().trim();
			} while (str.isEmpty());
			strArray[i] = str;
		}
		//using Insertion Sort Method for ascendent order
		String[] subArray = new String[n];
		for (int i = 0; i < subArray.length; i++) {
			subArray[i] = strArray[i];
		}
		int i;
		int j;
		String temp;
		for ( j = 1; j < subArray.length; j++) {
			temp = subArray[j];
			for ( i = j-1; (i>=0) && (subArray[i].compareToIgnoreCase(temp)>0); i--) {
				subArray[i+1] = subArray[i];
			}
			subArray[i+1] = temp;
		}

//		//fill TreeSet
//		for (String item : strArray) {
//			setOfStrings.add(item);
//		}
//		Arrays.sort(strArray); //sort array alphabetical
//		for (String item : strArray) {
//			System.out.println(item);
//		}
//		System.out.println();
//		for (String item : setOfStrings) {
//			System.out.println(item);
//		}

		System.out.println();
		for (String item : subArray) {
			System.out.println(item);
		}
		
	}

}
