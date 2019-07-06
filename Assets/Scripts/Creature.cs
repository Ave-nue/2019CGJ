using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : OccludeObject
{
    [SerializeField]
    float speed = 5;
    public Rigidbody2D rg;

    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();

        rg = GetComponent<Rigidbody2D>();
        if (rg == null)
            Debug.Log("null");
        else
            Debug.Log(rg);
    }

    public new void Update()
    {
        base.Update();
        

        //rg.velocity = new Vector2(0, 0);
    }

    public void Move(Vector2 direction)
    {

        rg.velocity = direction * speed;
        //transform.Translate(direction * speed * Time.deltaTime);
    }

    protected void MoveTo(Vector3 target)
    {
        Move((target - transform.position).normalized);
    }
}
