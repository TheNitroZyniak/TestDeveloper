using UnityEngine;
using UnityEngine.UI;

using CookingPrototype.Controllers;

using TMPro;

public class StartWindow : MonoBehaviour {
	public Button PlayButton = null;
	public GameObject TapBlock = null;
	public TMP_Text OrdersToWinText = null;


	private void Start() {
		GameplayController.Instance.TotalOrdersServedChanged += OnOrdersChanged;

		Time.timeScale = 0f;
		TapBlock?.SetActive(true);

		PlayButton?.onClick.AddListener(StartGame);
	}

	void OnDestroy() {
		if ( GameplayController.Instance ) {
			GameplayController.Instance.TotalOrdersServedChanged -= OnOrdersChanged;
		}
	}

	void StartGame() {
		Time.timeScale = 1f;
		TapBlock?.SetActive(false);
		gameObject.SetActive(false);
	}

	void OnOrdersChanged() {
		var gc = GameplayController.Instance;
		OrdersToWinText.text = gc.OrdersTarget.ToString();
	}
}
