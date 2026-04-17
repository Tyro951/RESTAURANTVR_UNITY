using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement; 

public class InputSpawner : MonoBehaviour
{
    [Header("Table (Main Droite - Gâchette)")]
    public GameObject tablePrefab;
    public InputActionReference tableSpawnAction;

    [Header("Chaise (Main Droite - Bouton A)")]
    public GameObject chairPrefab;
    public InputActionReference chairSpawnAction;

    [Header("Assiette (Main Gauche - Gâchette)")]
    public GameObject decoPrefab;
    public InputActionReference decoSpawnAction;

    public float distance = 1.5f;

    [Header("Reset Scene (Bouton Menu ou Autre)")]
    public InputActionReference resetAction;

    void Update()
    {
        if (tableSpawnAction.action.triggered) Spawn(tablePrefab);
        if (chairSpawnAction.action.triggered) Spawn(chairPrefab);
        if (decoSpawnAction.action.triggered) Spawn(decoPrefab);
        if (resetAction.action.triggered)
        {
            ResetScene();
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Spawn(GameObject prefab)
    {
        if (prefab == null) return;
        Transform cam = Camera.main.transform;
        
        Vector3 randomOffset = new Vector3(Random.Range(-0.2f, 0.2f), 0, Random.Range(-0.2f, 0.2f));
        Vector3 spawnPos = cam.position + (cam.forward * distance) + randomOffset;
        
        spawnPos.y = 0.8f; 
        Instantiate(prefab, spawnPos, Quaternion.Euler(0, cam.eulerAngles.y, 0));
    }
}