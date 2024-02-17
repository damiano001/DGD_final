using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Borders
{    
    public float minXOffset = 1.5f, maxXOffset = 1.5f, minYOffset = 1.5f, maxYOffset = 1.5f;
    public float minX, maxX, minY, maxY;
}

public class PlayerMovement : MonoBehaviour
{
    public Borders borders;
    Camera mainCamera;
    bool controlIsActive = true;
    
    public static PlayerMovement instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        mainCamera = Camera.main;
        ResizeBorders();
    }

    private void Update()
    {
        if (controlIsActive)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0);
            movement *= 15 * Time.deltaTime;
            
            transform.position = Vector3.MoveTowards(transform.position, transform.position + movement, movement.magnitude);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, borders.minX, borders.maxX),
                                             Mathf.Clamp(transform.position.y, borders.minY, borders.maxY),  0  );
        }
    }

    void ResizeBorders()
    {
        borders.minX = mainCamera.ViewportToWorldPoint(Vector2.zero).x + borders.minXOffset;
        borders.minY = mainCamera.ViewportToWorldPoint(Vector2.zero).y + borders.minYOffset;
        borders.maxX = mainCamera.ViewportToWorldPoint(Vector2.right).x - borders.maxXOffset;
        borders.maxY = mainCamera.ViewportToWorldPoint(Vector2.up).y - borders.maxYOffset;
    }
}
