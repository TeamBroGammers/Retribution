using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class QuitButton : MonoBehaviour {

	public Button Q;

	void Start()
	{
		Button btn = Q.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Application.Quit ();
	}

}
