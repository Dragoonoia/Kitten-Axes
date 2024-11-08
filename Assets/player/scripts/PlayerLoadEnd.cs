using Unity.VisualScripting;
using UnityEngine;

public class PlayerLoadEnd : MonoBehaviour
{
    [SerializeField] Canvas CanvasLoad;
    void Awake()
    {
        CanvasLoad = FindFirstObjectByType<Canvas>();
       Destroy(CanvasLoad.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
