using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightHandler : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private List<GameObject> lightsToControl; // Glisse tes sources de lumière ici
    [SerializeField] private InputAction toggleAction; // Optionnel : pour tester au clavier

    private bool isLightOn = true;

    private void OnMouseDown()
    {
        ToggleLights();
    }

    void Update()
    {
        if (toggleAction.triggered)
        {
            ToggleLights();
        }
    }

    public void ToggleLights()
    {
        isLightOn = !isLightOn;
        Debug.Log("Lumières allumées : " + isLightOn);

        foreach (var lightObj in lightsToControl)
        {
            if (lightObj != null)
            {
                lightObj.SetActive(isLightOn);
            }
        }
    }

    // Gestion de l'input clavier
    private void OnEnable() => toggleAction.Enable();
    private void OnDisable() => toggleAction.Disable();
}