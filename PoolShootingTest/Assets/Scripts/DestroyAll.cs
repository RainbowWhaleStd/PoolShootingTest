using System;
using UnityEditor;
using UnityEngine;

public class DestroyAll : MonoBehaviour
{
	public static BoxCollider2D Colllider;
	public float offset = 1.5f;
	private Vector2 viewportSize;
	private Bounds colBounds;

	private void Awake()
	{
		Colllider = GetComponent<BoxCollider2D>();
	}
	private void Start()
	{
		ResizeCollider();
	}

	void ResizeCollider()
	{
		if (Camera.main != null) viewportSize = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)) * 2;

		viewportSize.x *= offset;
		viewportSize.y *= offset;

		Colllider.size = viewportSize;
		colBounds = Colllider.bounds;
	}

	public void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.CompareTag("PlayerBullet")) coll.GetComponentInParent<Pool>().Despawn(coll.gameObject);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;

		Gizmos.DrawLine(new Vector2(colBounds.min.x, colBounds.min.y), new Vector2(colBounds.max.x, colBounds.min.y));
		Gizmos.DrawLine(new Vector2(colBounds.min.x, colBounds.min.y), new Vector2(colBounds.min.x, colBounds.max.y));
		Gizmos.DrawLine(new Vector2(colBounds.min.x, colBounds.max.y), new Vector2(colBounds.max.x, colBounds.max.y));
		Gizmos.DrawLine(new Vector2(colBounds.max.x, colBounds.max.y), new Vector2(colBounds.max.x, colBounds.min.y));
	}
}