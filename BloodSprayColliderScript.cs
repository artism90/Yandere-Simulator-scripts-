using System;
using UnityEngine;

// Token: 0x0200004C RID: 76
[Serializable]
public class BloodSprayColliderScript : MonoBehaviour
{
	// Token: 0x06000210 RID: 528 RVA: 0x00026AA8 File Offset: 0x00024CA8
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 13)
		{
			YandereScript yandereScript = (YandereScript)other.gameObject.GetComponent(typeof(YandereScript));
			if (yandereScript != null)
			{
				yandereScript.Bloodiness = (float)100;
				yandereScript.UpdateBlood();
				UnityEngine.Object.Destroy(this.gameObject);
			}
		}
	}

	// Token: 0x06000211 RID: 529 RVA: 0x00026B08 File Offset: 0x00024D08
	public virtual void Main()
	{
	}
}
