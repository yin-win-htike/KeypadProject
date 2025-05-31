# C# Coding Challenge

## 📖 Overview

An old phone keypad with alphabetical letters, a backspace key, and a send button.
Each button has a number to identify it and pressing a button multiple times will cycle through the letters on it allowing each button to represent more than one letter.
For example, pressing 2 once will return ‘A’ but pressing twice in succession will return ‘B’.
You must pause for a second in order to type two characters from the same button after each other: “222 2 22” -> “CAB”.

## 🛠️ Implementation Details


The application utilizes the **Windows Forms framework** and is written in C#. The 'OldPhonePad()' method handles input sequences and processes them based on rules.
### Example Inputs
| Input Sequence          | Output        
|-------------------------|---------------
| `222`                   | C             
| `2`                     | A            
| `22`                    | B      

## 🖥️ How to Run


* Clone the Repository

* Open the .sln file in Visual Studio.

* Build  and Run


## 🖌️ User Interface
The following elements are used in the program to model the look and texture of an old phone keypad:

* Buttons with numbers (0–9) * and #
* A display space for text input
* A display area for text output

## 📂 Project Structure

    KeypadProject/
    │
    ├── KeypadForm.cs              # Main logic for input processing
    ├── KeypadForm.Designer.cs     # UI Design Code
    ├── Resources/                 # Contains images for keypad buttons
    ├── README.md                  # Project documentation
    └── Utility    
         └── ButtonMapper.cs       # Define button mapping > numbers to characters   
         └── TextDecorder.cs       # Text decorder class        
    
    KeypadProjectTest/
    │
    ├── KeypadUnitTest.cs          # Test Cases



## 📂 Unit Testing
Unit test developed using NUnit library.

**Running the Unit Tests**

- Build the Solution: In Visual Studio, Build Project > Build Solution.
- Run the Tests: In Visual Studio, go to Test Project > Run All Tests.


## 🛡️ License

This project is licensed under the MIT License.
