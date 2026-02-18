using UnityEngine;

[CreateAssetMenu(fileName ="Entity", menuName ="Create Entity")]
public class Entity : ScriptableObject
{
    public bool Type;
    public int No;
    public string Message;
    public Sprite Phot;

    public SoundManager.SESuperLike SeSuperLike;
    public SoundManager.SELike SeLike;
    public SoundManager.SENope SeNope;

}
