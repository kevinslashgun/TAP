# TAP Course Labs Repository

## Description

This repository contains the lab assignments for the TAP (Advanced Programming Techniques) course.

## Lab 1: Fraction Library

### Objective

The objective of this lab is to develop a `Fraction` class, where objects represent fractions and manipulation functions are implemented as operators.

### Approach

The development follows the test-first approach, ensuring that each functionality is tested before implementation. NUnit Framework is used for testing.

### Verification

To verify the correct development of the class, aim for 100% code coverage. Ensure that the NUnit tests are recognized by Visual Studio by installing the NUnit Test Adapter.

### Part 1: Operator Overloading

#### Summary

The main goal is to build the field of fractions over integers.

#### Key Concepts

- Define `Fraction` class with read-only properties for numerator and denominator.
- Implement arithmetic operators (+, -, *, /) in infix syntax.
- Ensure `ToString` method displays fraction in normal form.
- Implement `Equals` method for equality comparison.
- Include implicit conversion from integer to fraction and explicit conversion from fraction to integer.
- Use simplification method to normalize fractions.
