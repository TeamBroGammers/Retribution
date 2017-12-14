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
		else if (other.tag == "Player" &&  Application.loadedLevelName == ("Scene_2"))
		{
			SceneManager.LoadScene("Mission1");

		}
		else if(other.tag == "Player" &&  Application.loadedLevelName == ("Mission1"))
		{
			SceneManager.LoadScene("IntroScene");
		}
	}
}
