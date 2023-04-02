using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAppearanceController : MonoBehaviour
{
    private Renderer planetRenderer;

    void Start() {
        planetRenderer = GetComponent<Renderer>();
    }

    public void setColor(Color color) {
       planetRenderer.material.SetColor("_Color", color);
    }
}
