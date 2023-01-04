using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public float radius = 5.0F;
    public float power = 10.0F;

    public GameObject rocket;
    Vector3 explosionPos;
    public float launchTime = 2f;
    public float launchHeight = 25f;

    public void LaunchRocket()
    {
        explosionPos = transform.position;
        GameObject newRocket = Instantiate(rocket, explosionPos, Quaternion.identity);
        newRocket.transform.position = new Vector3(explosionPos.x, explosionPos.y + launchHeight, explosionPos.z);
        LeanTween.move(newRocket, explosionPos, launchTime).setEase(LeanTweenType.easeInQuad);
        StartCoroutine(DelayExplosion());
        LeanTween.Destroy(newRocket, launchTime);
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
