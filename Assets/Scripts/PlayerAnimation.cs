using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	public Rigidbody rb;
	public Player PlayerScript;
	public Animator anim;
	
	public float SpeedX;
	public float SpeedY;
	public int attacknumber;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		SpeedX = PlayerScript.GetComponent<Rigidbody>().velocity.x;
		SpeedY = PlayerScript.GetComponent<Rigidbody>().velocity.z;
		anim.SetFloat("Speed", Mathf.Abs(SpeedX) + Mathf.Abs(SpeedY));
		attacknumber = PlayerScript.GetComponent<Player>().numberOfClicks;
		anim.SetInteger("AttackNumber", attacknumber);
		if(Input.GetKeyDown(KeyCode.J))
		{
			anim.SetTrigger("Attack");
		}
	}
}
