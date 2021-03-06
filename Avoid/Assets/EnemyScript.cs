﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour {

	public static List<EnemyScript> enemies = new List<EnemyScript>();

	protected Rigidbody2D rigidBody;

	void Awake() {
		EnemyScript.enemies.Add(this);
	}

	// Use this for initialization
	void Start () {
		this.rigidBody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		Vector2 diff = PlayerScript.instance.transform.position - this.transform.position;
		float num = 0;
		Vector2 influ = Vector2.zero;
		foreach (EnemyScript e in EnemyScript.enemies) {
			if (e == this) {continue;}
			Vector2 edist = e.transform.position - this.transform.position;
			if ((edist.normalized - diff.normalized).magnitude < 0.2f) {continue;}
			if (edist.magnitude < 3f) {
				influ += -0.09f * edist.normalized * (60f - edist.magnitude);
				num++;
			}
		}
		if (num > 0) {
			diff += influ / num;
		}

		diff.Normalize();
		this.rigidBody.AddForce(diff * 300.0f * Time.deltaTime);
		if (this.rigidBody.velocity.magnitude > 4.0f) {
			this.rigidBody.velocity = this.rigidBody.velocity * (4f / this.rigidBody.velocity.magnitude);
		}
	}
}
