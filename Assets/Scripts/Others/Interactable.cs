using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool canBeInteracted = true;
    public virtual void OnInteract() {}

}
