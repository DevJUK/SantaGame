using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceScript : MonoBehaviour
{
	private AudioManager SoundScript;
	public float RandomRotation;

	void Start ()
	{
		SoundScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioManager>();
		GetComponent<Rigidbody2D>().velocity = new Vector2(-7, 0);
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.GetComponent<DamageScript>())
		{
			if (collision.gameObject.GetComponent<DamageScript>().UseHealth == true)
			{
				SoundScript.PlaySound("Ouch");
				collision.gameObject.GetComponent<DamageScript>().Health = collision.gameObject.GetComponent<DamageScript>().Health - GetComponent<DamageScript>().AttackDamage;
				Destroy(this.gameObject, .1f);
			}
			else
			{
				//nothing
			}
		}
		else if (collision.gameObject.name == "DestroyBullets")
		{
			Destroy(this.gameObject, .1f);
		}

	}
}
