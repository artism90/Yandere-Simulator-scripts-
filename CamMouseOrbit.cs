using System;
using UnityEngine;

// Token: 0x02000003 RID: 3
[Serializable]
public class CamMouseOrbit : MonoBehaviour
{
	// Token: 0x06000006 RID: 6 RVA: 0x000028A4 File Offset: 0x00000AA4
	public CamMouseOrbit()
	{
		this.distance = 2.5f;
		this.xSpeed = 5;
		this.ySpeed = 2.5f;
		this.distSpeed = 10f;
		this.yMinLimit = -20f;
		this.yMaxLimit = 80f;
		this.distMinLimit = 0.5f;
		this.distMaxLimit = 50f;
		this.orbitDamping = 4f;
		this.distDamping = 4f;
		this.dist = this.distance;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002930 File Offset: 0x00000B30
	public virtual void Start()
	{
		Vector3 eulerAngles = this.transform.eulerAngles;
		this.x = eulerAngles.y;
		this.y = eulerAngles.x;
		if (this.rigidbody)
		{
			this.rigidbody.freezeRotation = true;
		}
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00002980 File Offset: 0x00000B80
	public virtual void LateUpdate()
	{
		if (this.target)
		{
			this.x += Input.GetAxis("Mouse X") * (float)this.xSpeed;
			this.y -= Input.GetAxis("Mouse Y") * this.ySpeed;
			if (this.CanZoon)
			{
				this.distance -= Input.GetAxis("Mouse ScrollWheel") * this.distSpeed;
			}
			this.y = this.ClampAngle(this.y, this.yMinLimit, this.yMaxLimit);
			this.distance = Mathf.Clamp(this.distance, this.distMinLimit, this.distMaxLimit);
			this.dist = Mathf.Lerp(this.dist, this.distance, this.distDamping * Time.deltaTime);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.Euler(this.y, this.x, (float)0), Time.deltaTime * this.orbitDamping);
			this.transform.position = this.transform.rotation * new Vector3((float)0, (float)0, -this.dist) + this.target.position;
			if (Input.GetKeyDown(KeyCode.O) && !this.CanZoon)
			{
				this.CanZoon = true;
			}
			else if (Input.GetKeyDown(KeyCode.O) && this.CanZoon)
			{
				this.CanZoon = false;
			}
		}
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002B20 File Offset: 0x00000D20
	public virtual float ClampAngle(float a, float min, float max)
	{
		while (max < min)
		{
			max += 360f;
		}
		while (a > max)
		{
			a -= 360f;
		}
		while (a < min)
		{
			a += 360f;
		}
		return (a <= max) ? a : ((a - (max + min) * 0.5f >= 180f) ? min : max);
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002BAC File Offset: 0x00000DAC
	public virtual void Main()
	{
	}

	// Token: 0x04000018 RID: 24
	public bool CanZoon;

	// Token: 0x04000019 RID: 25
	public Transform target;

	// Token: 0x0400001A RID: 26
	public float distance;

	// Token: 0x0400001B RID: 27
	public int xSpeed;

	// Token: 0x0400001C RID: 28
	public float ySpeed;

	// Token: 0x0400001D RID: 29
	public float distSpeed;

	// Token: 0x0400001E RID: 30
	public float yMinLimit;

	// Token: 0x0400001F RID: 31
	public float yMaxLimit;

	// Token: 0x04000020 RID: 32
	public float distMinLimit;

	// Token: 0x04000021 RID: 33
	public float distMaxLimit;

	// Token: 0x04000022 RID: 34
	public float orbitDamping;

	// Token: 0x04000023 RID: 35
	public float distDamping;

	// Token: 0x04000024 RID: 36
	private float x;

	// Token: 0x04000025 RID: 37
	private float y;

	// Token: 0x04000026 RID: 38
	private float dist;
}
