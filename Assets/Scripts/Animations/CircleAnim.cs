using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Knife.Attack;
using Knife.Core;

namespace Knife.Anim
{
	public class CircleAnim : BaseAnim
	{
		[Header("Particles")]
		[SerializeField] private ParticleSystem _breakWood;
		[SerializeField] private Transform _particleHolder;
		[SerializeField] private ParticleSystem[] _hitParticles;

		private CircleSpawner _circleSpawner;
		private bool _coroutineRunning = false;

		public static event Action<bool> NextCircle;

		private void OnEnable() => KnifeController.CircleDamage += HitCircleAnim;
		private void OnDisable() => KnifeController.CircleDamage -= HitCircleAnim;

		private void Start()
		{
			_circleSpawner = GetComponent<CircleSpawner>();
		}

		public void StartCircleAnim()
		{
			_coroutineRunning = true;
			_circleSpawner.DestroyPreviousCircle();
			StartCoroutine(NextCircleAnim());
		}

		public IEnumerator NextCircleAnim()
		{
			ParticleSystem obj = Instantiate(_breakWood, _particleHolder);
			obj.Play();
			yield return new WaitForSeconds(1.0f);
			obj.Clear();
			NextCircle?.Invoke(true);
			_coroutineRunning = false;
		}

		public void HitCircleAnim()
		{
			if (_coroutineRunning)
				return;

			foreach (var particle in _hitParticles)
			{
				ParticleSystem obj = Instantiate(particle, _particleHolder);
				obj.Play();
			}
		}
	}
}