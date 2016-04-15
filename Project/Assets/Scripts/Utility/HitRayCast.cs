using UnityEngine;
using System.Collections;

public class HitRayCast : MonoBehaviour
{ 
    public bool HitRay(string hitObjectName_)
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (!Physics.Raycast(ray, out hit)) return false;

        if (hit.collider.gameObject.name != hitObjectName_) return false;
        
        return true;
    }
}
