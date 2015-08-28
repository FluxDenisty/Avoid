using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public static PlayerScript instance;

	public Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		this.rigidBody = this.GetComponent<Rigidbody2D>();
		PlayerScript.instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 diff = Vector2.zero;
		if (Input.GetKey(KeyCode.W)) {
			diff += Vector2.up;
		}
		if (Input.GetKey(KeyCode.A)) {
			diff += Vector2.left;
		}
		if (Input.GetKey(KeyCode.S)) {
			diff += Vector2.down;
		}
		if (Input.GetKey(KeyCode.D)) {
			diff += Vector2.right;
		}

		this.rigidBody.AddForce(diff * 10.0f);
		if (this.rigidBody.velocity.magnitude > 4.5f) {
			this.rigidBody.velocity = this.rigidBody.velocity * (4f / this.rigidBody.velocity.magnitude);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			this.gameObject.SetActive(false);
		}
	}
}
