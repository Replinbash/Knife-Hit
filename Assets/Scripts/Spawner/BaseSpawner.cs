using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Knife.Core
{
	public abstract class BaseSpawner : MonoBehaviour
	{		
		protected internal int levelIndex = 0;

		private void Awake()
		{
			levelIndex = 0;
		}

		protected internal abstract void Initialize();
		protected internal abstract void CreatePool();

	}
}