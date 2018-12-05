using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public GameObject SantaBullet;
	public float JumpHeight;

	public float Timer;
	public float TimeLimit = 1;

	public Text HealthTxt;

	private AudioManager SoundScript;

	private void Start()
	{
		SoundScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioManager>();
	}

	private void Update()
	{
		Timer += Time.deltaTime;

		if (Input.GetMouseButtonDown(0))
		{
			if (Timer > 0)
			{
				if (Timer > TimeLimit)
				{
					Instantiate(SantaBullet, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, -90));
					SoundScript.PlaySound("Ho");
					Timer = 0;
				}
			}

		}

		HealthTxt.text = GetComponent<DamageScript>().Health.ToString();


		GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal") * 5, GetComponent<Rigidbody2D>().velocity.y);

		if (Input.GetButtonDown("Jump"))
		{
			if (Physics2D.Linecast(transform.position, transform.position + new Vector3(0, -3.5f, 0), 1 << LayerMask.NameToLayer("Land")))
			{
				GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpHeight));
			}
		}
	}
}
