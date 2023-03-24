using UnityEngine;
using UnityEngine.UI;

public class StaticHealthBarBehaviour : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetHealth(float health, float maxHealth)
    {
        slider.value = health;
        slider.maxValue = maxHealth;
    }
}