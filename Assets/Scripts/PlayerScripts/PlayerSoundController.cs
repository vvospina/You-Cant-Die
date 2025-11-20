using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip collectStrawberrySound;
    public AudioClip hurtSound;

    public void playJump()
    {
        audioSource.PlayOneShot(jumpSound);
    }

    public void playCollect()
    {
        audioSource.PlayOneShot(collectStrawberrySound);
    }
    public void playHurt()
    {
        audioSource.PlayOneShot(hurtSound);
    }
}
