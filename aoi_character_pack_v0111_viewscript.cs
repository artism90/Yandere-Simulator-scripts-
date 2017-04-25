using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
[Serializable]
public class aoi_character_pack_v0111_viewscript : MonoBehaviour
{
	// Token: 0x06000021 RID: 33 RVA: 0x00004174 File Offset: 0x00002374
	public aoi_character_pack_v0111_viewscript()
	{
		this.mode = "rote";
		this.x = 180f;
		this.y = 30f;
		this.distance = (float)1;
		this.xSpeed = 500f;
		this.ySpeed = 250f;
		this.movSpeed = 250f;
		this.yMinLimit = (float)-90;
		this.yMaxLimit = (float)90;
		this.zoomSpeed = 0.5f;
		this.zoomWheelBias = (float)5;
		this.zoomMin = 0.1f;
		this.zoomMax = (float)5;
		this.isFixTarget = true;
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00004210 File Offset: 0x00002410
	public virtual void Start()
	{
		this.xBk = this.x;
		this.yBk = this.y;
		this.distanceBk = this.distance;
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00004244 File Offset: 0x00002444
	public virtual void LateUpdate()
	{
		this.movX = Input.GetAxis("Mouse X");
		this.movY = Input.GetAxis("Mouse Y");
		this.wheel = Input.GetAxis("Mouse ScrollWheel");
		if (!this.isMouseLocked && Input.GetMouseButton(0))
		{
			string a = this.mode;
			if (a == "move")
			{
				this.TargetMove(this.movX, this.movY);
			}
			else if (a == "rote")
			{
				this.CameraRote(this.movX, this.movY);
			}
			else if (a == "zoom")
			{
				this.CameraZoom(this.movX, this.movY);
			}
		}
		if (Input.GetMouseButton(2))
		{
			this.TargetMove(this.movX, this.movY);
		}
		if (Input.GetMouseButton(1))
		{
			this.CameraZoom(this.movX, this.movY);
		}
		this.CameraZoom(this.wheel * this.zoomWheelBias, (float)0);
		if (this.isFixTarget && this.curTarget)
		{
			this.localTarget = this.curTarget;
		}
		else
		{
			this.localTarget = this.target;
		}
		Quaternion rotation = Quaternion.Euler(this.y, this.x, (float)0);
		Vector3 position = rotation * new Vector3((float)0, (float)0, -this.distance) + this.localTarget.position;
		if (!this.changeFlg)
		{
			this.transform.position = position;
		}
		if (this.isFixTarget && this.curTarget)
		{
			this.localTarget = this.curTarget;
		}
		else
		{
			this.localTarget = this.target;
		}
		if (!this.changeFlg)
		{
			this.transform.LookAt(this.localTarget.position, Vector3.up);
		}
		this.changeFlg = false;
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00004454 File Offset: 0x00002654
	public virtual void CameraRote(float _x, float _y)
	{
		this.x += _x * this.xSpeed * 0.01f;
		this.y -= _y * this.ySpeed * 0.01f;
		this.y = aoi_character_pack_v0111_viewscript.ClampAngle(this.y, this.yMinLimit, this.yMaxLimit);
	}

	// Token: 0x06000025 RID: 37 RVA: 0x000044B4 File Offset: 0x000026B4
	public virtual void CameraZoom(float _x, float _y)
	{
		this.distance += -_y * (float)10 * this.zoomSpeed * 0.02f;
		this.distance += -_x * (float)10 * this.zoomSpeed * 0.02f;
		if (this.distance < this.zoomMin)
		{
			this.distance = this.zoomMin;
		}
		if (this.distance > this.zoomMax)
		{
			this.distance = this.zoomMax;
		}
	}

	// Token: 0x06000026 RID: 38 RVA: 0x0000453C File Offset: 0x0000273C
	public virtual void TargetMove(float _x, float _y)
	{
		if (!this.isFixTarget)
		{
			float num = -_x * this.movSpeed * 0.055f * Time.deltaTime;
			float num2 = -_y * this.movSpeed * 0.055f * Time.deltaTime;
			Vector3 vector = new Vector3(num, num2);
			vector = this.camera.cameraToWorldMatrix.MultiplyVector(vector);
			this.target.Translate(vector);
		}
	}

	// Token: 0x06000027 RID: 39 RVA: 0x000045B0 File Offset: 0x000027B0
	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < (float)-360)
		{
			angle += (float)360;
		}
		if (angle > (float)360)
		{
			angle -= (float)360;
		}
		return Mathf.Clamp(angle, min, max);
	}

	// Token: 0x06000028 RID: 40 RVA: 0x000045FC File Offset: 0x000027FC
	public virtual void ModeMove()
	{
		this.mode = "move";
		MonoBehaviour.print("move");
	}

	// Token: 0x06000029 RID: 41 RVA: 0x00004614 File Offset: 0x00002814
	public virtual void ModeRote()
	{
		this.mode = "rote";
		MonoBehaviour.print("rote");
	}

	// Token: 0x0600002A RID: 42 RVA: 0x0000462C File Offset: 0x0000282C
	public virtual void ModeZoom()
	{
		this.mode = "zoom";
		MonoBehaviour.print("zoom");
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00004644 File Offset: 0x00002844
	public virtual void Reset()
	{
		this.distance = this.distanceBk;
		this.x = this.xBk;
		this.y = this.yBk;
		this.isFixTarget = true;
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00004674 File Offset: 0x00002874
	public virtual void FixTarget(bool _flag)
	{
		this.isFixTarget = _flag;
		if (this.curTarget)
		{
			this.target.position = this.curTarget.position;
		}
	}

	// Token: 0x0600002D RID: 45 RVA: 0x000046A4 File Offset: 0x000028A4
	public virtual void ModelTarget(Transform _transform)
	{
		this.curTarget = _transform;
		this.changeFlg = true;
	}

	// Token: 0x0600002E RID: 46 RVA: 0x000046B4 File Offset: 0x000028B4
	public virtual void MouseLock(bool _flag)
	{
		if (_flag || !Input.GetMouseButton(0))
		{
			this.isMouseLocked = _flag;
		}
	}

	// Token: 0x0600002F RID: 47 RVA: 0x000046D4 File Offset: 0x000028D4
	public virtual void Main()
	{
	}

	// Token: 0x0400005B RID: 91
	public Transform target;

	// Token: 0x0400005C RID: 92
	public string mode;

	// Token: 0x0400005D RID: 93
	public float x;

	// Token: 0x0400005E RID: 94
	public float y;

	// Token: 0x0400005F RID: 95
	public float distance;

	// Token: 0x04000060 RID: 96
	public float xSpeed;

	// Token: 0x04000061 RID: 97
	public float ySpeed;

	// Token: 0x04000062 RID: 98
	public float movSpeed;

	// Token: 0x04000063 RID: 99
	public float yMinLimit;

	// Token: 0x04000064 RID: 100
	public float yMaxLimit;

	// Token: 0x04000065 RID: 101
	public float zoomSpeed;

	// Token: 0x04000066 RID: 102
	public float zoomWheelBias;

	// Token: 0x04000067 RID: 103
	public float zoomMin;

	// Token: 0x04000068 RID: 104
	public float zoomMax;

	// Token: 0x04000069 RID: 105
	public Transform curTarget;

	// Token: 0x0400006A RID: 106
	private float xBk;

	// Token: 0x0400006B RID: 107
	private float yBk;

	// Token: 0x0400006C RID: 108
	private float movX;

	// Token: 0x0400006D RID: 109
	private float movY;

	// Token: 0x0400006E RID: 110
	private float wheel;

	// Token: 0x0400006F RID: 111
	private float distanceBk;

	// Token: 0x04000070 RID: 112
	private Vector3 cameraBk;

	// Token: 0x04000071 RID: 113
	private bool isMouseLocked;

	// Token: 0x04000072 RID: 114
	private bool isFixTarget;

	// Token: 0x04000073 RID: 115
	private Transform localTarget;

	// Token: 0x04000074 RID: 116
	private bool changeFlg;
}
