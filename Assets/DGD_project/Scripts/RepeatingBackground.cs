using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public float verticalSize;

    private void Update()
    {
        if (transform.position.y < -verticalSize)
        {
            RepositionBackground();
        }
    }

    void RepositionBackground()
    {
        Vector2 groundOffSet = new Vector2(0, verticalSize * 2f);
        transform.position = (Vector2)transform.position + groundOffSet;
    }
}

