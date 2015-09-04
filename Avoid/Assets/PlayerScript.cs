using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public static PlayerScript instance;

	public Rigidbody2D rigidBody;

	float gameTime = 0f;

	// Use this for initialization
	void Awake () {
		this.rigidBody = this.GetComponent<Rigidbody2D>();
		PlayerScript.instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		this.gameTime += Time.deltaTime;

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

		float MAX_SPEED = 5.5f * (1f + this.gameTime * 0.01f);
		float ACCELERATION = 15.0f * (1f + this.gameTime * 0.05f);

		this.rigidBody.AddForce(diff.normalized * ACCELERATION);
		if (this.rigidBody.velocity.magnitude > MAX_SPEED) {
			this.rigidBody.velocity = this.rigidBody.velocity * (MAX_SPEED / this.rigidBody.velocity.magnitude);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			this.gameObject.SetActive(false);
		}
	}

	void OnDisable() {
		this.gameTime = 0f;
	}
}
