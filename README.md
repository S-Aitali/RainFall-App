# RainFall-App - Windows Desktop Application

## Overview

This Windows desktop application is designed to read a text file, process the rows based on specified business rules, and save the processed rows to a new file. The application specifically processes rainfall data and performs the following:

1. Reads data from an input file.
2. Filters and processes valid rows.
3. Calculates the minimum, maximum, and average values of the valid data.
4. Saves the processed data to a new output file.

## Features

- **Upload File:** Select and upload a text file containing rainfall data.
- **Processing Rules:** Processes only positive numeric values. Ignores negative values and stops at a sentinel value of `99999`.
- **Statistics Calculation:** Calculates the minimum, maximum, and average of the valid data.
- **Save Processed Data:** Saves the processed values to a new text file.
- **Clear and Reset:** Allows clearing of all input fields and statistics.
- **Close Application:** Closes the application.

## How to Use

1. **Choose an Input File:**  
   Click the "Choose File" button to open a file dialog and select a `.txt` file containing rainfall data. Each line in the file should contain a single numeric value.
   
2. **Process the File:**  
   After selecting the file, click the "Upload File" button. The program will read the file, process the values, and display the following statistics:
   - Rows Affected (Total rows read)
   - Rows Processed (Valid rows)
   - Minimum, Maximum, and Average values of the processed data
   
3. **Save the Processed Data:**  
   Once the data has been processed, click the "Save" button to choose a location for the output file. The valid processed data will be saved to the chosen location.
   
4. **Clear Fields:**  
   Click the "Clear" button to reset the input and output fields.
   
5. **Close the Application:**  
   Use the "Close" button to exit the application.

## Business Rules

- **Valid Rows:** Only rows with non-negative numeric values are considered valid.
- **Sentinel Value:** The processing stops when the program encounters the value `99999` in the file.
- **Statistics:** The minimum, maximum, and average values are calculated from the valid rows.

## Requirements

- **.NET Framework**
- **Windows OS**
- **Visual Studio** (for development)

## File Formats

- **Input File:**  
  A text file (`.txt`) with each line containing a numeric value.
   **Output File:**  
A text file (`.txt`) that contains only the processed valid rows. The program will save only non-negative values, excluding the sentinel value (`99999`).

## Installation and Setup

 Clone the repository.
