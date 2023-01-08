using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimaCena : MonoBehaviour
{
    public static string UltimoLevel { get; private set; }
    private void OnDestroy()
    {
        UltimoLevel = gameObject.scene.name;
    }
    private void Start()
    {
        UltimoLevel = null;
        Debug.Log(UltimaCena.UltimoLevel);
    }
}
