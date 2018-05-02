using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;

	[Range(0,1)]
	public float inverseDrift; 

	private float lerpProgress = 0.0f;
	private float boundX;

	// Use this for initialization
	void Start () {
		float distancePlaneToCam = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distancePlaneToCam)); //get the leftmost point in the world in view
		float spriteBuffer = this.GetComponent<SpriteRenderer>().bounds.extents.x;
		boundX = Mathf.Abs(leftmost.x) - spriteBuffer; //need to account for width of ship and set boundary.
	}
	
	// Update is called once per frame
	void Update () {
		if(lerpProgress > 1.0f) print(lerpProgress);
		if(Input.GetKey(KeyCode.LeftArrow)) {
			lerpProgress = 0.0f;
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * speed, 0.0f);
		}
		else if(Input.GetKey(KeyCode.RightArrow)) {
			lerpProgress = 0.0f;
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0.0f);
		}
		else {
			float xVel = this.GetComponent<Rigidbody2D>().velocity.x;
			if(xVel != 0.0f) {
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Lerp(xVel, 0.0f, lerpProgress), 0.0f);
				lerpProgress += inverseDrift * Time.deltaTime;
			}
		}
		if(Mathf.Abs(this.transform.position.x) > boundX) {
			this.transform.position = new Vector2(Mathf.Clamp(this.transform.position.x, -boundX, boundX), this.transform.position.y);
		}
	}
}
