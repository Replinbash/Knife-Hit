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
		private Sequence _sequance; 

		[Header("Shake Settings")]
		private float _duration = 0.2f;
		private float _strenght = 0.1f;
		private int _vibrato = 15;

		private void OnEnable() => KnifeController.CircleDamage += DOShake;
		private void OnDisable()
		{
			KnifeController.CircleDamage -= DOShake;
			StopAllCoroutines();
			_sequance.Pause();
		}

		void Start()
		{
			DOTween.Init();
			GenerateRotate();
		}

		public void GenerateRotate()
		{
			switch (_circleSettings.rotateType)
			{
				case CircleSettings.RotateType.Left:
					StartCoroutine(DefaultRotate(-1f));
					break;

				case CircleSettings.RotateType.Right:
					StartCoroutine(DefaultRotate(+1f));
					break;

				case CircleSettings.RotateType.Random:
					RandomRotate();
					break;
			}
		}

		private Tween RandomRotate()
		{
			_sequance = DOTween.Sequence();
			_sequance.Append(transform.DORotate(new Vector3(0, 0, 360), _circleSettings.RotateSpeed, RotateMode.FastBeyond360)
			.SetEase(_circleSettings.EaseType));
			_sequance.Append(transform.DORotate(new Vector3(0, 0, -360), _circleSettings.RotateSpeed, RotateMode.FastBeyond360)
			.SetEase(_circleSettings.EaseType));
			_sequance.SetLoops(-1);

			return _sequance;
		}

		public IEnumerator DefaultRotate(float direction)
		{
			while (true)
			{
				transform.Rotate(0f, 0f, _circleSettings.RotateSpeed * direction * Time.deltaTime);
				yield return new WaitForEndOfFrame();
			}
		}

		public void DOShake() => transform.DOShakePosition(_duration, _strenght, _vibrato);
	}
}