using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{

    CinemachineVirtualCamera camShake;
    CinemachineBasicMultiChannelPerlin camShakeSettings;

    [SerializeField] float CamShakeAmpValue = 0.5f;
    [SerializeField] float CamShakeFrequencyValue = 0.2f;


    private void Start()
    {
        camShake = GetComponent<CinemachineVirtualCamera>();
        camShakeSettings = camShake.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }



    private void FixedUpdate()
    {
        camShakeSettings.m_AmplitudeGain = camShakeSettings.m_AmplitudeGain > 0f ? camShakeSettings.m_AmplitudeGain -= 0.01f : 0f;
        camShakeSettings.m_FrequencyGain = camShakeSettings.m_FrequencyGain > 0f ? camShakeSettings.m_FrequencyGain -= 0.01f : 0f;
    }




    [ContextMenu("Shake Screen")]
    public void ApplyScreenShake()
    {
        camShake.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        camShakeSettings.m_AmplitudeGain = CamShakeAmpValue;
        camShakeSettings.m_FrequencyGain = CamShakeFrequencyValue;
    }



}
