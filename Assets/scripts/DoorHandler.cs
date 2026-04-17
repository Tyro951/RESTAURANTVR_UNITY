using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    private bool isOpen = false;
    
    [Header("Réglages")]
    [SerializeField] private float openAngle = 90f; // L'angle d'ouverture
    [SerializeField] private float smoothSpeed = 3f; // Vitesse de l'animation

    private Quaternion closedRotation;
    private Quaternion targetRotation;

    void Start()
    {
        // On mémorise la rotation de départ (fermée)
        closedRotation = transform.rotation;
        targetRotation = closedRotation;
    }

    void Update()
    {
        // On fait pivoter le pivot vers la rotation cible progressivement
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smoothSpeed);
    }

    // Cette fonction sera appelée au clic ou via le XR Ray Interactor
    public void ToggleDoor()
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            // On calcule la rotation ouverte par rapport au départ
            targetRotation = closedRotation * Quaternion.Euler(0, openAngle, 0);
        }
        else
        {
            targetRotation = closedRotation;
        }
    }

    // Pour tester au clic de souris sur PC
    private void OnMouseDown()
    {
        ToggleDoor();
    }
}