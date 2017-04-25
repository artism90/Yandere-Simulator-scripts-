using System;
using UnityEngine;

// Token: 0x02000094 RID: 148
[Serializable]
public class FoldedUniformScript : MonoBehaviour
{
	// Token: 0x06000368 RID: 872 RVA: 0x00046FB4 File Offset: 0x000451B4
	public FoldedUniformScript()
	{
		this.InPosition = true;
	}

	// Token: 0x06000369 RID: 873 RVA: 0x00046FC4 File Offset: 0x000451C4
	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		if (this.Clean && this.Prompt.Button[0] != null)
		{
			this.Prompt.HideButton[0] = true;
		}
	}

	// Token: 0x0600036A RID: 874 RVA: 0x00047030 File Offset: 0x00045230
	public virtual void Update()
	{
		if (this.Clean)
		{
			if (this.Yandere.transform.position.x > (float)43 && this.Yandere.transform.position.x < (float)51 && this.Yandere.transform.position.z > (float)2 && this.Yandere.transform.position.z < (float)14)
			{
				this.InPosition = true;
			}
			else
			{
				this.InPosition = false;
			}
			if (this.Yandere.CensorSteam[0].active && this.Yandere.Bloodiness == (float)0 && this.InPosition)
			{
				this.Prompt.HideButton[0] = false;
			}
			else
			{
				this.Prompt.HideButton[0] = true;
			}
			if (this.Prompt.Circle[0].fillAmount == (float)0)
			{
				UnityEngine.Object.Instantiate(this.SteamCloud, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
				this.Yandere.Character.animation.CrossFade("f02_stripping_00");
				this.Yandere.Stripping = true;
				this.Yandere.CanMove = false;
				this.Timer += Time.deltaTime;
			}
			if (this.Timer > (float)0)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 1.5f)
				{
					this.Yandere.Schoolwear = 1;
					this.Yandere.ChangeSchoolwear();
					UnityEngine.Object.Destroy(this.gameObject);
				}
			}
		}
	}

	// Token: 0x0600036B RID: 875 RVA: 0x00047228 File Offset: 0x00045428
	public virtual void Main()
	{
	}

	// Token: 0x0400088D RID: 2189
	public YandereScript Yandere;

	// Token: 0x0400088E RID: 2190
	public PromptScript Prompt;

	// Token: 0x0400088F RID: 2191
	public GameObject SteamCloud;

	// Token: 0x04000890 RID: 2192
	public bool InPosition;

	// Token: 0x04000891 RID: 2193
	public bool Clean;

	// Token: 0x04000892 RID: 2194
	public float Timer;

	// Token: 0x04000893 RID: 2195
	public int Type;
}
