using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    GameObject board;
    public Sprite[] images;
    bool already = true;
    public int x;
    public int y;
    public int var;

    private void OnMouseDown()
    {
        if (already == true)
        {
            int X = board.GetComponent<Game>().nextTurn();
            var = X;
            spriteRenderer.sprite = images[X];
            already = false;
            board.GetComponent<Game>().onX(this);
        }
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        board = GameObject.Find("Board");
    }

    void Start()
    {
        spriteRenderer.sprite = null;
    }

}
