@Factorial
Feature: UsingCalculatorFactorial
  In order to compute permutations and large products
  As a math enthusiast
  I want to calculate factorials of non-negative integers

  Scenario: Calculate factorial of a positive integer
    Given I have a calculator
    When I calculate the factorial of 5
    Then the factorial result should be 120

  Scenario: Identity case for factorial of zero
    Given I have a calculator
    When I calculate the factorial of 0
    Then the factorial result should be 1

  Scenario: Reject negative number for factorial
    Given I have a calculator
    When I calculate the factorial of -5
    Then factorial calculation should be rejected