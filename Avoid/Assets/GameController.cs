using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	[SerializeField]
	EnemyScript enemyPrefab = null;

	[SerializeField]
	ChargingEnemyScript chargingPrefab = null;
	
	[SerializeField]
	Text scoreText = null;

	[SerializeField]
	Text helpText = null;

	[SerializeField]
	List<Transform> walls = new List<Transform>();

	PlayerScript player = null;

	private float timer = 0;

	private float gameTime = 0;

	// Use this for initialization
	void Start () {
		this.player = PlayerScript.instance;
	}

	void Update () {
		this.timer += Time.deltaTime;
		this.gameTime +=  Time.deltaTime;
		
		float size = 5f;// + gameTime * 0.1f;
//		Camera.main.orthographicSize = size;
//		this.walls[0].localPosition = Vector3.up * size;
//		this.walls[1].localPosition = Vector3.down * size;
//		this.walls[2].localPosition = Vector3.left * size * (9f/5f);
//		this.walls[3].localPosition = Vector3.right * size * (9f/5f);
//		
//		this.walls[0].localScale = this.walls[1].localScale = new Vector3(size * 6.5f, 1f, 1f);
//		this.walls[2].localScale = this.walls[3].localScale = new Vector3(1f, size * 3.5f, 1f);

		const float SPAWN_TIMER = 3f;
		if (timer > SPAWN_TIMER) {
			timer = 0;

			if (PlayerScript.instance.gameObject.activeInHierarchy) {
				Vector3 pos;
				do {
					pos = new Vector3(Random.Range(-(size * (9f/5f) - 1f), size * (9f/5f) - 1f), Random.Range(-(size - 1f), size - 1f), 0); 
				} while ((pos - PlayerScript.instance.transform.position).magnitude < 5f);

				EnemyScript type = (EnemyScript.enemies.Count % 3 == 2 ? this.chargingPrefab : this.enemyPrefab);
				EnemyScript enemy = GameObject.Instantiate<EnemyScript>(type);
				enemy.transform.position = pos;
			}
		}


		if (Input.GetKeyDown(KeyCode.Space)) {
			EnemyScript.enemies.ForEach( e => GameObject.Destroy(e.gameObject));
			EnemyScript.enemies.Clear();
			player.gameObject.SetActive(true);
			player.gameObject.transform.localPosition = Vector3.zero;
			player.rigidBody.velocity = Vector3.zero;
			this.gameTime = 0;
			this.timer = 0;
		}

		scoreText.text = EnemyScript.enemies.Count.ToString();
		scoreText.color = new Color(1f, (1f - this.timer / SPAWN_TIMER), (1f - this.timer / SPAWN_TIMER));

		this.helpText.color = new Color(1f, 1f, 1f, Mathf.Clamp01(SPAWN_TIMER - this.gameTime));
	}
}
