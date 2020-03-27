﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShooter : MonoBehaviour
{
    public CircleCollider2D Collider;
    private Vector2 _startPos;
    [SerializeField] private float _radius = 0.75f;
    [SerializeField] private float _throwSpeed = 30f;
    private Bird _bird;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseUp()
    {
        Collider.enabled = false;
        Vector2 velocity = _startPos - (Vector2)transform.position;
        float distance = Vector2.Distance(_startPos, transform.position);

        _bird.Shoot(velocity, distance, _throwSpeed);

        //kembalikan ketapel ke posisi awal
        gameObject.transform.position = _startPos;
    }

    void OnMouseDrag()
    {
        //mengubah posisi mouse ke world position
        Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //hitung supaya karet ketapel berada dalam radius yang ditentukan
        Vector2 dir = p - _startPos;
        if (dir.sqrMagnitude > _radius)
        {
            dir = dir.normalized * _radius;
        }
        transform.position = _startPos + dir;
    }

    public void InitiateBird(Bird bird)
    {
        _bird = bird;
        _bird.MoveTo(gameObject.transform.position, gameObject);
        Collider.enabled = true;
    }
}
