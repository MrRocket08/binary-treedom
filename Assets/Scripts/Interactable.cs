using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform target;
    public Player player;
    public Item itemToGive;
    public GameObject prompt;
    public float distance;

    private GameObject instPrompt = null;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if(distance <= radius && instPrompt == null)
        {
            instPrompt = Instantiate(prompt, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        } else if (distance > radius) { Destroy(instPrompt); instPrompt = null; }
    }

    private void OnMouseOver()
    {
        if (distance < radius && Input.GetKeyDown("F"))
        {
            if(player.addToInventory(itemToGive))
            {
                Destroy(this);
            }
        }
    }

}
