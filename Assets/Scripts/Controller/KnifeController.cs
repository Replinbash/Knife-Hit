using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
using Knife.Core;

namespace Knife.Attack
{
	public class KnifeController : MonoBehaviour
	{
		[SerializeField] private KnifeSettings _knifeSettings;

		private Rigidbody2D _rb;
		private BoxCollider2D _collider;

		public static event Action CircleDamage;

		private void Awake()
		{
			_rb = GetComponent<Rigidbody2D>();
			_collider = GetComponent<BoxCollider2D>();
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				KnifeMovement();
			}

			if (Input.GetKeyDown(KeyCode.Mouse1))
			{
				SceneManagement.Instance.LoadScene(1);
			}
		}

		private void KnifeMovement()
		{
			//_rb.velocity = _playerSettings.Direction * speed * Time.deltaTime;
			_rb.angularDrag = Random.Range(500f, 700f);
			_rb.AddForce(_knifeSettings.Direction * _knifeSettings.Speed, ForceMode2D.Force);
		}

		public Vector2 RandomVector2(float minAngle, float maxAngle)
		{
			float randomX = Random.Range(-minAngle, -maxAngle);
			float randomY = Random.Range(-minAngle, -maxAngle);
			return new Vector2(randomX, randomY);
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Boundry"))
			{
				GameManager.Instance.GameOver();
				Destroy(gameObject);
			}
		}

		private void OnCollisionEnter2D(Collision2D hit)
		{
			if (hit.gameObject.CompareTag("Circle"))
			{
				OnKnifeHit(hit);
				CircleDamage?.Invoke();
			}

			if (hit.gameObject.CompareTag("Knife"))			
				ReleaseKnife();			
		}

		private void OnKnifeHit(Collision2D hit)
		{
			_rb.velocity = Vector2.zero;
			_rb.isKinematic = true;
			gameObject.tag = "Knife";
			_collider.offset = _knifeSettings.Offset;
			_collider.size = _knifeSettings.Size;
			transform.SetParent(hit.gameObject.transform);
		}

		private void ReleaseKnife()
		{
			_rb.bodyType = RigidbodyType2D.Dynamic;
			_rb.constraints = RigidbodyConstraints2D.None;
			_rb.gravityScale = 1;
			_rb.velocity = Vector2.zero;
			_rb.AddForce(RandomVector2(1f, 2f) * _knifeSettings.Speed, ForceMode2D.Impulse);
			gameObject.tag = "Untagged";
		}		
	}
}