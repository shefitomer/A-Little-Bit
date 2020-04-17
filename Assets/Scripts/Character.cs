using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
	private GameObject DefaultImage;
	public GameObject GO;
	public Vector2 JumpingSpeed = new Vector2(10,10);
	private Vector2 Movement = new Vector2(1,1);
	public float WalkingSpeed = 0.1f;

	public Character(GameObject CharacterGO, Vector2 position)
	{
		this.DefaultImage = CharacterGO;
		GO = (GameObject)GameObject.Instantiate(CharacterGO);
		GO.transform.position = position;
		GO.name = "Player";
		GO.AddComponent<BoxCollider2D>();
	}

	public void Move(float x, float y)
	{
		GO.transform.position = new Vector2(x,y);
	}

	public void MoveOnXAxis(float difference)
	{
		GO.transform.position = new Vector2(GO.transform.position.x + difference,
											  GO.transform.position.y);
	}

	public void Jump()
	{
		float inputX = Input.GetAxis ("Horizontal");
		float inputY = Input.GetAxis ("Vertical");

		Movement = new Vector2(
			JumpingSpeed.x * inputX,
			JumpingSpeed.y * inputY);

		GO.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 30), ForceMode2D.Impulse);

	}

}
