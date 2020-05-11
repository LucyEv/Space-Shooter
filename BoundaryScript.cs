using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryScript : MonoBehaviour
{
    private void OnTriggerExit(Collider other) // Cрабатывает, когда другой Коллайдер покидает(Exit) границы текущего Коллайдера
    {
        Destroy(other.gameObject);
    }
}
