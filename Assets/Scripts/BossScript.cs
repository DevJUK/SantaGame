using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossScript : MonoBehaviour
{

	public enum Moves
	{
		NoAttack,
		Attack1,
		Attack2,
		Attack3,
	};

	public Text BossText;
	public Moves BossMoves;
	public float MoveSpeed;
	public Vector2 MoveVec;
	public bool MoveUp;
	public GameObject BossBullet;
	public GameObject BounceBullet;

	public float Timer;
	public float TimeLimit;

	private AudioManager SoundScript;


	private void Start()
	{
		SoundScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioManager>();
	}

	private void Update()
	{

		BossText.text = "Krampus Health: " + GetComponent<DamageScript>().Health.ToString();

		GetComponent<Rigidbody2D>().velocity = MoveVec;
		Timer += Time.deltaTime;



		switch (MoveUp)
		{
			case true:
				MoveVec = new Vector2(0, MoveSpeed);
				break;
			case false:
				MoveVec = new Vector2(0, -MoveSpeed);
				break;
			default:
				break;
		}




		switch (BossMoves)
		{
			case Moves.NoAttack:
				if (Timer > 1)
				{
					var NewState = (Moves)Random.Range(0, 4);
					BossMoves = NewState;
					Timer = 0;
				}
				break;
			case Moves.Attack1:
				Debug.Log("A1");

				if (Timer > 1)
				{
					//SoundScript.PlaySoundWithLowPitch("evil");
					Instantiate(BossBullet, new Vector3(transform.position.x - 5, transform.position.y, transform.position.z), transform.rotation);
					var NewState = (Moves)Random.Range(0, 3);
					BossMoves = NewState;
					Timer = 0;
				}
				break;
			case Moves.Attack2:
				Debug.Log("A2");
				if (Timer > .5)
				{
					var RandomRotation = Random.Range(-45, 45);
					var Rot = new Quaternion(RandomRotation, 0, 0, 0);
					Instantiate(BounceBullet, new Vector3(transform.position.x - 5, transform.position.y, transform.position.z), Rot);
					var NewState = (Moves)Random.Range(0, 3);
					BossMoves = NewState;
					Timer = 0;
				}
				break;
			case Moves.Attack3:
				Debug.Log("A3");
				if (Timer > 1)
				{
					GetComponent<DamageScript>().Health += 1;
					var NewState = (Moves)Random.Range(0, 3);
					BossMoves = NewState;
					Timer = 0;
				}
				break;
			default:
				break;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		MoveUp = !MoveUp;
	}


	public IEnumerator PerfomMove()
	{
		yield return new WaitForSeconds(1);
	}
}
