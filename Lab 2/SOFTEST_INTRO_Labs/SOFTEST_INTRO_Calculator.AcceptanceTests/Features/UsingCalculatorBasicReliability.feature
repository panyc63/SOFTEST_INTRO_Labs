@BasicMusa
Feature: UsingCalculatorBasicReliability
  In order to calculate the Basic Musa model's failures and intensities
  As a Software Quality Metric enthusiast
  I want to use my calculator to do this

  Scenario: Calculate current failure intensity at start (tau = 0)
    Given I have a calculator
    And Musa parameters initial intensity 10, total failures 100, and execution time 0 hours
    When I calculate the current failure intensity
    Then the result should be 10

  Scenario: Calculate current failure intensity after execution time
    Given I have a calculator
    And Musa parameters initial intensity 10, total failures 100, and execution time 10 hours
    When I calculate the current failure intensity
    Then the result should be 3.6787944117

  Scenario: Calculate expected cumulative failures
    Given I have a calculator
    And Musa parameters initial intensity 10, total failures 100, and execution time 10 hours
    When I calculate the expected cumulative failures
    Then the result should be 63.21205588

  Scenario: Reject negative execution time
    Given I have a calculator
    And Musa parameters initial intensity 10, total failures 100, and execution time -5 hours
    When I calculate the current failure intensity
    Then calculation should be rejected