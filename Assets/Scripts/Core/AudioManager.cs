using Knife.Anim;
using Knife.Attack;
using Knife.Level;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    public LevelSettings[] levelSettings;
	[Range(0, 1)] public float volume = 1;

	private int _circleIndex = 0;

    private void OnEnable()
    {
        KnifeController.CircleDamage += CircleHit;
        CircleAnim.NextCircle += NextCircleIndex;
	}

    private void OnDisable()
    {
        KnifeController.CircleDamage -= CircleHit;
		CircleAnim.NextCircle -= NextCircleIndex;
	}

    private void Start()
    {
		_circleIndex = 0;
	}

    public void CircleHit()
    {
        AudioSource.PlayClipAtPoint(levelSettings[_circleIndex].CircleHitAudio, transform.position, volume); 
	}

    public void NextCircleIndex(bool isNext)
    {
        if (isNext)
            _circleIndex++;
    }
}