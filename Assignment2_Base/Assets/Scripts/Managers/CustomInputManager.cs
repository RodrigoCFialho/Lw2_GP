using UnityEngine;

public class CustomInputManager : MonoBehaviour
{
    public static CustomInputManager Instance { get; private set; }
    private CustomInput customInput;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            customInput = new CustomInput();
            customInput.Enable();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public CustomInput GetCustomInput()
    {
        return customInput;
    }
}
