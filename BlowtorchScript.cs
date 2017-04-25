using System;
using UnityEngine;

// Token: 0x0200004E RID: 78
[Serializable]
public class BlowtorchScript : MonoBehaviour
{
	// Token: 0x06000216 RID: 534 RVA: 0x00026B5C File Offset: 0x00024D5C
	public virtual void Start()
	{
		this.Flame.localScale = new Vector3((float)0, (float)0, (float)0);
		this.enabled = false;
	}

	// Token: 0x06000217 RID: 535 RVA: 0x00026B7C File Offset: 0x00024D7C
	public virtual void Update()
	{
		this.Timer = Mathf.MoveTowards(this.Timer, (float)5, Time.deltaTime);
		float num = UnityEngine.Random.Range(0.9f, 1f);
		this.Flame.localScale = new Vector3(num, num, num);
		if (this.Timer == (float)5)
		{
			this.Flame.localScale = new Vector3((float)0, (float)0, (float)0);
			this.Yandere.Cauterizing = false;
			this.Yandere.CanMove = true;
			this.enabled = false;
			this.audio.Stop();
			this.Timer = (float)0;
		}
	}

	// Token: 0x06000218 RID: 536 RVA: 0x00026C1C File Offset: 0x00024E1C
	public virtual void Main()
	{
	}

	// Token: 0x04000457 RID: 1111
	public YandereScript Yandere;

	// Token: 0x04000458 RID: 1112
	public RagdollScript Corpse;

	// Token: 0x04000459 RID: 1113
	public PickUpScript PickUp;

	// Token: 0x0400045A RID: 1114
	public PromptScript Prompt;

	// Token: 0x0400045B RID: 1115
	public Transform Flame;

	// Token: 0x0400045C RID: 1116
	public float Timer;
}
