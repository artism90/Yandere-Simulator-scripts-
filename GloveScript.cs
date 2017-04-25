using System;
using UnityEngine;

// Token: 0x020000A1 RID: 161
[Serializable]
public class GloveScript : MonoBehaviour
{
	// Token: 0x0600039E RID: 926 RVA: 0x00049550 File Offset: 0x00047750
	public virtual void Start()
	{
		YandereScript yandereScript = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		Physics.IgnoreCollision(yandereScript.collider, this.MyCollider);
		if (this.transform.position.y > (float)1000)
		{
			this.transform.position = new Vector3((float)12, (float)0, (float)28);
		}
	}

	// Token: 0x0600039F RID: 927 RVA: 0x000495C4 File Offset: 0x000477C4
	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.transform.parent = this.Prompt.Yandere.transform;
			this.transform.localPosition = new Vector3((float)0, (float)1, 0.25f);
			this.Prompt.Yandere.Gloves = this;
			this.Prompt.Yandere.WearGloves();
			this.active = false;
		}
		if (this.Prompt.Yandere.Schoolwear == 1 && !this.Prompt.Yandere.ClubAttire)
		{
			this.Prompt.HideButton[0] = false;
		}
		else
		{
			this.Prompt.HideButton[0] = true;
		}
	}

	// Token: 0x060003A0 RID: 928 RVA: 0x000496A4 File Offset: 0x000478A4
	public virtual void Main()
	{
	}

	// Token: 0x040008F8 RID: 2296
	public PromptScript Prompt;

	// Token: 0x040008F9 RID: 2297
	public PickUpScript PickUp;

	// Token: 0x040008FA RID: 2298
	public Collider MyCollider;

	// Token: 0x040008FB RID: 2299
	public Projector Blood;
}
