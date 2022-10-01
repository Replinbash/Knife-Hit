using System.Collections;
using System.Collections.Generic;
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
			Random
		}
		[Header("Rotation Settings")]
		public RotateType rotateType;

		public float rotateSpeed;
		public float RotateSpeed
		{
			get { return rotateSpeed; }
			set {}
		}

		[Header("Shake Settings")]
		public float Duration;
		public float Strenght;
		public int Vibrato;
	}
}