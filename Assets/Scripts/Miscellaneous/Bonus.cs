using System;
using UnityEngine;

public class Bonus : MonoBehaviour
{
	public ParticleSystem cutVFX;
	public AudioClip cutAudio;
	private CircleCollider2D _collider;
	private SpriteRenderer _sprite;

	public static event Action BonusDamage;

	private void Awake()
	{
		_collider = GetComponent<CircleCollider2D>();
		_sprite = GetComponent<SpriteRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Untagged"))
		{
			ExplosionBonus();
			AudioManager.Instance.PlayAudio(cutAudio);
			cutVFX.Play();
			Destroy(gameObject, 1.5f);
			BonusDamage.Invoke();
		}

		if (collision.CompareTag("Apple") || collision.CompareTag("Knife"))
			Destroy(gameObject);
	}

	private void ExplosionBonus()
	{
		_collider.enabled = false;
		_sprite.enabled = false;
		transform.SetParent(null);
	}
}
