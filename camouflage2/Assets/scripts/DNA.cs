using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class DNA : MonoBehaviour
{
    public float r;
    public float g;
    public float b;
    bool dead = false;
    public float timetodie = 0f;
    SpriteRenderer spriteRenderer;
    Collider2D collider2d;
    populationmanager Populationmanager;
    
   
    void OnMouseDown()
    {
        Populationmanager = GetComponent<populationmanager>();
        print("yo");
        dead = true;
        
        timetodie = populationmanager.elapsed;
        Debug.Log("Dead at "+timetodie);
        spriteRenderer.enabled = false;
        collider2d.enabled = false;
        
    }
     void Start()
    {
        Populationmanager = GetComponent<populationmanager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(r, g, b);
        collider2d = GetComponent<Collider2D>();
    }

    
}
