using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class nextScene : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player" &&  Application.loadedLevelName == ("IntroScene"))
		{
		SceneManager.LoadScene("Scene_2");
		}
		else if(other.tag == "Player" &&  Application.loadedLevelName == ("Mission1"))
		{
			SceneManager.LoadScene("Mission2");
		}
		else if(other.tag == "Player" &&  Application.loadedLevelName == ("Mission2"))
		{
			SceneManager.LoadScene("Scene_3");
		}
		else if(other.tag == "Player" &&  Application.loadedLevelName == ("Scene_3"))
		{
			SceneManager.LoadScene("BossfightScene");
		}
	}
}
