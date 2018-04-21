using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word {

	public string word;
	private int typeIndex;
	private WordDisplay display;

	public Word (string _word, WordDisplay _display)
	{
		word = _word;
		display = _display;
		typeIndex = 0;
		display.SetWord (word);
	}

	public char GetNextLetter(){
		return word [typeIndex];
	}

	public void TypeLetter(){
		typeIndex++;
		display.RemoveLetter ();
	}

	public bool WordTyped(){
		bool wordTyped = (typeIndex >= word.Length);
		if (wordTyped) {
			display.RemoveWord ();
		}
		return wordTyped;
	}

	public void WordFailed(){
		display.RemoveWord ();
	}
}
