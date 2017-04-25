using System;
using UnityEngine;

// Token: 0x02000056 RID: 86
[Serializable]
public class BuildingDestructionScript : MonoBehaviour
{
	// Token: 0x06000238 RID: 568 RVA: 0x00028E50 File Offset: 0x00027050
	public virtual void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.Phase++;
			this.Sink = true;
		}
		if (this.Sink)
		{
			if (this.Phase == 1)
			{
				float y = this.transform.position.y - Time.deltaTime * (float)10;
				Vector3 position = this.transform.position;
				float num = position.y = y;
				Vector3 vector = this.transform.position = position;
				float x = UnityEngine.Random.Range(-1f, 1f);
				Vector3 position2 = this.transform.position;
				float num2 = position2.x = x;
				Vector3 vector2 = this.transform.position = position2;
				float z = UnityEngine.Random.Range(-19f, -21f);
				Vector3 position3 = this.transform.position;
				float num3 = position3.z = z;
				Vector3 vector3 = this.transform.position = position3;
			}
			else if (this.NewSchool.position.y != (float)0)
			{
				float y2 = Mathf.MoveTowards(this.NewSchool.position.y, (float)0, Time.deltaTime * (float)10);
				Vector3 position4 = this.NewSchool.position;
				float num4 = position4.y = y2;
				Vector3 vector4 = this.NewSchool.position = position4;
				float x2 = UnityEngine.Random.Range(-1f, 1f);
				Vector3 position5 = this.transform.position;
				float num5 = position5.x = x2;
				Vector3 vector5 = this.transform.position = position5;
				float z2 = UnityEngine.Random.Range(13f, 15f);
				Vector3 position6 = this.transform.position;
				float num6 = position6.z = z2;
				Vector3 vector6 = this.transform.position = position6;
			}
			else
			{
				int num7 = 0;
				Vector3 position7 = this.transform.position;
				float num8 = position7.x = (float)num7;
				Vector3 vector7 = this.transform.position = position7;
				int num9 = 14;
				Vector3 position8 = this.transform.position;
				float num10 = position8.z = (float)num9;
				Vector3 vector8 = this.transform.position = position8;
			}
		}
	}

	// Token: 0x06000239 RID: 569 RVA: 0x000290E4 File Offset: 0x000272E4
	public virtual void Main()
	{
	}

	// Token: 0x040004BD RID: 1213
	public Transform NewSchool;

	// Token: 0x040004BE RID: 1214
	public bool Sink;

	// Token: 0x040004BF RID: 1215
	public int Phase;
}
