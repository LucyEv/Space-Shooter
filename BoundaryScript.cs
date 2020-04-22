using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    private void OnTriggerExit(Collider other) // срабатывает, когда другой коллайдер покидает(EXIT) границы текущего коллайдера
    {
        Destroy(other.gameObject);
    }
}
