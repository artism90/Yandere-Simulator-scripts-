using System;
using UnityEngine;

// Token: 0x020000B3 RID: 179
[Serializable]
public class HomeMangaBookScript : MonoBehaviour
{
	// Token: 0x060003E6 RID: 998 RVA: 0x0004E77C File Offset: 0x0004C97C
	public virtual void Start()
	{
		int num = 90;
		Vector3 eulerAngles = this.transform.eulerAngles;
		float num2 = eulerAngles.x = (float)num;
		Vector3 vector = this.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x0004E7BC File Offset: 0x0004C9BC
	public virtual void Update()
	{
		if (this.Manga.Selected == this.ID)
		{
			float y = this.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed;
			Vector3 eulerAngles = this.transform.eulerAngles;
			float num = eulerAngles.y = y;
			Vector3 vector = this.transform.eulerAngles = eulerAngles;
		}
		else
		{
			int num2 = 0;
			Vector3 eulerAngles2 = this.transform.eulerAngles;
			float num3 = eulerAngles2.y = (float)num2;
			Vector3 vector2 = this.transform.eulerAngles = eulerAngles2;
		}
	}

	// Token: 0x060003E8 RID: 1000 RVA: 0x0004E86C File Offset: 0x0004CA6C
	public virtual void Main()
	{
	}

	// Token: 0x040009C0 RID: 2496
	public HomeMangaScript Manga;

	// Token: 0x040009C1 RID: 2497
	public float RotationSpeed;

	// Token: 0x040009C2 RID: 2498
	public int ID;
}
