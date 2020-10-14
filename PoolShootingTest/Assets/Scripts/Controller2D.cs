using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Controller2D : MonoBehaviour
{
	public float speed;

	private Rigidbody2D rb2d;
	private Vector2 velocity;

	private void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	public void MovePosition(Vector2 direction)
	{
		rb2d.MovePosition(direction);
	}

	public void MoveAxisY()
	{
		rb2d.velocity = transform.up * speed;
	}
}