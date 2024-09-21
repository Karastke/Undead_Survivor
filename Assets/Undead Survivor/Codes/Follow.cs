using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    RectTransform rect;


    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    void FixedUpdate()
    {
        Vector2 playerPos = new Vector2(GameManager.Instance.player.transform.position.x, GameManager.Instance.player.transform.position.y - 0.45f);
        rect.position = Camera.main.WorldToScreenPoint(playerPos);
    }
}
