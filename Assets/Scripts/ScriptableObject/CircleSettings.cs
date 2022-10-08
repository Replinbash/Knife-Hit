using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Knife.Circle
{
	[CreateAssetMenu(menuName = "Knife/CircleSettings")]
	public class CircleSettings : ScriptableObject
	{
		public enum RotateType
		{
			Left,
			Right,
			HalfRotate,
			FullRotate,
		}

		[Header("Rotation Settings")]
		public RotateType rotateType;
		public Ease EaseType;
		public float rotateSpeed;
		public float RotateSpeed { get { return rotateSpeed; } }		
	}
}