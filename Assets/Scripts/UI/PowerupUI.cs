using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupUI : MonoBehaviour 
{
	public Powerup Powerup;
	[SerializeField]
	private Image _PowerupSpriteRenderer;
	[SerializeField]
	private Slider _Slider; 

	public void Initialize(Powerup powerup)
	{
		_PowerupSpriteRenderer.sprite = powerup.PowerupSprite;
		StartCoroutine(PowerupTimer(powerup.PowerupTime));
	}

	private IEnumerator PowerupTimer(float totalTime)
	{
		float time = 0;
		while (time < totalTime)
		{
			yield return new WaitForSeconds(0.1f);
			time += 0.1f;
			_Slider.value = (totalTime - time) / totalTime;
		}
		Destroy(gameObject);
	}
}
