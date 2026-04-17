using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject tablePrefab;
    public GameObject chairPrefab;
    public GameObject decoPrefab;

    [Header("Inputs")]
    public InputActionReference tableSpawnAction;
    public InputActionReference chairSpawnAction;
    public InputActionReference decoSpawnAction;
    public InputActionReference resetAction;

    public float distance = 2.0f;

    void Update()
    {
        // On vérifie chaque action
        if (tableSpawnAction.action.triggered) Spawn(tablePrefab);
        if (chairSpawnAction.action.triggered) Spawn(chairPrefab);
        if (decoSpawnAction.action.triggered) Spawn(decoPrefab);
        
        if (resetAction.action.triggered) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Spawn(GameObject prefab)
    {
        if (prefab == null) return;

        Camera mainCam = Camera.main;
        if (mainCam == null) return;

        Vector3 forward = mainCam.transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 finalPos = mainCam.transform.position + (forward * distance);

        float groundY = 0f;
        if (prefab == decoPrefab) groundY = 0.75f; 

        finalPos.y = groundY;

        Instantiate(prefab, finalPos, Quaternion.Euler(0, mainCam.transform.eulerAngles.y, 0));
        
        Debug.Log("Objet spawné à : " + finalPos); 
    }
}