using UnityEditor;
using UnityEngine;

public class UserInput : MonoBehaviour

{
    public static UserInput instance;

    [HideInInspector] public Controls controls;
    [HideInInspector] public Vector2 moveInput;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        controls = new Controls();

        controls.Movement.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
    }

    public void OnEnable()
    {
        controls.Enable();
    }

    public void OnDisable()
    {
        controls.Disable();
    }


}
