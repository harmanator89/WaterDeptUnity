using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

    public Transform sun, moon;

    [SerializeField] int distanceFromOrgin = 10;
    [SerializeField] float daySpeed = .085f;

    [SerializeField] int orbitAngle;
    [SerializeField] int sunrisePOS;
    [SerializeField] int dayProgress;

	// Use this for initialization
	void Start ()
    {
        SetupOrbitals();
        SetOrbitalPath();
	}
	
    void SetupOrbitals()
    {
        Vector3 distanceFromOrginVector = new Vector3(distanceFromOrgin, 0, 0);

        sun.position = distanceFromOrginVector;
        moon.position = -distanceFromOrginVector;

        sun.rotation = Quaternion.Euler(0, -90, 0);
        moon.rotation = Quaternion.Euler(0, 90, 0);
    }

    void SetOrbitalPath()
    {
        transform.rotation = Quaternion.Euler(orbitAngle, sunrisePOS, dayProgress);
    }

	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.Rotate(0, 0, daySpeed);	
	}
}
