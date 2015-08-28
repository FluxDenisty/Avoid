using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	[SerializeField]
	EnemyScript enemyPrefab = null;

	private float timer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 3f) {
			Vector3 pos;
			do {
				pos = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0); 
			} while ((pos - PlayerScript.instance.transform.position).magnitude < 3f);

			EnemyScript enemy = GameObject.Instantiate<EnemyScript>(this.enemyPrefab);
			enemy.transform.position = pos;
			timer = 0;
		}

	}
}
