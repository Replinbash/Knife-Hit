using UnityEngine;
using Knife.Circle;

namespace Knife.Level
{
	[CreateAssetMenu(menuName = "Knife/CreateNewLevel")]
	public class LevelSettings : ScriptableObject
	{
		[Header("Settings")]
		public int Index;
		public GameObject CirclePrefab;
		public GameObject ApplePrefab;

		[Header("Circle Property")]
		public CircleSettings CircleSettings;
		public bool AddApple;
		public AudioClip CircleHitAudio;
	}
}