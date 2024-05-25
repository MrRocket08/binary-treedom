using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform target;
    public Player player;
    public Item itemToGive = null;
    public GameObject prompt;
    public float distance;

    private SpriteRenderer sp;
    private WeaponManager wm;
    private GameObject instPrompt = null;

    public Interactable(Item i)
    {
        itemToGive = i;
    }

    private void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        player = target.GetComponent<Player>();
        wm = GameObject.Find("Weapon").GetComponent<WeaponManager>();

        sp = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if(distance <= radius && instPrompt == null)
        {
            instPrompt = Instantiate(prompt, new Vector2(transform.position.x, transform.position.y + 1f), Quaternion.identity);
        } else if (distance > radius) { Destroy(instPrompt); instPrompt = null; }
    }

    private void OnMouseOver()
    {
        if (distance < radius && Input.GetButton("Submit"))
        {
            Debug.Log("interacted!");

            if(instPrompt != null) { Destroy(instPrompt); }

            if(itemToGive is Weapon)
            {
                if (itemToGive is TreeSlapper)
                {
                    wm.setWeapon(wm.GetComponent<TreeSlapper>());
                }
                
                Destroy(this.gameObject);
            } else
            {
                player.addToInventory(itemToGive);

                Destroy(this.gameObject);
            }
        }
    }

    public void setItemToGive(Item i)
    {
        itemToGive = i;

        sp.sprite = i.getSprite();
    }
}
