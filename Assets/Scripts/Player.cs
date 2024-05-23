using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{

    private Vector2 initPos;
    private GameController gc;
    private InterfaceController ic;
    private Rigidbody2D rb;
    private TrailRenderer tr;
    float initTrTime;

#nullable enable

    public ScriptableObject? playerStats;

#nullable disable
    // Start is called before the first frame update
    void Awake()
    {
        initPos = transform.position;
        ic = InterfaceController.ic;
        gc = GameController.gc;
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime * 100);
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Respawn"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        initTrTime = tr.time;
        tr.time = -1;
        rb.MovePosition(initPos);
        rb.velocity = Vector2.zero;
        Invoke("ResetTrails", 0.1f);
    }

    void ResetTrails()
    {
        tr.time = initTrTime;
    }
}
