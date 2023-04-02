using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public GameObject[] planets;
    private Dictionary<string, PlanetAppearanceController> planetControllers;

    void Start() {
        planetControllers = new Dictionary<string, PlanetAppearanceController>();
        foreach (GameObject planet in planets)
        {
            PlanetAppearanceController controller = planet.GetComponent<PlanetAppearanceController>();
            planetControllers.Add(planet.name, controller);
        }
    }
    public void setPlanetColors(Dictionary<string, float> moods) {
        foreach (KeyValuePair<string, PlanetAppearanceController> kvp in planetControllers)
        {
            Color mappedColor = convertColor(moods[kvp.Key]);
            kvp.Value.setColor(mappedColor);
        }
    }

    Color convertColor(float num) {
        if (num <= 2.5) {
            return Color.red;
        } else {
            return Color.blue;
        }
    }
}
