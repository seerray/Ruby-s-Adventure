using UnityEngine;

/// <summary>
/// Will handle giving health to the character when they enter the trigger.
/// </summary>
public class HealthCollectible : MonoBehaviour 
{
    public ParticleSystem PickupEffect;//拾取物品的特效

    public AudioClip audioClip;//音频资源

    private void OnTriggerEnter2D(Collider2D other)//other指与改游戏对象接触的另一个游戏对象
    {
        Rubycontroller controller = other.GetComponent<Rubycontroller>();

        if (controller != null)//当前发生触发检测的游戏对象身上是否有Rubycontroller脚本
        {
            //有Rubycontroller脚本情况
            //判断是否满血
            if (controller.Health<controller.maxHealth)
            {
                //不满血状态
                controller.ChangeHealth(1);//血量+1

                Instantiate(PickupEffect, transform.position, Quaternion.identity);//生成回复血量特效

                controller.PlaySound(audioClip);//播放吃到回血物品的音频

                Destroy(gameObject);//使物品消失
            }
            
        }
    }

}
