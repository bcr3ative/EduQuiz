using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class HoverDetector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler  {

	public NewGameManager newGameManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerEnter(PointerEventData eventData) {
		Button button = GameObject.Find(eventData.pointerEnter.transform.parent.name).GetComponent<Button>();
		newGameManager.updateHoveredButton(button);
		newGameManager.onButtonEnter();
	}

	public void OnPointerExit(PointerEventData eventData) {
		newGameManager.updateHoveredButton(null);
		newGameManager.onButtonExit();
	}
}
