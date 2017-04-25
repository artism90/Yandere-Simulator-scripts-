using System;
using UnityEngine;

// Token: 0x02000064 RID: 100
[Serializable]
public class ClothingScript : MonoBehaviour
{
	// Token: 0x06000277 RID: 631 RVA: 0x0002D444 File Offset: 0x0002B644
	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
	}

	// Token: 0x06000278 RID: 632 RVA: 0x0002D478 File Offset: 0x0002B678
	public virtual void Update()
	{
		if (this.CanPickUp)
		{
			if (this.Yandere.Bloodiness == (float)0)
			{
				this.CanPickUp = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Yandere.Bloodiness > (float)0)
		{
			this.CanPickUp = true;
			this.Prompt.enabled = true;
		}
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Yandere.Bloodiness = (float)0;
			this.Prompt.Yandere.UpdateBlood();
			UnityEngine.Object.Instantiate(this.FoldedUniform, this.transform.position + Vector3.up * (float)1, Quaternion.identity);
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	// Token: 0x06000279 RID: 633 RVA: 0x0002D560 File Offset: 0x0002B760
	public virtual void Main()
	{
	}

	// Token: 0x04000560 RID: 1376
	public YandereScript Yandere;

	// Token: 0x04000561 RID: 1377
	public PromptScript Prompt;

	// Token: 0x04000562 RID: 1378
	public GameObject FoldedUniform;

	// Token: 0x04000563 RID: 1379
	public bool CanPickUp;
}
