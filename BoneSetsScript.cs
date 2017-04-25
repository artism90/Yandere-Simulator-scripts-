using System;
using UnityEngine;

// Token: 0x02000051 RID: 81
[Serializable]
public class BoneSetsScript : MonoBehaviour
{
	// Token: 0x06000221 RID: 545 RVA: 0x00026E80 File Offset: 0x00025080
	public virtual void Start()
	{
	}

	// Token: 0x06000222 RID: 546 RVA: 0x00026E84 File Offset: 0x00025084
	public virtual void Update()
	{
		if (this.Head != null)
		{
			this.RightArm.localPosition = this.RightArmPosition;
			this.RightArm.localEulerAngles = this.RightArmRotation;
			this.LeftArm.localPosition = this.LeftArmPosition;
			this.LeftArm.localEulerAngles = this.LeftArmRotation;
			this.RightLeg.localPosition = this.RightLegPosition;
			this.RightLeg.localEulerAngles = this.RightLegRotation;
			this.LeftLeg.localPosition = this.LeftLegPosition;
			this.LeftLeg.localEulerAngles = this.LeftLegRotation;
			this.Head.localPosition = this.HeadPosition;
		}
		this.enabled = false;
	}

	// Token: 0x06000223 RID: 547 RVA: 0x00026F44 File Offset: 0x00025144
	public virtual void Main()
	{
	}

	// Token: 0x04000463 RID: 1123
	public Transform[] BoneSet1;

	// Token: 0x04000464 RID: 1124
	public Transform[] BoneSet2;

	// Token: 0x04000465 RID: 1125
	public Transform[] BoneSet3;

	// Token: 0x04000466 RID: 1126
	public Transform[] BoneSet4;

	// Token: 0x04000467 RID: 1127
	public Transform[] BoneSet5;

	// Token: 0x04000468 RID: 1128
	public Transform[] BoneSet6;

	// Token: 0x04000469 RID: 1129
	public Transform[] BoneSet7;

	// Token: 0x0400046A RID: 1130
	public Transform[] BoneSet8;

	// Token: 0x0400046B RID: 1131
	public Transform[] BoneSet9;

	// Token: 0x0400046C RID: 1132
	public Vector3[] BoneSet1Pos;

	// Token: 0x0400046D RID: 1133
	public Vector3[] BoneSet2Pos;

	// Token: 0x0400046E RID: 1134
	public Vector3[] BoneSet3Pos;

	// Token: 0x0400046F RID: 1135
	public Vector3[] BoneSet4Pos;

	// Token: 0x04000470 RID: 1136
	public Vector3[] BoneSet5Pos;

	// Token: 0x04000471 RID: 1137
	public Vector3[] BoneSet6Pos;

	// Token: 0x04000472 RID: 1138
	public Vector3[] BoneSet7Pos;

	// Token: 0x04000473 RID: 1139
	public Vector3[] BoneSet8Pos;

	// Token: 0x04000474 RID: 1140
	public Vector3[] BoneSet9Pos;

	// Token: 0x04000475 RID: 1141
	public int Timer;

	// Token: 0x04000476 RID: 1142
	public Transform RightArm;

	// Token: 0x04000477 RID: 1143
	public Transform LeftArm;

	// Token: 0x04000478 RID: 1144
	public Transform RightLeg;

	// Token: 0x04000479 RID: 1145
	public Transform LeftLeg;

	// Token: 0x0400047A RID: 1146
	public Transform Head;

	// Token: 0x0400047B RID: 1147
	public Vector3 RightArmPosition;

	// Token: 0x0400047C RID: 1148
	public Vector3 RightArmRotation;

	// Token: 0x0400047D RID: 1149
	public Vector3 LeftArmPosition;

	// Token: 0x0400047E RID: 1150
	public Vector3 LeftArmRotation;

	// Token: 0x0400047F RID: 1151
	public Vector3 RightLegPosition;

	// Token: 0x04000480 RID: 1152
	public Vector3 RightLegRotation;

	// Token: 0x04000481 RID: 1153
	public Vector3 LeftLegPosition;

	// Token: 0x04000482 RID: 1154
	public Vector3 LeftLegRotation;

	// Token: 0x04000483 RID: 1155
	public Vector3 HeadPosition;
}
