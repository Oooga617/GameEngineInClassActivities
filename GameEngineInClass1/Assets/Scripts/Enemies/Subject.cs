using UnityEngine;
using System.Collections.Generic;

public abstract class Subject : MonoBehaviour
{
    public abstract void Notify(Subject subject);
}
