using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000193 RID: 403
[Serializable]
public class FoldingChairScript : MonoBehaviour
{
	// Token: 0x0600083A RID: 2106 RVA: 0x000BCE2C File Offset: 0x000BB02C
	public virtual void Start()
	{
		int num = UnityEngine.Random.Range(0, Extensions.get_length(this.Student));
		UnityEngine.Object.Instantiate(this.Student[num], this.transform.position - new Vector3((float)0, 0.4f, (float)0), this.transform.rotation);
	}

	// Token: 0x0600083B RID: 2107 RVA: 0x000BCE84 File Offset: 0x000BB084
	public virtual void Main()
	{
	}

	// Token: 0x0400190D RID: 6413
	public GameObject[] Student;
}
