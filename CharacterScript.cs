using System;
using UnityEngine;

// Token: 0x0200005E RID: 94
[Serializable]
public class CharacterScript : MonoBehaviour
{
	// Token: 0x06000258 RID: 600 RVA: 0x0002ADB8 File Offset: 0x00028FB8
	public virtual void SetAnimations()
	{
		this.animation["f02_yanderePose_00"].layer = 1;
		this.animation["f02_yanderePose_00"].weight = (float)0;
		this.animation.Play("f02_yanderePose_00");
		this.animation["f02_shy_00"].layer = 2;
		this.animation["f02_shy_00"].weight = (float)0;
		this.animation.Play("f02_shy_00");
		this.animation["f02_fist_00"].layer = 3;
		this.animation["f02_fist_00"].weight = (float)0;
		this.animation.Play("f02_fist_00");
		this.animation["f02_mopping_00"].layer = 4;
		this.animation["f02_mopping_00"].weight = (float)0;
		this.animation["f02_mopping_00"].speed = (float)2;
		this.animation.Play("f02_mopping_00");
		this.animation["f02_carry_00"].layer = 5;
		this.animation["f02_carry_00"].weight = (float)0;
		this.animation.Play("f02_carry_00");
		this.animation["f02_mopCarry_00"].layer = 6;
		this.animation["f02_mopCarry_00"].weight = (float)0;
		this.animation.Play("f02_mopCarry_00");
		this.animation["f02_bucketCarry_00"].layer = 7;
		this.animation["f02_bucketCarry_00"].weight = (float)0;
		this.animation.Play("f02_bucketCarry_00");
		this.animation["f02_cameraPose_00"].layer = 8;
		this.animation["f02_cameraPose_00"].weight = (float)0;
		this.animation.Play("f02_cameraPose_00");
		this.animation["f02_dipping_00"].speed = (float)2;
		this.animation["f02_cameraPose_00"].weight = (float)0;
		this.animation["f02_shy_00"].weight = (float)0;
	}

	// Token: 0x06000259 RID: 601 RVA: 0x0002B014 File Offset: 0x00029214
	public virtual void Main()
	{
	}

	// Token: 0x04000508 RID: 1288
	public Transform RightBreast;

	// Token: 0x04000509 RID: 1289
	public Transform LeftBreast;

	// Token: 0x0400050A RID: 1290
	public Transform ItemParent;

	// Token: 0x0400050B RID: 1291
	public Transform PelvisRoot;

	// Token: 0x0400050C RID: 1292
	public Transform RightEye;

	// Token: 0x0400050D RID: 1293
	public Transform LeftEye;

	// Token: 0x0400050E RID: 1294
	public Transform Head;

	// Token: 0x0400050F RID: 1295
	public Transform[] Spine;

	// Token: 0x04000510 RID: 1296
	public Transform[] Arm;

	// Token: 0x04000511 RID: 1297
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04000512 RID: 1298
	public Renderer RightYandereEye;

	// Token: 0x04000513 RID: 1299
	public Renderer LeftYandereEye;
}
