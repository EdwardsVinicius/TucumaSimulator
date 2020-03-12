using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public static GameController Instance;
	private Canvas canvas;
	public Button exitButton;
	public Button nextButton;
	private int index;
	public Text text;

	void Awake () {
		if ( Instance == null){
			Instance = this;
			DontDestroyOnLoad(this);
		} else {
			Destroy(gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		canvas = GetComponent<Canvas> ();
		exitButton.onClick.AddListener(Exit);
		nextButton.onClick.AddListener(Next);

	}
	public void StageClear () {
		canvas.enabled = true;
		text.text = "Stage " + (index + 1) + " Clear!";
	}

	void Exit () {
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
	}

	void Next () {
		canvas.enabled = false;
		index++;
		SceneManager.LoadScene(index);
	}
}
