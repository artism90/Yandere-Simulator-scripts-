using System;
using UnityEngine;

// Token: 0x02000054 RID: 84
[Serializable]
public class BucketPourScript : MonoBehaviour
{
	// Token: 0x0600022C RID: 556 RVA: 0x000275CC File Offset: 0x000257CC
	public BucketPourScript()
	{
		this.PourHeight = string.Empty;
	}

	// Token: 0x0600022D RID: 557 RVA: 0x000275E0 File Offset: 0x000257E0
	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.enabled = false;
	}

	// Token: 0x0600022E RID: 558 RVA: 0x00027630 File Offset: 0x00025830
	public virtual void Update()
	{
		if (this.Yandere.PickUp != null)
		{
			if (this.Yandere.PickUp.Bucket != null)
			{
				if (this.Yandere.PickUp.Bucket.Full)
				{
					if (!this.Prompt.enabled)
					{
						this.Prompt.Label[0].text = "     " + "Pour";
						this.Prompt.enabled = true;
					}
				}
				else if (this.Yandere.PickUp.Bucket.Dumbbells == 5)
				{
					if (!this.Prompt.enabled)
					{
						this.Prompt.Label[0].text = "     " + "Drop";
						this.Prompt.enabled = true;
					}
				}
				else if (this.Prompt.enabled)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Prompt.Circle[0] != null && this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (this.Prompt.Label[0].text == "     " + "Pour")
			{
				this.Yandere.Stool = this.transform;
				this.Yandere.CanMove = false;
				this.Yandere.Pouring = true;
				this.Yandere.PourDistance = this.PourDistance;
				this.Yandere.PourHeight = this.PourHeight;
				this.Yandere.PourTime = this.PourTime;
			}
			else
			{
				this.Yandere.Character.animation.CrossFade("f02_bucketDrop_00");
				this.Yandere.MyController.radius = (float)0;
				this.Yandere.BucketDropping = true;
				this.Yandere.DropSpot = this.transform;
				this.Yandere.CanMove = false;
			}
		}
		if (this.Yandere.Pouring)
		{
			if (this.PourHeight == "Low" && Input.GetButtonDown("B"))
			{
				this.SplashCamera.Show = true;
				this.SplashCamera.MyCamera.enabled = true;
				this.SplashCamera.transform.position = new Vector3(2.875f, 0.8f, -35.625f);
				this.SplashCamera.transform.eulerAngles = new Vector3((float)0, (float)45, (float)0);
			}
		}
		else if (this.Yandere.BucketDropping && Input.GetButtonDown("B"))
		{
			this.SplashCamera.Show = true;
			this.SplashCamera.MyCamera.enabled = true;
			this.SplashCamera.transform.position = new Vector3(2.875f, 0.8f, -35.625f);
			this.SplashCamera.transform.eulerAngles = new Vector3((float)0, (float)45, (float)0);
		}
	}

	// Token: 0x0600022F RID: 559 RVA: 0x000279E4 File Offset: 0x00025BE4
	public virtual void Main()
	{
	}

	// Token: 0x0400049D RID: 1181
	public SplashCameraScript SplashCamera;

	// Token: 0x0400049E RID: 1182
	public YandereScript Yandere;

	// Token: 0x0400049F RID: 1183
	public PromptScript Prompt;

	// Token: 0x040004A0 RID: 1184
	public string PourHeight;

	// Token: 0x040004A1 RID: 1185
	public float PourDistance;

	// Token: 0x040004A2 RID: 1186
	public float PourTime;
}
