using System;

using UnityEngine;

using JetBrains.Annotations;

namespace CookingPrototype.Kitchen {
	[RequireComponent(typeof(FoodPlace))]
	public sealed class FoodTrasher : MonoBehaviour {

		FoodPlace _place = null;
		float     _timer = 0f;


		float _maxTimeBetweenTaps = 0.5f;
		float _lastTapTime = 0;

		void Start() {
			_place = GetComponent<FoodPlace>();
			_timer = Time.realtimeSinceStartup;
		}

		/// <summary>
		/// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
		/// </summary>
		[UsedImplicitly]
		public void TryTrashFood() {
			if (Time.time - _lastTapTime <= _maxTimeBetweenTaps) {
				var food = _place.CurFood;
				if ( food == null ) {
					return;
				}

				if (food.CurStatus == Food.FoodStatus.Overcooked) {
					OnDoubleTap();
					return;
				}
			}
			_lastTapTime = Time.time;
		}

		private void OnDoubleTap() {
			_place.FreePlace();
		}
	}
}
