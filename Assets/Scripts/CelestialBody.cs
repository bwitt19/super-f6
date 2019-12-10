using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{

    // Member variables
    public List<Vector3> Position = new List<Vector3>();
    public List<Vector3> Velocity = new List<Vector3>();
    public int Cycle { get; set; } = 0;
    public float AssignedScale { get; set; }
    public bool Focus { get; set; } = false;

    // Default constructor
    public CelestialBody() { }

    /*
    // Function to set all fields at once
    public void SetAllFields(int id, double posX, double posY, double posZ,
        double velX, double velY, double velZ, float scale = 1)
    {
        InternalID = id;
        Position[0] = posX * scale;
        Position[1] = posY * scale;
        Position[2] = posZ * scale;
        Velocity[0] = velX * scale;
        Velocity[1] = velY * scale;
        Velocity[2] = velZ * scale;
        AssignedScale = scale;
    }
    */

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
        properties += "\tCurrent scale is: " + AssignedScale + '\n';
        properties += '\n';
        Debug.Log(properties);
    }
    */

}
