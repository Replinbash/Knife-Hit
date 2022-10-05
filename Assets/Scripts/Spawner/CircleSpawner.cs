using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Knife.Level;
using Knife.Anim;
using System;
using Random = UnityEngine.Random;
using UnityEngine.Events;

namespace Knife.Core
{
	public class CircleSpawner : BaseSpawner
	{
		[SerializeField] private KnifeSpawner _knifeSpawner;
		private Queue<GameObject> _pooledCircleObjects = new Queue<GameObject>();	

		private Vector2[] _applePos = new Vector2[]
		{
			new Vector2(0f, 3.15f),
			new Vector2(-1f, 2.85f),
			new Vector2(-1f, -0.35f),
			new Vector2(0, -0.65f),
			new Vector2(0f, 3.15f),
			new Vector2(-1.6f, 2.25f),
			new Vector2(-1.9f, 1.25f),
			new Vector2(-1.6f, 0.25f),
		};

		public LevelSettings[] levelSettings;
		public UnityEvent gameOver;

		private void OnEnable() => CircleAnim.NextCircle += GetCircleObject;
		private void OnDisable() => CircleAnim.NextCircle -= GetCircleObject;

		private void Start() => Initialize();

		protected internal override void Initialize()
		{
			CreatePool();
			GetCircleObject(false);
		}

		protected internal override void CreatePool()
		{
			for (int i = 0; i < levelSettings.Length; i++)
			{
				var obj = Instantiate(levelSettings[i].CirclePrefab, gameObject.transform);
				obj.SetActive(false);
				_pooledCircleObjects.Enqueue(obj);

				if (levelSettings[i].AddApple)
				{
					for (int j = 0; j < levelSettings.Length; j++)
					{
						Instantiate(levelSettings[j].ApplePrefab, _applePos[Random.Range(0, _applePos.Length)], Quaternion.identity, obj.transform);
					}
				}
			}
		}

		protected internal void GetCircleObject(bool nextLevel)
		{
			try
			{
				if (nextLevel)
					_knifeSpawner.Initialize();

				GameObject obj = _pooledCircleObjects.Dequeue();
				obj.SetActive(true);
				GameManager.Instance.StageText.text = "Stage " + levelSettings[levelIndex].Index.ToString();
			}

			catch (InvalidOperationException)
			{
				gameOver?.Invoke();
				Debug.Log("Circle Queue Bitti!");
			}
		}

		protected internal void DestroyPreviousCircle()
		{
			levelIndex++;
			transform.GetChild(levelIndex - 1).gameObject.SetActive(false);			
		}
	}
}