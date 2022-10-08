using System.Collections;
using UnityEngine;
using DG.Tweening;
using Knife.Attack;
using Knife.Level;

namespace Knife.Circle
{
	public class CircleController : MonoBehaviour
	{
		[SerializeField] private LevelSettings _level;
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
			switch (_level.CircleSettings.rotateType)
			{
				case CircleSettings.RotateType.Left:
					StartCoroutine(DefaultRotate(-1f));
					break;

				case CircleSettings.RotateType.Right:
					StartCoroutine(DefaultRotate(+1f));
					break;

				case CircleSettings.RotateType.HalfRotate:
					RandomRotate(false);
					break;
				case CircleSettings.RotateType.FullRotate:
					RandomRotate(true);
					break;
			}
		}

		private void RandomRotate(bool isFullRotate)
		{
			_sequance = DOTween.Sequence();
			_sequance.Append(transform.DORotate(new Vector3(0, 0, 360), _level.CircleSettings.RotateSpeed, RotateMode.FastBeyond360)
			.SetEase(_level.CircleSettings.EaseType));

			if (isFullRotate)
			{
				_sequance.Append(transform.DORotate(new Vector3(0, 0, -360), _level.CircleSettings.RotateSpeed, RotateMode.FastBeyond360)
				.SetEase(_level.CircleSettings.EaseType));
			}

			_sequance.SetEase(_level.CircleSettings.EaseType);
			_sequance.SetLoops(-1);
		}

		public IEnumerator DefaultRotate(float direction)
		{
			while (true)
			{
				transform.Rotate(0f, 0f, _level.CircleSettings.RotateSpeed * direction * Time.deltaTime);
				yield return new WaitForEndOfFrame();
			}
		}

		public void DOShake() => transform.DOShakePosition(_duration, _strenght, _vibrato);
	}
}