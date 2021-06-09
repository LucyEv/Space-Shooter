using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    private void OnTriggerExit(Collider other) // Срабатывает, когда другой коллайдер покидает (Exit) границы текущего коллайдера 
                                               // It starts and works when another Collider leaves (Exit) the borders of the current Collider
    {
        Destroy(other.gameObject);
    }
}
