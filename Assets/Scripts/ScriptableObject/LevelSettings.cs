using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace Knife.Level
{
	[CreateAssetMenu(menuName = "Knife/CreateNewLevel")]
	public class LevelSettings : ScriptableObject
	{	
		public int Index;
		public GameObject CirclePrefab;
		public GameObject ApplePrefab;
		public int PoolSize;

		[Header("Circle Property")]
		public bool AddApple;
	}
}