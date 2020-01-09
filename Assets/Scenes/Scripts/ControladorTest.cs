using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorTest : MonoBehaviour
{
    public void StartTest()
    {
        PHPTestConexion test = (PHPTestConexion)FindObjectOfType(typeof(PHPTestConexion));
        test.GetRequest();
    }
}
