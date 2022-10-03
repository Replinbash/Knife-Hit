using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Knife.Attack;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace Knife.Circle
{
	public class CircleController : MonoBehaviour
	{
		[SerializeField] private CircleSettings _circleSettings;
		private float coroutineTimer = 3f;

		private void OnEnable() => KnifeController.CircleDamage += DOShake;
		private void OnDisable() => KnifeController.CircleDamage -= DOShake;

		void Start()
		{
			GenerateRotate();
		}

		void Update()
		{
			transform.Rotate(0f, 0f, _circleSettings.RotateSpeed * Time.deltaTime);
		}

		public void GenerateRotate()
		{
			switch (_circleSettings.rotateType)
			{
				case CircleSettings.RotateType.Left:
					_circleSettings.RotateSpeed = -_circleSettings.RotateSpeed;
					break;

				case CircleSettings.RotateType.Right:
					_circleSettings.RotateSpeed = +_circleSettings.RotateSpeed;
					break;

				case CircleSettings.RotateType.Random:
					{
						StartCoroutine(RandomRotation());
					}
					break;
			}
		}

		public IEnumerator RandomRotation()
		{
			while (true)
			{
				yield return new WaitForSeconds(coroutineTimer);
				_circleSettings.RotateSpeed = (Random.Range(0, 100) < 50 ? -1f : 1f) * Random.Range(50f, _circleSettings.RotateSpeed);
				Debug.Log("Random Rotate: " + _circleSettings.RotateSpeed);
			}
			
		}

		public void DOShake() => transform.DOShakePosition(_circleSettings.Duration, _circleSettings.Strenght, _circleSettings.Vibrato);
	}
}