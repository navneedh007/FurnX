using UnityEngine;

public class ModelRotation : MonoBehaviour
{
    public float rotationAmount = 30.0f; // Amount to rotate the model.

    private void Update()
    {
        // Check for button presses and perform rotation.
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RotateLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RotateRight();
        }
    }

    public void RotateLeft()
    {
        // Rotate the model to the left by the specified amount.
        transform.Rotate(Vector3.up, -rotationAmount);
    }

    public void RotateRight()
    {
        // Rotate the model to the right by the specified amount.
        transform.Rotate(Vector3.up, rotationAmount);
    }
}
