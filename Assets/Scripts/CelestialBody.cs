using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{

    // Member variables
    public int InternalID { get; set; }
    public double[] Position { get; set; } = new double[3];
    public double[] Velocity { get; set; } = new double[3];
    public bool Focus { get; set; } = false;

    // Default constructor
    public CelestialBody() { }

    // Overloaded constructor
    public void SetAllFields(int id, double posX, double posY, double posZ,
        double velX, double velY, double velZ)
    {
        InternalID = id;
        Position[0] = posX;
        Position[1] = posY;
        Position[2] = posZ;
        Velocity[0] = velX;
        Velocity[1] = velY;
        Velocity[2] = velZ;
    }

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

    public void GetDebugInfo()
    {
        string properties = "Current object:\n";
        properties += "\tID: " + InternalID + '\n';
        properties += "\tXPos: " + Position[0] + '\n';
        properties += "\tYPos: " + Position[1] + '\n';
        properties += "\tZPos: " + Position[2] + '\n';
        properties += "\tXVel: " + Velocity[0] + '\n';
        properties += "\tYVel: " + Velocity[1] + '\n';
        properties += "\tZVel: " + Velocity[2] + '\n';
        properties += '\n';
        Debug.Log(properties);
    }

}
