using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyMovement : MonoBehaviour {

	Transform player;
	static Animator anim;
	public Slider healthbar;
//	public float rotSpeed;
//	public float movSpeed;
//	public Animation anim;
//	public SphereCollider attackDistance;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		anim = GetComponent<Animator> (); 
//		anim = GetComponent<Animation> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (healthbar.value <= 0) return;

		if (Vector3.Distance (player.position, this.transform.position) < 10) {

			Vector3 direction = player.position - this.transform.position;
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
			anim.SetBool ("isIdle", false);

			if (direction.magnitude > 5) {
				this.transform.Translate (0, 0, 0.08f);
				anim.SetBool ("isRunning", true);
				anim.SetBool ("isAttacking", false);
			} else {
				anim.SetBool ("isAttacking", true);
				anim.SetBool ("isRunning", false);
			}

		} else {
			anim.SetBool ("isIdle", true);
			anim.SetBool ("isRunning", false);
			anim.SetBool ("isAttacking", false);
		}
	}
//		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (player.position - transform.position), rotSpeed * Time.deltaTime); 
//		transform.position += transform.forward * movSpeed * Time.deltaTime;
//		if (movSpeed != 0) {
//			anim.Play ("run");
//		}

}


