using System;
using UnityEngine;

// Token: 0x02000071 RID: 113
[Serializable]
public class CreditsLabelScript : MonoBehaviour
{
	// Token: 0x060002C2 RID: 706 RVA: 0x00035DC8 File Offset: 0x00033FC8
	public virtual void Start()
	{
		this.Rotation = (float)-90;
		float rotation = this.Rotation;
		Vector3 localEulerAngles = this.transform.localEulerAngles;
		float num = localEulerAngles.y = rotation;
		Vector3 vector = this.transform.localEulerAngles = localEulerAngles;
	}

	// Token: 0x060002C3 RID: 707 RVA: 0x00035E14 File Offset: 0x00034014
	public virtual void Update()
	{
		this.Rotation += Time.deltaTime * this.RotationSpeed;
		float rotation = this.Rotation;
		Vector3 localEulerAngles = this.transform.localEulerAngles;
		float num = localEulerAngles.y = rotation;
		Vector3 vector = this.transform.localEulerAngles = localEulerAngles;
		float y = this.transform.localPosition.y + Time.deltaTime * this.MovementSpeed;
		Vector3 localPosition = this.transform.localPosition;
		float num2 = localPosition.y = y;
		Vector3 vector2 = this.transform.localPosition = localPosition;
		if (this.Rotation > (float)90)
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}
	}

	// Token: 0x060002C4 RID: 708 RVA: 0x00035EDC File Offset: 0x000340DC
	public virtual void Main()
	{
	}

	// Token: 0x04000695 RID: 1685
	public float RotationSpeed;

	// Token: 0x04000696 RID: 1686
	public float MovementSpeed;

	// Token: 0x04000697 RID: 1687
	public float Rotation;
}
