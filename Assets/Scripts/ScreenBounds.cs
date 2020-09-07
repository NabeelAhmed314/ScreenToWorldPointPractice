using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    private Vector3 screenBounds;
    private Vector3 screenSize;
    public GameObject player;
    private float objectWidth;
    private float objectHeight;
    private void Start()
    {
        screenSize = new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z);
        screenBounds = Camera.main.ScreenToWorldPoint(screenSize);
        objectWidth = player.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = player.transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        player.transform.position = new Vector2(
            Mathf.Clamp(player.transform.position.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth),
            Mathf.Clamp(player.transform.position.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight));
    }
}