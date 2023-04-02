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
        if (num < 1) {
            return Color.grey;
        } else if (num < 2) {
            return new Color(0.07f, 0.23f, 0.54f, 1.0f);
        } else if (num < 3) {
            return new Color(0.40f, 0.07f, 0.66f, 1.0f);
        } else if (num < 4) {
            return new Color(0.94f, 0.00f, 0.30f, 1.0f);
        } else {
            return new Color(0.94f, 0.73f, 0.00f, 1.0f);
        }
    }
}
