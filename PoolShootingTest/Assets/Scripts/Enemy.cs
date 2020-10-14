using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICharacter
{
	public int hp;

	private void Update()
	{
		Destruction();
	}

	public void GetDamage(int damage)
	{
		hp -= damage;
	}

    public void Destruction()
    {
	    if (hp <= 0)
	    {
		    Destroy(gameObject);
	    }
    }
}
