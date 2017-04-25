using System;
using UnityEngine;

// Token: 0x02000192 RID: 402
[Serializable]
public class CameraMoveScript : MonoBehaviour
{
	// Token: 0x06000835 RID: 2101 RVA: 0x000BCC20 File Offset: 0x000BAE20
	public virtual void Start()
	{
		this.transform.position = this.StartPos.position;
		this.transform.rotation = this.StartPos.rotation;
	}

	// Token: 0x06000836 RID: 2102 RVA: 0x000BCC5C File Offset: 0x000BAE5C
	public virtual void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.Begin = true;
		}
		if (this.Begin)
		{
			this.Timer += Time.deltaTime * this.Speed;
			if (this.Timer > 0.1f)
			{
				this.OpenDoors = true;
				if (this.LeftDoor != null)
				{
					float x = Mathf.Lerp(this.LeftDoor.transform.localPosition.x, (float)1, Time.deltaTime);
					Vector3 localPosition = this.LeftDoor.transform.localPosition;
					float num = localPosition.x = x;
					Vector3 vector = this.LeftDoor.transform.localPosition = localPosition;
					float x2 = Mathf.Lerp(this.RightDoor.transform.localPosition.x, (float)-1, Time.deltaTime);
					Vector3 localPosition2 = this.RightDoor.transform.localPosition;
					float num2 = localPosition2.x = x2;
					Vector3 vector2 = this.RightDoor.transform.localPosition = localPosition2;
				}
			}
			this.transform.position = Vector3.Lerp(this.transform.position, this.EndPos.position, Time.deltaTime * this.Timer);
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.EndPos.rotation, Time.deltaTime * this.Timer);
		}
	}

	// Token: 0x06000837 RID: 2103 RVA: 0x000BCDF0 File Offset: 0x000BAFF0
	public virtual void LateUpdate()
	{
		if (this.Target != null)
		{
			this.transform.LookAt(this.Target);
		}
	}

	// Token: 0x06000838 RID: 2104 RVA: 0x000BCE20 File Offset: 0x000BB020
	public virtual void Main()
	{
	}

	// Token: 0x04001904 RID: 6404
	public Transform StartPos;

	// Token: 0x04001905 RID: 6405
	public Transform EndPos;

	// Token: 0x04001906 RID: 6406
	public Transform RightDoor;

	// Token: 0x04001907 RID: 6407
	public Transform LeftDoor;

	// Token: 0x04001908 RID: 6408
	public Transform Target;

	// Token: 0x04001909 RID: 6409
	public bool OpenDoors;

	// Token: 0x0400190A RID: 6410
	public bool Begin;

	// Token: 0x0400190B RID: 6411
	public float Speed;

	// Token: 0x0400190C RID: 6412
	public float Timer;
}
