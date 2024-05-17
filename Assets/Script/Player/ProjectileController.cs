// using UnityEngine;

// public class ProjectileController : MonoBehaviour
// {
//     [SerializeField] private LayerMask levelCollisionLayer;

//     private RangedAttackSO attackData;
//     private Rigidbody2D rigidbody;
//     private SpriteRenderer spriteRenderer;
//     private TrailRenderer trailRenderer;

//     private Vector2 direction;
//     private bool isReady;
//     private float currentDuration;
//     public bool fxOnDestory = true;

//     private void Awake()
//     {
//         spriteRenderer = GetComponentInChildren<SpriteRenderer>();
//         rigidbody = GetComponent<Rigidbody2D>();
//         trailRenderer = GetComponent<TrailRenderer>();
//     }

//     private void Update()
//     {
//         if (!isReady)
//         {
//             return;
//         }

//         currentDuration += Time.deltaTime;

//         if (currentDuration > attackData.duration)
//         {
//             DestroyProjectile(transform.position, false);
//         }

//         rigidbody.velocity = direction * attackData.speed;
//     }

//     public void InitializeAttack(RangedAttackSO attackData)
//     {
//         this.attackData = attackData;
//         this.direction = direction;

//         UpdateProjectileSprite();
//         trailRenderer.Clear();
//         currentDuration = 0;
//         spriteRenderer.color = attackData.projectileColor;

//         transform.right = this.direction;

//         isReady = true;
//     }

//     private void OnTriggerEnter2D(Collider2D collision)
//     {
//         // levelCollisionLayer에 포함되는 레이어인지 확인합니다.
//         if (IsLayerMatched(levelCollisionLayer.value, collision.gameObject.layer))
//         {
//             // 벽에서는 충돌한 지점으로부터 약간 앞 쪽에서 발사체를 파괴합니다.
//             Vector2 destroyPosition = collision.ClosestPoint(transform.position) - direction * .2f;
//             DestroyProjectile(destroyPosition, fxOnDestory);
//         }
//         // _attackData.target에 포함되는 레이어인지 확인합니다.
//         else if (IsLayerMatched(attackData.target.value, collision.gameObject.layer))
//         {
//             HealthSystem healthSystem = collision.GetComponent<HealthSystem>();
//             if (healthSystem != null)
//                     {
//                     // 충돌한 오브젝트의 체력을 감소시킵니다.
//                     bool isAttackApplied = healthSystem.ChangeHealth(-attackData.power);
                    
//                     // 넉백이 활성화된 경우, ★드★디★어★ 넉백을 적용합니다.
//                     if (isAttackApplied && attackData.isOnKnockBack)
//                     {
//                         ApplyKnockback(collision);
//                     }
//             }
// 			      // 아야! 피격 구현에서 추가 예정
//             // 충돌한 지점에서 발사체를 파괴합니다.
//             DestroyProjectile(collision.ClosestPoint(transform.position), fxOnDestory);
//         }
//     }

//     // 레이어가 일치하는지 확인하는 메소드입니다.
//     private bool IsLayerMatched(int layerMask, int objectLayer)
//     {
//         return layerMask == (layerMask | (1 << objectLayer));
//     }

//     private void UpdateProjectileSprite()
//     {
//         transform.localScale = Vector3.one * attackData.size;
//     }


//     private void DestroyProjectile(Vector3 position, bool createFx)
//     {
//         if (createFx)
//         {
//             // TODO : ParticleSystem에 대해서 배우고, 무기 NameTag로 해당하는 FX가져오기
//         }
//         gameObject.SetActive(false);
//     }
// }