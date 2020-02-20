package com.monktowntech.stringCalculator;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

class StringCalculatorTest {
  StringCalculator sc = new StringCalculator();

  @Test
  void emptyStringReturnsZero() {
    int result = sc.add("");
    assertEquals(0, result);
  }

  @Test
  void basicAddition() {
    assertEquals(3, sc.getSum(new String[]{"1", "1", "1"}));
  }

  @Test
  void getBasicDelimiter() {
    String input = "//;\n1;2";
    assertEquals(";", sc.getDelimiter(input));
  }

  @Test
  void onePlusTwo() {
    int result = sc.add("1,2");
    assertEquals(3, result);
  }

  @Test
  void onePlusTwoPlus3() {
    int result = sc.add("1,2,3");
    assertEquals(6, result);
  }

  @Test
  void onePlusTwoWithNewLineNAndComma() {
    int result = sc.add("1\n2,3");
    assertEquals(6, result);
  }

  @Test
  void onePlusTwoWithNewLineRAndComma() {
    int result = sc.add("1\r2,3");
    assertEquals(6, result);
  }

  @Test
  void onePlusTwoWithNewLinesRandN() {
    int result = sc.add("1\r2\n3");
    assertEquals(6, result);
  }

  @Test
  void onePlusOneWithDelimiter() {
    int result = sc.add("//;\n1;1");
    assertEquals(2, result);
  }

  @Test
  void negativeNumbersThrowException() {
    Assertions.assertThrows(IllegalArgumentException.class, () -> sc.add("4,-1"));
  }

  @Test
  void exceptionMessageIsCorrectForOneNegative() {
    String message = "";
    try {
      sc.add("4,-1");
    } catch (IllegalArgumentException e) {
      message = e.getMessage();
    }
    assertEquals("Negatives not allowed: -1 ", message);
  }

  @Test
  void exceptionMessageIsCorrectForThreeNegatives() {
    String message = "";
    try {
      sc.add("4,-1,5,-6,7,-5");
    } catch (IllegalArgumentException e) {
      message = e.getMessage();
    }
    assertEquals("Negatives not allowed: -1 -6 -5 ", message);
  }

  @Test
  void adds1000() {
    int result = sc.add("1,2,1000");
    assertEquals(1003, result);
  }

  @Test
  void ignoresNumbersGreaterThan1000() {
    int result = sc.add("1,1,1001,1,2345");
    assertEquals(3, result);
  }

  @Test
  void randomLengthDelimiter() {
    String input = "//[***]\n1***2***3";
    String result = sc.getDelimiter(input);
    assertEquals("***", result);
  }

  @Test
  void defaultDelimiter() {
    String input = "1,2";
    assertEquals("[,\n\r]", sc.getDelimiter(input));
  }


}
