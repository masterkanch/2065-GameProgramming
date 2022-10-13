using UnityEngine;
//using UnityEngine.EventSystems;
using DG.Tweening;

public class Collectibles : MonoBehaviour
{
    [SerializeField] private CollectibleSpawner collectibleSpawner;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SoCollectibles collectibleObject;
    [SerializeField] private ParticleSystem SpawnCollectible;
  
    
    private CollectibleType _collectibleType;
    private bool _isRespawnable;

    private void Start()
    {
        SetCollectible();
    }

    public CollectibleType GetCollectibleInfoOnContact()
    {
        gameObject.SetActive(false);

        if (_isRespawnable)
        {
            collectibleSpawner.StartRespawningCountdown();
        }

        return _collectibleType;
    }
    
    private void SetCollectible()
    {
        collectibleSpawner.SetOutlineSprite(collectibleObject.GetOutlineSprite());
        spriteRenderer.sprite = collectibleObject.GetSprite();
        _collectibleType = collectibleObject.GetCollectibleType();
        _isRespawnable = collectibleObject.GetRespawnable();
    }

    private void OnTriggerEnter2D(Collider2D col){
        SpawnCollectible.Play();
    }
}
