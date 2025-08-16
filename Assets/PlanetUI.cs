using UnityEngine;
using UnityEngine.UI;

public class PlanetUI : MonoBehaviour
{
    public PlanetHealth planet;
    public Slider hpBar;

    void Update()
    {
        if (planet && hpBar)
            hpBar.value = planet.HP01();
    }
}
