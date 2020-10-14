using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Bullet : MonoBehaviour
{
	[SerializeField] private int damage;

	private Controller2D controller;
	private bool isPlayerBullet;
	private bool isEnemyBullet;

	private void Awake()
	{
		controller = GetComponent<Controller2D>();
		isPlayerBullet = gameObject.CompareTag("PlayerBullet");
		isEnemyBullet = gameObject.CompareTag("EnemyBullet");
	}

	private void FixedUpdate()
	{
		controller.MoveAxisY();
	}

	public void OnTriggerEnter2D(Collider2D coll)
	{
		switch (coll.tag)
		{
			case "Enemy":
				if (isPlayerBullet)
				{
					coll.GetComponent<ICharacter>().GetDamage(damage);
					GetComponentInParent<Pool>().Despawn(gameObject);
				}
				break;

			case "Player":
				if (isEnemyBullet)
				{
					coll.GetComponent<ICharacter>().GetDamage(damage);
					GetComponentInParent<Pool>().Despawn(gameObject);
				}
				break;
		}
	}
}