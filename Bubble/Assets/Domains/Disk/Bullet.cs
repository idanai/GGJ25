using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 8;

    private bool _dead = false;
    
    private void Update()
    {
        transform.position +=  _moveSpeed * Time.deltaTime * Vector3.up;

        if (transform.position.y > 10)
            die();
    }

    protected virtual void OnHitModifier(ModifierBubble modifierBubble)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_dead) //prevent hitting 2 on same frame
            return;
        
        ModifierBubble modifierBubble = other.gameObject.GetComponent<ModifierBubble>();
        if (modifierBubble != null)
            OnHitModifier(modifierBubble);
        
        die();
    }

    private void die()
    {
        Destroy(gameObject);
        _dead = true;
    }
}
