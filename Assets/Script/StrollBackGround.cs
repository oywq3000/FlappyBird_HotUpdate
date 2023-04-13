using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StrollBackGround : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float strollSpeed = -5;

    public Transform[] strollBackground;
    private float _width;

    private float _startPosX;

    private int _peerCount;
    public float _limitX;


    // Start is called before the first frame update
    void Start()
    {
        _peerCount = strollBackground.Length;

        foreach (var background in strollBackground)
        {
            background.GetComponent<Rigidbody2D>().velocity = new Vector2(strollSpeed, 0);
        }


        _width = strollBackground[0].GetComponent<BoxCollider2D>().size.x;
        _limitX = strollBackground[0].position.x - _width;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            foreach (var background in strollBackground)
            {
                background.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

            return;
        }

        foreach (var background in strollBackground)
        {
            if (background.transform.position.x < _limitX)
            {
                var transform1 = background.transform;
                Vector3 pos = transform1.position;
                pos.x += _peerCount * _width;
                transform1.position = pos;
            }
        }
    }
}