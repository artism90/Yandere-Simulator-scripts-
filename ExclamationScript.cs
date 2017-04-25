using System;
using UnityEngine;

// Token: 0x0200008D RID: 141
[Serializable]
public class ExclamationScript : MonoBehaviour
{
	// Token: 0x0600034F RID: 847 RVA: 0x00046140 File Offset: 0x00044340
	public virtual void Start()
	{
		this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
		this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, (float)0));
	}

	// Token: 0x06000350 RID: 848 RVA: 0x00046190 File Offset: 0x00044390
	public virtual void Update()
	{
		this.Timer -= Time.deltaTime;
		if (this.Timer > (float)0)
		{
			this.transform.LookAt(Camera.main.transform);
			if (this.Timer > 1.5f)
			{
				this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)1, (float)1, (float)1), Time.deltaTime * (float)10);
				this.Alpha = Mathf.Lerp(this.Alpha, 0.5f, Time.deltaTime * (float)10);
				this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, this.Alpha));
			}
			else
			{
				if (this.transform.localScale.x > 0.1f)
				{
					this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3((float)0, (float)0, (float)0), Time.deltaTime * (float)10);
				}
				else
				{
					this.transform.localScale = new Vector3((float)0, (float)0, (float)0);
				}
				this.Alpha = Mathf.Lerp(this.Alpha, (float)0, Time.deltaTime * (float)10);
				this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, this.Alpha));
			}
		}
	}

	// Token: 0x06000351 RID: 849 RVA: 0x00046318 File Offset: 0x00044518
	public virtual void Main()
	{
	}

	// Token: 0x04000860 RID: 2144
	public Renderer Graphic;

	// Token: 0x04000861 RID: 2145
	public float Alpha;

	// Token: 0x04000862 RID: 2146
	public float Timer;
}
