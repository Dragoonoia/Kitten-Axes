using UnityEditor;
using UnityEngine;
using Fusion;

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

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


}
