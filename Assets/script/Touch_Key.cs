using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_Key : MonoBehaviour
{
    public GameObject effectPrefab;
    public AudioClip sound;
    public GameObject goal;
    public GameObject area;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ÉSÅ[ÉãÇ™èoåªÇ∑ÇÈ
            goal.SetActive(true);
            area.SetActive(true);

            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }
    }
}
