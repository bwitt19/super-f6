using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    // Member variables
    public int InternalID;
    public double[] Position = new double[3];
    public double[] Velocity = new double[3];

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Update x, y, z position values based on speed here? Maybe assign
        //   velocity vectors elsewhere that the bodies will travel on
    }


}
