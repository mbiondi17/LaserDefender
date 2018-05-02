using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public GameObject[] enemyPrefabs;
	// Use this for initialization
	void Start () {
		int enemyToSpawn = Random.Range(0, enemyPrefabs.Length);
		GameObject newEnemy = Instantiate(enemyPrefabs[enemyToSpawn], this.transform.position, Quaternion.identity);
		newEnemy.transform.parent = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
