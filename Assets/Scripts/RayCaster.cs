using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0f, 0f, angle);


        //raycast
        RaycastHit2D hit=Physics2D.Raycast(this.transform.position,direction.normalized,50f);

        //if we did something the collider that we hit is not null
        if (hit.collider != null)
        {
            print("Hit");
        }


        Color hitColor = Color.red;
        if (hit.collider != null)
        {
            hitColor = Color.green;
        }
        Debug.DrawRay(this.transform.position, direction.normalized * 50f, hitColor, 0.05f);

    }
}
