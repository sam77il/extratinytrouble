using UnityEngine;

public class Keys : Interactables
{
    [SerializeField] private string keyNumber; // The number this key represents
    private Keypad keypad; // Reference to the Keypad

    private void Start()
    {
        // find keypad script in one of the parents
        keypad = GetComponentInParent<Keypad>();

        Debug.Log(keypad.gameObject.name);

    }

    public override void Use()
    {
        keypad.PressKey(keyNumber);
    }

}
