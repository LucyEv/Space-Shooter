using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    private void OnTriggerExit(Collider other) // Cрабатывает, когда другой коллайдер покидает (Exit) границы текущего коллайдера 
                                               // It works when another Collider leaves (Exit) the borders of the current Collider
    {
        Destroy(other.gameObject);
    }
}
