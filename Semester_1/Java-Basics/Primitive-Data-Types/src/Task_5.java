


public class Task_5 {

	public static void main(String[] args) {
		String str1 = "Hello";
		String str2 = "World";
		Object obj1 = str1 + " " + str2 + "!";
		System.out.println(obj1);
		String newString = (String) obj1;
		System.out.println(newString);
		
		//boolean str1IsEqualStr2 = (str1 == str2); // not so correct. It may be has some problems
		boolean str1IsEqualStr2 = str1.equals(str2); // better way
		System.out.println(str1IsEqualStr2);
	}
}


