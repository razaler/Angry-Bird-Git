using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBird : Bird
{
    public Sprite boom;

    void Bomb()
    {
        RigidBody.bodyType = RigidbodyType2D.Static;
        Collider.radius *= 6.25f;
        this.GetComponent<SpriteRenderer>().sprite = boom;
        StartCoroutine(DestroyAfter(1));
    }

    public override void OnTap()
    {
        Bomb();
    }

}
