using Knife.Attack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Knife.Core;
using UnityEngine.UI;
using Knife.Anim;
using Color = UnityEngine.Color;

namespace Knife.UI
{
	public class Inventory : MonoBehaviour
	{
		[SerializeField] private Transform _content;
		[SerializeField] private GameObject _item;
		private int _nextItem = -1;

		public Color itemColor;

		private void OnEnable()
		{
			KnifeSpawner.KnifeSize += ListItems;
			KnifeController.CircleDamage += ChangeSpriteColor;
			CircleAnim.NextCircle += ClearItems;
		}
		private void OnDisable()
		{
			KnifeSpawner.KnifeSize -= ListItems;
			KnifeController.CircleDamage -= ChangeSpriteColor;
			CircleAnim.NextCircle -= ClearItems;
		}

		private void ListItems(int knifeSize)
		{
			for (int i = 0; i < knifeSize; i++)
			{
				var obj = Instantiate(_item, _content.transform);
			}
		}

		private void ClearItems(bool value)
		{
			if (value)
			{
				foreach (Transform item in _content)
				{
					Destroy(item.gameObject);
				}
			}

			_nextItem = -1;
		}

		public void ChangeSpriteColor()
		{
			_nextItem++;
			var item = _content.transform.GetChild(_nextItem);
			item.gameObject.GetComponent<Image>().color = itemColor;
		}

	}
}