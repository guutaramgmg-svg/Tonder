using UnityEngine;

public class CardBManager : MonoBehaviour
{
    public Entity m_Entity;

    public void SpriteRefresh(Entity entity)
    {
        m_Entity = entity;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = m_Entity.Phot;
    }
}
