using System;
using UnityEngine;

// Token: 0x020000AF RID: 175
[Serializable]
public class HomeCursorScript : MonoBehaviour
{
	// Token: 0x060003D2 RID: 978 RVA: 0x0004C428 File Offset: 0x0004A628
	public virtual void OnTriggerExit(Collider other)
	{
		if (other.gameObject == this.Photograph)
		{
			int num = 100;
			Vector3 position = this.Highlight.position;
			float num2 = position.y = (float)num;
			Vector3 vector = this.Highlight.position = position;
			this.Photograph = null;
		}
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x0004C484 File Offset: 0x0004A684
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name != "SouthWall")
		{
			this.Photograph = other.gameObject;
			this.Highlight.localEulerAngles = this.Photograph.transform.localEulerAngles;
			this.Highlight.localPosition = this.Photograph.transform.localPosition;
		}
	}

	// Token: 0x060003D4 RID: 980 RVA: 0x0004C4F0 File Offset: 0x0004A6F0
	public virtual void Main()
	{
	}

	// Token: 0x04000982 RID: 2434
	public GameObject Photograph;

	// Token: 0x04000983 RID: 2435
	public Transform Highlight;
}
