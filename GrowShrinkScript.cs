using System;
using UnityEngine;

// Token: 0x020000A5 RID: 165
[Serializable]
public class GrowShrinkScript : MonoBehaviour
{
	// Token: 0x060003AB RID: 939 RVA: 0x00049BC4 File Offset: 0x00047DC4
	public GrowShrinkScript()
	{
		this.Threshold = 1f;
		this.Slowdown = 0.5f;
		this.Strength = 1f;
		this.Target = 1f;
		this.Speed = 5f;
	}

	// Token: 0x060003AC RID: 940 RVA: 0x00049C04 File Offset: 0x00047E04
	public virtual void Start()
	{
		this.OriginalPosition = this.transform.localPosition;
		this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
	}

	// Token: 0x060003AD RID: 941 RVA: 0x00049C38 File Offset: 0x00047E38
	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		this.Scale += Time.deltaTime * this.Strength * this.Speed;
		if (!this.Shrink)
		{
			this.Strength += Time.deltaTime * this.Speed;
			if (this.Strength > this.Threshold)
			{
				this.Strength = this.Threshold;
			}
			if (this.Scale > this.Target)
			{
				this.Threshold *= this.Slowdown;
				this.Shrink = true;
			}
		}
		else
		{
			this.Strength -= Time.deltaTime * this.Speed;
			if (this.Strength < this.Threshold * (float)-1)
			{
				this.Strength = this.Threshold * (float)-1;
			}
			if (this.Scale < this.Target)
			{
				this.Threshold *= this.Slowdown;
				this.Shrink = false;
			}
		}
		if (this.Timer > 3.33333f)
		{
			this.FallSpeed += Time.deltaTime * (float)10;
			float y = this.transform.localPosition.y - this.FallSpeed * this.FallSpeed;
			Vector3 localPosition = this.transform.localPosition;
			float num = localPosition.y = y;
			Vector3 vector = this.transform.localPosition = localPosition;
		}
		this.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
	}

	// Token: 0x060003AE RID: 942 RVA: 0x00049DE8 File Offset: 0x00047FE8
	public virtual void Return()
	{
		this.transform.localPosition = this.OriginalPosition;
		this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.FallSpeed = (float)0;
		this.Threshold = 1f;
		this.Slowdown = 0.5f;
		this.Strength = 1f;
		this.Target = 1f;
		this.Scale = (float)0;
		this.Speed = 5f;
		this.Timer = (float)0;
		this.active = false;
	}

	// Token: 0x060003AF RID: 943 RVA: 0x00049E74 File Offset: 0x00048074
	public virtual void Main()
	{
	}

	// Token: 0x04000917 RID: 2327
	public float FallSpeed;

	// Token: 0x04000918 RID: 2328
	public float Threshold;

	// Token: 0x04000919 RID: 2329
	public float Slowdown;

	// Token: 0x0400091A RID: 2330
	public float Strength;

	// Token: 0x0400091B RID: 2331
	public float Target;

	// Token: 0x0400091C RID: 2332
	public float Scale;

	// Token: 0x0400091D RID: 2333
	public float Speed;

	// Token: 0x0400091E RID: 2334
	public float Timer;

	// Token: 0x0400091F RID: 2335
	public bool Shrink;

	// Token: 0x04000920 RID: 2336
	public Vector3 OriginalPosition;
}
