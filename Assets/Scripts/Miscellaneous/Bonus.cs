using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
	public ParticleSystem cutVFX;
	private Rigidbody2D _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Untagged"))
		{
			cutVFX.Play();
			ExplosionBonus();
			Destroy(gameObject, 1.5f);
		}
	}

	private void ExplosionBonus()
	{		
		_rb.freezeRotation = false;
		_rb.constraints = RigidbodyConstraints2D.None;
		transform.SetParent(null);
		_rb.gravityScale = 1;
		_rb.bodyType = RigidbodyType2D.Dynamic;
		Vector2 force = Vector3.up * 400f;
		_rb.AddForce(force);
	}
}
