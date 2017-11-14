using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public float damage;
    bool attackedPimple;
	
	// Update is called once per frame
	void Update ()
    {
        //Debug.Log(attackedPimple);
        if (Input.GetButton("Fire1"))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                PimpleScript pimpleScript = hit.transform.gameObject.GetComponent<PimpleScript>();

                if (pimpleScript != null && !attackedPimple)
                {
                    pimpleScript.takeDamage(damage);
                    if (pimpleScript.hp <= 0)
                        attackedPimple = true;
                }

            }
            if (attackedPimple){
                if (Input.GetButtonDown("Fire1"))
                    attackedPimple = false;
            }
        }
    }
}
