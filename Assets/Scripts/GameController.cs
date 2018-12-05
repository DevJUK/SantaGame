using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

	public GameObject Krampus;
	public GameObject Santa;
	

	void Update ()
	{

		if (Krampus.GetComponent<DamageScript>().Health <= 0)
		{
			SceneManager.LoadSceneAsync("Win");
		}
		else if (Santa.GetComponent<DamageScript>().Health <= 0)
		{
			SceneManager.LoadSceneAsync("Lose");
		}
	}
}
