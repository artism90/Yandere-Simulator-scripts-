using System;
using UnityEngine;

// Token: 0x02000073 RID: 115
[Serializable]
public class CreepyArmScript : MonoBehaviour
{
	// Token: 0x060002CA RID: 714 RVA: 0x000362C8 File Offset: 0x000344C8
	public virtual void Update()
	{
		float y = this.transform.position.y + Time.deltaTime * 0.1f;
		Vector3 position = this.transform.position;
		float num = position.y = y;
		Vector3 vector = this.transform.position = position;
	}

	// Token: 0x060002CB RID: 715 RVA: 0x00036324 File Offset: 0x00034524
	public virtual void Main()
	{
	}
}
