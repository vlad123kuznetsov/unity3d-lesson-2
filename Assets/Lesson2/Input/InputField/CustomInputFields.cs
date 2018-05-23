using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public interface IInputField
{
	string Text { get; }
	event System.Action<string> OnEndInput;
}

public class CustomInputFields : MonoBehaviour, IInputField
{
	[SerializeField] private Text input;
	
	private void Update()
	{
		/*
		if(EventSystem.current.firstSelectedGameObject != gameObject)
			return;
		*/
		
		if (Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			OnEndInput(input.text);
			input.text = "";
		}

		input.text += Input.inputString;
	}

	public string Text
	{
		get { return input.text; }
	}

	public event Action<string> OnEndInput = delegate(string s) {  };
}