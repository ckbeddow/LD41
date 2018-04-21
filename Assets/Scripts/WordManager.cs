using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour {

	public List<Word> words;
	public WordSpawner wordSpawner;
	public bool typingEnabled;
	public Timer timer;
	public GameManager gameManager;

	private bool hasActiveWord = false;
	private Word activeWord;
	private int wordsLeft;
	public int currentScore;



	private void Start(){
		//SpawnWordChallange (3);

	
	}

	private void Update(){
		if (timer.timerUp && typingEnabled) {
			ResetChallange ();
		}
	}

	private void ResetChallange(){
		
		typingEnabled = false;
		activeWord = null;
		wordsLeft = 0;

		words = null;
		wordSpawner.despawnCanvas ();
		hasActiveWord = false;
		Debug.Log ("failed");
	}
	public void SpawnWordChallange(int numberOfWords, float timeLimit){
		words = new List<Word>();
		for (int i = 0; i < numberOfWords; i++) {
			AddWord ();
		}
		currentScore = 0;
		SetTimer (timeLimit);
		wordsLeft = numberOfWords;
		typingEnabled = true;

	}

	public void AddWord ()
	{
		
		Word word = new Word (WordGenerator.GetRandomWord (), wordSpawner.SpawnWord());
		Debug.Log (word.word);
		words.Add (word);
	}

	public void TypeLetter ( char letter){
		
		//Define active word

		//Most Likely will remove this part
		//I don't think I'll want to have choices on what word you can type

		if (hasActiveWord) {
			//Check if letter was next
			if (activeWord.GetNextLetter () == letter) {
				activeWord.TypeLetter ();
				currentScore++;
			}
			//Remove from word

		} else {
			foreach (Word word in words) {
				if (word.GetNextLetter() == letter) {
					activeWord = word;
					hasActiveWord = true;
					word.TypeLetter ();
					break;
				}
			}
		}

		if (hasActiveWord && activeWord.WordTyped ()) {
			hasActiveWord = false;
			words.Remove (activeWord);
			wordsLeft--;
			if (wordsLeft <= 0) {
				typingEnabled = false;
				wordSpawner.despawnCanvas ();
				if (timer.timerUp == false) {
					Debug.Log ("Score!!");
					gameManager.Score (currentScore);
				} else {
					Debug.Log ("Failed!");
				}
			}

		}
	}

	public void SetTimer(float timeLimit){
		timer.resetTime (timeLimit);
	}
}
