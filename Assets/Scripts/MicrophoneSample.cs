using UnityEngine;
using System;
public class MicrophoneSample : MonoBehaviour
{

    public static event EventHandler OnThreshHold;
    public string microphoneName = null;  // Set the microphone name in the Unity Editor
    public float sensitivity = 100f;      // Adjust sensitivity for volume detection

    public float thresholdVolume = 5;

    void Start()
    {
        // Check if a microphone is available
        if (Microphone.devices.Length == 0)
        {
            Debug.LogError("No microphone found!");
            return;
        }

        // Use the default microphone if the name is not specified
        if (string.IsNullOrEmpty(microphoneName))
            microphoneName = Microphone.devices[0];

        // Start recording from the microphone
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(microphoneName, true, 10, AudioSettings.outputSampleRate);
        audioSource.loop = true;

        // Wait until the microphone starts recording
        while (!(Microphone.GetPosition(microphoneName) > 0)) { }

        // Play the recorded audio
        audioSource.Play();
    }

    void Update()
    {
        // Get the audio data
        AudioSource audioSource = GetComponent<AudioSource>();
        float[] samples = new float[256];
        audioSource.GetOutputData(samples, 0);

        // Calculate the volume
        float sum = 0f;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += Mathf.Abs(samples[i]);
        }

        // Normalize the volume
        float volume = sum / samples.Length * sensitivity;

        // Display the volume (you can replace this with your own logic)
        Debug.Log("Volume: " + volume);

        if(volume >= thresholdVolume || Input.GetKeyDown(KeyCode.Space)){
            OnThreshHold?.Invoke(this, EventArgs.Empty);
        }
    }
}
