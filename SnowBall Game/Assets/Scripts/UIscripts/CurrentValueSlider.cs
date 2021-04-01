using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentValueSlider : MonoBehaviour {

public Slider Slider;
public Text Text;

private void LateUpdate() {
	Text.text = Slider.value.ToString();
	}
}
