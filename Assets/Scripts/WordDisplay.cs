using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplay : MonoBehaviour {

	public TextMeshProUGUI text;

	public void SetWord(string word){
		text.text = word;
	}

	public void RemoveLetter (){
		text.text = text.text.Remove (0, 1);
		text.color = Color.red;

	}

	public void RemoveWord(){
		Destroy (gameObject);
	}
}
