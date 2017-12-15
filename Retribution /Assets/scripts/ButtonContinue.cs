using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonContinue : MonoBehaviour {

	public Button Continue;


	void Start()
	{
		Button btn = Continue.GetComponent<Button>();
			btn.onClick.AddListener (TaskOnClick);

	}

	void TaskOnClick()
	{
		if (Application.loadedLevelName == ("Main Menu")) {
			SceneManager.LoadScene ("IntroExplanation");
		} else if (Application.loadedLevelName == ("IntroExplanation")) {
			SceneManager.LoadScene ("IntroScene");
		} 
		else
		{
			SceneManager.LoadScene ("Mission1");
		}

	}
}
