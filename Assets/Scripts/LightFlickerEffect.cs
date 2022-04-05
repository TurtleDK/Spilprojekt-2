using UnityEngine;
using System.Collections.Generic;

// Written by Steve Streeting 2017
// License: CC0 Public Domain http://creativecommons.org/publicdomain/zero/1.0/

/// <summary>
/// Component which will flicker a linked light while active by changing its
/// intensity between the min and max values given. The flickering can be
/// sharp or smoothed depending on the value of the smoothing parameter.
///
/// Just activate / deactivate this component as usual to pause / resume flicker
/// </summary>
public class LightFlickerEffect : MonoBehaviour
{
    [Tooltip("Should this light flicker? If not the light will be fully on")]
    public bool flicker = false;

    [HideInInspector]
    public float startIntensity = 1;

    List<Light> Lights = new List<Light>();

    [Tooltip("Minimum random light intensity")]
    [HideInInspector] //maybe remove
    public float minIntensity = 0f;
    [Tooltip("Maximum random light intensity")]
    [HideInInspector] //maybe remove
    public float maxIntensity = 1f;
    [Tooltip("How much to smooth out the randomness; lower values = sparks, higher = lantern")]
    [Range(1, 50)]
    public int smoothing = 5;

    //Lavet af Rasmus
    [Tooltip("Fully turns off the light when flickering")]
    public bool fullFlicker = false;
    [Tooltip("Makes a bias when deciding if light should be on or off")]
    [Range(-1, 1)]
    public float fullFlickerBias = 0;
    //Lavet af Rasmus
    
    // Continuous average calculation via FIFO queue
    // Saves us iterating every time we update, we just change by the delta
    Queue<float> smoothQueue;
    float lastSum = 0;


    /// <summary>
    /// Reset the randomness and start again. You usually don't need to call
    /// this, deactivating/reactivating is usually fine but if you want a strict
    /// restart you can do.
    /// </summary>
    public void Reset()
    {
        smoothQueue.Clear();
        lastSum = 0;
    }

    private void Awake()
    {
        foreach (Light light in transform.GetComponentsInChildren<Light>())
        {
            Lights.Add(light);
        }
        startIntensity = Lights.Count >= 1 ? Lights[0].intensity : 1;
    }

    void Start()
    {
        smoothQueue = new Queue<float>(smoothing);
    }

    void FixedUpdate()
    {
        maxIntensity = startIntensity;

        if (Lights.Count == 0)
            return;

        if (!flicker)
        {
            foreach (Light light in Lights)
            {
                light.intensity = startIntensity;
            }
            return;
        }

        // pop off an item if too big
        while (smoothQueue.Count >= smoothing)
        {
            lastSum -= smoothQueue.Dequeue();
        }

        // Generate random new item, calculate new average
        float newVal = Random.Range(minIntensity, maxIntensity);
        smoothQueue.Enqueue(newVal);
        lastSum += newVal;

        float newIntensity = lastSum / (float)smoothQueue.Count;


        foreach (Light light in Lights)
        {

            // Calculate new smoothed average
            light.intensity = newIntensity;

        if (fullFlicker)
        {
                if (light.intensity > ((maxIntensity - minIntensity) / 2) + (-fullFlickerBias * (maxIntensity - minIntensity) / 2))
                {
                    light.intensity = maxIntensity;
                }
                else
                {
                    light.intensity = minIntensity;
                }
        }
        }

    }

    public void setFlicker(bool flicker)
    {
        this.flicker = flicker;
    }

    public void setSmoothing(int smoothing)
    {
        this.smoothing = smoothing; 
    }

    public void setIntensity(float intensity)
    {
        this.startIntensity = intensity;
    }

}