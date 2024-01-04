using UnityEngine;

public class PageManager : MonoBehaviour
{
    public int pages;
    public Enemy enemy;
    public Enemy enemy2;

    AudioSource source;
    AudioClip scarySound;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);

        source.PlayOneShot(scarySound);

        pages++;
        if(pages == 1)
        {
            // AI wake up
            enemy.target = transform;
        }
        if(pages == 2)
        {

            // AI view range 2x
            enemy.viewDistance *= 2;
        }
        if(pages == 3)
        {
            // AI speed 3x
            enemy.speed *= 3f;
        }
        if(pages == 4)
        {
            // 2 AIs
            enemy2.target = transform;

            // Sync variables between enemies
            enemy2.speed = enemy.speed;
            enemy2.viewDistance = enemy.viewDistance;
        }
    }
    private void Update()
    {
        if(pages == 5)
        {
            // Enemies always know your position
            // Chase mode
            enemy.target = transform;
            enemy2.target = transform;
        }
    }
}
