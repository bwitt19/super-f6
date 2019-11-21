using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    // Member variables
    public int InternalID;
    public double[] Position = new double[3];
    public double[] Velocity = new double[3];
    private bool Focus = False;


    // Start is called before the first frame update
    void Start()
    {
        // Create a trail based on the trajectory the object will take (can do
        //   after everything else is done -- eventual functionality)
    }

    // Update is called once per frame
    void Update()
    {
        // Update x, y, z position values based on speed here? Maybe assign
        //   velocity vectors elsewhere that the bodies will travel on
    }

    /*
    Eventual functionality to put in an onClick() type function: setting focus
    on a singular CelestialBody and allowing it to shine through the rest.
    */

    void setFocus(bool newFocus) { Focus = newFocus; }

}
