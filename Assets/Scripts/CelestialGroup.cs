using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialGroup : MonoBehaviour
{
    // Member variables
    public GameObject[] Bodies; // Array of CelestialBody objects to control
    public double[] BodyTrails; // Storing color of CelestialBody trails

    // Start is called before the first frame update
    void Start()
    {
        // Call a function to take in and create objects from JSON data in
        //   CleanedData.json -- there should be C# libraries to do this w/ JSON

        // Instantiate all of the necessary CelestialBody objects into the scene
        //   and store them in public array above
    }

    // Update is called once per frame
    void Update()
    {

    }

    public var ConvertFromJSON(string filename)
    {
        // Write something here to maybe convert the CleanedData.json file and
        //   export like an array/vector of satellite objects (class CelestialBody???)
    }
}
