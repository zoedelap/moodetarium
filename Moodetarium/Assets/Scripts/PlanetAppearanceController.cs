using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetAppearanceController : MonoBehaviour
{
    public Color customColor;

    // Update is called once per frame
    // void Update()
    // {
    //     // if (Input.GetKeyDown(KeyCode.Space)) {
    //     //     setColor();
    //     // }
    // }

    public void setColor() {
        // Get the Renderer component from the new cube
       var renderer = GetComponent<Renderer>();

        // Create a new RGBA color using the Color constructor and store it in a variable
        // Color customColor = new Color(0.4f, 0.9f, 0.7f, 1.0f);

       // Call SetColor using the shader property name "_Color" and setting the color to the custom color you created
       renderer.material.SetColor("_Color", customColor);
    }
}
