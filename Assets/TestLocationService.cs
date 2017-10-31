﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TestLocationService : MonoBehaviour {

    public Text latitude;
    public Text longitude;
    public Text altitude;


    IEnumerator Start() {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1) {
            print("Timed out");
            yield break;
        }

        // Connection has failed
       

        // Stop service if there is no need to query location updates continuously
      //  Input.location.Stop();
    }

    private void Update() {
        if (Input.location.status == LocationServiceStatus.Failed) {
            print("Unable to determine device location");
            //yield break;
        }
        else {
            // Access granted and location value could be retrieved
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
            latitude.text = Input.location.lastData.latitude.ToString();
            longitude.text = Input.location.lastData.longitude.ToString();
            altitude.text = Input.location.lastData.altitude.ToString();
        }
    }
}
