using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class Explode : MonoBehaviour
{

    public FMOD.Studio.EventInstance em;
    public EventReference soundName;

    public float radius = 5.0F;
    public float power = 10.0F;

    public GameObject explosion;
    public GameObject rocket;
    Vector3 explosionPos;
    public float launchTime = 2f;
    public float launchHeight = 25f;
    public Animator anim;

    public void LaunchRocket()
    {
        explosionPos = transform.position;
        GameObject newRocket = Instantiate(rocket, explosionPos, Quaternion.identity);
        LeanTween.delayedCall(launchTime, () => SpawnExplosion());

        anim.SetTrigger("BugButton");
        PlaySound();
        //KillSound();
        newRocket.transform.position = new Vector3(explosionPos.x, explosionPos.y + launchHeight, explosionPos.z);
        LeanTween.move(newRocket, explosionPos, launchTime).setEase(LeanTweenType.easeInQuad);
        StartCoroutine(DelayExplosion());
        LeanTween.Destroy(newRocket.transform.GetChild(0).gameObject, launchTime);
        LeanTween.Destroy(newRocket, launchTime+.7f);
    }

    void SpawnExplosion()
    {
        GameObject newExplosion = Instantiate(explosion, explosionPos, Quaternion.identity);
    }
    public void PlaySound()
    {
        em = FMODUnity.RuntimeManager.CreateInstance(soundName);
        //em.setParameterByName(pitchName, allNotes[Mathf.RoundToInt(slider.value)]);
        //em.setParameterByName(volumeName, volumeSlider.value / 10);
        em.start();
        em.release();
    }

    public void KillSound()
    {
        em.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    IEnumerator DelayExplosion()
    {
        yield return new WaitForSeconds(launchTime);
        ImpactForce();
        yield return null;
    }
    void ImpactForce()
    {
        
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
    }
}
