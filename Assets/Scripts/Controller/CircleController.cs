using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Knife.Attack;

namespace Knife.Circle
{
	public class CircleController : MonoBehaviour
	{
		[SerializeField] private CircleSettings _circleSettings;
		private Coroutine _coroutine;

		private void OnEnable() => KnifeController.CircleDamage += DOShake;
		private void OnDisable() => KnifeController.CircleDamage -= DOShake;

		void Start()
		{
			GenerateRotate();
		}

		public void GenerateRotate()
		{
			switch (_circleSettings.rotateType)
			{
				case CircleSettings.RotateType.Left:
					_coroutine = StartCoroutine(RotateCircle(false, -1f));
					break;

				case CircleSettings.RotateType.Right:
					_coroutine = StartCoroutine(RotateCircle(false, 1f));
					break;

				case CircleSettings.RotateType.Random:
					_coroutine = StartCoroutine(RotateCircle(true, -1f));
					break;
			}
		}

		public IEnumerator RotateCircle(bool isRandom, float value)
		{
			while (true)
			{
				if (isRandom)
					transform.DORotate(new Vector3(0, 0, value), _circleSettings.RotateSpeed * Time.deltaTime,
					RotateMode.FastBeyond360);

				else
					transform.Rotate(0f, 0f, _circleSettings.RotateSpeed * value * Time.deltaTime);

				yield return null;
			}

		}

		public void DOShake() => transform.DOShakePosition(_circleSettings.Duration, _circleSettings.Strenght, _circleSettings.Vibrato);
	}
}