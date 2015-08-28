using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	
	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		this.rigidBody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 diff = PlayerScript.instance.transform.position - this.transform.position;

		this.rigidBody.AddForce(diff * 5.0f);
		if (this.rigidBody.velocity.magnitude > 4.0f) {
			this.rigidBody.velocity = this.rigidBody.velocity * (4f / this.rigidBody.velocity.magnitude);
		}
	}
}
