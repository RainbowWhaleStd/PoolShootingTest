using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
	public GameObject _object;
	public int startingPoolSize = 5;

	private Queue<GameObject> currentObjects;

	private void Awake()
	{
		currentObjects = new Queue<GameObject>();
	}

	private void Start()
	{
		for (int i = 0; i < startingPoolSize; i++)
		{
			CreateObject();
		}
	}

	public GameObject Spawn()
	{
		if (currentObjects.Count != 0)
		{
			var _object = currentObjects.Dequeue();

			_object.SetActive(true);
			_object.transform.SetParent(gameObject.transform);

			return _object;
		}
		else
		{
			return CreateObject(true, false); ;
		}
	}

	public void Despawn(GameObject _object)
	{
		if (_object != null)
		{
			_object.SetActive(false);

			currentObjects.Enqueue(_object);
			//_object.transform.SetParent(gameObject.transform);
		}
	}

	private GameObject CreateObject(bool setActive = false, bool addToQueue = true)
	{
		GameObject obj = null;

		if (_object != null)
		{
			obj = Instantiate(_object);
			obj.SetActive(setActive);
			obj.transform.parent = transform;

			if (addToQueue)
			{
				currentObjects.Enqueue(obj);
			}

			return obj;
		}
		else
		{
			print("Добавь префаб в pool.");

		}

		return obj;
	}

	void OnDestroy()
	{
		_object = null;
		currentObjects = null;
	}
}