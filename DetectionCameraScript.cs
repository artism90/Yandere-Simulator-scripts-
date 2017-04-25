using System;
using UnityEngine;

// Token: 0x0200007E RID: 126
[Serializable]
public class DetectionCameraScript : MonoBehaviour
{
	// Token: 0x06000309 RID: 777 RVA: 0x0003E774 File Offset: 0x0003C974
	public virtual void Update()
	{
		this.transform.position = this.YandereChan.transform.position + Vector3.up * (float)100;
		int num = 90;
		Vector3 eulerAngles = this.transform.eulerAngles;
		float num2 = eulerAngles.x = (float)num;
		Vector3 vector = this.transform.eulerAngles = eulerAngles;
	}

	// Token: 0x0600030A RID: 778 RVA: 0x0003E7E0 File Offset: 0x0003C9E0
	public virtual void Main()
	{
	}

	// Token: 0x040007AC RID: 1964
	public Transform YandereChan;
}
