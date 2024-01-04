using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool isOn;
    public Light light;
    public AudioSource source;

    public float power = 100;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isOn = !isOn;
            source.Play();
        }
        light.enabled = isOn;
        if (isOn) power -= Time.deltaTime;
        light.intensity = power / 50; // default = 2
    }
}
