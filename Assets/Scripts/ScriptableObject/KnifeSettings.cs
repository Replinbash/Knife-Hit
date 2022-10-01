using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Knife.Attack
{
	[CreateAssetMenu(menuName = "Knife/KnifeSettings")]
	public class KnifeSettings : ScriptableObject
	{
		[Header("Knife Direction Settings")]
		public int Speed;
		public Vector2 Direction;

		[Header("Knife Collider Settings")]
		public Vector2 Offset;
		public Vector2 Size;
	}
}