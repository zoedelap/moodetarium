using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAppearanceController : MonoBehaviour
{
    // public Color customColor;

    public void setColor(Color color) {
        // Get the Renderer component from the new cube
       var renderer = GetComponent<Renderer>();

       // Call SetColor using the shader property name "_Color" and setting the color to the custom color you created
       renderer.material.SetColor("_Color", color);
    }
}
