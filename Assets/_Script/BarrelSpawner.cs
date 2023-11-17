using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject barrel;

    private float timer = 0f;
    private float timerMax = 4f;

    private void Update(){
        timer += Time.deltaTime;

        if(timer >= timerMax){
            timer = 0;
            timerMax = Random.Range(3f, 5f);
            Instantiate(barrel, transform.position, barrel.transform.rotation);
        }
    }

}
