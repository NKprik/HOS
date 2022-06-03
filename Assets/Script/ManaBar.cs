using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image fill;

    public void SetMaxMana(int Mana)
	{
		slider.maxValue = Mana;
		slider.value = Mana;

		fill.color = gradient.Evaluate(1f);
	}

	public void SetMana(int Mana)
	{
		slider.value = Mana;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

    
}


