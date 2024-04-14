# University Projects

This repository contains a series of projects developed during the university journey. The projects primarily focus on the practical application and experimentation of theoretical concepts learned during courses.

## Project 1: Fractions

### Description
The first project focuses on the development of a `Fraction` class, aimed at representing fractions and implementing operations on them. The implementation follows the "test first" approach, where tests are defined for each functionality first, and then implementation follows.

### Specifications
The `Fraction` class must meet the following requirements:
- Read-only properties for numerator and denominator.
- Constructor that initializes the object with the normalized form of the fraction.
- Implementation of arithmetic operators (+, -, *, /) in infix syntax.
- `ToString` method that returns the representation of the fraction in normalized form.
- `Equals` method that checks equality between fractions.
- Implicit conversion from integer to fraction.
- Explicit conversion from fraction to integer, raising an exception if the denominator is not 1.

### Part 1: Operator Overloading (Initial Example)
To begin, tests are defined for the constructor, following the "test first" approach. We start with the following correct and incorrect cases to ensure proper handling of inputs and edge cases.

## Project 2: Custom-Attribute and Reflection

### Description
The second project focuses on the use of custom attributes and reflection in C#. The goal is to develop a system where methods can be annotated with custom attributes and dynamically invoked through reflection.

### Specifications
The project is divided into two versions: a base and an advanced one. In the base version, three projects are created in a solution:
- A console application `Executer`.
- A class library `MyAttribute` to define a custom attribute `ExecuteMe`.
- A class library `MyLibrary` where classes with methods annotated with `[ExecuteMe]` are defined.

### Base Version
1. Define the custom attribute `ExecuteMe` that can be associated with methods.
2. Create public classes in `MyLibrary` with public methods annotated with `[ExecuteMe]`.
3. Use reflection in `Executer` to load the DLL of `MyLibrary` and dynamically invoke the annotated methods.

### Second Release
1. Optimize the reference to `MyLibrary` in `Executer`.
2. Experiment with the values and types of arguments for the `ExecuteMe` annotation.
3. Handle errors such as the absence of the default constructor and incorrect parameters in annotated methods.

### Possible Improvements
- Handle non-default constructors and optional parameters in annotated methods.
- Explore interactions between custom attributes, reflection, and parameter types.

## Contributions
Contributions are welcome through pull requests. For any issues or suggestions, feel free to create a new issue.
