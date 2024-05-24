using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform target;
    public Player player;
    public Item itemToGive;
    public GameObject prompt;
    public float distance;

    private SpriteRenderer sp;
    private GameObject instPrompt = null;

    public Interactable(Item i)
    {
        itemToGive = i;
    }

    private void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        player = target.gameObject.GetComponent<Player>();

        sp = GetComponent<SpriteRenderer>();
        sp.sprite = itemToGive.getSprite();
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

    public void setItemToGive(Item i)
    {
        itemToGive = i;

        sp.sprite = i.getSprite();
    }
}
