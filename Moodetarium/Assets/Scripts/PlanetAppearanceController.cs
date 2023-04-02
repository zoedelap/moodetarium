using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAppearanceController : MonoBehaviour
{
    private Renderer planetRenderer;
    private float originalScale;

    void Start() {
        planetRenderer = GetComponent<Renderer>();
        originalScale = gameObject.transform.localScale.x;
    }

    public void setColor(Color color) {
       planetRenderer.material.SetColor("_Color", color);
    }

    public void setSize(float scaleValue) {
        scaleValue = originalScale * scaleValue;
        gameObject.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
    }
}
