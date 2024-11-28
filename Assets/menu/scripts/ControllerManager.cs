using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    [SerializeField] private GameObject StartButton;
    [SerializeField] private GameObject OptionsButton;
    [SerializeField] private GameObject QuitButton;

    private float hovering;
    private bool onOptions;
    private bool onSecondScreen;
    private float moveInput;

    void Start()
    {
        hovering = 1;
        onOptions = false;
        onSecondScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        ControllerUpDown();

    }

    private void ControllerUpDown()
    {

        moveInput = moveInput = UserInput.instance.moveInput.y; ;
        if (moveInput > 0)
        {
            hovering += 1;
        }
        if (moveInput < 0)
        {
            hovering -= 1;
        }
        if (onOptions == false && hovering > 3)
        {
            hovering = 3;
        }
        if (onOptions == false && hovering < 0)
        {
            hovering = 1;
        }

    }

    private void SelectedOption()
    {
      
    }
}
