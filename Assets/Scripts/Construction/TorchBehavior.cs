using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchBehavior : MonoBehaviour
{
    [Tooltip("maximum possible intensity the light can flicker to")]
    [SerializeField, Min(0)] float maxIntensity = 150f;

    [Tooltip("minimum possible intensity the light can flicker to")]
    [SerializeField, Min(0)] float minIntensity = 50f;

    [Tooltip("maximum frequency of often the light will flicker in seconds")]
    [SerializeField, Min(0)] float maxFlickerFrequency = 1f;

    [Tooltip("minimum frequency of often the light will flicker in seconds")]
    [SerializeField, Min(0)] float minFlickerFrequency = 0.1f;

    [Tooltip("how fast the light will flicker to it's next intensity (a very high value will)" +
        "look like a dying lightbulb while a lower value will look more like an organic fire")]
    [SerializeField, Min(0)] float strength = 5f;

    public Color lightColor = new Color(0xFF, 0xC0, 0x8A);


    private Light LightSource => GetComponentInChildren<Light>();

    float baseIntensity;
    float nextIntensity;

    float flickerFrequency;
    float timeOfLastFlicker;


    private void OnValidate()
    {
        if (maxIntensity < minIntensity) minIntensity = maxIntensity;
        if (maxFlickerFrequency < minFlickerFrequency) minFlickerFrequency = maxFlickerFrequency;
    }

    private void Awake()
    {
        baseIntensity = LightSource.intensity;

        timeOfLastFlicker = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        LightSource.color = lightColor;

        if (timeOfLastFlicker + flickerFrequency < Time.time)
        {
            timeOfLastFlicker = Time.time;
            nextIntensity = Random.Range(minIntensity, maxIntensity);
            flickerFrequency = Random.Range(minFlickerFrequency, maxFlickerFrequency);
        }

        Flicker();

    }


    private void Flicker()
    {
        LightSource.intensity = Mathf.Lerp(
            LightSource.intensity,
            nextIntensity,
            strength * Time.deltaTime
        );
    }

    public void Reset()
    {
        LightSource.intensity = baseIntensity;
    }


}

