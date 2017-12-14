using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartMission1 : MonoBehaviour {

	public Button Restart;

	void Start()
	{
		Button btn = Restart.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		SceneManager.LoadScene ("Mission1");
	}


}
