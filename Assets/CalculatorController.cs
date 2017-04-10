using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorController : MonoBehaviour {

	// JUST A TEST
	// TODO Memory buttons
	// TODO Decimal

	// UI Text Element to be modified by this script, attached in the Inspector

	public Text outputDisplay;

	// Internal variables

	private float operandA;
	private float operandB;

	private string userInput;
	private string nextOperation;

	private bool enteredDigits = true;
	private bool hasDecimal = false;

	// Initialization

	void Start () {
		AC ();
	}

	// Handler for 0-9 buttons

	public void ButtonDigit(string digit) {
		if (enteredDigits) {
			userInput += digit;
		}
		else {
			userInput = digit;
		}
		UpdateDisplay (userInput);
		operandB = float.Parse (userInput);
		enteredDigits = true;
	}

	// Handler for Operation buttons

	public void ButtonOperation(string operation) {
		if (enteredDigits) {
			Equals ();
		}
		nextOperation = operation;
	}

	// Handler for Equals button

	public void Equals() {
		Calculate (nextOperation);
		UpdateDisplay (operandA.ToString());
		enteredDigits = false;
	}

	public void AC() {
		operandA = 0;
		operandB = 0;
		nextOperation = null;
		UpdateDisplay (operandA.ToString());
	}

	public void C() {
		operandB = 0;
		UpdateDisplay (operandB.ToString());
	}

	private void Calculate(string operation) {
		switch (operation) {
		case "add":
			operandA = operandA + operandB;
			break;
		case "subtract":
			operandA = operandA - operandB;
			break;
		case "multiply":
			operandA = operandA * operandB;
			break;
		case "divide":
			operandA = operandA / operandB;
			break;
		case null:
			operandA = operandB;
			break;
		}
	}

	// Update the UI Text Element with the number in the argument

	private void UpdateDisplay(string display) {
		outputDisplay.text = display;
	}
}
