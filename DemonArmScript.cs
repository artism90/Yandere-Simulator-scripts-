using System;
using UnityEngine;

// Token: 0x0200007A RID: 122
[Serializable]
public class DemonArmScript : MonoBehaviour
{
	// Token: 0x060002FA RID: 762 RVA: 0x0003DA70 File Offset: 0x0003BC70
	public DemonArmScript()
	{
		this.Rising = true;
		this.IdleAnim = "DemonArmIdle";
	}

	// Token: 0x060002FB RID: 763 RVA: 0x0003DA8C File Offset: 0x0003BC8C
	public virtual void Update()
	{
		if (!this.Rising)
		{
			if (!this.Attacking)
			{
				this.animation.CrossFade(this.IdleAnim);
			}
			else if (!this.Attacked)
			{
				if (this.animation["DemonArmAttack"].time >= this.animation["DemonArmAttack"].length * 0.25f)
				{
					this.ClawCollider.enabled = true;
					this.Attacked = true;
				}
			}
			else if (this.animation["DemonArmAttack"].time >= this.animation["DemonArmAttack"].length)
			{
				this.animation.CrossFade(this.IdleAnim);
				this.Attacking = false;
				this.Attacked = false;
			}
		}
		else if (this.animation["DemonArmRise"].time > this.animation["DemonArmRise"].length)
		{
			this.Rising = false;
		}
	}

	// Token: 0x060002FC RID: 764 RVA: 0x0003DBA8 File Offset: 0x0003BDA8
	public virtual void OnTriggerEnter(Collider other)
	{
		if ((StudentScript)other.gameObject.GetComponent(typeof(StudentScript)) != null && ((StudentScript)other.gameObject.GetComponent(typeof(StudentScript))).StudentID > 1)
		{
			this.audio.clip = this.Whoosh;
			this.audio.pitch = UnityEngine.Random.Range(-0.9f, 1.1f);
			this.audio.Play();
			this.animation.CrossFade("DemonArmAttack");
			this.Attacking = true;
		}
	}

	// Token: 0x060002FD RID: 765 RVA: 0x0003DC4C File Offset: 0x0003BE4C
	public virtual void Main()
	{
	}

	// Token: 0x04000789 RID: 1929
	public GameObject DismembermentCollider;

	// Token: 0x0400078A RID: 1930
	public Collider ClawCollider;

	// Token: 0x0400078B RID: 1931
	public bool Attacking;

	// Token: 0x0400078C RID: 1932
	public bool Attacked;

	// Token: 0x0400078D RID: 1933
	public bool Rising;

	// Token: 0x0400078E RID: 1934
	public string IdleAnim;

	// Token: 0x0400078F RID: 1935
	public AudioClip Whoosh;
}
