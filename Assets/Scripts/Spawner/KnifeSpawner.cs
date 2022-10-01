using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Knife.Attack;
using System;
using Random = UnityEngine.Random;
using Knife.Anim;

namespace Knife.Core
{
	public class KnifeSpawner : BaseSpawner
	{
		[SerializeField] private CircleAnim _circleAnim;
		private Stack<GameObject> _pooledKnifeObjects;

		public GameObject _objectPrefab;	
		public static event Action<int> KnifeSize;

		private void OnEnable() => KnifeController.CircleDamage += GetKnifeObject;
		private void OnDisable() => KnifeController.CircleDamage -= GetKnifeObject;

		private void Start() => Initialize();

		protected internal override void Initialize()
		{
			CreatePool();
			GetKnifeObject();
		}

		protected internal override void CreatePool()
		{
			_pooledKnifeObjects = new Stack<GameObject>();
			var knifeSize = Random.Range(4, 7);

			for (int i = 0; i < knifeSize; i++)
			{
				GameObject obj = Instantiate(_objectPrefab, new Vector3(0, -3f, 0), Quaternion.identity, gameObject.transform);
				obj.SetActive(false);
				_pooledKnifeObjects.Push(obj);
			}
			KnifeSize?.Invoke(knifeSize);
		}

		protected internal void GetKnifeObject()
		{
			try
			{
				GameObject obj = _pooledKnifeObjects.Pop();
				obj.SetActive(true);
			}
			catch (InvalidOperationException)
			{				
				Debug.Log("Knife Stack Bitti!");
				_circleAnim.StartCircleAnim();
			}
		}
	}
}