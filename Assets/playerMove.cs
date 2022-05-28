using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float move = 10;
    public float speed = 2.0f;
    private bool isRight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal")*speed*Time.deltaTime,0,0);
        Vector3 characterscale = transform.localScale;
        if(Input.GetAxis("Horizontal")<0)
        {
            characterscale.x = 2;
        }
        if(Input.GetAxis("Horizontal")>0)
            {
            characterscale.x = -2;
            }
        transform.localScale = characterscale;
    }
}
