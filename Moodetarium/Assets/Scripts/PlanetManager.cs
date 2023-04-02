using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public GameObject[] planets;
    private PlanetAppearanceController[] planetControllers;

    void Start() {
        planetControllers = new PlanetAppearanceController[planets.Length];
        for (int i = 0; i < planets.Length; i++)
        {
            planetControllers[i] = planets[i].GetComponent<PlanetAppearanceController>();
        }
    }
    public void setPlanetColors() {
        foreach (PlanetAppearanceController controller in planetControllers)
        {
            controller.setColor();
        }
    }
}
