using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour{
	private static GameManager instance;
	[SerializeField] 
	private GameObject energyPrefab;

	public GameObject EnergyPrefab {
		get {
			return energyPrefab;
		}

	}
		public static GameManager Instance {
		get {
			if (instance == null) 
			{
				instance = FindObjectOfType<GameManager> ();
			}
			return instance;
		}
	}
}
