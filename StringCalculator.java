package com.someorganization.stringCalculator;

public class StringCalculator {

  public int add(String numbersWithDelimiter) throws IllegalArgumentException {
    if (numbersWithDelimiter.isEmpty()) {
      return 0;
    }

    String delimiter = this.getDelimiter(numbersWithDelimiter);

    String numberString = numbersWithDelimiter
        .replaceAll("//", "")
        .replaceAll("[\\[\\]]", "");
    if (!Character.isDigit(numberString.charAt(0))) {
      numberString = numberString.substring(1);
    }

    String[] numbers = numberString.split(delimiter);

    return getSum(numbers);
  }

  int getSum(String[] numberList) {
    int answer = 0;
    StringBuilder error = new StringBuilder();

    for (String s : numberList) {
      s = s.replace("\n", "")
          .replace("\r", "");
      int value = Integer.parseInt(s);
      if (value < 0) {
        error.append(s).append(" ");
      } else if (value < 1001) {
        answer += value;
      }
    }
    if (error.length() > 0) throw new IllegalArgumentException("Negatives not allowed: " + error.toString());
    return answer;
  }


  String getDelimiter(final String input) {
    String characterDelimiter = "//";
    String delimiter = "[,\n\r]";
    if (input.indexOf("//[") == 0) {
      var indexOfEnd = input.indexOf("]\n");
      delimiter = input.substring("//[".length(), indexOfEnd);
    } else if (input.indexOf("//") == 0) {
      delimiter = input.substring(2, 3);
    }

    return delimiter;
  }


}
