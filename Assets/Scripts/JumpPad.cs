using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpPadForce = 13f;
    [SerializeField] private float additionalSleepJumpTime = 0.3f;
    [SerializeField] private SoAudioClips jumpPadAudioClips;
    private static readonly int Bounce = Animator.StringToHash("Bounce");

    public float GetJumpPadForce() => jumpPadForce;
    public float GetAdditionalSleepJumpTime() => additionalSleepJumpTime;
    
    public void TriggerJumpPad()
    {
        animator.SetTrigger(Bounce);
        audioSource.PlayOneShot(jumpPadAudioClips.GetAudioClip());
    }
}
