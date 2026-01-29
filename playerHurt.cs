using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class playerHurt : MonoBehaviour
{
    public int hitPoints;
    public float immunnityTimer = 3;
    public bool immune=false;


    // Update is called once per frame
    void Update()
    {
        immunity();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "Enemy" && immune == false)
        {
            Debug.Log("Ouchie");
            hitPoints = hitPoints - 1;
            immune = true;
        }
        else if(collision.gameObject.tag == "Enemy" && immune == true)
        {

        }

    }

    private void immunity()
    {
        if(immune)
        {
            immunnityTimer -= Time.deltaTime;
        }
        if(immunnityTimer<0)
        {
            immunnityTimer = 3;
            immune = false;
        }
    }


}
