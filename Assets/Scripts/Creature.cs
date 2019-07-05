using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField]
    float velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void Move(Vector2 direction)
    {
        transform.Translate(direction * velocity * Time.deltaTime);
    }

    protected void MoveTo(Vector3 target)
    {

    }
}
