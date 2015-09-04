using UnityEngine;
using System.Collections;

public class ChargingEnemyScript : EnemyScript {

	private float timer = 0f;

	protected override void Update () {
		this.timer += Time.deltaTime;

		if (this.timer > 2.1f) {
			this.timer = 0f;
			Vector3 target = PlayerScript.instance.transform.localPosition + (Vector3)(PlayerScript.instance.rigidBody.velocity * 1.3f);
			Vector3 force =  target - this.transform.localPosition;
			force = force.normalized * 400f;
			this.rigidBody.AddForce(force);
		}
	}
}
